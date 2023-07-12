using System.Threading.Tasks;

namespace Nucleus.Core.Shared.Contracts.Managers
{
    public interface ISiteMapManager
    {
        Task<string> RenderSiteMap();
    }
}
