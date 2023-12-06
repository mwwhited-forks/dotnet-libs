using System.Collections.Generic;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderContext : IMessageSenderContext
{
    public string MessageId { get; internal set; } = null!;
    public Dictionary<string, object> Headers { get; } = new();
}
