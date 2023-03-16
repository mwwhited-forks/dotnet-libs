using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Vlog.Contracts.Services;
using Nucleus.Vlog.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Persistence
{
    public class VlogPersistenceRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IVlogService, VlogService>();
            return services;
        }
    }
}
