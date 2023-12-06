namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderContext
{
    string MessageId { get; }
    Dictionary<string, object> Headers { get; }
}
