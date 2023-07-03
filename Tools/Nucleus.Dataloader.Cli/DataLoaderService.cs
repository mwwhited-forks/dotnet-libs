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
using MongoDB.Bson;
using System.Linq.Expressions;
using Nucleus.Blog.Persistence.Collections;
using Amazon.Auth.AccessControlPolicy;
using Eliassen.System.ResponseModel;
using System.Collections;

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
                if (data == null) throw new NotSupportedException($"{collection} has no value on {instance}");

                var collectionType = typeof(IMongoCollection<>).MakeGenericType(elementType);

                var idProperty = elementType.GetProperties().FirstOrDefault(e => e.GetCustomAttribute<BsonIdAttribute>() != null)
                    ?? throw new NotSupportedException();
                var createdOn = elementType.GetProperty("CreatedOn", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                    ?? throw new NotSupportedException();

                var parameter = Expression.Parameter(elementType, "e");
                var idSelector = Expression.Lambda(Expression.Property(parameter, idProperty), parameter);

                var castMethod = typeof(Queryable).GetMethod(nameof(Queryable.Cast)).MakeGenericMethod(elementType);

                var collectionQuerableParameterType = Type.MakeGenericSignatureType(typeof(IMongoCollection<>), Type.MakeGenericMethodParameter(0));
                var collectionQueryableMethod = typeof(IMongoCollectionExtensions)
                    .GetMethod(
                        name: nameof(IMongoCollectionExtensions.AsQueryable),
                        genericParameterCount: 1,
                        bindingAttr: BindingFlags.Static | BindingFlags.Public,
                        binder: null,
                        types: new[] { collectionQuerableParameterType, typeof(AggregateOptions) },
                        modifiers: null
                        )
                    ?.MakeGenericMethod(elementType) ??
                    throw new NotSupportedException($"{nameof(IMongoCollectionExtensions.AsQueryable)} for {typeof(IMongoCollection<>).MakeGenericType(elementType)} not found")
                    ;

                var selectorExpressionType = typeof(Expression<>).MakeGenericType(
                    Type.MakeGenericSignatureType(typeof(Func<,>),
                        Type.MakeGenericMethodParameter(0),
                        Type.MakeGenericMethodParameter(1))
                    );
                var queryableSelectorOpen = typeof(Queryable).GetMethod(nameof(Queryable.Select), 2, new[]
                {
                    Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(0)),
                    selectorExpressionType
                });
                var closedArrayQueryMethod = queryableSelectorOpen.MakeGenericMethod(elementType, idProperty.PropertyType);


                var enumerableParameterType = Type.MakeGenericSignatureType(typeof(IEnumerable<>), Type.MakeGenericMethodParameter(0));
                var toArrayMethod = typeof(Enumerable)
                    .GetMethod(
                        name: nameof(Enumerable.ToArray),
                        genericParameterCount: 1,
                        bindingAttr: BindingFlags.Static | BindingFlags.Public,
                        binder: null,
                        types: new[] { enumerableParameterType },
                        modifiers: null
                        );
                var closedIdToArrayMethod = toArrayMethod.MakeGenericMethod(idProperty.PropertyType);
                var closedElementToArrayMethod = toArrayMethod.MakeGenericMethod(elementType);

                var openExceptMethod = typeof(Enumerable)
                    .GetMethod(
                        name: nameof(Enumerable.Except),
                        genericParameterCount: 1,
                        bindingAttr: BindingFlags.Static | BindingFlags.Public,
                        binder: null,
                        types: new[] { enumerableParameterType, enumerableParameterType },
                        modifiers: null
                        );
                var closedExceptMethod = openExceptMethod.MakeGenericMethod(idProperty.PropertyType);

                var keyLookupTypeFunc = Type.MakeGenericSignatureType(
                    typeof(Func<,>),
                    Type.MakeGenericMethodParameter(0),
                    Type.MakeGenericMethodParameter(1)
                    );
                var expressionKeyLookupType = typeof(Expression<>).MakeGenericType(keyLookupTypeFunc);
                var queryableParameterType0 = Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(0));
                var queryableParameterType1 = Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(1));
                var openExceptByMethod = typeof(Queryable)
                    .GetMethod(
                        name: nameof(Queryable.ExceptBy),
                        genericParameterCount: 2,
                        bindingAttr: BindingFlags.Static | BindingFlags.Public,
                        binder: null,
                        types: new[] { queryableParameterType0, queryableParameterType1, expressionKeyLookupType },
                        modifiers: null
                        );
                var closedExceptByMethod = openExceptByMethod.MakeGenericMethod(elementType, idProperty.PropertyType);

                var insertManyMethod = collectionType
                    .GetMethod(
                        name: "InsertMany",
                        bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                        binder: null,
                        types: new[] {
                            typeof(IEnumerable<>).MakeGenericType(elementType),
                            typeof(InsertManyOptions),
                            typeof(CancellationToken),
                            },
                        modifiers: null
                        );

                if (data.GetType().IsAssignableTo(collectionType) && result is object[] array)
                {
                    var queryableArray = castMethod.Invoke(null, new object[] { array.AsQueryable() });

                    var queryableCollection = collectionQueryableMethod.Invoke(null, new object[] { data, null });
                    var collectionIdsQuery = closedArrayQueryMethod.Invoke(null, new object[] { queryableCollection, idSelector });
                    var collectionIds = closedIdToArrayMethod.Invoke(null, new object[] { collectionIdsQuery });

                    var missingElements = closedExceptByMethod.Invoke(null, new object[] { queryableArray, collectionIds, idSelector });
                    var missingElementsArray = (Array)closedElementToArrayMethod.Invoke(null, new object[] { missingElements });

                    if (missingElementsArray.Length == 0)
                    {
                        _log.LogInformation(
                            $"Imported: no records into {{{nameof(collectionName)}}} from \"{{{nameof(sourceFile)}}}\"",
                            collectionName,
                            sourceFile
                            );
                    }
                    else
                    {
                        insertManyMethod.Invoke(data, new object[] { missingElementsArray, null, CancellationToken.None });

                        _log.LogInformation(
                            $"Imported: #{{count}} into {{{nameof(collectionName)}}} from \"{{{nameof(sourceFile)}}}\"",
                            missingElementsArray.Length,
                            collectionName,
                            sourceFile
                            );
                    }
                }

            }
            catch (Exception ex)
            {
                _log.LogError($"{{{nameof(collection)}}}::{{{nameof(instance)}}} -> {{{nameof(ex.Message)}}}", collection, instance, ex.Message);
                _log.LogDebug($"{{{nameof(collection)}}}::{{{nameof(instance)}}} -> {{{nameof(Exception)}}}", collection, instance, ex);
            }
        }


        public async Task DropCollectionAsync(PropertyInfo collection, object instance, CancellationToken cancellationToken)
        {
            try
            {
                var elementType = collection.PropertyType.GetGenericArguments()[0];
                var setType = elementType.MakeArrayType();
                var collectionName = collection.GetCustomAttributes<CollectionNameAttribute>().FirstOrDefault()?.CollectionName ?? elementType.Name;

                _log.LogInformation($"Deleting: {{{nameof(collectionName)}}}", collectionName);

                var data = collection.GetValue(instance);
                var db = (IMongoDatabase)data.GetType().GetProperty("Database").GetValue(data);
                await db.DropCollectionAsync(collectionName);

                _log.LogInformation($"Deleted: {{{nameof(collectionName)}}}", collectionName);
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
                    else if (_settings.Action == DataLoaderActions.DropCollection)
                    {
                        await DropCollectionAsync(collection, db.database, cancellationToken);
                    }
                    else if (_settings.Action == DataLoaderActions.DropCollectionAndImport)
                    {
                        await DropCollectionAsync(collection, db.database, cancellationToken);
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