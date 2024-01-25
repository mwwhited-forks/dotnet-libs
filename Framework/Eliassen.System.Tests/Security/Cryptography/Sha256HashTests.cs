﻿using Eliassen.System.Security.Cryptography;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.System.Tests.Security.Cryptography;

[TestClass]
public class Sha256HashTests
{
    public TestContext TestContext { get; set; } = null!;

    [DataTestMethod]
    [TestCategory(TestCategories.Unit)]
    [DataRow("Hello World!", "f4OxZX/x/FO5LcGBSKHWXfwtSx+j1ncoSt3SABJtkGk=")]
    [DataRow("hello world", "uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=")]
    public void GetHash(string input, string expected)
    {
        var hash = new Sha256Hash();
        var hashed = hash.GetHash(input);
        TestContext.WriteLine($"\"{input}\" => \"{hashed}\"");
        Assert.AreEqual(expected, hashed);
    }
}

