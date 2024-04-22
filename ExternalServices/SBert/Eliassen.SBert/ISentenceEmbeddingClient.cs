using System.Threading.Tasks;

namespace Eliassen.SBert;

/// <summary>
/// Represents a client for generating sentence embeddings.
/// </summary>
public interface ISentenceEmbeddingClient
{
    /// <summary>
    /// Asynchronously generates a sentence embedding as an array of single-precision floating-point numbers.
    /// </summary>
    /// <param name="input">The input sentence to generate the embedding for.</param>
    /// <returns>An array of single-precision floating-point numbers representing the embedding of the input sentence.</returns>
    Task<float[]> GetEmbeddingAsync(string input);

    /// <summary>
    /// Asynchronously generates a sentence embedding as an array of double-precision floating-point numbers.
    /// </summary>
    /// <param name="input">The input sentence to generate the embedding for.</param>
    /// <returns>An array of double-precision floating-point numbers representing the embedding of the input sentence.</returns>
    Task<double[]> GetEmbeddingDoubleAsync(string input);
}
