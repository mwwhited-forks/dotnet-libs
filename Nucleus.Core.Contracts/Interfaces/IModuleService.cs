using Nucleus.Core.Persistence.Models;
using System.Linq;

namespace Nucleus.Core.Persistence.Interfaces
{
    public interface IModuleService
    {
        IQueryable<Module> Query();
    }
}
