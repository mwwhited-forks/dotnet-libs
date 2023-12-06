namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderContextFactory
{
    IMessageSenderContext Create(Type targetQueueType, Type messageType, string messageId);
}
