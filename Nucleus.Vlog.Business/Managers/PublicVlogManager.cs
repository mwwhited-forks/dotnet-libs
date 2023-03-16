using Nucleus.Vlog.Contracts.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nucleus.Vlog.Contracts.Services;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;

namespace Nucleus.Vlog.Business.Managers
{
    public class PublicVlogManager : IPublicVlogManager
    {

        private readonly IVlogService _vlogService;

        public PublicVlogManager(IVlogService VlogService)
        {
            _vlogService = VlogService;
        }
        public async Task<PagedResult<VlogModel>> GetVlogsPagedAsync(VlogsFilter vlogsFilter)
        {
            List<VlogModel> vlogs = await _vlogService.GetPagedAsync(vlogsFilter.PagingModel, vlogsFilter.VlogFilters, true);
            PagedResult<VlogModel> result = new PagedResult<VlogModel>()
            {
                CurrentPage = vlogsFilter.PagingModel.CurrentPage,
                PageSize = vlogsFilter.PagingModel.PageSize,
                Results = vlogs,
                RowCount = await _vlogService.GetPagedCountAsync(vlogsFilter.PagingModel, vlogsFilter.VlogFilters, true),
                PageCount = vlogs.Count
            };
            return result;
        }

        public async Task<List<VlogModel>> GetVlogs() =>
          await _vlogService.GetAsync();

        public async Task<VlogModel?> GetVlogSlug(string slug) =>
          await _vlogService.GetSlugAsync(slug, true);

        public async Task<List<VlogModel>?> GetRecentVlogs(int i) =>
            await _vlogService.GetRecentAsync(i, true);
    }
}
