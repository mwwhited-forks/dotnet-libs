namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderProvider
{
    Task SendAsync(object message, IMessageSenderContext context);
}
