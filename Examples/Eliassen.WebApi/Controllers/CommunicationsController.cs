using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MessageQueueing;
using Eliassen.WebApi.Models;
using Eliassen.WebApi.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunicationsController : ControllerBase
{
    private readonly IMessageSender<EmailMessageModel> _email;

    public CommunicationsController(
        IMessageSender<EmailMessageModel> email
        )
    {
        _email = email;
    }

    [HttpPost("public")]
    [AllowAnonymous]
    public async Task<string> TestMessage([FromBody] EmailMessageModel model) =>
        await _email.SendAsync(model);

    [HttpPost("private")]
    [Authorize]
    public async Task<string> TestAuthMessage([FromBody] EmailMessageModel model) =>
        await _email.SendAsync(model);
}