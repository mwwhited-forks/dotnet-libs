using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Lesson.Contracts.Services;
using Nucleus.Lesson.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Lesson.Persistence
{
    public class LessonPersistenceRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<ILessonService, LessonService>();
            return services;
        }
    }
}
