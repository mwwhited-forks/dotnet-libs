using Azure.AI.OpenAI;
using Eliassen.AI;
using Microsoft.Extensions.Options;

namespace Eliassen.OpenAI.AI.Services;

public class OpenAIManager(IOptions<OpenAIOptions> config) : ILanguageModelProvider
{
    private readonly IOptions<OpenAIOptions> _config = config;

    public async Task<string> GetResponseAsync(string promptDetails, string userInput)
    {
        OpenAIClient api = new(_config.Value.APIKey);

        ChatCompletionsOptions chatCompletionsOptions = new()
        {
            DeploymentName = _config.Value.DeploymentName,
            Messages =
            {
                // The system message represents instructions or other guidance about how the assistant should behave
                new ChatRequestSystemMessage(promptDetails),
                // User messages represent current or historical input from the end user
                new ChatRequestUserMessage(userInput)
            }
        };


        var response = await api.GetChatCompletionsAsync(chatCompletionsOptions);
        return response.Value.Choices[0].Message.Content;
    }
}
