using Eliassen.System.Linq.Expressions;
using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    public record SearchQuery<TModel> : SearchQuery, ISearchQuery<TModel>
    {
        public IReadOnlyCollection<string> Filterable => ExpressionTreeBuilder.GetFilterablePropertyNames<TModel>();
        public IReadOnlyCollection<string> Searchable => ExpressionTreeBuilder.GetSearchablePropertyNames<TModel>();
        public IReadOnlyCollection<string> Sortable => ExpressionTreeBuilder.GetSortablePropertyNames<TModel>();
    }
    public record SearchQuery : ISearchQuery
    {
        /// <inheritdoc cref="IPageQuery.CurrentPage"/>
        public virtual int CurrentPage { get; set; }
        /// <inheritdoc cref="IPageQuery.PageSize"/>
        public virtual int PageSize { get; set; }
        /// <inheritdoc cref="IPageQuery.ExcludePageCount"/>
        public virtual bool ExcludePageCount { get; set; }

        /// <inheritdoc cref="ISearchTermQuery.SearchTerm"/>
        public virtual string? SearchTerm { get; set; }

        /// <inheritdoc cref="IFilterQuery.Filter"/>
        public virtual Dictionary<string, SearchParameter> Filter { get; init; } = new();

        /// <inheritdoc cref="ISortQuery.OrderBy"/>
        public virtual Dictionary<string, OrderDirections> OrderBy { get; init; } = new();

        IDictionary<string, SearchParameter> IFilterQuery.Filter => Filter;
        IDictionary<string, OrderDirections> ISortQuery.OrderBy => OrderBy;
    }
}
