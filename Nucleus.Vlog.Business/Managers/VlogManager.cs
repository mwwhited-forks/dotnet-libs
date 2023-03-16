using Nucleus.Vlog.Contracts.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nucleus.Vlog.Contracts.Services;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System;

namespace Nucleus.Vlog.Business.Managers
{
    public class VlogManager : IVlogManager
    {

        private readonly IVlogService _vlogService;

        public VlogManager(IVlogService vlogService)
        {
            _vlogService = vlogService;
        }

        public async Task<VlogModel?> GetVlog(string vlogId) =>
          await _vlogService.GetAsync(vlogId);

        public async Task<PagedResult<VlogModel>> GetVlogsPagedAsync(VlogsFilter vlogsFilter)
        {
            PagedResult<VlogModel> result = new PagedResult<VlogModel>();
            List<VlogModel> blogs = await _vlogService.GetPagedAsync(vlogsFilter.PagingModel, vlogsFilter.VlogFilters, false);
            result = new PagedResult<VlogModel>()
            {
                CurrentPage = vlogsFilter.PagingModel.CurrentPage,
                PageSize = vlogsFilter.PagingModel.PageSize,
                Results = blogs,
                RowCount = await _vlogService.GetPagedCountAsync(vlogsFilter.PagingModel, vlogsFilter.VlogFilters, false),
                PageCount = blogs.Count
            };
            return result;
        }

        public async Task<ResponseModel<VlogModel?>> SaveVlogAsync(VlogModel vlog)
        {
            if (vlog == null || string.IsNullOrEmpty(vlog.Title) || string.IsNullOrEmpty(vlog.Content) || string.IsNullOrEmpty(vlog.Slug))
                return new ResponseModel<VlogModel?>()
                {
                    IsSuccess = false,
                    Message = "Missing Required Fields"
                };
            ResponseModel<VlogModel?> result = new ResponseModel<VlogModel?>() { IsSuccess = true };
            if (String.IsNullOrEmpty(vlog.VlogId))
            {
                vlog.CreatedOn = DateTimeOffset.Now;
                result.Response = await _vlogService.CreateAsync(vlog);
                return result;
            }
            else
            {
                vlog.CreatedOn = DateTimeOffset.FromUnixTimeMilliseconds(vlog.CreatedOnUnix);
                await _vlogService.UpdateAsync(vlog);
                result.Response = vlog;
                return result;
            }
        }
    }
}
