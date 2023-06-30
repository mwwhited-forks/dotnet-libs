namespace Eliassen.System.ResponseModel;

public record ResultMessage
{
    public MessageLevels Level { get; init; } = MessageLevels.Information;
    public string Message { get; init; }
    public string? MessageCode { get; init; }
    public string? Context { get; init; }
    public object? MetaData { get; init; }

    internal static class Messages
    {
        public const string NoSearchQueryFilter = $"No filtering detected";
        public const string NoSearchQueryFilterCode = "NO_SEARCHQUERY_FILTER";

        public const string NoPropertyFilter = $"No filtering for property";
        public const string NoPropertyFilterCode = "NO_PROPERTY_FILTER";
    }
}
