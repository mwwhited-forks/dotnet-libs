using Eliassen.Search.Models;

namespace Eliassen.Search;

public interface ISearchProvider
{
    Task<IEnumerable<SearchResultWithSummaryModel>> HybridSearchAsync(string? query, int limit);
    Task<IEnumerable<SearchResultWithSummaryModel>> LexicalSearchAsync(string? query, int limit);
    Task<IEnumerable<SearchResultModel>> ListAsync();
    Task<IEnumerable<SearchResultWithSummaryModel>> SemanticSearchAsync(string? query, int limit);
}
