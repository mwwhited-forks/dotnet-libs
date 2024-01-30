using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Eliassen.System.Text.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Eliassen.System.Tests.Text;

[TestClass]
public class SerializerSelectorTest
{
    public required TestContext TestContext { get; set; }

    [DataTestMethod]
    [DataRow(SerializerTypes.Json, typeof(DefaultJsonSerializer))]
    [DataRow(SerializerTypes.Bson, typeof(DefaultBsonSerializer))]
    [DataRow(SerializerTypes.Xml, typeof(DefaultXmlSerializer))]
    public void DefaultSerializerTest(SerializerTypes targetSerializerType, Type expectedType)
    {
        var config = new ConfigurationBuilder().Build();
        var services = new ServiceCollection()
            .AddTransient<IConfiguration>(_ => config)
            .TryAddSystemExtensions(config, new()
            {
                DefaultSerializerType = targetSerializerType
            })
            .BuildServiceProvider()
            ;
        var serializer = services.GetRequiredService<ISerializer>();
        Assert.IsInstanceOfType(serializer, expectedType);
    }

    [DataTestMethod]
    [DataRow(SerializerTypes.Json, typeof(DefaultJsonSerializer))]
    [DataRow(SerializerTypes.Bson, typeof(DefaultBsonSerializer))]
    [DataRow(SerializerTypes.Xml, typeof(DefaultXmlSerializer))]
    [DataRow("JSON", typeof(DefaultJsonSerializer))]
    [DataRow("BSON", typeof(DefaultBsonSerializer))]
    [DataRow("XML", typeof(DefaultXmlSerializer))]
    public void KeyedSerializerTest(object targetSerializerType, Type expectedType)
    {
        var config = new ConfigurationBuilder().Build();
        var services = new ServiceCollection()
            .AddTransient<IConfiguration>(_ => config)
            .TryAddSystemExtensions(config)
            .BuildServiceProvider()
            ;
        var serializer = services.GetRequiredKeyedService<ISerializer>(targetSerializerType);
        Assert.IsInstanceOfType(serializer, expectedType);
    }
}
