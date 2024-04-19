namespace Eliassen.AI;

public interface IEmbeddingProvider
{
    int Length { get; }
    Task<float[]> GetEmbeddingAsync(string content);
}
