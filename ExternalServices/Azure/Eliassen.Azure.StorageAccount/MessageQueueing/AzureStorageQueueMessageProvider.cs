using Eliassen.MessageQueueing.Services;
using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public class AzureStorageQueueMessageProvider : IMessageSenderProvider, IMessageReceiverProvider
{
    private readonly ISerializer _serializer;
    private readonly IQueueClientFactory _client;
    private readonly ILogger _logger;

    public AzureStorageQueueMessageProvider(
        IJsonSerializer serializer,
        IQueueClientFactory client,
        ILogger<AzureStorageQueueMessageProvider> logger
        )
    {
        _serializer = serializer;
        _client = client;
        _logger = logger;
    }


    public async Task<string?> SendAsync(object message, IMessageContext context)
    {
        var client = _client.Create(context.Config);

        var wrapped = new WrappedQueueMessage
        {
            ContentType = "application/json;",
            PayloadType = message.GetType().AssemblyQualifiedName,
            CorrelationId = context.CorrelationId,
            Payload = message,
            Properties = context.Headers,
        };

        var serialized = _serializer.Serialize(wrapped);
        var result = await client.SendMessageAsync(serialized);

        return result.Value.MessageId;
    }

    public async Task WatchQueue(
        IConfigurationSection config,
        Func<object, Task> handlerAsync,
        CancellationToken cancellationToken = default
        )
    {
        var client = _client.Create(config);
        var newCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken).Token;

        //while (!newCancellationToken.IsCancellationRequested)
        //{
        var message = await client.ReceiveMessageAsync(null, newCancellationToken);

        _logger.LogInformation($"Received: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);

        using var stream = message.Value.Body.ToStream();
        var serialized = _serializer.Deserialize(stream, typeof(WrappedQueueMessage));

        if (serialized != null)
        {
            _logger.LogInformation($"Handle: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
            await handlerAsync(serialized);
            _logger.LogInformation($"Handled: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
        }

        _logger.LogInformation($"Dequeue: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
        await client.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt, newCancellationToken);
        // }
    }
}
