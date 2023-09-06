namespace Nucleus.External.Azure.StorageAccount;

public record BlobResponseDto
{
    public string? Status { get; set; }
    public bool Error { get; set; }
    public BlobDto Blob { get; set; } = new();
}
