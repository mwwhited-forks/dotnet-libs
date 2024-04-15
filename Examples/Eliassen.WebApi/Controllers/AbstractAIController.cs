#if DEBUG

using Eliassen.AI.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractAIController : ControllerBase
    {
        private readonly IOpenAIManager _openAIManager;

        public AbstractAIController(IOpenAIManager openAIManager)
        {
            _openAIManager = openAIManager;
        }

        /// <summary>
        /// Generate an AbstractAI Response based on the prompt and user input
        /// </summary>
        /// <returns>The string response from the AbstractAI</returns>
        [HttpPost]
        public async Task<string> GetResponseAsync(string promptDetails, string userInput, string openAiKey) =>
            await _openAIManager.GetResponseAsync(promptDetails, userInput, openAiKey);
    }
}

#endif
