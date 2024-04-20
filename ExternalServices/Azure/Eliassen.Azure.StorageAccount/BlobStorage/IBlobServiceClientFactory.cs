using Azure.Storage.Blobs;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Interface for a factory that creates instances of <see cref="BlobProvider"/>.
/// </summary>
public interface IBlobServiceClientFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="BlobProvider"/> with the specified <paramref name="collectionName"/>.
    /// </summary>
    /// <param name="collectionName">The name of the collection to create the BlobProvider for.</param>
    /// <returns>A new instance of <see cref="BlobProvider"/>.</returns>
    BlobServiceClient Create();
}
