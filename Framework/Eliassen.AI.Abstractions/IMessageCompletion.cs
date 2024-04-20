﻿namespace Eliassen.AI;

/// <summary>
/// Represents a provider for message completion.
/// </summary>
public interface IMessageCompletion
{
    /// <summary>
    /// Retrieves a completion for the given prompt from the specified model.
    /// </summary>
    /// <param name="modelName">The name of the model used for completion.</param>
    /// <param name="prompt">The prompt for which to retrieve the completion.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the completion for the prompt.</returns>
    Task<string> GetCompletionAsync(string modelName, string prompt);
}
