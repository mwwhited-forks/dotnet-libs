namespace Eliassen.Communications.Services;

public interface ICommunicationSender<TMessageType>
{
    Task<string> SendAsync(TMessageType message);
}
