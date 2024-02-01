namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents the options for configuring an Azure Blob Storage container.
/// </summary>
public class AzureBlobContainerOptions
{    /// <summary>
     /// Gets or sets the name of the container.
     /// </summary>
     /// <remarks>
     /// This property is required and specifies the name of the Azure Blob Storage container.
     /// </remarks>
    public required string ContainerName { get; set; }

    /// <summary>
    /// Gets or sets the connection string for the Azure Storage account.
    /// </summary>
    /// <remarks>
    /// This property is required and specifies the connection string used to connect to the Azure Storage account.
    /// </remarks>
    public required string ConnectionString { get; set; }
}
