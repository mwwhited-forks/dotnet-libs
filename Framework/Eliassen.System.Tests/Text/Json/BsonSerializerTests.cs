using Eliassen.System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Eliassen.System.Tests.Text.Json;

[TestClass]
public class BsonSerializerTests
{
    public TestContext TestContext { get; set; } = null!;

    public JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions
        {
            TypeInfoResolver = new BsonTypeInfoResolver(),
            WriteIndented = true,
        };
    }

    [TestMethod]
    public void Test(JsonSerializerOptions options)
    {
        TargetModel model = new();
        var json = JsonSerializer.Serialize(model, model.GetType(), options);

        this.TestContext.WriteLine(json);
    }
}
