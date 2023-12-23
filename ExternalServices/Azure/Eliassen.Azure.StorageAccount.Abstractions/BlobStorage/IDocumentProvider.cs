namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Provides functionality for managing documents, including listing, uploading, downloading, and deleting.
/// </summary>
public interface IDocumentProvider
{
    /// <summary>
    /// Retrieves a list of BlobDto representing the available documents.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the list of BlobDto.</returns>
    Task<List<BlobDto>> ListAsync();

    /// <summary>
    /// Uploads a document with the specified metadata and content.
    /// </summary>
    /// <param name="document">The metadata of the document to upload.</param>
    /// <param name="content">The content stream of the document.</param>
    /// <returns>A task that represents the asynchronous operation, containing the BlobResponseDto for the uploaded document.</returns>
    Task<BlobResponseDto> UploadAsync(DocumentModel document, Stream content);

    /// <summary>
    /// Downloads the document with the specified filename.
    /// </summary>
    /// <param name="blobFilename">The filename of the document to download.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the BlobDto for the downloaded document.
    /// Returns null if the document with the specified filename is not found.
    /// </returns>
    Task<BlobDto?> DownloadAsync(string blobFilename);

    /// <summary>
    /// Deletes the document with the specified filename.
    /// </summary>
    /// <param name="blobFilename">The filename of the document to delete.</param>
    /// <returns>A task that represents the asynchronous operation, containing the BlobResponseDto for the deletion result.</returns>
    Task<BlobResponseDto> DeleteAsync(string blobFilename);
}