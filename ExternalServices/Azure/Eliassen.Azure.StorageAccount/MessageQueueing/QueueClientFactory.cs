using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public class QueueClientFactory : IQueueClientFactory
{
    public QueueClient Create(IConfigurationSection config) =>
         new QueueClient(
            config["ConnectionString"] ?? throw new ApplicationException($"Configuration \"{config.Path}:ConnectionString\" is missing"),
            config["QueueName"] ?? throw new ApplicationException($"Configuration \"{config.Path}:QueueName\" is missing"),
            new QueueClientOptions
            {
                MessageEncoding = QueueMessageEncoding.Base64,
            });
}
