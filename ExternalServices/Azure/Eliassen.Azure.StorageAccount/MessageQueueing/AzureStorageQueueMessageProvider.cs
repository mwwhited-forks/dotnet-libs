using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public class AzureStorageQueueMessageProvider : IMessageSenderProvider, IMessageReceiverProvider
{
    private readonly ISerializer _serializer;
    private readonly IQueueClientFactory _client;
    private readonly IMessageContextFactory _context;
    private readonly ILogger _logger;

    private Type? _channelType;
    private IConfigurationSection? _config;
    private readonly IProducerConsumerCollection<IMessageHandler> _handlers = new ConcurrentBag<IMessageHandler>();

    public AzureStorageQueueMessageProvider(
        IJsonSerializer serializer,
        IQueueClientFactory client,
        IMessageContextFactory context,
        ILogger<AzureStorageQueueMessageProvider> logger
        )
    {
        _serializer = serializer;
        _client = client;
        _context = context;
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

    public void Handlers(IEnumerable<IMessageHandler> handlers)
    {
        foreach (var handler in handlers)
            _handlers.TryAdd(handler);
    }
    public void Config(IConfigurationSection config) => _config = config;
    public void ChannelType(Type channelType) => _channelType = channelType;


    public async Task RunAsync(
        CancellationToken cancellationToken = default
        )
    {
        var client = _client.Create(_config ?? throw new ApplicationException("No configuration"));
        var newCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken).Token;

        while (!newCancellationToken.IsCancellationRequested)
        {
            var message = await client.ReceiveMessageAsync(null, newCancellationToken);

            if (message?.Value == null)
            {
                _logger.LogInformation($"Nothing Received");
                await Task.Delay(1000);
                continue;
            }

            _logger.LogInformation($"Received: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);

            using var stream = message.Value.Body.ToStream();
            var deserialized = _serializer.Deserialize<WrappedQueueMessage>(stream);

            if (deserialized != null)
            {
                var context = _context.Create(_channelType ?? throw new ApplicationException("No channel type"), deserialized, _config);

                var payloadType = deserialized.PayloadType == null ? null : Type.GetType(deserialized.PayloadType);
                object payload = deserialized.Payload;
                if (payloadType != null)
                {
                    var convert = _serializer.Serialize(payload, payload.GetType());
                    payload = _serializer.Deserialize(convert, payloadType) ?? payload;
                }

                _logger.LogInformation($"Handle: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);

                foreach (var handler in _handlers)
                {

                    await handler.HandleAsync(payload, context);
                }

                _logger.LogInformation($"Handled: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
            }
            else
            {
                _logger.LogWarning($"Nothing to handle");
            }

            _logger.LogInformation($"Dequeue: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
            await client.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt, newCancellationToken);
        }
    }
}
