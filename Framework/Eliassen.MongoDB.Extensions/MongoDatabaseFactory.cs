using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Eliassen.MongoDB.Extensions
{
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MongoDatabaseFactory(
            IServiceProvider serviceProvider
            )
        {
            _serviceProvider = serviceProvider;
        }

        public TDatabase Create<TDatabase, TSettings>()
            where TSettings : class, IMongoSettings
        {
            var settings = _serviceProvider.GetRequiredService<IOptions<TSettings>>();
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            var proxy = MongoDispatchProxy.Create<TDatabase>(database, settings.Value);
            return proxy;
        }
    }
}