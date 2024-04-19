namespace Eliassen.Search;

public interface IEmbeddingProvider
{
    int Length { get; }
    Task<float[]> GetEmbeddingAsync(string content);
}
