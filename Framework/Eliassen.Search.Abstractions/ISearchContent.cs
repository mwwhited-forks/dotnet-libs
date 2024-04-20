using System.Collections.Generic;

namespace Eliassen.Search;

/// <summary>
/// Represents a provider for searching content of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of content to search.</typeparam>
public interface ISearchContent<T>
{
    /// <summary>
    /// Queries the content provider asynchronously to retrieve search results.
    /// </summary>
    /// <param name="queryString">The query string used to search for content.</param>
    /// <param name="limit">The maximum number of search results to retrieve. Defaults to 25.</param>
    /// <param name="page">The page number of search results to retrieve. Defaults to 0.</param>
    /// <returns>An asynchronous enumerable that yields search results of type <typeparamref name="T"/>.</returns>
    IAsyncEnumerable<T> QueryAsync(string? queryString, int limit = 25, int page = 0);
}
