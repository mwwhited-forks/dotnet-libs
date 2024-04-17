#if DEBUG

using Eliassen.AI;
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
        public async Task<string> GetResponseAsync(string promptDetails, string userInput) =>
            await _llmProvider.GetResponseAsync(promptDetails, userInput);
    }
}

#endif
