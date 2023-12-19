namespace Eliassen.MessageQueueing;


public interface IMessageSender
{
    Task<string> SendAsync(object message, string? messageId = default);
}

public interface IMessageSender<TChannel> : IMessageSender
{
}
