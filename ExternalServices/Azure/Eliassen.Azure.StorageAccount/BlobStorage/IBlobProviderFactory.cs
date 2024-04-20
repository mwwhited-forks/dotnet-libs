namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Interface for a factory that creates instances of <see cref="BlobProvider"/>.
/// </summary>
public interface IBlobProviderFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="BlobProvider"/> for the specified collection name.
    /// </summary>
    /// <param name="collectionName">The name of the collection.</param>
    /// <returns>A new instance of <see cref="BlobProvider"/>.</returns>
    BlobProvider Create(string collectionName);
}
