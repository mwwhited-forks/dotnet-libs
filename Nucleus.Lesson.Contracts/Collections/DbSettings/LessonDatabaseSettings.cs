namespace Nucleus.Lesson.Contracts.Collections.DbSettings
{
    public class LessonDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string LessonsCollectionName { get; set; } = null!;
    }
}
