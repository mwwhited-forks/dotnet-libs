using Eliassen.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Search.Semantic;

public class WrappedVectorStore : IVectorStore
{
    private readonly IVectorStore _wrapped;

    public WrappedVectorStore(
        IVectorStore wrapped
        ) => _wrapped = wrapped;

    public IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find) =>
        _wrapped.FindNeighborsAsync(find);
    public IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find, string groupBy) =>
        _wrapped.FindNeighborsAsync(find, groupBy);
    public IAsyncEnumerable<SearchResultModel> ListAsync() =>
        _wrapped.ListAsync();
    public Task<string[]> StoreVectorsAsync(IEnumerable<float[]> embeddings, Dictionary<string, object> metadata) =>
        _wrapped.StoreVectorsAsync(embeddings, metadata);
}

public class WrappedVectorStore<T> : WrappedVectorStore, IVectorStore<T>
{
    public WrappedVectorStore(IVectorStoreFactory factory) : base(factory.Create<T>()) { }
}
