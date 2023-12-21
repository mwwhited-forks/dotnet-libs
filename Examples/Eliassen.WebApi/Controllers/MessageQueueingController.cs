using Eliassen.WebApi.Models;
using Eliassen.WebApi.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageQueueingController : ControllerBase
{
    private readonly IExampleMessageProvider _provider;

    public MessageQueueingController(
        IExampleMessageProvider provider
        )
    {
        _provider = provider;
    }

    [HttpPost("public")]
    [AllowAnonymous]
    public async Task<string> PublicSend([FromBody] ExampleMessageModel model, string? correlationId = default) =>
        await _provider.PostAsync(model, correlationId);

    [HttpPost("private")]
    [Authorize]
    public async Task<string> AuthenticatedSend([FromBody] ExampleMessageModel model, string? correlationId = default) =>
        await _provider.PostAsync(model, correlationId);
}
