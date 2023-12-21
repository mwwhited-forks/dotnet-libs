using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;

namespace Eliassen.WebApi.Provider
{
    public interface IExampleMessageProvider
    {
        Task<string> PostAsync(object message, string? correlationId);
    }
    public class ExampleMessageProvider : IExampleMessageProvider, IMessageQueueHandler<ExampleMessageProvider>
    {
        private readonly IMessageQueueSender _sender;
        private readonly ILogger _logger;

        public ExampleMessageProvider(
            IMessageQueueSender<ExampleMessageProvider> sender,
            ILogger<ExampleMessageProvider> logger
            )
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task<string> PostAsync(object message, string? correlationId)
        {
            _logger.LogInformation("Send: {message} [{correlationId}]", message, correlationId);
            var messageId = await _sender.SendAsync(message, correlationId);
            _logger.LogInformation("Sent: {message} [{correlationId}]-[{messageId}]", message, correlationId, messageId);
            return messageId;
        }

        public Task HandleAsync(object message, IMessageContext context)
        {
            _logger.LogInformation("Received: {message} [{correlationId}]", message, context.CorrelationId);
            return Task.CompletedTask;
        }
    }
}
