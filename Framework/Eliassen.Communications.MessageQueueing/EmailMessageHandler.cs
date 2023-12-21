using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eliassen.Communications.MessageQueueing
{
    public class EmailMessageHandler : IMessageQueueHandler<EmailMessageModel, EmailMessageModel>
    {
        private readonly IMessageSender<EmailMessageModel> _email;
        private readonly ILogger _logger;

        public EmailMessageHandler(
            IMessageSender<EmailMessageModel> email,
            ILogger<EmailMessageHandler> logger
            )
        {
            _email = email;
            _logger = logger;   
        }

        public Task HandleAsync(EmailMessageModel message, IMessageContext context)
        {
            message.ReferenceId ??= context.CorrelationId;
            _logger.LogInformation("Sending {subject} for {from} [{id}]", message.Subject, message.FromAddress, message.ReferenceId);
            return _email.SendAsync(message);
        }

        public Task HandleAsync(object message, IMessageContext context)
        {
            if (message is EmailMessageModel messageModel)
            {
                return HandleAsync(messageModel, context);
            }
            return Task.CompletedTask;
        }

    }
}
