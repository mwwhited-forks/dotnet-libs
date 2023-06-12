using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Linq;

namespace Eliassen.System.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration<TConfig>(
            this IServiceCollection services,
            IConfiguration config
            )
            where TConfig : class
        {
            var section = TypeDescriptor.GetAttributes(typeof(TConfig))
                .OfType<ConfigurationSectionAttribute>()
                .FirstOrDefault()?.ConfigurationSection ?? typeof(TConfig).Name;
            services.Configure<TConfig>(config.GetSection(section));
            return services;
        }
    }
}
