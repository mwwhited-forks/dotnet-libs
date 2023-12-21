using Eliassen.MessageQueueing.Services;

namespace Eliassen.MessageQueueing;

public interface IMessageQueueHandler
{
    Task HandleAsync(object message, IMessageContext context);
}
public interface IMessageQueueHandler<TChannel> : IMessageQueueHandler
{
}
public interface IMessageQueueHandler<TChannel, TMessage> : IMessageQueueHandler<TChannel>
{
    new Task HandleAsync(TMessage message, IMessageContext context);
}

