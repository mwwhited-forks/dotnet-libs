using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Blog.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddBlogPersistenceServices(this IServiceCollection services)
        {
            new BlogPersistenceRegistrar().AddServices(services);
            return services;
        }
    }
}
