using Eliassen.AI;
using Eliassen.AI.Models;
using OllamaSharp;
using OllamaSharp.Models;
using OllamaSharp.Streamer;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Ollama;

/// <summary>
/// Represents a class responsible for generating message completions using the Ollama API.
/// </summary>
public class OllamaMessageCompletion : IMessageCompletion, ILanguageModelProvider, IEmbeddingProvider
{
    private readonly OllamaApiClient _client;
    private readonly IOllamaModelMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="OllamaMessageCompletion"/> class.
    /// </summary>
    /// <param name="client">The OllamaApiClient instance used for communication with the Ollama API.</param>
    /// <param name="mapper">Model mapper for Ollama request/response.</param>
    public OllamaMessageCompletion(
        OllamaApiClient client,
        IOllamaModelMapper mapper
        )
    {
        _client = client;
        _mapper = mapper;
    }

    private int? _length;
    /// <summary>
    /// Gets the length of the embeddings.
    /// </summary>
    public int Length => _length ??= GetEmbeddingAsync("hello world", null).Result.Length;

    /// <summary>
    /// Retrieves the embedding vector for the given content.
    /// </summary>
    /// <param name="content">The content for which to retrieve the embedding.</param>
    /// <param name="model">The model for which to retrieve the embedding.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the 
    /// embedding vector as an array of single-precision floats.</returns>
    public async Task<float[]> GetEmbeddingAsync(
        string content,
#if DEBUG
        string? model
#else
        string? model = default
#endif
        ) =>
        await _client.GetEmbeddingSingleAsync(content, model ?? _client.SelectedModel);

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
    /// Retrieves a completion for the given prompt from the specified model.
    /// </summary>
    /// <param name="model">Completion request model</param>
    /// <returns>Resulting response object</returns>
    public async Task<CompletionResponse> GetCompletionAsync(CompletionRequest model) =>
        _mapper.Map(await _client.GetCompletion(_mapper.Map(model)));

    /// <summary>
    /// Retrieves a response from the language model based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">Details of the prompt or context.</param>
    /// <param name="userInput">The user input or query.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response from the language model.</returns>
    public async Task<string> GetResponseAsync(string promptDetails, string userInput) =>
        //TODO:should probably build a custom model but this works for now
        (await _client.GetCompletion(new()
        {
            Model = _client.SelectedModel,
            Prompt = $"SYSTEM: {promptDetails}" + //TODO: do something smarter here
            $"" +
            $"USER: {userInput}",
        })).Response;

    /// <summary>
    /// Gets a streamed response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns>An asynchronous enumerable of strings representing the streamed response.</returns>
    public async IAsyncEnumerable<string> GetStreamedResponseAsync(string promptDetails, string userInput, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var queue = new ConcurrentQueue<string>();
        var completed = false;

        var streamer = new ActionResponseStreamer<GenerateCompletionResponseStream>(response =>
        {
            queue.Enqueue(response.Response);
            completed = response.Done;
        });
        var context = await _client.StreamCompletion(new()
        {
            Model = _client.SelectedModel,
            Prompt = $"SYSTEM: {promptDetails}" + //TODO: do something smarter here
            $"" +
            $"USER: {userInput}",
            Stream = true,
        }, streamer, cancellationToken: cancellationToken);

        while (!cancellationToken.IsCancellationRequested)
        {
            if (queue.TryDequeue(out var response) && response is not null)
                yield return response;

            if (queue.IsEmpty && completed)
                break;
        }
    }
}
