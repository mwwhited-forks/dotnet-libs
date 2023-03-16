using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Blog.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddPublicBusinessServices(this IServiceCollection services)
        {
            new BlogAccessRegistrar().AddServices(services);
            return services;
        }
    }
}
