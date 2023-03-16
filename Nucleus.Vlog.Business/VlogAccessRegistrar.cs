using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Vlog.Business.Managers;
using Nucleus.Vlog.Contracts.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Business
{
    public class VlogAccessRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IVlogManager, VlogManager>();
            services.AddTransient<IPublicVlogManager, PublicVlogManager>();
            return services;
        }
    }
}
