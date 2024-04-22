using Eliassen.AI;
using Eliassen.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractAIController : ControllerBase
    {
        private readonly ILangageModelProvider _llmProvider;

        public AbstractAIController(ILangageModelProvider llmProvider)
        {
            _llmProvider = llmProvider;
        }

        /// <summary>
        /// Generate an AbstractAI Response based on the prompt and user input
        /// </summary>
        /// <returns>The string response from the AbstractAI</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> GetResponseAsync([FromBody] GenAiRequestModel model) =>
            await _llmProvider.GetResponseAsync(model.PromptDetails, model.UserInput);

        /// <summary>
        /// Generate an AbstractAI Response based on the prompt and user input
        /// </summary>
        /// <returns>The string response from the AbstractAI</returns>
        [HttpPost("Streamed")]
        [AllowAnonymous]
        public async Task<string> GetStreamedResponseAsync([FromBody] GenAiRequestModel model)
        {
            string result = await _llmProvider.GetStreamedResponseAsync(model.PromptDetails, model.UserInput);
            return result;
        }
    }
}
