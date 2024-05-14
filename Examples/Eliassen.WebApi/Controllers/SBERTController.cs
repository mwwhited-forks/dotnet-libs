using Eliassen.AI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Eliassen.WebApi.Controllers;

/// <summary>
/// Controller for AI-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SBERTController : ControllerBase
{
    private readonly IEmbeddingProvider _embedding;

    /// <summary>
    /// Initializes a new instance of the <see cref="AIController"/> class with the specified dependencies.
    /// </summary>
    /// <param name="embedding">The embedding provider.</param>
    public SBERTController(
        [FromKeyedServices("SBERT")] IEmbeddingProvider embedding
        ) => _embedding = embedding;

    /// <summary>
    /// Retrieves the embedding vector for the given text.
    /// </summary>
    /// <param name="text">The text for which to retrieve the embedding vector.</param>
    /// <returns>The embedding vector.</returns>
    [HttpGet]
    public async Task<float[]> Embed(string text) =>
        await _embedding.GetEmbeddingAsync(text, default);
}
