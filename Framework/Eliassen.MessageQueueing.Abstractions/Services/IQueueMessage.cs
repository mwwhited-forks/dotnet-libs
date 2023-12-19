namespace Eliassen.MessageQueueing.Services;

public interface IQueueMessage
{
    string ContentType { get; }
    string? CorrelationId { get; }
    object Payload { get; }
    string? PayloadType { get; }
    Dictionary<string, object?> Properties { get; }
}