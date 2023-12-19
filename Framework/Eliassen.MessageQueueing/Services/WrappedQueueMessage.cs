using Eliassen.MessageQueueing.Services;
using System.Collections.Generic;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public record WrappedQueueMessage : IQueueMessage
{
    public string ContentType { get; init; }
    public string? CorrelationId { get; init; }
    public object Payload { get; init; }
    public string? PayloadType { get; init; }
    public Dictionary<string, object?> Properties { get; init; }
}
