using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Blog.Business.Managers;
using Nucleus.Blog.Contracts.Managers;

namespace Nucleus.Blog.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddPublicBusinessServices(this IServiceCollection services)
        {
            services.TryAddTransient<IBlogManager, BlogManager>();
            services.TryAddTransient<IPublicBlogManager, PublicBlogManager>();
            return services;
        }
    }
}
