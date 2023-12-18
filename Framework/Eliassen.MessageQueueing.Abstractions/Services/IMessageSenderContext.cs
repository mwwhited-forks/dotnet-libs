using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderContext
{
    string MessageId { get; set; }
    Dictionary<string, object?> Headers { get; }
    IConfigurationSection Config { get; }
}
