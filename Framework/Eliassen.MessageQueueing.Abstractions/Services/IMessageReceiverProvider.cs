using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageReceiverProvider
{
    Task WatchQueue(
        IConfigurationSection config,
        Func<object, Task> handler,
        CancellationToken cancellationToken = default
        );
}

