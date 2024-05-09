using MongoDB.Driver;

namespace Eliassen.MongoDB.Extensions;

/// <summary>
/// provide a centralized means to create Atlas Vector Search
/// </summary>
public interface IMongoVectorSearch
{
    IMongoDatabase CreateVectorSearch<TSettings>()
        where TSettings : class, IMongoSettings;
}
