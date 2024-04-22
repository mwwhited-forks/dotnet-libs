using System.Threading.Tasks;

namespace Eliassen.SBert;
public interface ISentenceEmbeddingClient
{
    Task<float[]> GetEmbeddingAsync(string input);
    Task<double[]> GetEmbeddingDoubleAsync(string input);
}