using Azure.Storage.Queues;
using Eliassen.MessageQueueing.Services;
using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public class AzureStorageQueueMessageSenderProvider : IMessageSenderProvider
{
    private readonly ISerializer _serializer;

    public AzureStorageQueueMessageSenderProvider(
        IJsonSerializer serializer
        )
    {
        _serializer = serializer;
    }


    public async Task<string?> SendAsync(object message, IMessageSenderContext context)
    {
        var client = new QueueClient(
            context.Config["ConnectionString"] ?? throw new ApplicationException($"Configuration \"{context.Config.Path}:ConnectionString\" is missing"),
            context.Config["QueueName"] ?? throw new ApplicationException($"Configuration \"{context.Config.Path}:QueueName\" is missing"),
            new QueueClientOptions
            {
                MessageEncoding = QueueMessageEncoding.Base64,
            });

        var wrapped = new
        {
            ContentType = $"application/json; Class={message.GetType().FullName}",
            CorrelationId = context.MessageId,
            Payload = message,
            Properties = context.Headers,
        };

        var serialized = _serializer.Serialize(wrapped);

        var result = await client.SendMessageAsync(serialized);

        return result.Value.MessageId;
    }
}
