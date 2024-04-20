using Eliassen.AI;
using OllamaSharp;
using System.Threading.Tasks;

namespace Eliassen.Ollama;

/// <summary>
/// Represents a class responsible for generating message completions using the Ollama API.
/// </summary>
public class MessageCompletion : IMessageCompletion
{
    private readonly OllamaApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageCompletion"/> class.
    /// </summary>
    /// <param name="client">The OllamaApiClient instance used for communication with the Ollama API.</param>
    public MessageCompletion(
        OllamaApiClient client
        )
    {
        _client = client;
    }

    /// <summary>
    /// Generates a completion for the given prompt using the specified model.
    /// </summary>
    /// <param name="modelName">The name of the model to use for completion.</param>
    /// <param name="prompt">The prompt for which completion is requested.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the completion response.</returns>
    public async Task<string> GetCompletionAsync(string modelName, string prompt) =>
        (await _client.GetCompletion(new()
        {
            Model = modelName,
            Prompt = prompt,
        })).Response;

}
