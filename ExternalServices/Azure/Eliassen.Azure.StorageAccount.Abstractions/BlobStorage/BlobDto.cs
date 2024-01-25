namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a Data Transfer Object (DTO) for handling blob-related information.
/// </summary>
public record BlobDto
{
    /// <summary>
    /// Gets or sets the URI of the blob.
    /// </summary>
    public string? Uri { get; set; }

    /// <summary>
    /// Gets or sets the name of the blob.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the content type of the blob.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// Gets or sets the content stream of the blob.
    /// </summary>
    public Stream? Content { get; set; }
}
