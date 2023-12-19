using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public interface IQueueClientFactory
{
    QueueClient Create(IConfigurationSection config);
}
