using System.Threading.Tasks;

namespace Nucleus.AbstractAI.Contracts.Managers
{
    public interface IOpenAIManager
    {
        Task<string> GetResponseAsync(string promptDetails, string userInput);
    }
}
