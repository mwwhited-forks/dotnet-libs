using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Lesson.Business.Managers;
using Nucleus.Lesson.Contracts.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Lesson.Business
{
    public class LessonAccessRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<ILessonManager, LessonManager>();
            services.AddTransient<IPublicLessonManager, PublicLessonManager>();
            return services;
        }
    }
}
