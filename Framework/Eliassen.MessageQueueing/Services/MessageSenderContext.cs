using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderContext : IMessageSenderContext
{
    public string MessageId { get; set; } = null!;

    public Dictionary<string, object?> Headers { get; } = new();

    public IConfigurationSection Config { get; set; } = null!;
}
