using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Managers;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using Nucleus.Lesson.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Nucleus.Core.Contracts.Rights;

namespace Nucleus.Lesson.Business.Managers
{
    public class PublicLessonManager : IPublicLessonManager
    {

        private readonly ILessonService _lessonService;

        public PublicLessonManager(ILessonService LessonService)
        {
            _lessonService = LessonService;
        }

        public async Task<List<LessonModel>> GetLessons() =>
          await _lessonService.GetAsync();

        public async Task<List<LessonModel>?> GetRecentLessons(int i) =>
            await _lessonService.GetRecentAsync(i, true);

        public async Task<List<LessonModel>?> GetLessonsByLessonScheduleId(string lessonScheduleId) =>
            await _lessonService.GetLessonsByLessonScheduleId(lessonScheduleId);


        public IQueryable<LessonModel> QueryLessons() => _lessonService.Query();

        public void UpdateLesson(LessonModel lesson)
        {
            _lessonService.UpdateAsync(lesson);
        }

        public void UpdateLessons(LessonModel[] lessons)
        {
            foreach (var lesson in lessons)
            {
                UpdateLesson(lesson);
            }
        }
    }
}
