using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Core.Shared.Business.Managers;
using Nucleus.Core.Shared.Contracts.Managers;

namespace Nucleus.Core.Shared.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddSharedBusinessServices(this IServiceCollection services)
        {
            services.TryAddTransient<ISiteMapManager, SiteMapManager>();
            return services;
        }
    }
}
