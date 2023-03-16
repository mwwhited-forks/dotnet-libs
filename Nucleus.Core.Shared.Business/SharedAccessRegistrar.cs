using Nucleus.Core.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Nucleus.Core.Shared.Contracts.Managers;
using Nucleus.Core.Shared.Business.Managers;

namespace Nucleus.Core.Shared.Business
{
    public class SharedAccessRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<ISiteMapManager, SiteMapManager>();
            return services;
        }
    }
}
