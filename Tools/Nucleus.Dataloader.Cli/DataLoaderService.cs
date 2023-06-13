using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Data.Entity.Core.Mapping;
using Eliassen.System.Configuration;

namespace Nucleus.Dataloader.Cli
{
    public class DataLoaderService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _log;
        private readonly IMongoSettings _mongo;
        private readonly DataLoaderSettings _dataloader;
        private readonly IMongoDatabaseRegistation _databases;

        public DataLoaderService(
            IServiceProvider serviceProvider,
            ILogger<DataLoaderService> log,
            IOptions<DefaultMongoDatabaseSettings> mongo,
            IOptions<DataLoaderSettings> dataloader,
            IMongoDatabaseRegistation databases
            )
        {
            _serviceProvider = serviceProvider;
            _log = log;
            _mongo = mongo.Value;
            _dataloader = dataloader.Value;
            _databases = databases;
        }

        public object ConvertTo(object input, Type type) =>
            this.GetType()
                .GetMethod(nameof(this.ConvertTo), 1, new[] { typeof(object) })
                .MakeGenericMethod(type)
                .Invoke(this, new[] { input });
        public T ConvertTo<T>(object input) =>
            (T)input;

        public Array AsArray(object input, Type type) =>
            (Array)this.GetType()
                .GetMethod(nameof(this.AsArray), 1, new[] {
                    typeof(IMongoCollection<>).MakeGenericType(Type.MakeGenericMethodParameter(0))
                })
                .MakeGenericMethod(type)
                .Invoke(this, new[] { input });
        public T[] AsArray<T>(IMongoCollection<T> collection) => collection.AsQueryable().ToArray();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var databases = from type in _databases.Types
                            select (type, ConvertTo(_serviceProvider.GetRequiredService(type), type));
            var dbs = databases.ToList();

            foreach (var db in dbs)
            {
                foreach (var prop in db.type.GetProperties())
                {
                    var elementType = prop.PropertyType.GetGenericArguments()[0];
                    var dateProps = elementType.GetProperties()
                                               .Where(t => new[] { typeof(DateTimeOffset), typeof(DateTimeOffset?) }.Contains(t.PropertyType))
                                               .ToArray();

                    if (dateProps.Any())
                    {
                        var data = prop.GetValue(db.Item2);
                        var arr = AsArray(data, elementType);
                        var json = System.Text.Json.JsonSerializer.Serialize(arr);
                        //var bson = BsonValue.Create(arr);
                        //var database = 

                    }
                }
            }

            var x = 1;

            //var path = _dataloader.SourcePath;
            //var matcher = new Matcher(StringComparison.OrdinalIgnoreCase);
            //matcher.AddInclude(_dataloader.IncludePath);

            //var mongoClient = new MongoClient(_mongo.ConnectionString);
            //var database = mongoClient.GetDatabase(_mongo.DatabaseName);

            //Console.WriteLine($"dir: {path}");
            //foreach (var file in matcher.GetResultsInFullPath(path))
            //{
            //    Console.WriteLine($"file: {file}");
            //    var collectionName = Path.GetFileNameWithoutExtension(file);
            //    var collection = database.GetCollection<BsonDocument>(collectionName);
            //    Console.Write($"\tCollection: {collectionName}");

            //    var jsonContent = File.ReadAllText(file);
            //    var bsonArray = BsonSerializer.Deserialize<BsonArray>(jsonContent);

            //    var doc = 0;
            //    foreach (var item in bsonArray.OfType<BsonDocument>())
            //    {
            //        doc++;
            //        DateTime? value = item.Names.Contains("createdOn") ? item["createdOn"] switch
            //        {
            //            BsonArray arr when arr[0].BsonType == BsonType.String => new DateTime(long.Parse(arr[0].AsString) + (arr[1].AsInt32 * 60 * 1000)),
            //            BsonArray arr when arr[0].BsonType == BsonType.Int64 => new DateTime(arr[0].AsInt64 + (arr[1].AsInt32 * 60 * 1000)),
            //            BsonDateTime bdt => bdt.ToUniversalTime(),
            //            _ => null
            //        } : null;

            //        item["createdOn"] = value ?? DateTime.UtcNow;

            //        //  collection.InsertOne(item.AsBsonDocument);
            //    }

            //    Console.WriteLine($" => {doc}");

            //    //using (var fileWriter = File.Create(file))
            //    //using (var textWriter = new StreamWriter(fileWriter))
            //    //{
            //    //    BsonSerializer.Serialize(textWriter, bsonArray);
            //    //}

            //    File.WriteAllText(file, bsonArray.ToString());
            //}

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}