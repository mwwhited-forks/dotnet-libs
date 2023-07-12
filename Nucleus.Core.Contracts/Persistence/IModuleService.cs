using Nucleus.Core.Contracts.Models;
using System.Linq;

namespace Nucleus.Core.Contracts.Persistence
{
    public interface IModuleService
    {
        IQueryable<Module> Query();
    }
}
