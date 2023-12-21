namespace Eliassen.MessageQueueing;


public interface IMessageQueueSender
{
    Task<string> SendAsync(object message, string? messageId = default);
}

public interface IMessageQueueSender<TChannel> : IMessageQueueSender
{
}
