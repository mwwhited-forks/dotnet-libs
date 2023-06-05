using Eliassen.System.Linq.Expressions;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    /// <summary>
    /// This is a collection of operations for extending IQueryable{T} 
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static IQueryResult ExecuteBy(this IQueryable query, ISearchQuery searchQuery)
        {
            var interfaces = from inf in query.GetType().GetInterfaces()
                             where inf.IsGenericType
                             where inf.GetGenericTypeDefinition() == typeof(IQueryable<>)
                             select inf;

            var @interface = interfaces.FirstOrDefault() ??
                throw new NotSupportedException($"{query.GetType()} is not supported");
            var elementType = @interface.GetGenericArguments()[0];

            var queryType = Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(0)) ??
                throw new NotSupportedException($"{query.GetType()} is not supported");

            var methodSignature = typeof(QueryableExtensions).GetMethod(
                nameof(ExecuteBy),
                1,
                new[] { queryType, typeof(ISearchQuery) }
                ) ??
                throw new NotSupportedException($"{query.GetType()} is not supported");

            var method = methodSignature.MakeGenericMethod(elementType);
            var result = method.Invoke(null, new object[] { query, searchQuery }) ??
                throw new NotSupportedException($"{query.GetType()} is not supported");
            var paged = (IQueryResult)result;
            return paged;
        }

        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static IQueryResult<TModel> ExecuteBy<TModel>(this IQueryable<TModel> query, ISearchQuery searchQuery)
        {
            var queryBuilder = new QueryBuilder<TModel>(
                new SortBuilder<TModel>(), 
                new ExpressionTreeBuilder<TModel>()
                );
            var ordered = queryBuilder.BuildFrom(query, searchQuery, StringComparison.InvariantCultureIgnoreCase);

            return searchQuery.PageSize >= 0 ?
                queryBuilder.PageBy(ordered, searchQuery) :
                new QueryResult<TModel>(ordered)
                ;
        }
    }
}
