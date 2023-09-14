using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Managers;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using Nucleus.Lesson.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Business.Managers
{
    public class PublicLessonScheduleManager : IPublicLessonScheduleManager
    {

        private readonly ILessonScheduleService _LessonScheduleService;

        public PublicLessonScheduleManager(ILessonScheduleService LessonService)
        {
            _LessonScheduleService = LessonService;
        }
        public async Task<List<LessonScheduleModel>> GetLessons() =>
          await _LessonScheduleService.GetAsync();

        public async Task<List<LessonScheduleModel>> GetRecentLessons(int i) =>
            await _LessonScheduleService.GetRecentAsync(i, true);
        public IQueryable<LessonScheduleModel> QueryLessons() => _LessonScheduleService.Query();

        public Task<LessonScheduleModel?> GetLessonSlug(string slug)
        {
            throw new System.NotImplementedException();
        }
    }
}
