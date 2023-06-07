using Eliassen.TestUtilities.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.TestUtilities.Tests.Logging
{
    [TestClass]
    public class TestLoggerExtensionsTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void AddTestLoggingServicesTest()
        {
            var services = new ServiceCollection()
                .AddTestLoggingServices(TestContext)
                .BuildServiceProvider()
                ;

            var logger = services.GetRequiredService<ILogger<TestLoggerExtensionsTests>>();
            logger.LogInformation("Test Message");
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetTestLoggingServicesTest()
        {
            var logger = TestContext.GetTestLoggingServices<TestLoggerExtensionsTests>();
            Assert.IsNotNull(logger);
            logger.LogInformation("Test Message");
        }
    }
}
