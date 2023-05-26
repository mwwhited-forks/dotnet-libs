using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq
{
    public interface ISearchQuery : IPageQuery, ISortQuery, ISearchTermQuery, IFilterQuery
    {
        //IPagedQueryResult<TModel> For<TModel>(IEnumerable<TModel> query);
        //IPagedQueryResult<TModel> For<TModel>(IQueryable<TModel> query);
        //Task<IPagedQueryResult<TModel>> ForAsync<TModel>(IEnumerable<TModel> query, CancellationToken cancellationToken = default);
        //Task<IPagedQueryResult<TModel>> ForAsync<TModel>(IQueryable<TModel> query, CancellationToken cancellationToken = default);
    }
}