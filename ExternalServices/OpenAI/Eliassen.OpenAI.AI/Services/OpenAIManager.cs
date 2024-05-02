using Azure.AI.OpenAI;
using Eliassen.AI;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.OpenAI.AI.Services;

/// <summary>
/// Provides methods for interacting with the OpenAI language model.
/// </summary>
public class OpenAIManager : ILanguageModelProvider
{
    private readonly IOptions<OpenAIOptions> _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAIManager"/> class.
    /// </summary>
    /// <param name="config">The OpenAI configuration options.</param>
    public OpenAIManager(IOptions<OpenAIOptions> config)
    {
        _config = config;
    }

    /// <summary>
    /// Gets a response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the generated response.</returns>
    public async Task<string> GetResponseAsync(string promptDetails, string userInput)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var response = await api.GetChatCompletionsAsync(new()
        {
            DeploymentName = _config.Value.DeploymentName,
            Messages =
                {
                    // The system message represents instructions or other guidance about how the assistant should behave
                    new ChatRequestSystemMessage(promptDetails),
                    // User messages represent current or historical input from the end user
                    new ChatRequestUserMessage(userInput)
                }
        });
        return response.Value.Choices[0].Message.Content;
    }

    /// <summary>
    /// Gets a streamed response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An asynchronous enumerable of response messages.</returns>
    public async IAsyncEnumerable<string> GetStreamedResponseAsync(
        string promptDetails,
        string userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
        )
    {
        OpenAIClient api = new(_config.Value.APIKey);

        await foreach (var chatUpdate in await api.GetChatCompletionsStreamingAsync(new()
        {
            DeploymentName = _config.Value.DeploymentName,
            Messages =
            {
                // The system message represents instructions or other guidance about how the assistant should behave
                new ChatRequestSystemMessage(promptDetails),
                // User messages represent current or historical input from the end user
                new ChatRequestUserMessage(userInput)
            }
        }))
        {
            if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
            {
                yield return chatUpdate.ContentUpdate;
            }

            if (cancellationToken.IsCancellationRequested) { yield break; }
        }
    }
}
