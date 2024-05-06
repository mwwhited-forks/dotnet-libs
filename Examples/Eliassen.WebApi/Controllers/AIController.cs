using Eliassen.AI;
using Eliassen.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    /// Generate an AbstractAI Streamed Response based on the prompt and user input
    /// </summary>
    /// <returns>The streamed string responses from the AbstractAI</returns>
    [HttpPost("Streamed")]
    [AllowAnonymous]
    public async IAsyncEnumerable<string> GetStreamedResponseAsync([FromBody] GenerativeAiRequestModel model)
    {
        await foreach (var response in _llmProvider.GetStreamedResponseAsync(model.PromptDetails, model.UserInput))
        {
            yield return response;
        };
    }

    /// <summary>
    /// Retrieves the embedding vector for the given text.
    /// </summary>
    /// <param name="text">The text for which to retrieve the embedding vector.</param>
    /// <returns>The embedding vector.</returns>
    [HttpGet]
    public async Task<float[]> Embed(string text) => await _embedding.GetEmbeddingAsync(text);

    /// <summary>
    /// Generate an LLM Response based on the prompt and user input
    /// </summary>
    /// <returns>The string response from the LLM</returns>
    [HttpPost("Context")]
    [AllowAnonymous]
    public async IAsyncEnumerable<string> GetContextResponseAsync([FromBody] GenAiContextRequestModel model)
    {
        await foreach (var response in _llmProvider.GetContextResponseAsync(model.AssistantConfinment, model.PromptDetails, model.UserInput))
        {
            yield return response;
        };
    }

    /// <summary>
    /// Generate embeddings
    /// </summary>
    /// <returns>The float response from the LLM</returns>
    [HttpPost("Embeddings")]
    [AllowAnonymous]
    public async Task<ReadOnlyMemory<float>> GenerateEmbeddingsAsync([FromBody] GenerativeAiRequestModel model) =>
        await _llmProvider.GetEmbeddedResponseAsync(model.UserInput);
}
