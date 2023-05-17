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
    public class LessonAdminController : ControllerBase
    {
        private ILessonManager _lessonManager { get; set; }

        public LessonAdminController(ILessonManager lessonManager)
        {
            _lessonManager = lessonManager;
        }

        [HttpPost("Lessons")]
        [ApplicationRight(Rights.Vlog.Manager)]
        public async Task<IActionResult> GetAllLessonsPagedAsync(LessonsFilter filter) =>
           new JsonResult(await _lessonManager.GetLessonsPagedAsync(filter));

        [HttpGet("Lesson/{id}")]
        [ApplicationRight(Rights.Vlog.Manager)]
        public async Task<IActionResult> GetAsync(string id) =>
            new JsonResult(await _lessonManager.GetLesson(id));

        [HttpPost("Save")]
        [ApplicationRight(Rights.Vlog.Manager)]
        public async Task<IActionResult> SaveAsync(LessonModel lesson) =>
            new JsonResult(await _lessonManager.SaveLessonAsync(lesson));

    }
}
