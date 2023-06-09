using Microsoft.Extensions.FileSystemGlobbing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Nucleus.Dataloader.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("MongoDatabase__ConnectionString");
            var path = args.FirstOrDefault();
            var matcher = new Matcher(StringComparison.OrdinalIgnoreCase);
            matcher.AddInclude(@"**/*.json");

            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("nucleus2");

            Console.WriteLine($"dir: {path}");
            foreach (var file in matcher.GetResultsInFullPath(path))
            {
                Console.WriteLine($"file: {file}");
                var collectionName = Path.GetFileNameWithoutExtension(file);
                var collection = database.GetCollection<BsonDocument>(collectionName);
                Console.Write($"\tCollection: {collectionName}");

                var jsonContent = File.ReadAllText(file);
                var bsonArray = BsonSerializer.Deserialize<BsonArray>(jsonContent);

                var doc = 0;
                foreach (var item in bsonArray.OfType<BsonDocument>())
                {
                    doc++;
                    DateTime? value = item.Names.Contains("createdOn") ? item["createdOn"] switch
                    {
                        BsonArray arr when arr[0].BsonType == BsonType.String => new DateTime(long.Parse(arr[0].AsString) + (arr[1].AsInt32 * 60 * 1000)),
                        BsonArray arr when arr[0].BsonType == BsonType.Int64 => new DateTime(arr[0].AsInt64 + (arr[1].AsInt32 * 60 * 1000)),
                        BsonDateTime bdt => bdt.ToUniversalTime(),
                        _ => null
                    } : null;

                    item["createdOn"] = value ?? DateTime.UtcNow;

                    collection.InsertOne(item.AsBsonDocument);
                }

                Console.WriteLine($" => {doc}");
            }
        }
    }
}