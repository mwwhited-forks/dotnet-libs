using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public interface IQueryBuilder<TModel>
    {
        IOrderedQueryable<TModel> BuildFrom(IQueryable<TModel> query, ISearchQuery searchQuery, StringComparison stringComparison);
        IPagedQueryResult<TModel> PageBy(IOrderedQueryable<TModel> query, IPageQuery? pager);
    }
}
