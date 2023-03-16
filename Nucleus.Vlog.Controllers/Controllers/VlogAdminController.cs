using Nucleus.Core.Busines.Attributes;
using Nucleus.Core.Contracts;
using Nucleus.Vlog.Contracts.Managers;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Vlog.Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VlogAdminController : ControllerBase
    {
        private IVlogManager _vlogManager { get; set; }

        public VlogAdminController(IVlogManager vlogManager)
        {
            _vlogManager = vlogManager;
        }

        [HttpPost("Vlogs")]
        [ApplicationRight(Rights.Vlog.Manager)]
        public async Task<IActionResult> GetAllVlogsPagedAsync(VlogsFilter filter) =>
           new JsonResult(await _vlogManager.GetVlogsPagedAsync(filter));

        [HttpGet("Vlog/{id}")]
        [ApplicationRight(Rights.Vlog.Manager)]
        public async Task<IActionResult> GetAsync(string id) =>
            new JsonResult(await _vlogManager.GetVlog(id));

        [HttpPost("Save")]
        [ApplicationRight(Rights.Vlog.Manager)]
        public async Task<IActionResult> SaveAsync(VlogModel vlog) =>
            new JsonResult(await _vlogManager.SaveVlogAsync(vlog));

    }
}
