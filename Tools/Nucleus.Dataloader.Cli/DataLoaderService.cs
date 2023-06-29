using Eliassen.MongoDB.Extensions;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations.ElementNameValidators;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Persistence.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;

namespace Nucleus.Dataloader.Cli
{
    public class DataLoaderService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _log;
        private readonly IMongoSettings _mongo;
        private readonly DataLoaderSettings _settings;
        private readonly IMongoDatabaseRegistration _databases;
        private readonly IJsonSerializer _jsonSerializer;

        public DataLoaderService(
            IServiceProvider serviceProvider,
            ILogger<DataLoaderService> log,
            IOptions<DefaultMongoDatabaseSettings> mongo,
            IOptions<DataLoaderSettings> settings,
            IMongoDatabaseRegistration databases,
            IJsonSerializer jsonSerializer
            )
        {
            _serviceProvider = serviceProvider;
            _log = log;
            _mongo = mongo.Value;
            _settings = settings.Value;
            _databases = databases;
            _jsonSerializer = jsonSerializer;
        }

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public object ConvertTo(object input, Type type) =>
            this.GetType()
                .GetMethod(nameof(this.ConvertTo), 1, new[] { typeof(object) })
                .MakeGenericMethod(type)
                .Invoke(this, new[] { input });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        public T ConvertTo<T>(object input) =>
            (T)input;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public Array AsArray(object input, Type type) =>
            (Array)this.GetType()
                .GetMethod(nameof(this.AsArray), 1, new[] {
                    typeof(IMongoCollection<>).MakeGenericType(Type.MakeGenericMethodParameter(0))
                })
                .MakeGenericMethod(type)
                .Invoke(this, new[] { input });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        public T[] AsArray<T>(IMongoCollection<T> collection) => collection.AsQueryable().ToArray();

        public async Task ExportAsync(PropertyInfo collection, object instance, CancellationToken cancellationToken)
        {
            try
            {
                var elementType = collection.PropertyType.GetGenericArguments()[0];
                var collectionName = collection.GetCustomAttributes<CollectionNameAttribute>().FirstOrDefault()?.CollectionName ?? elementType.Name;

                _log.LogInformation($"Exporting: {{{nameof(collectionName)}}}", collectionName);

                var data = collection.GetValue(instance);
                var arr = AsArray(data ?? throw new NotSupportedException(nameof(data)), elementType);

                var targetFile = Path.Combine(_settings.SourcePath, $"{collectionName}.json");
                using var fileStream = File.Create(targetFile);
                await _jsonSerializer.SerializeAsync(arr, fileStream);

                _log.LogInformation($"Exported: {{{nameof(collectionName)}}} to \"{{{nameof(targetFile)}}}\"", collectionName, targetFile);
            }
            catch (Exception ex)
            {
                _log.LogError($"{{{nameof(collection)}}}::{{{nameof(instance)}}} -> {{{nameof(ex.Message)}}}", collection, instance, ex.Message);
                _log.LogDebug($"{{{nameof(collection)}}}::{{{nameof(instance)}}} -> {{{nameof(Exception)}}}", collection, instance, ex);
            }
        }

        public async Task ImportAsync(PropertyInfo collection, object instance, CancellationToken cancellationToken)
        {
            try
            {
                var elementType = collection.PropertyType.GetGenericArguments()[0];
                var setType = elementType.MakeArrayType();
                var collectionName = collection.GetCustomAttributes<CollectionNameAttribute>().FirstOrDefault()?.CollectionName ?? elementType.Name;

                _log.LogInformation($"Importing: {{{nameof(collectionName)}}}", collectionName);

                var sourceFile = Path.Combine(_settings.SourcePath, $"{collectionName}.json");
                using var fileStream = File.OpenRead(sourceFile);
                var result = await _jsonSerializer.DeserializeAsync(fileStream, setType);

                var data = collection.GetValue(instance);
                var collectionType = typeof(IMongoCollection<>).MakeGenericType(elementType);

                var idProperty = elementType.GetProperties().FirstOrDefault(e => e.GetCustomAttribute<BsonIdAttribute>() != null)
                    ?? throw new NotSupportedException();
                var createdOn = elementType.GetProperty("CreatedOn", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                    ?? throw new NotSupportedException();

                if (data is IMongoCollection<UserCollection> users && result is UserCollection[] userArrays)
                {
                    var ids = userArrays.Select(e => e.UserId).ToArray();

                    var eee = users.AsQueryable().ToList();

                    var exists = users.AsQueryable()
                        .Where(u => ids.Contains(u.UserId))
                        .Select(u => new { u.UserId, u.CreatedOn })
                        .ToArray()
                        ;

                    var qqq = users.AsQueryable().Where(q=>q.UserId == "641cd44eaa22983c3e4edb32");
                    var tsq = qqq.ToString();

                    var matched = from u in userArrays
                                  select new
                                  {
                                      User = u,
                                      Match = exists.FirstOrDefault(i => i.UserId == u.UserId),
                                  };
                    var ma = matched.ToArray();


                    foreach (var u in userArrays)
                    {
                        var idValue = idProperty.GetValue(u) as string;
                        //var modifiedOnValue = modifiedOn.GetValue(u) as DateTimeOffset?;
                        var createdOnValue = createdOn.GetValue(u) as DateTimeOffset?;
                        _log.LogInformation(idValue);

                        //new FindOneAndReplaceOptions<UserCollection, UserCollection>();

                        //var ret = users.FindOneAndReplace(
                        //    usr => usr.UserId == idValue && (!usr.CreatedOn.HasValue || usr.CreatedOn < createdOnValue),
                        //    u,
                        //    );
                        //users.UP
                        // 
                        //new UpdateOptions { IsUpsert = true, }
                    }

                }

                //if (data.GetType().IsAssignableTo(collectionType))
                //{
                //    //     [BsonId]
                //}

                //IMongoCollection<UserCollection> user;
                //string userId = "";
                //DateTimeOffset createdOn = DateTimeOffset.Now;

                //var updateDef = Builders<UserCollection>.Update;

                //user.FindOneAndUpdate(u => u.UserId == userId && u.CreatedOn < createdOn, updateDef.);

                //var arr = AsArray(data ?? throw new NotSupportedException(nameof(data)), elementType);
                //TODO: do partial updates

                //TODO: create partial/build update

                //IMongoCollection<UserCollection> users;
                ////users.Find()

                _log.LogInformation($"Imported: {{{nameof(collectionName)}}} to \"{{{nameof(sourceFile)}}}\"", collectionName, sourceFile);

                throw new NotSupportedException($"ImportAsync");
            }
            catch (Exception ex)
            {
                _log.LogError($"{{{nameof(collection)}}}::{{{nameof(instance)}}} -> {{{nameof(ex.Message)}}}", collection, instance, ex.Message);
                _log.LogDebug($"{{{nameof(collection)}}}::{{{nameof(instance)}}} -> {{{nameof(Exception)}}}", collection, instance, ex);
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var databases = from type in _databases.Types
                            select (type: type, database: ConvertTo(_serviceProvider.GetRequiredService(type), type));
            var dbs = databases.ToList();

            foreach (var db in dbs)
            {
                foreach (var collection in db.type.GetProperties())
                {
                    if (cancellationToken.IsCancellationRequested) return;

                    if (_settings.Action == DataLoaderActions.Export)
                    {
                        await ExportAsync(collection, db.database, cancellationToken);
                    }
                    else if (_settings.Action == DataLoaderActions.Import)
                    {
                        await ImportAsync(collection, db.database, cancellationToken);
                    }
                    else
                    {
                        throw new NotSupportedException($"{_settings.Action}");
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
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}