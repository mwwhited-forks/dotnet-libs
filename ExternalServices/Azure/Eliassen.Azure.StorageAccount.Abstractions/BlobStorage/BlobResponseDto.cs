namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a Data Transfer Object (DTO) for a blob response.
/// </summary>
public record BlobResponseDto
{
    /// <summary>
    /// Gets or sets the status of the blob response.
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether an error occurred in the blob response.
    /// </summary>
    public bool Error { get; set; }

    /// <summary>
    /// Gets or sets the blob information associated with the response.
    /// </summary>
    public BlobDto Blob { get; set; } = new();
}
