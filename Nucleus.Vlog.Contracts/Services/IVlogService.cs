using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Collections;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Vlog.Contracts.Services
{
    public interface IVlogService
    {

        Task<List<VlogModel>> GetPagedAsync(PagingModel pagingModel, VlogsFilterItem? filterItems, bool onlyActive);

        Task<long> GetPagedCountAsync(PagingModel pagingModel, VlogsFilterItem? filterItems, bool onlyActive);

        Task<List<VlogModel>> GetAsync();

        Task<List<VlogModel>> GetRecentAsync(int i, bool onlyActive);

        Task<VlogModel?> GetSlugAsync(string slug, bool onlyActive);

        Task<VlogModel?> GetAsync(string id);

        Task<VlogModel> CreateAsync(VlogModel newBlog);

        Task UpdateAsync(VlogModel updatedBlog);

        Task RemoveAsync(string id);
    }
}
