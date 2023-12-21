namespace Eliassen.Communications.Services;

public interface IMessageSender<TMessageType>
{
    Task<string> SendAsync(TMessageType message);
}
