using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eliassen.MongoDB.Extensions
{
    /// <summary>
    /// This proxy allow for dynamic creation of wrapper classes to expose MongoDatabase instances
    /// </summary>
    internal class MongoDispatchProxy : DispatchProxy
    {
        private IMongoDatabase _database = null!;
        private IMongoSettings _settings = null!;

        private readonly Dictionary<MethodInfo, object> _collections = new();

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (targetMethod == null) throw new ArgumentNullException(nameof(targetMethod));

            if (_collections.TryGetValue(targetMethod, out var ret))
            {
                return ret;
            }

            var name = targetMethod.Name.StartsWith("get_") ? targetMethod.Name[4..] : targetMethod.Name;

            name = targetMethod.DeclaringType?.GetProperty(name)
                ?.GetCustomAttributes()
                ?.OfType<CollectionNameAttribute>()
                ?.FirstOrDefault()?.CollectionName ?? name;

            var collectionType = targetMethod.ReturnType.GetGenericArguments()[0];
            var collection = _database.GetType()
                ?.GetMethod(nameof(IMongoDatabase.GetCollection))
                ?.MakeGenericMethod(collectionType)
                ?.Invoke(_database, new object?[]
                {
                    name,
                    null //MongoCollectionSettings
                })
                ?? throw new NotSupportedException();

            if (_collections.TryGetValue(targetMethod, out ret))
            {
                return ret;
            }

            _collections.Add(targetMethod, collection);
            return collection;
        }

        public static T Create<T>(IMongoDatabase database, IMongoSettings settings)
        {
            object instance = Create<T, MongoDispatchProxy>() ?? throw new NotSupportedException();
            ((MongoDispatchProxy)instance)._database = database;
            ((MongoDispatchProxy)instance)._settings = settings;
            return (T)instance;
        }
    }
}