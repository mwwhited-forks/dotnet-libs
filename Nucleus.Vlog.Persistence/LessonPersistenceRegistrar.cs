using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Vlog.Contracts.Services;
using Nucleus.Vlog.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Persistence
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
