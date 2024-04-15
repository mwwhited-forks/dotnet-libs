using Azure;
using Azure.AI.OpenAI;
using Eliassen.AI.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Eliassen.LLMProvider
{
    public class OpenAIManager : IOpenAIManager
    {
        public OpenAIManager()
        {

        }

        public async Task<string> GetResponseAsync(string promptDetails, string userInput, string openAiKey)
        {
            OpenAIClient api = new(openAiKey);

            ChatCompletionsOptions chatCompletionsOptions = new()
            {
                DeploymentName = "gpt-3.5-turbo",
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
                return ex.Message;
            }
        }
    }
}
