using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Vlog.Business.Managers;
using Nucleus.Vlog.Contracts.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Business
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
