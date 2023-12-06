namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderResolver
{
    string Provider(Type targetQueueType, Type messageType);
    string MessageId(Type targetQueueType, Type messageType, string? messageId);
}
