using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
<<<<<<< HEAD
<<<<<<< HEAD
using Nucleus.Lesson.Contracts.Collections;
=======
>>>>>>> master
=======
>>>>>>> 6ef5f15b67cdc4c208046f61a2b9b8ff52e806d1
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
