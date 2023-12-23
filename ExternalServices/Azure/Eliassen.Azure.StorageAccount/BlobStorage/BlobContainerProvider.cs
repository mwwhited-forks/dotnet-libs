using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

public class BlobContainerProvider(
    IConfiguration config,
    ILogger<BlobContainerProvider> logger
        ) : IDocumentProvider
{
    private readonly string? _containerName = config[ConfigKeys.Container.DefaultContainerName];
    private readonly BlobContainerClient _blobClient = new BlobContainerClient(config[ConfigKeys.Container.DefaultConnectionString], config[ConfigKeys.Container.DefaultContainerName]);
    private readonly ILogger<BlobContainerProvider> _logger = logger;

    public async Task<List<BlobDto>> ListAsync()
    {

        // Create a new list object for 
        List<BlobDto> files = new List<BlobDto>();

        await foreach (BlobItem file in _blobClient.GetBlobsAsync())
        {
            // Add each file retrieved from the storage container to the files list by creating a BlobDto object
            string uri = _blobClient.Uri.ToString();
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

    public async Task<BlobResponseDto> UploadAsync(DocumentModel document, Stream content)
    {
        BlobResponseDto response = new BlobResponseDto();

        //await container.CreateAsync();
        try
        {
            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            BlobClient client = _blobClient.GetBlobClient(document.DocumentKey);

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
#warning should not return stack trace in response
            // Log error to console and create a new response we can return to the requesting method
            _logger.LogError($"Unhandled Exception. ID: {{{nameof(ex.StackTrace)}}} - Message: {{{nameof(ex.Message)}}}", ex.StackTrace, ex.Message);
            response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
            response.Error = true;
            return response;
        }

        // Return the BlobUploadResponse object
        return response;
    }

    public async Task<BlobDto?> DownloadAsync(string blobFilename)
    {
        try
        {
            // Get a reference to the blob uploaded earlier from the API in the container from configuration settings
            BlobClient file = _blobClient.GetBlobClient(blobFilename);

            // Check if the file exists in the container
            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                Stream blobContent = data;

                // Download the file details async
                var content = await file.DownloadContentAsync();

                // Add data to variables in order to return a BlobDto
                string name = blobFilename;
                string contentType = content.Value.Details.ContentType;

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

    public async Task<BlobResponseDto> DeleteAsync(string blobFilename)
    {
        BlobClient file = _blobClient.GetBlobClient(blobFilename);
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
