using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eliassen.Communications.MessageQueueing;
/// <summary>
/// Represents a message handler for handling and sending email messages.
/// </summary>
public class EmailMessageHandler : IMessageQueueHandler<EmailMessageModel, EmailMessageModel>
{
    private readonly ICommunicationSender<EmailMessageModel> _email;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailMessageHandler"/> class.
    /// </summary>
    /// <param name="email">The communication sender for email messages.</param>
    /// <param name="logger">The logger.</param>
    public EmailMessageHandler(
        ICommunicationSender<EmailMessageModel> email,
        ILogger<EmailMessageHandler> logger
    )
    {
        _email = email;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified email message asynchronously.
    /// </summary>
    /// <param name="message">The email message to handle.</param>
    /// <param name="context">The message context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task HandleAsync(EmailMessageModel message, IMessageContext context)
    {
        message.ReferenceId ??= context.CorrelationId;
        _logger.LogInformation("Sending {subject} for {from} [{id}]", message.Subject, message.FromAddress, message.ReferenceId);
        return _email.SendAsync(message);
    }

    /// <summary>
    /// Handles the specified message asynchronously.
    /// </summary>
    /// <param name="message">The message to handle.</param>
    /// <param name="context">The message context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task HandleAsync(object message, IMessageContext context)
    {
        if (message is EmailMessageModel messageModel)
        {
            return HandleAsync(messageModel, context);
        }
        return Task.CompletedTask;
    }
}