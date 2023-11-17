namespace Eliassen.Azure.StorageAccount;

public interface IDocumentProvider
{
    Task<List<BlobDto>> ListAsync();
    Task<BlobResponseDto> UploadAsync(DocumentModel document, Stream content);
    Task<BlobDto?> DownloadAsync(string blobFilename);
    Task<BlobResponseDto> DeleteAsync(string blobFilename);
}
