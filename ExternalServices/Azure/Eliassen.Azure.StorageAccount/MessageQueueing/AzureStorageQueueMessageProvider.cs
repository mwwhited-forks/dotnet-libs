using Eliassen.MessageQueueing.Services;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

/// <summary>
/// Provides functionality for sending and receiving messages using Azure Storage Queues.
/// </summary>
/// <remark>
/// Initializes a new instance of the <see cref="AzureStorageQueueMessageProvider"/> class.
/// </remark>
/// <param name="serializer">The JSON serializer for message serialization and deserialization.</param>
/// <param name="clientFactory">The factory for creating Azure Storage Queue clients.</param>
/// <param name="logger">The logger for logging messages.</param>
public class AzureStorageQueueMessageProvider(
    IJsonSerializer serializer,
    IQueueClientFactory clientFactory,
    ILogger<AzureStorageQueueMessageProvider> logger
        ) : IMessageSenderProvider, IMessageReceiverProvider
{
    private IMessageHandlerProvider? _handlerProvider;

    /// <summary>
    /// Sends a message asynchronously to an Azure Storage Queue.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    /// <param name="context">The message context containing additional information.</param>
    /// <returns>The message ID if the send operation is successful; otherwise, <c>null</c>.</returns>
    public async Task<string?> SendAsync(object message, IMessageContext context)
    {
        var client = clientFactory.Create(context.Config);

        var wrapped = new WrappedQueueMessage
        {
            ContentType = "application/json;",
            PayloadType = message.GetType().AssemblyQualifiedName,
            CorrelationId = context.CorrelationId ?? "",
            Payload = message,
            Properties = context.Headers,
        };

        var serialized = serializer.Serialize(wrapped);
        var result = await client.SendMessageAsync(serialized);

        return result.Value.MessageId;
    }

    /// <summary>
    /// Sets the message handler provider for processing received messages.
    /// </summary>
    /// <param name="handlerProvider">The message handler provider.</param>
    /// <returns>The current instance of <see cref="AzureStorageQueueMessageProvider"/>.</returns>
    public IMessageReceiverProvider SetHandlerProvider(IMessageHandlerProvider handlerProvider)
    {
        _handlerProvider = handlerProvider;
        return this;
    }

    /// <summary>
    /// Runs the message receiver asynchronously, continuously listening for incoming messages.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to stop the receiver.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RunAsync(
        CancellationToken cancellationToken = default
        )
    {
        var client = clientFactory.Create(_handlerProvider?.Config ?? throw new ApplicationException("No configuration"));
        var newCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken).Token;

        while (!newCancellationToken.IsCancellationRequested)
        {
            var message = await client.ReceiveMessageAsync(TimeSpan.FromMinutes(1), newCancellationToken);

            if (message?.Value == null)
            {
                logger.LogInformation($"Nothing Received waiting");
                await Task.Delay(1000, cancellationToken);  //TODO: this should be configurable
                continue;
            }

            using var stream = message.Value.Body.ToStream();
            var deserialized = serializer.Deserialize<WrappedQueueMessage>(stream)
                ?? throw new NotSupportedException($"No payload found");

            await _handlerProvider.HandleAsync(deserialized, message.Value.MessageId);

            logger.LogInformation($"Dequeue: {{{nameof(message.Value.MessageId)}}}", message.Value.MessageId);
            var response = await client.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt, newCancellationToken);
        }
    }
}
