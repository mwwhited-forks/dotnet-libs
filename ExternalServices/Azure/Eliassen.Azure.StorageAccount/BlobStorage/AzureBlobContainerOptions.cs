namespace Eliassen.Azure.StorageAccount.BlobStorage;

public class AzureBlobContainerOptions
{
    public required string ContainerName { get; set; }
    public required string ConnectionString { get; set; }
}
