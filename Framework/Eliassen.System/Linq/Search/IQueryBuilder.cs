using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public interface IQueryBuilder
    {
        IQueryResult ExecuteBy(IQueryable query, ISearchQuery searchQuery);
    }
    public interface IQueryBuilder<TModel> : IQueryBuilder
    {
        IQueryResult<TModel> ExecuteBy(IQueryable<TModel> query, ISearchQuery searchQuery);
    }
}
