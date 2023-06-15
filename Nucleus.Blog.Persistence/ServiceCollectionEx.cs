using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Blog.Contracts.Persistence;
using Nucleus.Blog.Persistence.Services;

namespace Nucleus.Blog.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddBlogPersistenceServices(this IServiceCollection services)
        {
            services.TryAddMongoDatabase<IBlogMongoDatabase>();

            services.TryAddTransient<IBlogService, BlogService>();
            return services;
        }
    }
}
