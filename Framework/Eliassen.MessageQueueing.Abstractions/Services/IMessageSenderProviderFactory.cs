namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderProviderFactory
{
    IMessageSenderProvider Sender(Type channelType, Type messageType);
}
