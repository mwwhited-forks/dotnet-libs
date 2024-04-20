using OllamaSharp;

namespace Eliassen.Ollama;

/// <summary>
/// Factory class for creating instances of the <see cref="OllamaApiClient"/>.
/// </summary>
public class OllamaApiClientFactory : IOllamaApiClientFactory
{
    /// <summary>
    /// Builds a new instance of the <see cref="OllamaApiClient"/> with the specified host.
    /// </summary>
    /// <param name="host">The host address where the Ollama API is hosted.</param>
    /// <returns>A new instance of the <see cref="OllamaApiClient"/>.</returns>
    public OllamaApiClient Build(string host) => new($"http://{host}:11434");
}
