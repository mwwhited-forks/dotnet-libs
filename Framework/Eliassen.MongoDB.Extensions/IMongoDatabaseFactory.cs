using MongoDB.Driver;

namespace Eliassen.MongoDB.Extensions
{
    public interface IMongoDatabaseFactory
    {
        IMongoDatabase Create<TSettings>()
            where TSettings : class, IMongoSettings;
        TDatabase Create<TDatabase, TSettings>()
            where TSettings : class, IMongoSettings;
    }
}