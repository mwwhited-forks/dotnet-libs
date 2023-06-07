using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.TestUtilities.Tests
{
    [TestClass]
    public class TestContextWrapperTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ResolveTypeTest()
        {
            // Test
            var testContextWrapper = new TestContextWrapper(this.TestContext);

            var result = testContextWrapper.ResolveType();

            // Assert
            Assert.AreEqual(typeof(TestContextWrapperTests), result);
        }
    }
}
