using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddCoreBusinessServices(this IServiceCollection services)
        {
            new CoreBusinessRegistrar().AddServices(services);
            return services;
        }
    }
}
