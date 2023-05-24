using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq
{
    public interface ISearchQuery : IPageQuery, ISortQuery, ISearchTermQuery, IFilterQuery
    {
        IPagedResult<TModel> For<TModel>(IEnumerable<TModel> query);
        IPagedResult<TModel> For<TModel>(IQueryable<TModel> query);
        Task<IPagedResult<TModel>> ForAsync<TModel>(IEnumerable<TModel> query, CancellationToken cancellationToken = default);
        Task<IPagedResult<TModel>> ForAsync<TModel>(IQueryable<TModel> query, CancellationToken cancellationToken = default);
    }
}