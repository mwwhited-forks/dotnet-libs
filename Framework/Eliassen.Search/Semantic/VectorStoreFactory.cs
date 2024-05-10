using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Eliassen.Search.Semantic;

/// <summary>
/// Represents a factory for creating vector stores.
/// </summary>
public class VectorStoreFactory : IVectorStoreFactory
{
    private readonly IVectorStoreProviderFactory _factory;

    /// <summary>
    /// Initializes a new instance of the <see cref="VectorStoreFactory"/> class.
    /// </summary>
    /// <param name="factory">The factory to create vector store provider.</param>
    public VectorStoreFactory(
        IVectorStoreProviderFactory factory
        ) => _factory = factory;

    /// <summary>
    /// Creates a vector store based on the specified container name.
    /// </summary>
    /// <param name="containerName">The name of the container.</param>
    /// <returns>The created vector store.</returns>
    public virtual IVectorStore Create(string containerName) =>
       new WrappedVectorStore(_factory.Create(containerName));

    /// <summary>
    /// Creates a vector store based on the specified type.
    /// </summary>
    /// <typeparam name="T">The type for which the vector store is created.</typeparam>
    /// <returns>The created vector store.</returns>
    public IVectorStore Create<T>() =>
        Create(
            typeof(T).GetCustomAttribute<VectorStoreAttribute>()?.ContainerName ??
            typeof(T).GetCustomAttribute<TableAttribute>()?.Name ??
            typeof(T).Name
            );
}
