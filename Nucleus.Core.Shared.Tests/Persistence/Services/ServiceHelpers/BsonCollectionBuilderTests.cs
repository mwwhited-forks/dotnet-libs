﻿using Eliassen.MongoDB.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;

namespace Nucleus.Core.Shared.Tests.Persistence.Services.ServiceHelpers
{
    public class TargetModel
    {
        public string Name { get; set; }
    }
    public class TargetCollection
    {
        // [BsonElement("Name")]
        public string? Name { get; set; }
    }


    [TestClass]
    public class BsonCollectionBuilderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildCollectionTest()
        {
            //MongoDB.Bson.Serialization.Conventions.

            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());

            ConventionRegistry.Register("Camel case convention", pack, t => true);

            var model = new TargetModel { Name = "hello", };

            var builder = new BsonCollectionBuilder<TargetModel, TargetCollection>();
            var collection = builder.BuildCollection(model);

            Assert.AreEqual(model.Name, collection.Name);
        }

        [TestMethod]
        public void BuildCollectionStringTest()
        {
            var f = new MongoDatabaseFactory(null);
            /*
 MongoDatabaseFactory : IMongoDatabaseFactory
            */

            var model = new TargetModel { Name = "hello", };
            var builder = new BsonCollectionBuilder<TargetModel, TargetCollection>();
            var text = builder.BuildCollectionString(model);

            TestContext.WriteLine(text);
        }

        /*
    public class BsonCollectionBuilder<T,TCollection>
    {
        public TCollection BuildCollection(T item)
        {
            var jsonDoc = JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ContractResolver = BsonContractResolver.Instance });
            return BsonSerializer.Deserialize<TCollection>(jsonDoc);
        }

        public string BuildCollectionString(T item) =>
            JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ContractResolver = BsonContractResolver.Instance });
    }
        */
    }
}
