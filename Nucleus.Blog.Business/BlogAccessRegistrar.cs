using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Blog.Business.Managers;
using Nucleus.Blog.Contracts.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Blog.Business
{
    public class BlogAccessRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IBlogManager, BlogManager>();
            services.AddTransient<IPublicBlogManager, PublicBlogManager>();
            return services;
        }
    }
}
