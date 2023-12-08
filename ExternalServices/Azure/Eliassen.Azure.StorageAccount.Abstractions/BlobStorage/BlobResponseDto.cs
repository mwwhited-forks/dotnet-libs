namespace Eliassen.Azure.StorageAccount.BlobStorage;

public record BlobResponseDto
{
    public string? Status { get; set; }
    public bool Error { get; set; }
    public BlobDto Blob { get; set; } = new();
}
