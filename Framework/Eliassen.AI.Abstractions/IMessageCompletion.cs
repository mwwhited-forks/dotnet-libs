namespace Eliassen.AI;

public interface IMessageCompletion
{
    Task<string> GetCompletionAsync(string modelName, string prompt);
}
