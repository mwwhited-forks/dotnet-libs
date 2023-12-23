namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a document upload model, extending the <see cref="DocumentModel"/> with additional data.
/// </summary>
public record DocumentUploadModel : DocumentModel
{
    /// <summary>
    /// Gets or sets the binary data of the document.
    /// </summary>
    public byte[]? Data { get; set; }
}