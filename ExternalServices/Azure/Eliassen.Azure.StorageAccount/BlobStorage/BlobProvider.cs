using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Eliassen.Documents.Containers;
using Eliassen.Documents.Depercated;
using Eliassen.Documents.Models;
using Eliassen.Extensions.Linq;
using Eliassen.Search;
using Eliassen.Search.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a provider for storing and searching content in Azure Blob storage.
/// </summary>
public class BlobProvider :
    IStoreContent,
    ISearchContent<BlobItem>,
    ISearchContent<SearchResultModel>,
    IGetContent<ContentReference>,
    IGetSummary<ContentReference>,
    IBlobContainerProvider
{
    private readonly BlobContainerClient _blockBlobClient;
    private readonly ILogger _logger;

    public string ContainerName { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BlobProvider"/> class with the specified <paramref name="client"/> and <paramref name="collectionName"/>.
    /// </summary>
    /// <param name="client">The BlobServiceClient used to connect to the Azure Blob storage.</param>
    /// <param name="collectionName">The name of the collection in the Azure Blob storage.</param>
    /// <param name="loggerFactory">ILoggerFactory instance.</param>
    public BlobProvider(
        BlobServiceClient client,
        string collectionName,
        ILoggerFactory loggerFactory
        )
    {
        _logger = loggerFactory.CreateLogger(nameof(BlobProvider) + $"-{collectionName}");
        ContainerName = collectionName.ToLower();
        _blockBlobClient = client.GetBlobContainerClient(ContainerName);
        _blockBlobClient.CreateIfNotExists();
    }

    /// <summary>
    /// Retrieves the content of the specified file from Azure Blob storage.
    /// </summary>
    /// <param name="file">The name of the file to retrieve.</param>
    /// <returns>A ContentReference object representing the retrieved content.</returns>
    public async Task<ContentReference?> GetContentAsync(string file)
    {
        var blob = _blockBlobClient.GetBlobClient(file);

        if (!await blob.ExistsAsync())
            return null;

        var result = await blob.DownloadStreamingAsync();
        return new ContentReference
        {
            Content = result.Value.Content,
            ContentType = result.Value.Details.ContentType,
            FileName = Path.GetFileName(file)
        };
    }

    /// <summary>
    /// Retrieves the summary of the specified file from Azure Blob storage.
    /// </summary>
    /// <param name="file">The name of the file to retrieve the summary for.</param>
    /// <returns>A ContentReference object representing the summary content.</returns>
    public Task<ContentReference?> GetSummaryAsync(string file) => GetContentAsync(file);

    /// <summary>
    /// Queries Azure Blob storage for files that match the specified criteria.
    /// </summary>
    /// <param name="queryString">The query string to search for.</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="page">The page number of results to retrieve.</param>
    /// <returns>An asynchronous enumerable of BlobItem objects representing the search results.</returns>
    public IAsyncEnumerable<SearchResultModel> QueryAsync(string? queryString, int limit = 25, int page = 0) =>
        from item in ((ISearchContent<BlobItem>)this).QueryAsync(queryString, limit, page)
        select new SearchResultModel
        {
            Content = "", //TODO: do something else here
            File = item.Metadata["File"],
            PathHash = item.Metadata["PathHash"],
            Score = 1,
            Type = SearchTypes.None,
        };

    /// <summary>
    /// Queries Azure Blob storage for files that match the specified criteria.
    /// </summary>
    /// <param name="queryString">The query string to search for.</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="page">The page number of results to retrieve.</param>
    /// <returns>An asynchronous enumerable of BlobItem objects representing the search results.</returns>
    IAsyncEnumerable<BlobItem> ISearchContent<BlobItem>.QueryAsync(string? queryString, int limit = 25, int page = 0) =>
        _blockBlobClient.GetBlobsAsync(); //todo: add query but who really cares

    /// <summary>
    /// Stores the specified content in Azure Blob storage.
    /// </summary>
    /// <param name="full">The full path of the content to store.</param>
    /// <param name="file">The name of the file to store.</param>
    /// <param name="pathHash">The hash value of the file path.</param>
    /// <returns>A boolean value indicating whether the operation was successful.</returns>
    public async Task<bool> TryStoreAsync(string full, string file, string pathHash) //TODO: change this to use streams and take a metadata collection
    {
        var blob = _blockBlobClient.GetBlobClient(file);
        if (!await blob.ExistsAsync())
        {
            // Check if file exists in blob store
            //  If not exist upload
            _logger.LogInformation("upload -> {file}", file);
            _ = await blob.UploadAsync(full, overwrite: false);

            // https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-properties-metadata
            await blob.SetMetadataAsync(new Dictionary<string, string>
            {
                ["File"] = file,
                ["OriginalFile"] = full,
                ["PathHash"] = pathHash,
            });

            return true;
        }

        return false;
    }

    public async Task<ContentMetaDataReference?> GetContentMetaDataAsync(string path)
    {
        var blob = _blockBlobClient.GetBlobClient(path);
        if (!await blob.ExistsAsync()) return null;

        var header = await blob.GetPropertiesAsync();
        return new ContentMetaDataReference
        {
            FileName = blob.Name,
            ContentType = header.Value.ContentType,
            MetaData = header.Value.Metadata.ToDictionary(k => k.Key, k => k.Value),
        };
    }

    public async Task StoreContentAsync(ContentReference reference, IDictionary<string, string>? metadata = null)
    {
        var blob = _blockBlobClient.GetBlobClient(reference.FileName);

        _logger.LogInformation("upload -> {file}", reference.FileName);
        _ = await blob.UploadAsync(reference.Content, overwrite: false);

        _ = await blob.SetHttpHeadersAsync(new BlobHttpHeaders
        {
            ContentType = reference.ContentType,
        });

        // https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-properties-metadata

        if (metadata != null)
        {
            var data = metadata.ToDictionary(k => k.Key, v => $"{v.Value}");
            await blob.SetMetadataAsync(data);
        }
    }

    public IQueryable<ContentMetaDataReference> QueryContent()
    {
        //TODO: build a query provider!
        var query = from p in _blockBlobClient.GetBlobs().AsPages()
                    from b in p.Values
                    select new ContentMetaDataReference
                    {
                        FileName = b.Name,
                        ContentType = b.Properties.ContentType,
                        MetaData = b.Metadata.ToDictionary(k => k.Key, k => k.Value),
                    };
        return query.AsQueryable();
    }
}

//public class BlobQueryProvider : IQueryProvider
//{
//    // https://learn.microsoft.com/en-us/previous-versions/bb546158(v=vs.140)?redirectedfrom=MSDN
//    public IQueryable CreateQuery(Expression expression) => throw new NotImplementedException();
//    public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => throw new NotImplementedException();
//    public object? Execute(Expression expression) => throw new NotImplementedException();
//    public TResult Execute<TResult>(Expression expression) => throw new NotImplementedException();
//}
