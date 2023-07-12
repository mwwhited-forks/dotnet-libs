using System.Collections;

namespace Eliassen.System.ResponseModel
{
    public interface IQueryResult : IResult
    {
        public IEnumerable Rows { get; }
    }
    public interface IQueryResult<TModel> : IQueryResult
    {
        public new IReadOnlyCollection<TModel> Rows { get; }
    }
}
