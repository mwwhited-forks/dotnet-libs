using Eliassen.System.Tests.TestTargets;
using Eliassen.System.Text.Json;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Eliassen.System.Tests.Text.Json;

[TestClass]
public class BsonSerializerTests
{
    public required TestContext TestContext { get; set; }

    private static JsonSerializerOptions GetOptions() => new()
    {
        TypeInfoResolver = new BsonTypeInfoResolver(),
        WriteIndented = true,
    };

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public void Test()
    {
        var model = new TargetModel();
        var json = JsonSerializer.Serialize(model, model.GetType(), GetOptions());

        TestContext.WriteLine(json);
    }
}
