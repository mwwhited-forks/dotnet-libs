using Eliassen.System.Text.Json;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json.Nodes;

namespace Eliassen.System.Tests.Text.Json;

[TestClass]
public class JNodeExtensionsTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void ToXNodeTest_Simple()
    {
        var jsonText = "{\"prop1\":\"value\"}";
        var json = JsonNode.Parse(jsonText);
        var xml = json.ToXFragment();
        Assert.IsNotNull(xml);

        this.TestContext.WriteLine(jsonText);
        this.TestContext.WriteLine(new string('=', 40));
        this.TestContext.WriteLine(xml);
        this.TestContext.AddResult(xml);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void ToXNodeTest_Number()
    {
        var jsonText = "30";
        var json = JsonNode.Parse(jsonText);
        var xml = json.ToXFragment();
        Assert.IsNotNull(xml);

        this.TestContext.WriteLine(jsonText);
        this.TestContext.WriteLine(new string('=', 40));
        this.TestContext.WriteLine(xml);
        this.TestContext.AddResult(xml);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void ToXNodeTest_String()
    {
        var jsonText = "\"Hello!\"";

        var json = JsonNode.Parse(jsonText);
        var xml = json.ToXFragment();
        Assert.IsNotNull(xml);

        this.TestContext.WriteLine(jsonText);
        this.TestContext.WriteLine(new string('=', 40));
        this.TestContext.WriteLine(xml);
        this.TestContext.AddResult(xml);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void ToXNodeTest_Array()
    {
        var jsonText = "[\"Hello!\",1,3,false,null,true,4.5]";
        var json = JsonNode.Parse(jsonText);
        var xml = json.ToXFragment();
        Assert.IsNotNull(xml);

        this.TestContext.WriteLine(jsonText);
        this.TestContext.WriteLine(new string('=', 40));
        this.TestContext.WriteLine(xml);
        this.TestContext.AddResult(xml);
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void ToXNodeTest_Complex()
    {
        var jsonText = @"{
  ""name"": ""John Doe"",
  ""age"": 30,
  ""city"": ""New York"",
  ""isMarried"": true,
  ""children"": [
    {
      ""name"": ""Alice"",
      ""age"": 5
    },
    {
      ""name"": ""Bob"",
      ""age"": 8
    }
  ]
}
";
        var json = JsonNode.Parse(jsonText);
        var xml = json.ToXFragment();
        Assert.IsNotNull(xml);

        this.TestContext.WriteLine(jsonText);
        this.TestContext.WriteLine(new string('=', 40));
        this.TestContext.WriteLine(xml);
        this.TestContext.AddResult(xml);
    }
}
