namespace Eliassen.Search.Semantic;

/// <summary>
/// Interface for creating instances of IVectorStore.
/// </summary>
public interface IVectorStoreFactory
{
    /// <summary>
    /// Creates a new instance of IVectorStore with the specified container name.
    /// </summary>
    /// <param name="containerName">The name of the container.</param>
    /// <returns>A new instance of IVectorStore.</returns>
    IVectorStore Create(string containerName);

    /// <summary>
    /// Creates a new instance of IVectorStore of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of IVectorStore to create.</typeparam>
    /// <returns>A new instance of IVectorStore of the specified type.</returns>
    IVectorStore Create<T>();
}
