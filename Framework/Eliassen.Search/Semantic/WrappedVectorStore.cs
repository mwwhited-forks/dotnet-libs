using Eliassen.Search.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Search.Semantic;

/// <summary>
/// Represents a vector store that wraps another vector store.
/// </summary>
public class WrappedVectorStore<T> : IVectorStore<T>
{
    private readonly IVectorStore _wrapped;

    /// <summary>
    /// Initializes a new instance of the <see cref="WrappedVectorStore"/> class.
    /// </summary>
    /// <param name="wrapped">The vector store to wrap.</param>
    [ActivatorUtilitiesConstructor]
    public WrappedVectorStore(
        IVectorStoreFactory factory
        ) : this(factory.Create<T>()) { }

    internal WrappedVectorStore(
        IVectorStore wrapper
        ) => _wrapped = wrapper;

    /// <summary>
    /// Finds nearest neighbors asynchronously based on the specified vector.
    /// </summary>
    /// <param name="find">The vector to search for neighbors.</param>
    /// <returns>An asynchronous enumerable collection of search results representing nearest neighbors.</returns>
    public IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find) =>
        _wrapped.FindNeighborsAsync(find);

    /// <summary>
    /// Finds nearest neighbors asynchronously based on the specified vector and groups the results by a specified field.
    /// </summary>
    /// <param name="find">The vector to search for neighbors.</param>
    /// <param name="groupBy">The field to group the results by.</param>
    /// <returns>An asynchronous enumerable collection of search results representing nearest neighbors grouped by the specified field.</returns>
    public IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find, string groupBy) =>
        _wrapped.FindNeighborsAsync(find, groupBy);

    /// <summary>
    /// Retrieves all items asynchronously.
    /// </summary>
    /// <returns>An asynchronous enumerable collection of search results.</returns>
    public IAsyncEnumerable<SearchResultModel> ListAsync() =>
        _wrapped.ListAsync();

    /// <summary>
    /// Stores vectors asynchronously along with their associated metadata.
    /// </summary>
    /// <param name="embeddings">The vector embeddings to store.</param>
    /// <param name="metadata">The metadata associated with the vectors.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the IDs of the stored vectors.</returns>
    public Task<string[]> StoreVectorsAsync(IEnumerable<float[]> embeddings, Dictionary<string, object> metadata) =>
        _wrapped.StoreVectorsAsync(embeddings, metadata);
}
