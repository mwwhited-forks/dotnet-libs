using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Eliassen.Search.Semantic;

public class VectorStoreFactory : IVectorStoreFactory
{
    private readonly IVectorStoreProviderFactory _factory;

    public VectorStoreFactory(
        IVectorStoreProviderFactory factory
        ) => _factory = factory;

    public IVectorStore Create(string containerName) =>
       new WrappedVectorStore(_factory.Create(containerName));

    public IVectorStore Create<T>() =>
        Create(
            typeof(T).GetCustomAttribute<VectorStoreAttribute>()?.ContainerName ??
            typeof(T).GetCustomAttribute<TableAttribute>()?.Name ??
            typeof(T).Name
            );
}
