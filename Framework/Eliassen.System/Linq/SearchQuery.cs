using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq
{
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
        public virtual Dictionary<string, object>? Filter { get; set; }

        /// <inheritdoc cref="ISortQuery.OrderBy"/>
        public virtual Dictionary<string, object>? OrderBy { get; set; }

        IDictionary<string, object>? IFilterQuery.Filter => Filter;

        IDictionary<string, OrderDirections> ISortQuery.OrderBy =>
            (OrderBy ?? new Dictionary<string, object>()).ToDictionary(k => k.Key, v => ToOrderDirections(v.Value));

        private static OrderDirections ToOrderDirections(object input) =>
            input switch
            {
                OrderDirections @enum => @enum,
                int num => (OrderDirections)num,
                string str when Enum.TryParse<OrderDirections>(str, out var enu) => enu,
                string str => str.StartsWith(OrderDirectionsExtensions.DescendingShort, StringComparison.InvariantCultureIgnoreCase) ? OrderDirections.Descending : OrderDirections.Ascending,
                _ => OrderDirections.Ascending,
            };

        public IPagedResult<TModel> For<TModel>(IEnumerable<TModel> query) => query.AsQueryable().ExecuteBy(this);
        public IPagedResult<TModel> For<TModel>(IQueryable<TModel> query) => query.ExecuteBy(this);

        public Task<IPagedResult<TModel>> ForAsync<TModel>(IEnumerable<TModel> query, CancellationToken cancellationToken = default) =>
            query.AsQueryable().ExecuteByAsync(this, cancellationToken);
        public Task<IPagedResult<TModel>> ForAsync<TModel>(IQueryable<TModel> query, CancellationToken cancellationToken = default) =>
            query.ExecuteByAsync(this, cancellationToken);
    }
}
