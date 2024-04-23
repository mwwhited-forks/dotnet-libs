using Newtonsoft.Json.Linq;

namespace Eliassen.AI;

/// <summary>
/// Represents a provider for interacting with a language model.
/// </summary>
public interface ILangageModelProvider
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
    /// <returns>An asynchronous enumerable of strings representing the streamed response.</returns>
    IAsyncEnumerable<string> GetStreamedResponseAsync(string promptDetails, string userInput);
}
