using MongoDB.Driver;
using Nucleus.Lesson.Persistence.Collections;

namespace Nucleus.Lesson.Persistence.Services
{
    public interface ILessonMongoDatabase
    {
        IMongoCollection<LessonCollection> Lessons { get; }
    }
}
