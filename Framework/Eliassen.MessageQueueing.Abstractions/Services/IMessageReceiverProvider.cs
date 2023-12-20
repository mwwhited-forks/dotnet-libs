namespace Eliassen.MessageQueueing.Services;

public interface IMessageReceiverProvider
{
    public IMessageReceiverProvider SetHandlerProvider(IMessageHandlerProvider handlerProvider);

    Task RunAsync(
        CancellationToken cancellationToken = default
        );
}

