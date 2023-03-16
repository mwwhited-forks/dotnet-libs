using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Persistence
{
    public class CorePersistenceRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
