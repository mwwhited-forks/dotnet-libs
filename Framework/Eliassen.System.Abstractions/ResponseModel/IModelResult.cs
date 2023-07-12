namespace Eliassen.System.ResponseModel;

public interface IModelResult
{
    object? Data { get; }
    IReadOnlyCollection<ResultMessage>? Messages { get; }
}

public interface IModelResult<TModel> : IModelResult
{
    new TModel? Data { get; }
}
