namespace Eliassen.System.Linq.Search
{
    public interface ISearchQuery : IPageQuery, ISortQuery, ISearchTermQuery, IFilterQuery
    {
    }

    public interface ISearchQuery<TModel> : ISearchQuery
    {
    }
}