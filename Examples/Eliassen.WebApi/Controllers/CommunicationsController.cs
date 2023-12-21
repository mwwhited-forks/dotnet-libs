using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MessageQueueing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunicationsController : ControllerBase
{
    private readonly IMessageSender<EmailMessageModel> _email;
    private readonly IMessageQueueSender<EmailMessageModel> _queue;

    public CommunicationsController(
        IMessageSender<EmailMessageModel> email,
        IMessageQueueSender<EmailMessageModel> queue
        )
    {
        _email = email;
        _queue = queue;
    }

    [HttpPost("public")]
    [AllowAnonymous]
    public async Task<string> SendAnonymous([FromBody] EmailMessageModel model) =>
        await _email.SendAsync(model);

    [HttpPost("queued")]
    [AllowAnonymous]
    public async Task<string> Enqueue([FromBody] EmailMessageModel model) =>
        await _queue.SendAsync(model, model.ReferenceId);

    [HttpPost("private")]
    [Authorize]
    public async Task<string> SendAuthorize([FromBody] EmailMessageModel model) =>
        await _email.SendAsync(model);
}