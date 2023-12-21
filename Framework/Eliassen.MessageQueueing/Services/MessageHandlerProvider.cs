using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing.Services;

public class MessageHandlerProvider : IMessageHandlerProvider
{
    private readonly ISerializer _serializer;
    private readonly IMessageContextFactory _context;
    private readonly ILogger _logger;

    private Type? _channelType;
    private IConfigurationSection? _config;
    private readonly ConcurrentBag<IMessageQueueHandler> _handlers = new ();

    public IConfigurationSection Config => _config;

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

    public IMessageHandlerProvider SetHandlers(IEnumerable<IMessageQueueHandler> handlers)
    {
        foreach (var handler in handlers)
            _handlers.Add(handler);
        return this;
    }
    public IMessageHandlerProvider SetChannelType(Type channelType)
    {
        _channelType = channelType;
        return this;
    }
    public IMessageHandlerProvider SetConfig(IConfigurationSection config)
    {
        _config = config;
        return this;
    }

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