namespace Eliassen.System.ResponseModel;

public record ModelResult<TModel> : IModelResult<TModel>
{
    public ModelResult(TModel data) => Data = data;

    public TModel? Data { get; }
    object? IModelResult.Data => Data;

    public IReadOnlyCollection<ResultMessage>? Messages { get; init; }
}