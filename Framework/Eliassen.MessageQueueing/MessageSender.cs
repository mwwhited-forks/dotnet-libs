using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing;

public class MessageSender<TChannel> : IMessageSender<TChannel>
{
    private readonly IMessageContextFactory _context;
    private readonly IMessageSenderProviderFactory _provider;
    private readonly IMessagePropertyResolver _resolver;
    private readonly ILogger _logger;

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

    public async Task<string> SendAsync(
        object message,
        string? correlationId = default
        )
    {
        //TODO: add useful logging
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
        var provider = _provider.Create(targetType, messageType);

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
