using Eliassen.System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.MongoDB.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMongoServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddConfiguration<DefaultMongoDatabaseSettings>(config);
            services.TryAddSingleton<IMongoDatabaseFactory, MongoDatabaseFactory>();
            return services;
        }

        public static IServiceCollection TryAddMongoDatabase<TDatabase, TSettings>(this IServiceCollection services)
            where TDatabase : class
            where TSettings : class, IMongoSettings
        {
            services.TryAddTransient(sp => sp.GetRequiredService<IMongoDatabaseFactory>().Create<TDatabase, TSettings>());
            return services;
        }

        public static IServiceCollection TryAddMongoDatabase<TDatabase>(this IServiceCollection services)
            where TDatabase : class => TryAddMongoDatabase<TDatabase, DefaultMongoDatabaseSettings>(services);
    }
}