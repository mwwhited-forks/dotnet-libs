using Eliassen.Search.Models;

namespace Eliassen.Search;

public interface ISearchProvider
{
    Task<IEnumerable<SearchResultModel>> HybridSearchAsync(string? query, int limit);
    Task<IEnumerable<SearchResultModel>> LexicalSearchAsync(string? query, int limit);
    Task<IEnumerable<SearchResultModel>> ListAsync();
    Task<IEnumerable<SearchResultModel>> SemanticSearchAsync(string? query, int limit);
}
