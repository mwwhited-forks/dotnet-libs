namespace Eliassen.MessageQueueing.Services;

/// <summary>
/// Represents a wrapped queue message.
/// </summary>
public record WrappedQueueMessage : IQueueMessage
{
    /// <summary>
    /// Gets or initializes the content type of the message.
    /// </summary>
    public string ContentType { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the correlation ID of the message.
    /// </summary>
    public string CorrelationId { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the payload of the message.
    /// </summary>
    public object Payload { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the payload type of the message.
    /// </summary>
    public string? PayloadType { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the properties associated with the message.
    /// </summary>
    public Dictionary<string, object?> Properties { get; init; } = null!;
}