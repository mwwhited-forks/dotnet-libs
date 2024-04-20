using Azure.Storage.Blobs;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Interface for a factory that creates instances of <see cref="BlobProvider"/>.
/// </summary>
public interface IBlobServiceClientFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="BlobServiceClient"/>.
    /// </summary>
    /// <returns>The created <see cref="BlobServiceClient"/>.</returns>
    BlobServiceClient Create();
}
