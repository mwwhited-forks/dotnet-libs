using Azure;
using Azure.AI.OpenAI;
using Eliassen.AI;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Eliassen.OpenAI.AI.Services
{
    public class OpenAIManager(IOptions<OpenAIOptions> config) : ILangageModelProvider
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

        public async Task<Stream> GetStreamedResponseAsync(string promptDetails, string userInput)
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

            StreamingResponse<StreamingChatCompletionsUpdate> response = await api.GetChatCompletionsStreamingAsync(chatCompletionsOptions);

            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    _ = chatUpdate.ContentUpdate;
                }
            }
        }

        //public async Task<string> GetStreamedResponseAsync(string promptDetails, string userInput)
        //{
        //    OpenAIClient api = new(_config.Value.APIKey);

        //    ChatCompletionsOptions chatCompletionsOptions = new()
        //    {
        //        DeploymentName = _config.Value.DeploymentName,
        //        Messages =
        //            {
        //                // The system message represents instructions or other guidance about how the assistant should behave
        //                new ChatRequestSystemMessage(promptDetails),
        //                // User messages represent current or historical input from the end user
        //                // new ChatRequestUserMessage(userInput)
        //            }
        //    };


        //    using (MemoryStream outputStream = new MemoryStream())
        //    {

        //        StreamingResponse<StreamingChatCompletionsUpdate> response = await api.GetChatCompletionsStreamingAsync(chatCompletionsOptions);

        //        using (StreamWriter writer = new StreamWriter(outputStream, leaveOpen: true))
        //        {
        //            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
        //            {
        //                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
        //                {
        //                    await writer.WriteLineAsync(chatUpdate.ContentUpdate);
        //                    await writer.FlushAsync(); 
        //                }
        //            }
        //        }

        //        // Reset the memory stream position to the beginning before reading it
        //        outputStream.Position = 0;

        //        using (StreamReader reader = new StreamReader(outputStream, Encoding.UTF8))
        //        {
        //            // Read the streamed values asynchronously
        //            return await reader.ReadToEndAsync();
        //        }
        //    }
        //}
    }
}
