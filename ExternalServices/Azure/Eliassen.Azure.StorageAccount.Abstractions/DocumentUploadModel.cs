namespace Eliassen.Azure.StorageAccount;

public record DocumentUploadModel : DocumentModel
{
    public byte[]? Data { get; set; }
}
