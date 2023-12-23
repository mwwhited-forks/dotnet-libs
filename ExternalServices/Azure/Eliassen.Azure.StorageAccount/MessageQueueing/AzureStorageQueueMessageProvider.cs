using Eliassen.MessageQueueing.Services;
using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public class AzureStorageQueueMessageProvider(
    IJsonSerializer serializer,
    IQueueClientFactory client,
    ILogger<AzureStorageQueueMessageProvider> logger
        ) : IMessageSenderProvider, IMessageReceiverProvider
{
    private readonly ISerializer _serializer = serializer;
    private readonly IQueueClientFactory _client = client;
    private readonly ILogger _logger = logger;

    private IMessageHandlerProvider? _handlerProvider;

    public async Task<string?> SendAsync(object message, IMessageContext context)
    {
        var client = _client.Create(context.Config);

        var wrapped = new WrappedQueueMessage
        {
            ContentType = "application/json;",
            PayloadType = message.GetType().AssemblyQualifiedName,
            CorrelationId = context.CorrelationId ?? "",
            Payload = message,
            Properties = context.Headers,
        };

        var serialized = _serializer.Serialize(wrapped);
        var result = await client.SendMessageAsync(serialized);

        return result.Value.MessageId;
    }

    public IMessageReceiverProvider SetHandlerProvider(IMessageHandlerProvider handlerProvider)
    {
        _handlerProvider = handlerProvider;
        return this;
    }

    public async Task RunAsync(
        CancellationToken cancellationToken = default
        )
    {
        var client = _client.Create(_handlerProvider?.Config ?? throw new ApplicationException("No configuration"));
        var newCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken).Token;

        while (!newCancellationToken.IsCancellationRequested)
        {
            var message = await client.ReceiveMessageAsync(TimeSpan.FromMinutes(1), newCancellationToken);

            if (message?.Value == null)
            {
                _logger.LogInformation($"Nothing Received waiting");
                await Task.Delay(1000);  //TODO: this should be configurable
                continue;
            }

            using var stream = message.Value.Body.ToStream();
            var deserialized = _serializer.Deserialize<WrappedQueueMessage>(stream)
                ?? throw new NotSupportedException($"No payload found");

            await _handlerProvider.HandleAsync(deserialized, message.Value.MessageId);

            _logger.LogInformation($"Dequeue: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
            var response = await client.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt, newCancellationToken);
        }
    }
}
