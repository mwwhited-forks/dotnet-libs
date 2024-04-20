using Eliassen.AI;
using Eliassen.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliassen.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AIController : ControllerBase
{
    private readonly ILanguageModelProvider _llmProvider;
    private readonly IEmbeddingProvider _embedding;

    public AIController(
        ILanguageModelProvider llmProvider,
        IEmbeddingProvider embedding
        )
    {
        _llmProvider = llmProvider;
        _embedding = embedding;
    }

    /// <summary>
    /// Generate an LLM Response based on the prompt and user input
    /// </summary>
    /// <returns>The string response from the LLM</returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<string> GetResponseAsync([FromBody] GenAiRequestModel model) =>
        await _llmProvider.GetResponseAsync(model.PromptDetails, model.UserInput);


    [HttpGet]
    public async Task<float[]> Embed(string text) => await _embedding.GetEmbeddingAsync(text);
}
