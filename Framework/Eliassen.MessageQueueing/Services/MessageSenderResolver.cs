using System;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderResolver : IMessageSenderResolver
{
    public virtual string MessageId(Type targetQueueType, Type messageType, string? messageId) =>
        string.IsNullOrWhiteSpace(messageId) ? Guid.NewGuid().ToString() : messageId;

    public virtual string Provider(Type targetQueueType, Type messageType)
    {
        //TODO: lookup provider based on types
        //TODO: lookup value from configuration

        throw new NotImplementedException();
    }
}
