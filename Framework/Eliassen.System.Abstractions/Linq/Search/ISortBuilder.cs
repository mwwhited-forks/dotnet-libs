using Eliassen.System.Linq.Expressions;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public interface ISortBuilder<TModel>
    {
        IOrderedQueryable<TModel> SortBy(
            IQueryable<TModel> query,
            ISortQuery searchRequest,
            IExpressionTreeBuilder<TModel> treeBuilder,
            StringComparison stringComparison
            );
    }
}
