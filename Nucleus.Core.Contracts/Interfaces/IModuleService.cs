using Nucleus.Core.Contracts.Models;
using System.Linq;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IModuleService
    {
        IQueryable<Module> Query();
    }
}
