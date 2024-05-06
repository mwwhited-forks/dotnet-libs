using Azure;
using Azure.AI.OpenAI;
using Eliassen.AI;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using SharpToken;

namespace Eliassen.OpenAI.AI.Services;

public class OpenAIManager(IOptions<OpenAIOptions> config) : ILanguageModelProvider
{
    private readonly IOptions<OpenAIOptions> _config = config;
    private const int MaxTokenLength = 2048;

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

    public async IAsyncEnumerable<string> GetStreamedContextResponseAsync(string assistantConfinment,
        List<string> systemInteractions, 
        List<string> userInput, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        OpenAIClient api = new(_config.Value.APIKey);
        var request = new ChatCompletionsOptions
        {
            DeploymentName = _config.Value.DeploymentName
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

        await foreach (var chatUpdate in await api.GetChatCompletionsStreamingAsync(request))
        {
            if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
            {
                yield return chatUpdate.ContentUpdate;
            }

            if (cancellationToken.IsCancellationRequested) { yield break; }
        }
    }

    public async Task<ReadOnlyMemory<float>> GetEmbeddedResponseAsync(string data)
    {
        var encoding = GptEncoding.GetEncoding("cl100k_base");
        var count = encoding.CountTokens(data);

        if(count > MaxTokenLength)
        {
            throw new Exception($"Data Exceeded Token Limit of {MaxTokenLength} tokens");
        }

        OpenAIClient api = new(_config.Value.APIKey);

        EmbeddingsOptions embeddingsOptions = new()
        {
            DeploymentName = _config.Value.EmbeddingModel,
            Input = { data },
        };

        Response<Embeddings> response = await api.GetEmbeddingsAsync(embeddingsOptions);

        EmbeddingItem item = response.Value.Data[0];
        return item.Embedding;
    }
}
