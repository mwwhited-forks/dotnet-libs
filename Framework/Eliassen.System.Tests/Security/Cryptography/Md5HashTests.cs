using Eliassen.System.Security.Cryptography;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.System.Tests.Security.Cryptography;

[TestClass]
public class Md5HashTests
{
    public TestContext TestContext { get; set; } = null!;

    [DataTestMethod]
    [TestCategory(TestCategories.Unit)]
    [DataRow("Hello World!", "7Qdih1MuhjZehB6Sv8UNjA==")]
    [DataRow("hello world", "XrY7u+Ae7tCTyyK7j1rNww==")]
    public void GetHash(string input, string expected)
    {
        var hash = new Md5Hash();
        var hashed = hash.GetHash(input);
        TestContext.WriteLine($"\"{input}\" => \"{hashed}\"");
        Assert.AreEqual(expected, hashed);
    }
}

