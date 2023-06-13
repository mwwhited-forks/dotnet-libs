using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;
using static Nucleus.Core.Persistence.Rights;

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

        public async Task ExportAsync(PropertyInfo collection, object instance, CancellationToken cancellationToken)
        {
            var elementType = collection.PropertyType.GetGenericArguments()[0];
            var collectionName = collection.GetCustomAttributes<CollectionNameAttribute>().FirstOrDefault()?.CollectionName ?? elementType.Name;

            _log.LogInformation($"Exporting: {{{nameof(collectionName)}}}", collectionName);

            var data = collection.GetValue(instance);
            var arr = AsArray(data, elementType);
            var json = System.Text.Json.JsonSerializer.Serialize(arr, options: new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
            });
            var targetFile = Path.Combine(_dataloader.SourcePath, $"{collectionName}.json");
            await File.WriteAllTextAsync(targetFile, json);

            _log.LogInformation($"Exported: {{{nameof(collectionName)}}} to \"{{{nameof(targetFile)}}}\"", collectionName, targetFile);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var databases = from type in _databases.Types
                            select (type, ConvertTo(_serviceProvider.GetRequiredService(type), type));
            var dbs = databases.ToList();

            foreach (var db in dbs)
            {
                foreach (var collection in db.type.GetProperties())
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    await ExportAsync(collection, db.Item2, cancellationToken);
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

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}