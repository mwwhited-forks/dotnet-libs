using Eliassen.AI;
using Eliassen.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eliassen.WebApi.Controllers;

/// <summary>
/// Controller for AI-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AIController : ControllerBase
{
    private readonly ILanguageModelProvider _llmProvider;
    private readonly IEmbeddingProvider _embedding;

    /// <summary>
    /// Initializes a new instance of the <see cref="AIController"/> class with the specified dependencies.
    /// </summary>
    /// <param name="llmProvider">The language model provider.</param>
    /// <param name="embedding">The embedding provider.</param>
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
    public async Task<string> GetResponseAsync([FromBody] GenerativeAiRequestModel model) =>
        await _llmProvider.GetResponseAsync(model.PromptDetails, model.UserInput);

    /// <summary>
    /// Retrieves the embedding vector for the given text.
    /// </summary>
    /// <param name="text">The text for which to retrieve the embedding vector.</param>
    /// <returns>The embedding vector.</returns>
    [HttpGet]
    public async Task<float[]> Embed(string text) => await _embedding.GetEmbeddingAsync(text);
}
