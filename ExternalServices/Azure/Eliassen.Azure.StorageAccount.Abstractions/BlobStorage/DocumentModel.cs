namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a document with associated metadata.
/// </summary>
public record DocumentModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the document.
    /// </summary>
    public string? DocumentId { get; set; }

    /// <summary>
    /// Gets or sets the key associated with the document.
    /// </summary>
    public string? DocumentKey { get; set; }

    /// <summary>
    /// Gets or sets the name of the document.
    /// </summary>
    public string? DocumentName { get; set; }

    /// <summary>
    /// Gets or sets the type of the document.
    /// </summary>
    public string? DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the size of the document in bytes.
    /// </summary>
    public long? DocumentSize { get; set; }

    /// <summary>
    /// Gets or sets the repository where the document is stored.
    /// </summary>
    public string? DocumentRepository { get; set; }

    /// <summary>
    /// Gets or sets the category of the document.
    /// </summary>
    public string? DocumentCategory { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the document was created.
    /// </summary>
    public DateTimeOffset? CreatedOn { get; set; }
}
