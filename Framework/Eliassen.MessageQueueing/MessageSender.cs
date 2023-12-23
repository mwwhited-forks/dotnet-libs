using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing;

/// <summary>
/// Represents a message sender for a specific communication channel (<typeparamref name="TChannel"/>).
/// </summary>
/// <typeparam name="TChannel">The type representing the communication channel.</typeparam>
public class MessageSender<TChannel> : IMessageQueueSender<TChannel>
{
    private readonly IMessageContextFactory _context;
    private readonly IMessageSenderProviderFactory _provider;
    private readonly IMessagePropertyResolver _resolver;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageSender{TChannel}"/> class.
    /// </summary>
    /// <param name="context">The message context factory.</param>
    /// <param name="provider">The message sender provider factory.</param>
    /// <param name="resolver">The message property resolver.</param>
    /// <param name="logger">The logger.</param>
    public MessageSender(
        IMessageContextFactory context,
        IMessageSenderProviderFactory provider,
        IMessagePropertyResolver resolver,
        ILogger<TChannel> logger
    )
    {
        _context = context;
        _provider = provider;
        _resolver = resolver;
        _logger = logger;
    }

    /// <summary>
    /// Sends a message asynchronously to the specified communication channel.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    /// <param name="correlationId">The correlation ID associated with the message (optional).</param>
    /// <returns>The ID of the sent message.</returns>
    public async Task<string> SendAsync(
        object message,
        string? correlationId = default
    )
    {
        // TODO: Add useful logging

        var targetType = typeof(TChannel);
        var messageType = message.GetType();

        var stackFrame = new StackFrame(5 /* this is based on the depth of the async/await state machine.  5 will get to the original caller  */, true);

        var callerMethod = stackFrame.GetMethod();
        var lineNumber = stackFrame.GetFileLineNumber();
        var callerPath = stackFrame.GetFileName();

        var originMessageId = correlationId;
        correlationId = _resolver.MessageId(targetType, messageType, correlationId);
        var requestId = _resolver.GenerateId(targetType, messageType);
        var config = _resolver.Configuration(targetType, messageType);
        var context = _context.Create(
            targetType,
            messageType,
            originMessageId,
            correlationId,
            requestId,
            config,
            callerMethod,
            lineNumber,
            callerPath
        );
        var provider = _provider.Sender(targetType, messageType);

        _logger.LogInformation("Sending: \"{message}\" [{orgMessageId} -> {messageId}] to \"{targetType}\" from \"{caller}::{method}\"",
            message,
            originMessageId,
            correlationId,
            targetType,
            callerMethod?.DeclaringType,
            callerMethod
        );

        try
        {
            var sentId = await provider.SendAsync(message, context);

            _logger.LogInformation("Sent: [{orgMessageId} -> {messageId}] => ({sentId})",
                originMessageId,
                correlationId,
                sentId
            );

            context.SentId = sentId;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: \"{message}\" [{orgMessageId} -> {messageId}]",
                ex.Message,
                originMessageId,
                correlationId
            );

            _logger.LogDebug("Exception: {trace}\r\n [{orgMessageId} -> {messageId}]",
                ex.ToString(),
                originMessageId,
                correlationId
            );

            throw;
        }
        return context.SentId ?? context.CorrelationId ?? originMessageId ?? requestId;
    }
}