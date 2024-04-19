using Eliassen.AI;
using OllamaSharp;
using System.Threading.Tasks;

namespace Eliassen.Ollama;

public class MessageCompletion : IMessageCompletion
{
    private readonly OllamaApiClient _client;

    public MessageCompletion(
        OllamaApiClient client
        )
    {
        _client = client;
    }

    public async Task<string> GetCompletionAsync(string modelName, string prompt) =>
        (await _client.GetCompletion(new()
        {
            Model = modelName,
            Prompt = prompt,
        })).Response;

}
