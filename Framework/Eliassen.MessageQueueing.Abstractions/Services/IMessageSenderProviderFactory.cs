namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderProviderFactory
{
    IMessageSenderProvider Create(Type channelType, Type messageType);
}
