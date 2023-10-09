using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
<<<<<<< HEAD
using Nucleus.Lesson.Contracts.Collections;
=======
>>>>>>> master
using Nucleus.Lesson.Persistence.Collections;

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
