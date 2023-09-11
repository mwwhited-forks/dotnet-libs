using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Managers;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using Nucleus.Lesson.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Business.Managers
{
    public class LessonAdminManager : ILessonAdminManager
    {

        private readonly ILessonAdminService _lessonAdminService;

        public LessonAdminManager(ILessonAdminService lessonAdminService)
        {
            _lessonAdminService = lessonAdminService;
        }

        public async Task<LessonAdminModel?> GetLesson(string lessonId) =>
          await _lessonAdminService.GetAsync(lessonId);

#warning retire this
        public async Task<PagedResult<LessonAdminModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter)
        {
            lessonsFilter.PagingModel ??= PagingModel.Default;
            List<LessonAdminModel> blogs = await _lessonAdminService.GetPagedAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, false);
            var result = new PagedResult<LessonAdminModel>()
            {
                CurrentPage = lessonsFilter.PagingModel.CurrentPage,
                PageSize = lessonsFilter.PagingModel.PageSize,
                Results = blogs,
                RowCount = await _lessonAdminService.GetPagedCountAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, false),
                PageCount = blogs.Count
            };
            return result;
        }

        public async Task<ResponseModel<LessonAdminModel?>> SaveLessonAsync(LessonAdminModel lesson)
        {
            if (lesson == null || string.IsNullOrEmpty(lesson.Title) || string.IsNullOrEmpty(lesson.Teacher))
                return new ResponseModel<LessonAdminModel?>()
                {
                    IsSuccess = false,
                    Message = "Missing Required Fields"
                };
            ResponseModel<LessonAdminModel?> result = new ResponseModel<LessonAdminModel?>() { IsSuccess = true };
            if (String.IsNullOrEmpty(lesson.LessonId))
            {
                result.Response = await _lessonAdminService.CreateAsync(lesson);
                return result;
            }
            else
            {
                await _lessonAdminService.UpdateAsync(lesson);
                result.Response = lesson;
                return result;
            }
        }
    }
}
