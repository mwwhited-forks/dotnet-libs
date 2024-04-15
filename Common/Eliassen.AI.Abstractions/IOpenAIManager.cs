namespace Eliassen.AI.Abstractions
{    
    public interface IOpenAIManager
    {
        Task<string> GetResponseAsync(string promptDetails, string userInput, string openAiKey);
    }
}
