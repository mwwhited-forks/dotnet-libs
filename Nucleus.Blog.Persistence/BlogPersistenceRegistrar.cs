using Nucleus.Blog.Contracts.Services;
using Nucleus.Blog.Persistence.Services;
using Nucleus.Core.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Blog.Persistence
{
    public class BlogPersistenceRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            return services;
        }
    }
}
