namespace Eliassen.AI;

public interface ILangageModelProvider
{
    Task<string> GetResponseAsync(string promptDetails, string userInput);
    Task<string> GetStreamedResponseAsync(string promptDetails, string userInput);
}
