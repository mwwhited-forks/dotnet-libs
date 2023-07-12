namespace Eliassen.System.ResponseModel;

public interface IResult
{
    IReadOnlyCollection<ResultMessage>? Messages { get; }
}
