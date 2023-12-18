using Eliassen.System.Text.Json.Serialization;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Eliassen.System.Tests.Text.Json.Serialization;

[TestClass]
public class DefaultJsonSerializerTests
{
    public TestContext TestContext { get; set; } = null!;

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void SerializeTest_Anonymous()
    {
        var serializer = new DefaultJsonSerializer();

        var input = new { Hello = "world" };
        var values = InOut(serializer, input);

        TestContext.AddResult(values.serialized);
        TestContext.AddResult(values.result);

        Assert.AreEqual(input, values.result);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void SerializeTest_AnonymousWithStringObjectDictionary()
    {
        var serializer = new DefaultJsonSerializer();

        var input = new
        {
            Hello = "world",
            Dict = new Dictionary<string, object>
            {
                {"one", 1L },
                {"two", 2L},
                { "three", "3"},
            },
        };

        var values = InOut(serializer, input);

        TestContext.AddResult(values.serialized);
        TestContext.AddResult(values.result);

        Assert.AreEqual(input.Hello, values.result.Hello);

        Assert.AreEqual(input.Dict["one"], values.result.Dict["one"]);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void SerializeTest_IConfigurationSection()
    {
        var serializer = new DefaultJsonSerializer();

        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            {"Configuration:Property", "test-value" },
        });
        var config = configBuilder.Build();
        IConfigurationSection input = config.GetSection("Configuration");
        IConfigurationRoot r = null;

        var values = InOut(serializer, input);

        TestContext.AddResult(values.serialized);
        TestContext.AddResult(values.result);

        Assert.AreEqual(input["Property"], values.result["Property"]);
    }


    private (string serialized, T result) InOut<T>(IJsonSerializer serializer, T input)
    {
        var serialized = serializer.Serialize(input);
        var result = serializer.Deserialize<T>(serialized);
        return (serialized, result);
    }
}
