namespace Eliassen.MongoDB.Extensions
{
    public interface IMongoDatabaseFactory
    {
        TDatabase Create<TDatabase, TSettings>()
            where TSettings : class, IMongoSettings;
    }
}