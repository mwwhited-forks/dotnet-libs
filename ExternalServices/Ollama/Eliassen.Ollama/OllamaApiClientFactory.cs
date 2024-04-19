using OllamaSharp;

namespace Eliassen.Ollama;

public class OllamaApiClientFactory : IOllamaApiClientFactory
{
    public OllamaApiClient Build(string host) => new($"http://{host}:11434");
}
