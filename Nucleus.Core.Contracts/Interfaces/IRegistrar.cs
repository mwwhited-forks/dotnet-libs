using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IRegistrar
    {
        IServiceCollection AddServices(IServiceCollection services);
    }
}
