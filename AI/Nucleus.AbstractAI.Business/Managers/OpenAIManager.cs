using Nucleus.AbstractAI.Contracts.Managers;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure;
using Microsoft.Extensions.Configuration;
using System;

namespace Nucleus.AbstractAI.Business.Managers
{
    public class OpenAIManager : IOpenAIManager
    {
        private readonly IConfiguration _config;
        private readonly string OpenAiKey = "";

        public OpenAIManager(IConfiguration config)
        {
            _config = config;
            OpenAiKey = _config.GetValue<string>("OpenAI:apiKey");
        }

        public async Task<string> GetResponseAsync(string promptDetails, string userInput)
        {
            OpenAIClient api = new(OpenAiKey);

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

            try {
                response = await api.GetChatCompletionsAsync(chatCompletionsOptions);
                return response.Value.Choices[0].Message.Content;
            } 
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
