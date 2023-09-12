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
    public class LessonScheduleManager : ILessonScheduleManager
    {

        private readonly ILessonScheduleService _LessonScheduleService;

        public LessonScheduleManager(ILessonScheduleService LessonScheduleService)
        {
            _LessonScheduleService = LessonScheduleService;
        }

        public async Task<LessonScheduleModel?> GetLesson(string lessonId) =>
          await _LessonScheduleService.GetAsync(lessonId);

#warning retire this
        public async Task<PagedResult<LessonScheduleModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter)
        {
            lessonsFilter.PagingModel ??= PagingModel.Default;
            List<LessonScheduleModel> blogs = await _LessonScheduleService.GetPagedAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, false);
            var result = new PagedResult<LessonScheduleModel>()
            {
                CurrentPage = lessonsFilter.PagingModel.CurrentPage,
                PageSize = lessonsFilter.PagingModel.PageSize,
                Results = blogs,
                RowCount = await _LessonScheduleService.GetPagedCountAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, false),
                PageCount = blogs.Count
            };
            return result;
        }

        public async Task<ResponseModel<LessonScheduleModel?>> SaveLessonAsync(LessonScheduleModel lesson)
        {
            if (lesson == null || string.IsNullOrEmpty(lesson.Title) || string.IsNullOrEmpty(lesson.Teacher))
                return new ResponseModel<LessonScheduleModel?>()
                {
                    IsSuccess = false,
                    Message = "Missing Required Fields"
                };
            ResponseModel<LessonScheduleModel?> result = new ResponseModel<LessonScheduleModel?>() { IsSuccess = true };
            if (String.IsNullOrEmpty(lesson.LessonId))
            {
                result.Response = await _LessonScheduleService.CreateAsync(lesson);
                return result;
            }
            else
            {
                await _LessonScheduleService.UpdateAsync(lesson);
                result.Response = lesson;
                return result;
            }
        }
    }
}
