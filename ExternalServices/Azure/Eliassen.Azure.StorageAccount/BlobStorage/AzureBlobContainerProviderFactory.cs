using Eliassen.Documents.Containers;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

public class AzureBlobContainerProviderFactory : IBlobContainerProviderFactory
{
    private readonly IBlobProviderFactory _factory;

    public AzureBlobContainerProviderFactory(
        IBlobProviderFactory factory
        ) => _factory = factory;

    public IBlobContainerProvider Create(string containerName) =>
        _factory.Create(containerName);
}
