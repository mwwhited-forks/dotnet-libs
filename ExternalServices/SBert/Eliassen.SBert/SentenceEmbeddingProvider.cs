using System.Threading.Tasks;
using System;
using Eliassen.AI;

namespace Eliassen.SBert;

public class SentenceEmbeddingProvider : IEmbeddingProvider
{
    private readonly SBertClient _client;

    public SentenceEmbeddingProvider(
        SBertClient client
    )
    {
        _client = client;
        Console.WriteLine($"connect to embeddings");
    }

    private int? _length;
    public int Length => _length ??= GetEmbeddingAsync("hello world").Result.Length;

    public Task<float[]> GetEmbeddingAsync(string content) => _client.GetEmbeddingAsync(content);
}
