using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Persistence.Collections;
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
            Teacher = item.Teacher,
            Attendees = item.Attendees,
            Duration = item.Duration,
            Price = item.Price,
            Tags= item.Tags,
            Notes = item.Notes,
            StartDateTime = item.StartDateTime,
            EndDateTime = item.EndDateTime
            
        };
    }
}
