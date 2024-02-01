using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.MongoDB.Tests;

[TestClass]
public class MongoQueryFixes
{
    public required TestContext TestContext { get; set; }

    public void Test()
    {
        TestContext.WriteLine(TestContext.TestName);
    }

}
