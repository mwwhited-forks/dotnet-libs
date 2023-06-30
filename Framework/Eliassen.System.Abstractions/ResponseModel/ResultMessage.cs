namespace Eliassen.System.ResponseModel;

public record ResultMessage
{
    public MessageLevels Level { get; init; } = MessageLevels.Information;
    public string Message { get; init; }
    public string? MessageCode { get; init; }
    public string? Context { get; init; }
    public object? MetaData { get; init; }
}
