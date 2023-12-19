using Eliassen.MessageQueueing.Services;

namespace Eliassen.MessageQueueing;

public interface IMessageHandler<TQueueSource>
{
    Task HandleAsync(object message, IMessageContext context);
}
public interface IMessageHandler<TQueueSource, TMessage> : IMessageHandler<TQueueSource>
{
    new Task HandleAsync(TMessage message, IMessageContext context);
}

