using Eliassen.Search.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Search;

/// <summary>
/// Represents a provider for conducting searches.
/// </summary>
[Obsolete]
public interface ISearchProvider
{
    /// <summary>
    /// Performs a hybrid search based on the specified query and limit.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <param name="limit">The maximum number of search results to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the search results.</returns>
    Task<IEnumerable<SearchResultModel>> HybridSearchAsync(string? query, int limit);

    /// <summary>
    /// Performs a lexical search based on the specified query and limit.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <param name="limit">The maximum number of search results to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the search results.</returns>
    Task<IEnumerable<SearchResultModel>> LexicalSearchAsync(string? query, int limit);

    /// <summary>
    /// Retrieves a list of search results.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of search results.</returns>
    Task<IEnumerable<SearchResultModel>> ListAsync();

    /// <summary>
    /// Performs a semantic search based on the specified query and limit.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <param name="limit">The maximum number of search results to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the search results.</returns>
    Task<IEnumerable<SearchResultModel>> SemanticSearchAsync(string? query, int limit);
}
