using Nucleus.Lesson.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Lesson.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddLessonPersistenceServices(this IServiceCollection services)
        {
            new LessonPersistenceRegistrar().AddServices(services);
            return services;
        }
    }
}
