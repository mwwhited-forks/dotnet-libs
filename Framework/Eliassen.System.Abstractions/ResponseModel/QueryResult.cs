using System.Collections;

namespace Eliassen.System.ResponseModel;

/// <inheritdoc/>
public class QueryResult<TModel> : IQueryResult<TModel>
{
    /// <inheritdoc/>
    public QueryResult(
        IEnumerable<TModel> items
        )
    {
        Rows = items as List<TModel> ?? items.ToList();
    }

    /// <inheritdoc/>
    public QueryResult(
        IQueryResult<TModel> toWrap
        ) : this(
            items: toWrap.Rows
            )
    {
    }

    /// <inheritdoc/>
    public QueryResult()
    {
    }

    /// <inheritdoc/>
    public IReadOnlyCollection<TModel> Rows { get; } = new List<TModel>();
    IEnumerable IQueryResult.Rows => Rows;

    public IReadOnlyCollection<ResultMessage>? Messages { get; init; }
}
