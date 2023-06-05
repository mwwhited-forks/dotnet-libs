using Eliassen.TestUtilities.Assertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace Eliassen.TestUtilities.Tests.Assertions
{
    [TestClass]
    public class JsonComparerTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void AssertDifferencesTest()
        {
            // Test
            var data = new
            {
                Int = 123,
                String = "Test String",
                Guid = new Guid("38B7BA3D-321E-4D41-BC90-C58B921D8DF0"),
                Bytes = Encoding.UTF8.GetBytes("Hello World"),
                Object = new { Hello = "World!" },
                Array = new[] { "Test", " Data" },
            };

            JsonComparer.AssertDifferences(TestContext, data);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void AssertDifferencesTest_UnsortedArray()
        {
            // Test
            var rand = new Random();
            var data = Enumerable.Range(0, 10).OrderBy(_ => rand.NextDouble()).ToArray();
            JsonComparer.AssertDifferences(TestContext, data);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void AssertDifferencesTest_UnsortedComplex()
        {
            // Test
            var rand = new Random();
            var data = new
            {
                Value = "Hello",
                Array = Enumerable.Range(0, 10).OrderBy(_ => rand.NextDouble()).ToArray(),
                Again = new
                {
                    Hello = "World!",
                    Value = 1234.4,
                },
                Mixed = new object[]
                {
                    new { Hi="There"},
                    1,
                    3.4,
                    new Guid("e14dc8be-5306-475d-b75e-5dff6bf2b8a1"),
                    new { Bi="There"},
                    new { Bi="There2"},
                    new { Bi="There", ANother="one"},
                    new { Bi="There", ANother="tow"},
                    DateTimeOffset.Parse("2021-08-20T08:23:51.6310298-04:00").ToUniversalTime(),
                }
            };
            JsonComparer.AssertDifferences(TestContext, data);
        }
    }
}