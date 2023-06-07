using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Blog.Contracts.Services;
using Nucleus.Blog.Persistence.Services;

namespace Nucleus.Blog.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddBlogPersistenceServices(this IServiceCollection services)
        {
            services.TryAddTransient<IBlogService, BlogService>();
            return services;
        }
    }
}
