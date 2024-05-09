using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Eliassen.SBert;

/// <summary>
/// Client for interacting with SBert.
/// </summary>
public class SentenceEmbeddingClient : ISentenceEmbeddingClient
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="SentenceEmbeddingClient"/> class.
    /// </summary>
    /// <param name="httpClient">The HttpClient.</param>
    public SentenceEmbeddingClient(
        HttpClient httpClient
        ) => _httpClient = httpClient;

    /// <summary>
    /// Retrieves the embedding vector for the given input as an array of single-precision floats.
    /// </summary>
    /// <param name="input">The input text.</param>
    /// <returns>An array of single-precision floats representing the embedding.</returns>
    public async Task<float[]> GetEmbeddingAsync(string input)
    {
        var results = await _httpClient.GetAsync($"/generate-embedding?query={input}");
        var json = await results.Content.ReadAsStringAsync();
        var node = JsonSerializer.Deserialize<JsonNode>(json);
        var array = (JsonArray?)node?["embedding"];
        var floats = array?.OfType<JsonNode>().Select(i => (float)i).ToArray();
        return floats ?? [];
    }

    /// <summary>
    /// Retrieves the embedding vector for the given input as an array of double-precision floats.
    /// </summary>
    /// <param name="input">The input text.</param>
    /// <returns>An array of double-precision floats representing the embedding.</returns>
    public async Task<double[]> GetEmbeddingDoubleAsync(string input)
    {
        var results = await _httpClient.GetAsync($"/generate-embedding?query={input}");
        var json = await results.Content.ReadAsStringAsync();
        var node = JsonSerializer.Deserialize<JsonNode>(json);
        var array = (JsonArray?)node?["embedding"];
        var floats = array?.OfType<JsonNode>().Select(i => (double)i).ToArray();
        return floats ?? [];
    }
}
