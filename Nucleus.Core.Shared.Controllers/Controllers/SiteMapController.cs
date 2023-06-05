using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Shared.Contracts.Managers;
using System.Text;

namespace Nucleus.Core.Shared.Controllers.Controllers
{
    [Route("api")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {
        private readonly ISiteMapManager _siteMapManager;

        public SiteMapController(ISiteMapManager siteMapManager)
        {
            _siteMapManager = siteMapManager;
        }

        [HttpGet("SiteMap")]
        public async Task<IActionResult> GetSiteMap() =>
            File(Encoding.UTF8.GetBytes(await _siteMapManager.RenderSiteMap()), "text/xml");

    }
}
