using Eliassen.System.Security.Cryptography;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.System.Tests.Security.Cryptography;

[TestClass]
public class Sha512HashTests
{
    public TestContext TestContext { get; set; } = null!;

    [DataTestMethod]
    [TestCategory(TestCategories.Unit)]
    [DataRow("Hello World!", "hhhE1nBOhXP+w02WfiC8/vPUJM9IvgTm3AjyvVjHKXQzcQFerYkcw88cnTS0kmS1EHUbH/nlN5N7xGtdb/TsyA==")]
    [DataRow("hello world", "MJ7MSJwS1utMxA9QyQLytNDtd+5RGnx6m808qG1M2G+YndNbxf9JlnDaNCVbRbDP2DDoH2Bdz33FVC6TrpzXbw==")]
    public void GetHash(string input, string expected)
    {
        var hash = new Sha512Hash();
        var hashed = hash.GetHash(input);
        TestContext.WriteLine($"\"{input}\" => \"{hashed}\"");
        Assert.AreEqual(expected, hashed);
    }
}

