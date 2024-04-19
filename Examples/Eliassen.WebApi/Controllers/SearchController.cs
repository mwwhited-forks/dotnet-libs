using Eliassen.Search;
using Eliassen.Search.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers;

[AllowAnonymous]
[Route("[Controller]/[Action]")]
public class SearchController : Controller
{
    private readonly ISearchProvider _search;

    public SearchController(
        ISearchProvider search
        )
    {
        _search = search;
    }

    [HttpGet]
    public async Task<IEnumerable<SearchResultModel>> List() => await _search.ListAsync();

    [HttpGet]
    public async Task<IEnumerable<SearchResultModel>> SemanticSearch(string? query = default, int limit = 10)
    {
        Response.Headers[$"X-APP-{nameof(query)}"] = query;
        Response.Headers[$"X-APP-{nameof(limit)}"] = limit.ToString();
        return await _search.SemanticSearchAsync(query, limit);
    }

    [HttpGet]
    public async Task<IEnumerable<SearchResultModel>> LexicalSearch(string? query = default, int limit = 10)
    {
        Response.Headers[$"X-APP-{nameof(query)}"] = query;
        Response.Headers[$"X-APP-{nameof(limit)}"] = limit.ToString();
        return await _search.LexicalSearchAsync(query, limit);
    }

    [HttpGet]
    public async Task<IEnumerable<SearchResultModel>> HybridSearch(string? query = default, int limit = 10)
    {
        Response.Headers[$"X-APP-{nameof(query)}"] = query;
        Response.Headers[$"X-APP-{nameof(limit)}"] = limit.ToString();
        return await _search.HybridSearchAsync(query, limit);
    }

}
