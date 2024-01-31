using Eliassen.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Eliassen.MongoDB.Tests;

[TestClass]
public class MongoDBTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "MongoDatabase:DatabaseName" , "Test"},
                { "MongoDatabase:ConnectionString" , "mongodb://localhost:27017?collation={locale:'en_US',caseLevel:false,strength:2 }"},
            })
            ;
        var config = configBuilder.Build();

        var services = new ServiceCollection();
        services.TryAddMongoServices(config);
        services.TryAddSystemExtensions(config);

        services.TryAddMongoDatabase<ITestMongoDatabase>();
        var provider = services.BuildServiceProvider();

        var db = provider.GetRequiredService<ITestMongoDatabase>();

        var entity = new TestCollection
        {
            TestId = "655d21138c73243c786dbb72",
            Value1 = Guid.NewGuid().ToString(),
            Date = DateTimeOffset.Now,
        };

        var filter = new FilterDefinitionBuilder<TestCollection>
        {

        }.Where(e => e.TestId != null && e.TestId == entity.TestId); //.Eq(e =>  e.TestId, entity.TestId);

        //if (entity.TestId == null)
        //{
        //    db.Tests.InsertOne(entity);
        //}
        //else
        //{
        //    var ret = db.Tests.ReplaceOne(filter, entity);
        //}

        //var insertOptions = new InsertOneOptions
        //{
        //};
        //db.Tests.InsertOne(entity);

        var replaceOptions = new FindOneAndReplaceOptions<TestCollection>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After,
            BypassDocumentValidation = false,
        };
        var replaced = db.Tests.FindOneAndReplace(filter, entity, replaceOptions);

        //var updateDef = new UpdateDefinitionBuilder<TestCollection>()
        //    .Set(i => i.Value1, entity.Value1)
        //    ;
        //;
        //var udpateOptions = new FindOneAndUpdateOptions<TestCollection>
        //{
        //    IsUpsert = true,
        //    ReturnDocument = ReturnDocument.After,
        //};
        //var updated = db.Tests.FindOneAndUpdate(filter, updateDef, udpateOptions);

    }

    [TestMethod]
    public void TestMethod2()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "MongoDatabase:DatabaseName" , "Test"},
                { "MongoDatabase:ConnectionString" , "mongodb://localhost:27017?collation={locale:'en_US',caseLevel:false,strength:2 }"},
            })
            ;
        var config = configBuilder.Build();

        var services = new ServiceCollection();
        services.TryAddMongoServices(config);
        services.TryAddSystemExtensions(config);

        services.TryAddMongoDatabase<ITestMongoDatabase>();
        var provider = services.BuildServiceProvider();

        var db = provider.GetService<ITestMongoDatabase>();

        var entity = new TestCollection
        {
            //    TestId = "655d21138c73243c786dbb72",
            Value1 = Guid.NewGuid().ToString(),
            Date = DateTimeOffset.Now,
        };

        var filter = new FilterDefinitionBuilder<TestCollection>()
            .Where(e => e.TestId != null && e.TestId == entity.TestId);

        var replaceOptions = new FindOneAndUpdateOptions<TestCollection>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After,
            BypassDocumentValidation = false,
        };

        //var def = new UpdateDefinitionBuilder<TestCollection>().
        //    ;

        //var replaced = db.Tests.FindOneAndUpdate(
        //    filter, def, replaceOptions
        //    );

    }
}
