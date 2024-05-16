using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class ApacheTikaHealthCheckTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void Test()
    {
        var mockRepo = new MockRepository(MockBehavior.Strict);
        var mockClient = mockRepo.Create<IApacheTikaClient>();

        var check = new ApacheTikaHealthCheck(mockClient.Object);

        check.CheckHealthAsync(context.)

        mockRepo.VerifyAll();
    }
}
