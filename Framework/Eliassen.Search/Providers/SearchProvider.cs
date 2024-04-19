using Eliassen.AI;
using Eliassen.Extensions.Linq;
using Eliassen.Search.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Search.Providers;

public class SearchProvider : ISearchProvider
{
    private readonly ISearchContent<SearchResultModel> _semantic;
    private readonly ISearchContent<SearchResultModel> _lexical;
    private readonly ISearchContent<SearchResultModel> _hybrid;
    private readonly IEmbeddingProvider _embedding;
    private readonly ISearchContent<SearchResultModel> _contentStore;

    public SearchProvider(
        [FromKeyedServices(SearchTypes.Semantic)] ISearchContent<SearchResultModel> semantic,
        [FromKeyedServices(SearchTypes.Lexical)] ISearchContent<SearchResultModel> lexical,
        [FromKeyedServices(SearchTypes.Hybrid)] ISearchContent<SearchResultModel> hybrid,
        IEmbeddingProvider embedding,
        [FromKeyedServices(SearchTypes.None)] ISearchContent<SearchResultModel> contentStore
        )
    {
        _semantic = semantic;
        _lexical = lexical;
        _hybrid = hybrid;
        _embedding = embedding;
        _contentStore = contentStore;
    }

    public async Task<IEnumerable<SearchResultModel>> ListAsync() =>
        await _contentStore.QueryAsync("").ToReadOnlyCollectionAsync();

    public async Task<float[]> EmbedAsync(string text) => await _embedding.GetEmbeddingAsync(text);

    public async Task<IEnumerable<SearchResultModel>> SemanticSearchAsync(string? query, int limit) =>
        await _semantic.QueryAsync(query, limit).ToReadOnlyCollectionAsync();

    public async Task<IEnumerable<SearchResultModel>> LexicalSearchAsync(string? query, int limit) =>
       await _lexical.QueryAsync(query, limit).ToReadOnlyCollectionAsync();

    public async Task<IEnumerable<SearchResultModel>> HybridSearchAsync(string? query, int limit) =>
        await _hybrid.QueryAsync(query, limit).ToReadOnlyCollectionAsync();

}
