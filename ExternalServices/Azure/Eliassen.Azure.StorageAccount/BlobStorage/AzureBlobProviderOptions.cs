namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Options for configuring Azure Blob storage provider.
/// </summary>
public class AzureBlobProviderOptions
{
    /// <summary>
    /// Gets or sets the connection string for Azure Blob storage.
    /// </summary>
    public required string ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets the name of the collection for storing documents in Azure Blob storage.
    /// </summary>
    public required string DocumentCollectionName { get; set; }

    /// <summary>
    /// Gets or sets the name of the collection for storing document summaries in Azure Blob storage.
    /// </summary>
    public required string SummaryCollectionName { get; set; }
}
