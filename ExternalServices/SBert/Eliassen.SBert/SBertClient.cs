using System.Net.Http;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.Extensions.Options;

namespace Eliassen.SBert;

/// <summary>
/// Client for interacting with SBert.
/// </summary>
public class SBertClient
{
    private readonly IOptions<SBertOptions> _options;
    private readonly HttpClient _httpClient; //TODO: this should be done differently

    /// <summary>
    /// Initializes a new instance of the <see cref="SBertClient"/> class.
    /// </summary>
    /// <param name="options">The SBert options.</param>
    public SBertClient(IOptions<SBertOptions> options)
    {
        _options = options;
        _httpClient = new() { BaseAddress = new Uri(_options.Value.Url) };
    }

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
        var array = (JsonArray)node["embedding"];
        var floats = array.Select(i => (float)i).ToArray();
        return floats;
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
        var array = (JsonArray)node["embedding"];
        var floats = array.Select(i => (double)i).ToArray();
        return floats;
    }

}
