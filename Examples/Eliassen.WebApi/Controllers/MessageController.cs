using Eliassen.WebApi.Models;
using Eliassen.WebApi.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IExampleMessageProvider _provider;

        public MessageController(
            IExampleMessageProvider provider
            )
        {
            _provider = provider;
        }

        [HttpPost("public")]
        public async Task<string> TestMessage([FromBody] ExampleMessageModel model, string? correlationId = default) =>
            await _provider.PostAsync(model, correlationId);

        [HttpPost("private")]
        [Authorize]
        public async Task<string> TestAuthMessage([FromBody] ExampleMessageModel model, string? correlationId = default) =>
            await _provider.PostAsync(model, correlationId);
    }
}
