namespace Eliassen.MessageQueueing.Services;

public interface IMessageReceiverProviderFactory
{
    IEnumerable<IMessageReceiverProvider> Create();
}