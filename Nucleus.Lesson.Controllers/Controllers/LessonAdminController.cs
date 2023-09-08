using Eliassen.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts;
using Nucleus.Lesson.Contracts.Managers;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;

namespace Nucleus.Lesson.Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LessonAdminController : ControllerBase
    {
        private readonly ILessonAdminManager _lessonAdminManager;

        public LessonAdminController(ILessonAdminManager lessonAdminManager)
        {
            _lessonAdminManager = lessonAdminManager;
        }

#warning retire this
        [Obsolete]
        [HttpPost("Lessons")]
        [ApplicationRight(Rights.Lesson.Manager)]
        public async Task<IActionResult> GetAllLessonsPagedAsync(LessonsFilter filter) =>
           new JsonResult(await _lessonAdminManager.GetLessonsPagedAsync(filter));

        [HttpGet("Lesson/{id}")]
        [ApplicationRight(Rights.Lesson.Manager)]
        public async Task<IActionResult> GetAsync(string id) =>
            new JsonResult(await _lessonAdminManager.GetLesson(id));

        [HttpPost("Save")]
        [ApplicationRight(Rights.Lesson.Manager)]
        public async Task<IActionResult> SaveAsync(LessonAdminModel lesson) =>
            new JsonResult(await _lessonAdminManager.SaveLessonAsync(lesson));

    }
}
