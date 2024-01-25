using Eliassen.System.Tests.Text.Json.TestTargets;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;

namespace Eliassen.System.Tests.Text.Json;

[TestClass]
public class BsonDateConverterTests
{
    public TestContext TestContext { get; set; } = null!;

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void SerializeTest_Nullable()
    {
        var expected = DateTimeOffset.Now;

        var result = JsonSerializer.Serialize(new TestDateProperty
        {
            Nullable = expected,
        });

        this.TestContext.AddResult(result, fileName: "result.json");

        var document = JsonDocument.Parse(result);
        var selected = document.RootElement.GetProperty("Nullable").GetProperty("$date").GetString() ??
            throw new NotSupportedException();
        this.TestContext.WriteLine(selected);

        var parsed = DateTimeOffset.Parse(selected);
        Assert.AreEqual(expected, parsed);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void SerializeTest_Value()
    {
        var expected = DateTimeOffset.Now;

        var result = JsonSerializer.Serialize(new TestDateProperty
        {
            Value = expected,
        });

        this.TestContext.AddResult(result, fileName: "result.json");

        var document = JsonDocument.Parse(result);
        var selected = document.RootElement.GetProperty("Value").GetProperty("$date").GetString() ??
            throw new NotSupportedException();
        this.TestContext.WriteLine(selected);

        var parsed = DateTimeOffset.Parse(selected);
        Assert.AreEqual(expected, parsed);
    }

    [DataTestMethod]
    [TestCategory(TestCategories.Unit)]
    [DataRow(@"{""Nullable"":{""$date"":""2023-07-05T14:16:32.2015217-04:00""},""Value"":{""$date"":""0001-01-01T00:00:00+00:00""}}", "2023-07-05T14:16:32.2015217-04:00")]
    [DataRow(@"{""Nullable"":null,""Value"":{""$date"":""2023-07-05T14:17:05.2315812-04:00""}}", null)]
    public void DeserializeTest_Nullable(string input, string? expected)
    {
        this.TestContext.AddResult(input, fileName: "input.json");
        var result = JsonSerializer.Deserialize<TestDateProperty>(input);
        this.TestContext.AddResult(result, fileName: "result.json");

        var parsed = expected == null ? (DateTimeOffset?)null : DateTimeOffset.Parse(expected);
        Assert.AreEqual(parsed, result?.Nullable);
    }

    [DataTestMethod]
    [TestCategory(TestCategories.Unit)]
    [DataRow(@"{""Nullable"":{""$date"":""2023-07-05T14:16:32.2015217-04:00""},""Value"":{""$date"":""0001-01-01T00:00:00+00:00""}}", "0001-01-01T00:00:00+00:00")]
    [DataRow(@"{""Nullable"":null,""Value"":{""$date"":""2023-07-05T14:17:05.2315812-04:00""}}", "2023-07-05T14:17:05.2315812-04:00")]
    public void DeserializeTest_Value(string input, string? expected)
    {
        this.TestContext.AddResult(input, fileName: "input.json");
        var result = JsonSerializer.Deserialize<TestDateProperty>(input);
        this.TestContext.AddResult(result, fileName: "result.json");

        var parsed = expected == null ? (DateTimeOffset?)null : DateTimeOffset.Parse(expected);
        Assert.AreEqual(parsed, result?.Value);
    }
}
