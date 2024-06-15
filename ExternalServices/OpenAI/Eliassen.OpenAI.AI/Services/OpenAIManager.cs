using Azure;
using Azure.AI.OpenAI;
using Eliassen.AI;
using Eliassen.AI.Models;
using Microsoft.Extensions.Options;
using SharpToken;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.OpenAI.AI.Services;

/// <summary>
/// Provides methods for interacting with the OpenAI language model.
/// </summary>
public class OpenAIManager : ILanguageModelProvider
{
    private readonly IOptions<OpenAIClientOptions> _config;
    private const int MaxTokenLength = 2048;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAIManager"/> class.
    /// </summary>
    /// <param name="config">The OpenAI configuration options.</param>
    public OpenAIManager(IOptions<OpenAIClientOptions> config) => _config = config;

    /// <summary>
    /// Gets a response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="promptDetails">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the generated response.</returns>
    public async Task<string> GetResponseAsync(string promptDetails, 
        string userInput, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var response = await api.GetChatCompletionsAsync(new()
        {
            DeploymentName = _config.Value.Model,
            Messages =
                {
                    // The system message represents instructions or other guidance about how the assistant should behave
                    new ChatRequestSystemMessage(promptDetails),
                    // User messages represent current or historical input from the end user
                    new ChatRequestUserMessage(userInput)
                }
        }, cancellationToken);
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
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);

        await foreach (var chatUpdate in await api.GetChatCompletionsStreamingAsync(new()
        {
            DeploymentName = _config.Value.Model,
            Messages =
            {
                // The system message represents instructions or other guidance about how the assistant should behave
                new ChatRequestSystemMessage(promptDetails),
                // User messages represent current or historical input from the end user
                new ChatRequestUserMessage(userInput)
            }
        }, cancellationToken: cancellationToken))
        {
            if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
            {
                yield return chatUpdate.ContentUpdate;
            }

            if (cancellationToken.IsCancellationRequested) { yield break; }
        }
    }

    public async IAsyncEnumerable<string> GetStreamedContextResponseAsync(string assistantConfinment,
        List<string> systemInteractions,
        List<string> userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var request = new ChatCompletionsOptions
        {
            DeploymentName = _config.Value.Model
        };

        request.Messages.Add(new ChatRequestAssistantMessage(assistantConfinment));

        // Add system messages
        foreach (var detail in systemInteractions)
        {
            request.Messages.Add(new ChatRequestSystemMessage(detail));
        }

        // Add user messages
        foreach (var input in userInput)
        {
            request.Messages.Add(new ChatRequestUserMessage(input));
        }

        await foreach (var chatUpdate in await api.GetChatCompletionsStreamingAsync(request, cancellationToken))
        {
            if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
            {
                yield return chatUpdate.ContentUpdate;
            }

            if (cancellationToken.IsCancellationRequested) { yield break; }
        }
    }

    public async Task<float[]> GetEmbeddedResponseAsync(string data, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var encoding = GptEncoding.GetEncoding("cl100k_base");
        var count = encoding.CountTokens(data);

        if (count > MaxTokenLength)
        {
            throw new Exception($"Data Exceeded Token Limit of {MaxTokenLength} tokens");
        }

        OpenAIClient api = new(_config.Value.APIKey);
        
        EmbeddingsOptions embeddingsOptions = new()
        {
            DeploymentName = _config.Value.EmbeddingModel,
            Input = { data },
        };

        Response<Embeddings> response = await api.GetEmbeddingsAsync(embeddingsOptions, cancellationToken);
        EmbeddingItem item = response.Value.Data[0];

        return item.Embedding.ToArray();
    }

    public async Task<string> GetContextResponseAsync(string assistantConfinment,
        List<string> systemInteractions,
        List<string> userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var request = new ChatCompletionsOptions
        {
            DeploymentName = _config.Value.Model
        };

        request.Messages.Add(new ChatRequestAssistantMessage(assistantConfinment));

        // Add system messages
        foreach (var detail in systemInteractions)
        {
            request.Messages.Add(new ChatRequestSystemMessage(detail));
        }

        // Add user messages
        foreach (var input in userInput)
        {
            request.Messages.Add(new ChatRequestUserMessage(input));
        }

        var response = await api.GetChatCompletionsAsync(request, cancellationToken);

        return response.Value.Choices[0].Message.Content;
    }

    /// <summary>
    /// Gets a response asynchronously based on the provided prompt details and user input.
    /// </summary>
    /// <param name="assistantConfinment">The details of the prompt.</param>
    /// <param name="ragData">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the generated response.</returns>
    public async Task<string> GetRAGResponseAsync(string assistantConfinment,
        string ragData,
        string userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var response = await api.GetChatCompletionsAsync(new()
        {
            DeploymentName = _config.Value.Model,
            Messages =
                {
                    new ChatRequestAssistantMessage(assistantConfinment),
                    // The system message represents instructions or other guidance about how the assistant should behave
                    new ChatRequestSystemMessage($"With the content from a file thats passed in, you can only respond within its context. content: {ragData}"),
                    // User messages represent current or historical input from the end user
                    new ChatRequestUserMessage(userInput)
                }
        }, cancellationToken);
        return response.Value.Choices[0].Message.Content;
    }

    /// <summary>
    /// Gets a response asynchronously based on the ragData and userInput
    /// </summary>
    /// <param name="ragData">The details of the prompt.</param>
    /// <param name="userInput">The user input.</param>
    /// <param name="systemInteractions">The system input.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the generated response.</returns>
    public async IAsyncEnumerable<string> GetRAGResponseCitiationsAsync(List<KeyValuePairModel> ragData,
        List<string> systemInteractions,
        List<string> userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var request = new ChatCompletionsOptions
        {
            DeploymentName = _config.Value.Model
        };

        StringBuilder aiData = new();
        StringBuilder aiKey = new();

        foreach (var detail in ragData)
        {
            aiData.Append(detail.Value);
            aiKey.Append(detail.Key);
        }

        request.Messages.Add(new ChatRequestSystemMessage($"" +
            $"With the content from a file thats passed in, you can only respond within its context. content: {aiData.ToString()}, " +
            $"also when using the information provide citiations in your response " +
            $"using the ${aiKey.ToString()} for each unique piece of information in markdown so its cliclable"));

        // Add system messages
        foreach (var detail in systemInteractions)
        {
            request.Messages.Add(new ChatRequestSystemMessage(detail));
        }

        // Add user messages
        foreach (var input in userInput)
        {
            request.Messages.Add(new ChatRequestUserMessage(input));
        }

        await foreach (var chatUpdate in await api.GetChatCompletionsStreamingAsync(request, cancellationToken))
        {
            if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
            {
                yield return chatUpdate.ContentUpdate;
            }

            if (cancellationToken.IsCancellationRequested) { yield break; }
        }
    }
}
