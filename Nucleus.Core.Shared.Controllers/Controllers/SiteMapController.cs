using Nucleus.Core.Shared.Contracts.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text;

namespace Nucleus.Core.Shared.Controllers.Controllers
{
    [Route("api")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {
        private ISiteMapManager _siteMapManager { get; set; }

        public SiteMapController(ISiteMapManager siteMapManager)
        {
            _siteMapManager = siteMapManager;
        }

        [HttpGet("SiteMap")]
        public async Task<IActionResult> GetSiteMap() =>
            File(Encoding.UTF8.GetBytes(await _siteMapManager.RenderSiteMap()), "text/xml");

    }
}
