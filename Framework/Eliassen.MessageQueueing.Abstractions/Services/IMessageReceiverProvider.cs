using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageReceiverProvider
{

    void Handlers(IEnumerable<IMessageHandler> handlers);
    void Config(IConfigurationSection config);
    void ChannelType(Type channelType);

    Task RunAsync(
        CancellationToken cancellationToken = default
        );
}

