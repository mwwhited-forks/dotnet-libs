using Eliassen.System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq.Search
{
    public record SearchQuery<TModel> : SearchQuery
    {
        public IReadOnlyCollection<string> Filterable => ExpressionTreeBuilder.GetFilterablePropertyNames<TModel>();
        public IReadOnlyCollection<string> Searchable => ExpressionTreeBuilder.GetSearchablePropertyNames<TModel>();
        public IReadOnlyCollection<string> Sortable => ExpressionTreeBuilder.GetSortablePropertyNames<TModel>();
    }
    public record SearchQuery : IPageQuery, ISortQuery, ISearchTermQuery, IFilterQuery, ISearchQuery
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

        //public IQueryResult<TModel> For<TModel>(IEnumerable<TModel> query) => query.AsQueryable().ExecuteBy(this);
        //public IQueryResult<TModel> For<TModel>(IQueryable<TModel> query) => query.ExecuteBy(this);

        //public Task<IQueryResult<TModel>> ForAsync<TModel>(IEnumerable<TModel> query, CancellationToken cancellationToken = default) =>
        //    query.AsQueryable().ExecuteByAsync(this, cancellationToken);
        //public Task<IQueryResult<TModel>> ForAsync<TModel>(IQueryable<TModel> query, CancellationToken cancellationToken = default) =>
        //    query.ExecuteByAsync(this, cancellationToken);
    }
}
