namespace Eliassen.Azure.StorageAccount.BlobStorage;

public record DocumentUploadModel : DocumentModel
{
    public byte[]? Data { get; set; }
}
