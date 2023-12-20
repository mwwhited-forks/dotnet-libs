using Eliassen.MessageQueueing.Services;

namespace Eliassen.MessageQueueing;

public interface IMessageHandler
{
    Task HandleAsync(object message, IMessageContext context);
}
public interface IMessageHandler<TChannel> : IMessageHandler
{
}
public interface IMessageHandler<TChannel, TMessage> : IMessageHandler<TChannel>
{
    new Task HandleAsync(TMessage message, IMessageContext context);
}

