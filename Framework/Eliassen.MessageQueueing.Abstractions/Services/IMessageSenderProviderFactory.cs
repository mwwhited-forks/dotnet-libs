namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderProviderFactory
{
    IMessageSenderProvider Create(Type targetQueueType, Type messageType);
}
