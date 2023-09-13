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
#warning retire this
        public async Task<PagedResult<LessonScheduleModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter)
        {
            lessonsFilter.PagingModel ??= PagingModel.Default;
            List<LessonScheduleModel> lessons = await _LessonScheduleService.GetPagedAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, true);
            PagedResult<LessonScheduleModel> result = new PagedResult<LessonScheduleModel>()
            {
                CurrentPage = lessonsFilter.PagingModel.CurrentPage,
                PageSize = lessonsFilter.PagingModel.PageSize,
                Results = lessons,
                RowCount = await _LessonScheduleService.GetPagedCountAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, true),
                PageCount = lessons.Count
            };
            return result;
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
