using Eliassen.System.Configuration;

namespace Eliassen.MongoDB.Extensions
{
    [ConfigurationSection("MongoDatabase")]
    public class DefaultMongoDatabaseSettings : IMongoSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}