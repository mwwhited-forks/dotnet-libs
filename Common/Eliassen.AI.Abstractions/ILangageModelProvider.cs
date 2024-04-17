namespace Eliassen.AI
{    
    public interface ILangageModelProvider
    {
        Task<string> GetResponseAsync(string promptDetails, string userInput);
    }
}
