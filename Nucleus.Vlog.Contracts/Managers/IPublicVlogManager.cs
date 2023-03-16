using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Vlog.Contracts.Managers
{
    public interface IPublicVlogManager
    {
        Task<PagedResult<VlogModel>> GetVlogsPagedAsync(VlogsFilter vlogsFilter);
        Task<List<VlogModel>> GetVlogs();
        Task<VlogModel?> GetVlogSlug(string slug);
        Task<List<VlogModel>?> GetRecentVlogs(int i);
    }
}
