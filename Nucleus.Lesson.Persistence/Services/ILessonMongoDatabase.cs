using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
using Nucleus.Lesson.Contracts.Collections;

namespace Nucleus.Lesson.Persistence.Services
{
    public interface ILessonMongoDatabase
    {
        [CollectionName("lessons")]
        IMongoCollection<LessonCollection> Lessons { get; }

        [CollectionName("lessonSchedule")]
        IMongoCollection<LessonScheduleCollection> LessonSchedule { get; }
    }
}
