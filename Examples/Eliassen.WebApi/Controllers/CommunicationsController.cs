using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MessageQueueing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers;

/// <summary>
/// Controller for handling communication-related operations, such as sending emails and messages to a queue.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CommunicationsController : ControllerBase
{
    private readonly ICommunicationSender<EmailMessageModel> email;
    private readonly IMessageQueueSender<EmailMessageModel> queue;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommunicationsController"/> class.
    /// </summary>
    /// <param name="email">The email communication sender.</param>
    /// <param name="queue">The message queue sender.</param>
    public CommunicationsController(
        ICommunicationSender<EmailMessageModel> email,
        IMessageQueueSender<EmailMessageModel> queue)
    {
        this.email = email ?? throw new ArgumentNullException(nameof(email));
        this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
    }

    /// <summary>
    /// Sends an email publicly without requiring authentication.
    /// </summary>
    /// <param name="model">The email message model.</param>
    /// <returns>A task representing the asynchronous operation and containing a string result.</returns>
    [HttpPost("public")]
    [AllowAnonymous]
    public async Task<string> SendAnonymous([FromBody] EmailMessageModel model) =>
        await email.SendAsync(model);

    /// <summary>
    /// Enqueues an email message to be processed asynchronously.
    /// </summary>
    /// <param name="model">The email message model.</param>
    /// <returns>A task representing the asynchronous operation and containing a string result.</returns>
    [HttpPost("queued")]
    [AllowAnonymous]
    public async Task<string> Enqueue([FromBody] EmailMessageModel model) =>
        await queue.SendAsync(model, model.ReferenceId);

    /// <summary>
    /// Sends an email with authorization, requiring the caller to be authenticated.
    /// </summary>
    /// <param name="model">The email message model.</param>
    /// <returns>A task representing the asynchronous operation and containing a string result.</returns>
    [HttpPost("private")]
    [Authorize]
    public async Task<string> SendAuthorize([FromBody] EmailMessageModel model) =>
        await email.SendAsync(model);
}
