using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Implementation of <see cref="IDocumentProvider"/> for handling blob containers in Azure Storage.
/// </summary>
/// <remark>
/// Initializes a new instance of the <see cref="BlobContainerProvider"/> class.
/// </remark>
/// <param name="config">The configuration.</param>
/// <param name="logger">The logger.</param>
public class BlobContainerProvider(
    IOptions<AzureBlobContainerOptions> config,
    ILogger<BlobContainerProvider> logger
        ) : IDocumentProvider
{
    private readonly string? _containerName = config.Value.ContainerName;
    private readonly BlobContainerClient _blobClient = new(config.Value.ConnectionString, config.Value.ContainerName);
    private readonly ILogger<BlobContainerProvider> _logger = logger;

    /// <summary>
    /// Lists all blobs in the container.
    /// </summary>
    /// <returns>A list of <see cref="BlobDto"/> representing the blobs in the container.</returns>
    public async Task<List<BlobDto>> ListAsync()
    {
        // Create a new list object for 
        List<BlobDto> files = [];

        await foreach (var file in _blobClient.GetBlobsAsync())
        {
            // Add each file retrieved from the storage container to the files list by creating a BlobDto object
            var uri = _blobClient.Uri.ToString();
            var name = file.Name;
            var fullUri = $"{uri}/{name}";

            files.Add(new BlobDto
            {
                Uri = fullUri,
                Name = name,
                ContentType = file.Properties.ContentType
            });
        }

        // Return all files to the requesting method
        return files;
    }

    /// <summary>
    /// Uploads a blob to the container.
    /// </summary>
    /// <param name="document">The document model.</param>
    /// <param name="content">The content stream.</param>
    /// <returns>A <see cref="BlobResponseDto"/> representing the result of the upload operation.</returns>
    public async Task<BlobResponseDto> UploadAsync(DocumentModel document, Stream content)
    {
        BlobResponseDto response = new();

        try
        {
            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            var client = _blobClient.GetBlobClient(document.DocumentKey);

            await client.UploadAsync(content);

            // Everything is OK and file got uploaded
            response.Status = $"File {document.DocumentKey} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

        }
        // If the file already exists, we catch the exception and do not upload it
        catch (RequestFailedException ex)
           when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
        {
            _logger.LogError($"File with name {{{nameof(document.DocumentKey)}}} already exists in container. Set another name to store the file in the container: '{{containerName}}.'", document.DocumentKey, _containerName);
            response.Status = $"File with name {document.DocumentKey} already exists. Please use another name to store your file.";
            response.Error = true;
            return response;
        }
        // If we get an unexpected error, we catch it here and return the error message
        catch (RequestFailedException ex)
        {
            // Log error to console and create a new response we can return to the requesting method
            _logger.LogError($"Unhandled Exception. Message: {{{nameof(ex.Message)}}}", ex.Message);
            _logger.LogDebug($"Unhandled Exception. ID: {{{nameof(ex.StackTrace)}}} - Message: {{{nameof(ex.Message)}}}", ex.StackTrace, ex.Message);
            response.Status = $"Unexpected error: {ex.Message}. Check log with StackTrace ID.";
            response.Error = true;
            return response;
        }

        // Return the BlobUploadResponse object
        return response;
    }

    /// <summary>
    /// Downloads a blob from the container.
    /// </summary>
    /// <param name="blobFilename">The name of the blob.</param>
    /// <returns>A <see cref="BlobDto"/> representing the downloaded blob or <c>null</c> if the blob does not exist.</returns>
    public async Task<BlobDto?> DownloadAsync(string blobFilename)
    {
        try
        {
            // Get a reference to the blob uploaded earlier from the API in the container from configuration settings
            var file = _blobClient.GetBlobClient(blobFilename);

            // Check if the file exists in the container
            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                var blobContent = data;

                // Download the file details async
                var content = await file.DownloadContentAsync();

                // Add data to variables in order to return a BlobDto
                var name = blobFilename;
                var contentType = content.Value.Details.ContentType;

                // Create new BlobDto with blob data from variables
                return new BlobDto { Content = blobContent, Name = name, ContentType = contentType };
            }
        }
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
        {
            // Log error to console
            _logger.LogError($"File {{{nameof(blobFilename)}}} was not found.", blobFilename);
        }

        // File does not exist, return null and handle that in requesting method
        return null;
    }

    /// <summary>
    /// Deletes a blob from the container.
    /// </summary>
    /// <param name="blobFilename">The name of the blob.</param>
    /// <returns>A <see cref="BlobResponseDto"/> representing the result of the delete operation.</returns>
    public async Task<BlobResponseDto> DeleteAsync(string blobFilename)
    {
        var file = _blobClient.GetBlobClient(blobFilename);
        try
        {
            // Delete the file
            await file.DeleteAsync();
        }
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
        {
            // File did not exist, log to console and return new response to requesting method
            _logger.LogError($"File {{{nameof(blobFilename)}}} was not found.", blobFilename);
            return new BlobResponseDto { Error = true, Status = $"File with name {blobFilename} not found." };
        }

        // Return a new BlobResponseDto to the requesting method
        return new BlobResponseDto { Error = false, Status = $"File: {blobFilename} has been successfully deleted." };

    }
}
