using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.AI;

/// <summary>
/// Represents a provider for a language model.
/// </summary>
public interface ILanguageModelProvider
{
    /// <summary>
    /// Gets a response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <returns>A task representing the asynchronous operation that returns the response.</returns>
    Task<string> GetResponseAsync(string promptDetails, string userInput);

    /// <summary>
    /// Gets a streamed response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns>An asynchronous enumerable of strings representing the streamed response.</returns>
    IAsyncEnumerable<string> GetStreamedResponseAsync(
        string promptDetails,
        string userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="assistantConfinment">The confinment of the AI Assistant</param>
    /// <param name="systemInteractions">The previous generated responses by the AI</param>
    /// <param name="userInput">The user input including any previous messages in the chat</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns>A task representing the asynchronous operation that returns the response.</returns>
    IAsyncEnumerable<string> GetStreamedContextResponseAsync(string assistantConfinment, 
        List<string> systemInteractions, 
        List<string> userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the embeddded response for the data provided.
    /// </summary>
    /// <param name="data">The data to be embedded there is a token limit of 2048 tokens.</param>
    /// <returns>Float array with the embedding data</returns>
    Task<ReadOnlyMemory<float>> GetEmbeddedResponseAsync(string data);
}
