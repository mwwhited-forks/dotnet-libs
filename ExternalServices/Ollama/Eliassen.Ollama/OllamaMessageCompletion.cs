using Eliassen.AI;
using OllamaSharp;
using System.Threading.Tasks;

namespace Eliassen.Ollama;

/// <summary>
/// Represents a class responsible for generating message completions using the Ollama API.
/// </summary>
public class OllamaMessageCompletion : IMessageCompletion, ILanguageModelProvider
{
    private readonly OllamaApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="OllamaMessageCompletion"/> class.
    /// </summary>
    /// <param name="client">The OllamaApiClient instance used for communication with the Ollama API.</param>
    public OllamaMessageCompletion(
        OllamaApiClient client
        ) => _client = client;

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

    /// <summary>
    /// Retrieves a response from the language model based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">Details of the prompt or context.</param>
    /// <param name="userInput">The user input or query.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response from the language model.</returns>
    public async Task<string> GetResponseAsync(string promptDetails, string userInput) => //TODO:should probably build a custom model but this works for now
        (await _client.GetCompletion(new()
        {
            Model = _client.SelectedModel,
            Prompt = $"SYSTEM: {promptDetails}" +
            $"" +
            $"USER: {userInput}",
        })).Response;
}
