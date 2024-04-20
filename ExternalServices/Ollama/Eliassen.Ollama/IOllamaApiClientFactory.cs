using OllamaSharp;

namespace Eliassen.Ollama;

/// <summary>
/// Represents a factory for creating instances of the OllamaApiClient.
/// </summary>
public interface IOllamaApiClientFactory
{
    /// <summary>
    /// Builds an instance of the OllamaApiClient for the specified host.
    /// </summary>
    /// <param name="host">The host address where the Ollama API is hosted.</param>
    /// <returns>An instance of the OllamaApiClient.</returns>
    OllamaApiClient Build(string host);
}
