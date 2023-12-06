namespace Eliassen.MessageQueueing;

public interface IMessageSender<TQueueTarget>
{
    Task<string> SendAsync(object message, string? messageId = default);
}
