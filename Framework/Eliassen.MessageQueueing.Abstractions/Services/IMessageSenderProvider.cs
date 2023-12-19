namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderProvider
{
    Task<string?> SendAsync(object message, IMessageContext context);
}
