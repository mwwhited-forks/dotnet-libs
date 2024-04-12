﻿#if DEBUG

using Microsoft.AspNetCore.Mvc;
using Nucleus.AbstractAI.Contracts.Managers;

namespace Nucleus.AbstractAI.Controllers
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
        public async Task<string> GetResponseAsync(string promptDetails, string userInput) => 
            await _openAIManager.GetResponseAsync(promptDetails, userInput);
    }
}

#endif
