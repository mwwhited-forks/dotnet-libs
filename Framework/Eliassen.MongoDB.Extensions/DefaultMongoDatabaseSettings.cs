using Eliassen.System.Configuration;

namespace Eliassen.MongoDB.Extensions;

/// <summary>
/// Default connection information for MongoDatabases, Duplicating this class with a different
/// ConfigurationSectionAttribute value will allow for declaring secondary connection configurations
/// </summary>
[ConfigurationSection("MongoDatabase")]
public class DefaultMongoDatabaseSettings : IMongoSettings
{
    /// <inheritdoc/>
    public string ConnectionString { get; set; } = null!;

    /// <inheritdoc/>
    public string DatabaseName { get; set; } = null!;

    public override string ToString() => new
    {
        ConnectionString,
        DatabaseName,
    }.ToString() ?? "";
}