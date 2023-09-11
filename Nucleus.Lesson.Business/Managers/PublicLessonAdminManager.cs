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
    public class PublicLessonAdminManager : IPublicLessonAdminManager
    {

        private readonly ILessonAdminService _lessonAdminService;

        public PublicLessonAdminManager(ILessonAdminService LessonService)
        {
            _lessonAdminService = LessonService;
        }
#warning retire this
        public async Task<PagedResult<LessonAdminModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter)
        {
            lessonsFilter.PagingModel ??= PagingModel.Default;
            List<LessonAdminModel> lessons = await _lessonAdminService.GetPagedAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, true);
            PagedResult<LessonAdminModel> result = new PagedResult<LessonAdminModel>()
            {
                CurrentPage = lessonsFilter.PagingModel.CurrentPage,
                PageSize = lessonsFilter.PagingModel.PageSize,
                Results = lessons,
                RowCount = await _lessonAdminService.GetPagedCountAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, true),
                PageCount = lessons.Count
            };
            return result;
        }

        public async Task<List<LessonAdminModel>> GetLessons() =>
          await _lessonAdminService.GetAsync();

        //public async Task<LessonAdminModel?> GetLessonSlug(string slug) =>
        //  await _lessonAdminService.GetSlugAsync(slug, true);

        public async Task<List<LessonAdminModel>?> GetRecentLessons(int i) =>
            await _lessonAdminService.GetRecentAsync(i, true);
        public IQueryable<LessonAdminModel> QueryLessons() => _lessonAdminService.Query();
    }
}
