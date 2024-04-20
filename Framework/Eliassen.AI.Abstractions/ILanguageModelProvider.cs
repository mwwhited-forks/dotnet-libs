namespace Eliassen.AI;

/// <summary>
/// Represents a provider for a language model.
/// </summary>
public interface ILanguageModelProvider
{
    /// <summary>
    /// Retrieves a response from the language model based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">Details of the prompt or context.</param>
    /// <param name="userInput">The user input or query.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response from the language model.</returns>
    Task<string> GetResponseAsync(string promptDetails, string userInput);
}
