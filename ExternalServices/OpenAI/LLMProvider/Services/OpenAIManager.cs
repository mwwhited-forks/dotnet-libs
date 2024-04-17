using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using LLMProvider.Services;
using Eliassen.AI;

namespace Eliassen.OpenAI.AI.Services
{
    public class OpenAIManager(IOptions<OpenAIOptions> config) : ILangageModelProvider
    {
        public async Task<string> GetResponseAsync(string promptDetails, string userInput)
        {
            OpenAIClient api = new(config.Value.APIKey);

            ChatCompletionsOptions chatCompletionsOptions = new()
            {
                DeploymentName = config.Value.DeploymentName,
                Messages =
                {
                    // The system message represents instructions or other guidance about how the assistant should behave
                    new ChatRequestSystemMessage(promptDetails),
                    // User messages represent current or historical input from the end user
                    new ChatRequestUserMessage(userInput)
                }
            };

            Response<ChatCompletions> response;

            try
            {
                response = await api.GetChatCompletionsAsync(chatCompletionsOptions);
                return response.Value.Choices[0].Message.Content;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
