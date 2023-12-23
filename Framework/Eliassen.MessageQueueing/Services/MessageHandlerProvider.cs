using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing.Services;
/// <summary>
/// Provides handling of queue messages by coordinating multiple <see cref="IMessageQueueHandler"/> instances.
/// </summary>
public class MessageHandlerProvider : IMessageHandlerProvider
{
    private readonly ISerializer _serializer;
    private readonly IMessageContextFactory _context;
    private readonly ILogger _logger;

    private Type? _channelType;
    private IConfigurationSection _config = null!;
    private readonly ConcurrentBag<IMessageQueueHandler> _handlers = [];

    /// <summary>
    /// Gets the configuration section associated with the message handler.
    /// </summary>
    public IConfigurationSection Config => _config ?? throw new ApplicationException($"Missing Configuration");

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandlerProvider"/> class.
    /// </summary>
    /// <param name="serializer">The JSON serializer.</param>
    /// <param name="context">The factory for creating instances of <see cref="IMessageContext"/>.</param>
    /// <param name="logger">The logger for logging messages.</param>
    public MessageHandlerProvider(
        IJsonSerializer serializer,
        IMessageContextFactory context,
        ILogger<MessageHandlerProvider> logger
        )
    {
        _serializer = serializer;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Sets the collection of <see cref="IMessageQueueHandler"/> instances that will handle the messages.
    /// </summary>
    /// <param name="handlers">The collection of message handlers.</param>
    /// <returns>The current instance of <see cref="IMessageHandlerProvider"/>.</returns>
    public IMessageHandlerProvider SetHandlers(IEnumerable<IMessageQueueHandler> handlers)
    {
        foreach (var handler in handlers)
            _handlers.Add(handler);
        return this;
    }

    /// <summary>
    /// Sets the type of the message channel associated with the handler.
    /// </summary>
    /// <param name="channelType">The type of the message channel.</param>
    /// <returns>The current instance of <see cref="IMessageHandlerProvider"/>.</returns>
    public IMessageHandlerProvider SetChannelType(Type channelType)
    {
        _channelType = channelType;
        return this;
    }

    /// <summary>
    /// Sets the configuration section associated with the message handler.
    /// </summary>
    /// <param name="config">The configuration section.</param>
    /// <returns>The current instance of <see cref="IMessageHandlerProvider"/>.</returns>
    public IMessageHandlerProvider SetConfig(IConfigurationSection config)
    {
        _config = config ?? throw new ApplicationException($"Missing Configuration");
        return this;
    }

    /// <summary>
    /// Handles the specified queue message by invoking each registered message handler.
    /// </summary>
    /// <param name="message">The queue message to handle.</param>
    /// <param name="messageId">The ID of the message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task HandleAsync(IQueueMessage message, string messageId)
    {
        if (message != null)
        {
            var context = _context.Create(
                _channelType ?? throw new ApplicationException("No channel type"),
                message,
                Config ?? throw new ApplicationException("No channel configuration")
                );

            var payloadType = message.PayloadType == null ? null : Type.GetType(message.PayloadType);
            object payload = message.Payload;
            if (payloadType != null)
            {
                var convert = _serializer.Serialize(payload, payload.GetType());
                payload = _serializer.Deserialize(convert, payloadType) ?? payload;
            }

            _logger.LogInformation($"Handle: {{{nameof(messageId)}}}", messageId);
            context.SentId = messageId;

            foreach (var handler in _handlers)
            {
                await handler.HandleAsync(payload, context);
            }

            _logger.LogInformation($"Handled: {{{nameof(messageId)}}}", messageId);
        }
        else
        {
            _logger.LogWarning($"Nothing to handle");
        }
    }
}