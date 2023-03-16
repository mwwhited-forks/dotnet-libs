using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Vlog.Contracts.Managers
{
    public interface IVlogManager
    {
        Task<VlogModel?> GetVlog(string vlogId);

        Task<PagedResult<VlogModel>> GetVlogsPagedAsync(VlogsFilter vlogsFilter);

        Task<ResponseModel<VlogModel?>> SaveVlogAsync(VlogModel vlog);
    }
}