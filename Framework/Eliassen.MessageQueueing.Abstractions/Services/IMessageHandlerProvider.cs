using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageHandlerProvider
{
    Task HandleAsync(IQueueMessage message, string messageId);
    IConfigurationSection Config { get; }

    internal IMessageHandlerProvider SetHandlers(IEnumerable<IMessageQueueHandler> handlers);
    internal IMessageHandlerProvider SetChannelType(Type channelType);
    internal IMessageHandlerProvider SetConfig(IConfigurationSection config);
}