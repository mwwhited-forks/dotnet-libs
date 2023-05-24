using Microsoft.AspNetCore.Mvc;
using Nucleus.Lesson.Contracts.Managers;

namespace Nucleus.Lesson.Controllers.Controllers
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
        //TODO: restore
#warning RESTORE THIS FEATURE

        //[HttpPost("Lessons")]
        //public async Task<IActionResult> GetAllLessons(LessonsFilter filter) =>
        //    new JsonResult(await _publicLessonManager.GetLessonsPagedAsync(filter));

        [HttpGet("Slug/{id}")]
        public async Task<IActionResult> GetLessonSlug(string id) =>
            new JsonResult(await _publicLessonManager.GetLessonSlug(id));

        [HttpGet("RecentLessons/{id}")]
        public async Task<IActionResult> GetRecentLessons(int id) =>
            new JsonResult(await _publicLessonManager.GetRecentLessons(id));

    }
}
