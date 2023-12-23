using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;

namespace Eliassen.WebApi.Provider;

/// <summary>
/// Implementation of <see cref="IExampleMessageProvider"/> and <see cref="IMessageQueueHandler{TMessage}"/>
/// for handling and sending example messages.
/// </summary>
public class ExampleMessageProvider : IExampleMessageProvider, IMessageQueueHandler<ExampleMessageProvider>
{
    private readonly IMessageQueueSender<ExampleMessageProvider> _sender;
    private readonly ILogger<ExampleMessageProvider> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleMessageProvider"/> class.
    /// </summary>
    /// <param name="sender">The message queue sender for sending messages.</param>
    /// <param name="logger">The logger for logging messages.</param>
    public ExampleMessageProvider(
        IMessageQueueSender<ExampleMessageProvider> sender,
        ILogger<ExampleMessageProvider> logger)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public async Task<string> PostAsync(object message, string? correlationId)
    {
        _logger.LogInformation("Send: {message} [{correlationId}]", message, correlationId);
        var messageId = await _sender.SendAsync(message, correlationId);
        _logger.LogInformation("Sent: {message} [{correlationId}]-[{messageId}]", message, correlationId, messageId);
        return messageId;
    }

    /// <inheritdoc/>
    public Task HandleAsync(object message, IMessageContext context)
    {
        _logger.LogInformation("Received: {message} [{correlationId}]", message, context.CorrelationId);
        return Task.CompletedTask;
    }
}
