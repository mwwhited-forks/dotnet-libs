using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageContext
{
    public string? OriginMessageId { get; }
    public string? CorrelationId { get; set; }
    public string? RequestId { get; }
    public string? SentId { get; set; }

    public string? ChannelType { get; }
    public string? MessageType { get; }

    public DateTimeOffset? SentAt { get; }
    public string? SentBy { get; }
    public string? SentFrom { get; }

    object? this[string key] { get; set; }

    Dictionary<string, object?> Headers { get; }

    IConfigurationSection Config { get; }
}
