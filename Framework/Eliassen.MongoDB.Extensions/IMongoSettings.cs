namespace Eliassen.MongoDB.Extensions
{
    public interface IMongoSettings
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}