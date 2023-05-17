using Nucleus.Vlog.Contracts.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nucleus.Vlog.Contracts.Services;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System;

namespace Nucleus.Vlog.Business.Managers
{
    public class LessonManager : ILessonManager
    {

        private readonly ILessonService _lessonService;

        public LessonManager(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public async Task<LessonModel?> GetLesson(string lessonId) =>
          await _lessonService.GetAsync(lessonId);

        public async Task<PagedResult<LessonModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter)
        {
            PagedResult<LessonModel> result = new PagedResult<LessonModel>();
            List<LessonModel> blogs = await _lessonService.GetPagedAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, false);
            result = new PagedResult<LessonModel>()
            {
                CurrentPage = lessonsFilter.PagingModel.CurrentPage,
                PageSize = lessonsFilter.PagingModel.PageSize,
                Results = blogs,
                RowCount = await _lessonService.GetPagedCountAsync(lessonsFilter.PagingModel, lessonsFilter.LessonFilters, false),
                PageCount = blogs.Count
            };
            return result;
        }

        public async Task<ResponseModel<LessonModel?>> SaveLessonAsync(LessonModel lesson)
        {
            if (lesson == null || string.IsNullOrEmpty(lesson.Title) || string.IsNullOrEmpty(lesson.Content) || string.IsNullOrEmpty(lesson.Slug))
                return new ResponseModel<LessonModel?>()
                {
                    IsSuccess = false,
                    Message = "Missing Required Fields"
                };
            ResponseModel<LessonModel?> result = new ResponseModel<LessonModel?>() { IsSuccess = true };
            if (String.IsNullOrEmpty(lesson.LessonId))
            {
                lesson.CreatedOn = DateTimeOffset.Now;
                result.Response = await _lessonService.CreateAsync(lesson);
                return result;
            }
            else
            {
                lesson.CreatedOn = DateTimeOffset.FromUnixTimeMilliseconds(lesson.CreatedOnUnix);
                await _lessonService.UpdateAsync(lesson);
                result.Response = lesson;
                return result;
            }
        }
    }
}
