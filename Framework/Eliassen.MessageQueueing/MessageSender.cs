using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing;

public class MessageSender<TQueueTarget> : IMessageSender<TQueueTarget>
{
    private readonly IMessageSenderContextFactory _context;
    private readonly IMessageSenderProviderFactory _provider;
    private readonly IMessageSenderResolver _resolver;
    private readonly ILogger _logger;

    public MessageSender(
        IMessageSenderContextFactory context,
        IMessageSenderProviderFactory provider,
        IMessageSenderResolver resolver,
        ILogger<TQueueTarget> logger
        )
    {
        _context = context;
        _provider = provider;
        _resolver = resolver;
        _logger = logger;
    }

    public async Task<string> SendAsync(
        object message,
        string? messageId = default
        )
    {
        //TODO: add useful logging
        var targetType = typeof(TQueueTarget);
        var messageType = message.GetType();

        var stackFrame = new StackFrame(5 /* this is based on the depth of the async/await state machine.  5 will get to the original caller  */, true);

        var callerMethod = stackFrame.GetMethod();
        var lineNumber = stackFrame.GetFileLineNumber();
        var callerPath = stackFrame.GetFileName();

        var orgMessageId = messageId;
        messageId = _resolver.MessageId(targetType, messageType, messageId);
        var config = _resolver.Configuration(targetType, messageType);
        var context = _context.Create(targetType, messageType, messageId, config, callerMethod, lineNumber, callerPath);
        var provider = _provider.Create(targetType, messageType);

        _logger.LogInformation("Sending: \"{message}\" [{orgMessageId} -> {messageId}] to \"{targetType}\" from \"{caller}::{method}\"",
            message,
            orgMessageId,
            messageId,
            targetType,
            callerMethod?.DeclaringType,
            callerMethod
            );

        try
        {
            var correlationId = await provider.SendAsync(message, context);

            _logger.LogInformation("Sent: [{orgMessageId} -> {messageId}] => ({correlationId})",
                orgMessageId,
                messageId,
                correlationId
                );
            if (!string.IsNullOrWhiteSpace(correlationId))
                context.MessageId = correlationId;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: \"{message}\" [{orgMessageId} -> {messageId}]",
                ex.Message,
                orgMessageId,
                messageId
                );

            _logger.LogDebug("Exception: {trace}\r\n [{orgMessageId} -> {messageId}]",
                ex.ToString(),
                orgMessageId,
                messageId
                );

            throw;
        }
        return context.MessageId;
    }
}
