using Eliassen.AI;
using OllamaSharp;
using OllamaSharp.Models;
using OllamaSharp.Streamer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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
        //TODO: not sure this works
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
        }, streamer);


        while (!cancellationToken.IsCancellationRequested && !completed)
        {
            if (queue.TryDequeue(out var response) && response is not null)
                yield return response;
        }
    }

    public async Task<string> GetContextResponseAsync(string assistantConfinment, List<string> systemInteractions, List<string> userInput)
    {
        return "";
    }

    public async Task<ReadOnlyMemory<float>> GetEmbeddedResponseAsync(string data)
    {
        float value = float.Parse("-0.1");
        ReadOnlyMemory<float> result = new float[] { value }.AsMemory();
        return result;
    }
}
