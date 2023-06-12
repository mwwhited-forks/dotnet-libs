using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Lesson.Contracts.Services;
using Nucleus.Lesson.Persistence.Services;

namespace Nucleus.Lesson.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddLessonPersistenceServices(this IServiceCollection services)
        {
            services.TryAddMongoDatabase<ILessonMongoDatabase>();

            services.TryAddTransient<ILessonService, LessonService>();
            return services;
        }
    }
}
