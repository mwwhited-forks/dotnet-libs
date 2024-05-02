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
#pragma warning disable CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable
        [EnumeratorCancellation] CancellationToken cancellationToken = default);
#pragma warning restore CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable
}
