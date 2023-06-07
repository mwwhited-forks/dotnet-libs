using Nucleus.Lesson.Contracts.Collections;
using Nucleus.Lesson.Contracts.Models;
using System;
using System.Linq.Expressions;

namespace Nucleus.Lesson.Persistence.Services
{
    public static class Projections
    {
        public static Expression<Func<LessonCollection, LessonModel>> Lessons => item => new LessonModel()
        { 
            LessonId = item.LessonId,
            Content = item.Content,
            Preview = item.Preview,
            Slug = item.Slug,
            Title = item.Title,
            Enabled = item.Enabled,
            CreatedOn = item.CreatedOn,
        };
    }
}
