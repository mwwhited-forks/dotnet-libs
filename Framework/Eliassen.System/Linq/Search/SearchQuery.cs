using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    /// <inheritdoc/>
    public class SearchQuery<TModel> : SearchQuery, ISearchQuery<TModel>
    {
    }

    /// <inheritdoc/>
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
        public Dictionary<string, FilterParameter> Filter { get; init; } = new();

        /// <inheritdoc cref="ISortQuery.OrderBy"/>
        public Dictionary<string, OrderDirections> OrderBy { get; init; } = new();

        IDictionary<string, FilterParameter> IFilterQuery.Filter => Filter;
        IDictionary<string, OrderDirections> ISortQuery.OrderBy => OrderBy;
    }
}
