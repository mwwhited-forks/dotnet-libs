namespace Eliassen.Search;

public interface IMessageCompletion
{
    Task<string> GetCompletionAsync(string modelName, string prompt);
}