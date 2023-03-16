using Nucleus.Vlog.Contracts.Managers;
using Nucleus.Vlog.Contracts.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Vlog.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlogController : ControllerBase
    {
        private IPublicVlogManager _publicVlogManager { get; set; }

        public VlogController(IPublicVlogManager publicVlogManager)
        {
            _publicVlogManager = publicVlogManager;
        }

        [HttpPost("Vlogs")]
        public async Task<IActionResult> GetAllVlogs(VlogsFilter filter) =>
            new JsonResult(await _publicVlogManager.GetVlogsPagedAsync(filter));

        [HttpGet("Slug/{id}")]
        public async Task<IActionResult> GetVlogSlug(string id) =>
            new JsonResult(await _publicVlogManager.GetVlogSlug(id));

        [HttpGet("RecentVlogs/{id}")]
        public async Task<IActionResult> GetRecentVlogs(int id) =>
            new JsonResult(await _publicVlogManager.GetRecentVlogs(id));

    }
}
