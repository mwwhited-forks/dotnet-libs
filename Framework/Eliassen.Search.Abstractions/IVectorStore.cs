using Eliassen.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Search;

public interface IVectorStore
{
    Task<string[]> StoreVectorsAsync(IEnumerable<float[]> embeddings, Dictionary<string, object> metadata);
    IAsyncEnumerable<SearchResultModel> ListAsync();
    IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find);
    IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find, string groupBy);
}

public interface IVectorStore<T> : IVectorStore
{
}

