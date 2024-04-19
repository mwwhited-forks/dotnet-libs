namespace Eliassen.Azure.StorageAccount.BlobStorage;

public interface IBlobProviderFactory
{
    BlobProvider Create(string collectionName);
}
