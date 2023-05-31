using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    public class SearchQuery<TModel> : SearchQuery, ISearchQuery<TModel>
    {
    }
    public class SearchQuery : ISearchQuery
    {
        /// <inheritdoc cref="IPageQuery.CurrentPage"/>
        public int CurrentPage { get; set; }
        /// <inheritdoc cref="IPageQuery.PageSize"/>
        public int PageSize { get; set; }
        /// <inheritdoc cref="IPageQuery.ExcludePageCount"/>
        public bool ExcludePageCount { get; set; }

        /// <inheritdoc cref="ISearchTermQuery.SearchTerm"/>
        public string? SearchTerm { get; set; }

        /// <inheritdoc cref="IFilterQuery.Filter"/>
        public Dictionary<string, SearchParameter> Filter { get; init; } = new();

        /// <inheritdoc cref="ISortQuery.OrderBy"/>
        public Dictionary<string, OrderDirections> OrderBy { get; init; } = new();

        IDictionary<string, SearchParameter> IFilterQuery.Filter => Filter;
        IDictionary<string, OrderDirections> ISortQuery.OrderBy => OrderBy;
    }
}
