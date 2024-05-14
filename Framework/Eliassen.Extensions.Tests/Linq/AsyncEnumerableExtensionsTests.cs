using Eliassen.Extensions.Linq;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Extensions.Tests.Linq;

[TestClass]
public class AsyncEnumerableExtensionsTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public async Task ToListAsyncTest()
    {
#pragma warning disable CS0619
        var results = await CreateTestData().ToListAsync();
#pragma warning restore CS0619
        Assert.AreEqual(10, results.Count());
    }

    private async IAsyncEnumerable<string> CreateTestData()
    {
        for (var x = 0; x < 10; x++)
        {
            await Task.Yield();
            yield return x.ToString();
        }
    }
}
