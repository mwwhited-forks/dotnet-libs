using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Eliassen.Documents.Containers;

public class BlobContainerFactory : IBlobContainerFactory
{
    private readonly IBlobContainerProviderFactory _factory;

    public BlobContainerFactory(
        IBlobContainerProviderFactory factory
        ) => _factory = factory;

    public IBlobContainer Create(string containerName) =>
       new WrappedBlobContainer(_factory.Create(containerName));

    public IBlobContainer Create<T>() =>
        Create(
            typeof(T).GetCustomAttribute<BlobContainerAttribute>()?.ContainerName ??
            typeof(T).GetCustomAttribute<TableAttribute>()?.Name ??
            typeof(T).Name
            );
}
