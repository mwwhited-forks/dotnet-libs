using MongoDB.Driver;

namespace Eliassen.MongoDB.Tests;

public interface ITestMongoDatabase
{
    IMongoCollection<TestCollection> Tests { get; }
}
