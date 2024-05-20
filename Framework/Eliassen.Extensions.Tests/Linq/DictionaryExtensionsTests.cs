using Eliassen.Extensions.Linq;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Eliassen.Extensions.Tests.Linq;

[TestClass]
public class DictionaryExtensionsTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void TryGetValueTest()
    {
        var dict = new Dictionary<string, string>()
        {
            {"HELLO", "world" },
        };

        Assert.IsTrue(dict.TryGetValue("hello", out var value, StringComparer.InvariantCultureIgnoreCase));
        Assert.AreEqual("world", value);
    }
}
