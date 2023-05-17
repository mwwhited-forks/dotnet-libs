using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddLessonBusinessServices(this IServiceCollection services)
        {
            new LessonAccessRegistrar().AddServices(services);
            return services;
        }
    }
}
