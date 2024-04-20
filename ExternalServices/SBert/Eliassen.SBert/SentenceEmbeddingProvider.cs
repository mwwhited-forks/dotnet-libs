using System.Threading.Tasks;
using System;
using Eliassen.AI;

namespace Eliassen.SBert;

/// <summary>
/// Provides sentence embeddings using SBert.
/// </summary>
public class SentenceEmbeddingProvider : IEmbeddingProvider
{
    private readonly SBertClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="SentenceEmbeddingProvider"/> class.
    /// </summary>
    /// <param name="client">The SBertClient instance for obtaining embeddings.</param>
    public SentenceEmbeddingProvider(
        SBertClient client
    )
    {
        _client = client;
        Console.WriteLine($"connect to embeddings");
    }

    private int? _length;
    /// <summary>
    /// Gets the length of the embeddings.
    /// </summary>
    public int Length => _length ??= GetEmbeddingAsync("hello world").Result.Length;

    /// <summary>
    /// Gets the embedding for the given content asynchronously.
    /// </summary>
    /// <param name="content">The content for which to obtain the embedding.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the embedding as an array of floats.</returns>
    public Task<float[]> GetEmbeddingAsync(string content) => _client.GetEmbeddingAsync(content);
}
