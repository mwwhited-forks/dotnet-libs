using Nucleus.Vlog.Contracts.Managers;
using Nucleus.Vlog.Contracts.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Vlog.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private IPublicLessonManager _publicLessonManager { get; set; }

        public LessonController(IPublicLessonManager publicLessonManager)
        {
            _publicLessonManager = publicLessonManager;
        }

        [HttpPost("Lessons")]
        public async Task<IActionResult> GetAllVlogs(LessonsFilter filter) =>
            new JsonResult(await _publicLessonManager.GetLessonsPagedAsync(filter));

        [HttpGet("Slug/{id}")]
        public async Task<IActionResult> GetVlogSlug(string id) =>
            new JsonResult(await _publicLessonManager.GetLessonSlug(id));

        [HttpGet("RecentLessons/{id}")]
        public async Task<IActionResult> GetRecentVlogs(int id) =>
            new JsonResult(await _publicLessonManager.GetRecentLessons(id));

    }
}
