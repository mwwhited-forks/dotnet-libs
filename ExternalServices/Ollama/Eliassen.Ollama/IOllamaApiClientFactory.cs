using OllamaSharp;

namespace Eliassen.Ollama;

public interface IOllamaApiClientFactory
{
    OllamaApiClient Build(string host);
}
