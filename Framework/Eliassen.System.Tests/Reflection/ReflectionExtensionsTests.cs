using Eliassen.System.Reflection;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Eliassen.System.Tests.Reflection
{
    [TestClass]
    public class ReflectionExtensionsTests
    {
        public static IEnumerable<object?[]> MakeSafeTestData() => new[]
        {
            new object?[]{typeof(string), "Hello World", "Hello World" },
            new object?[]{typeof(string), 1, "1" },
            new object?[]{typeof(byte[]), Convert.ToBase64String(new byte[] { 65, 66, 67 }), new byte[] {65,66,67 } },

            new object?[]{typeof(Guid), "18AACB9C-2989-4322-A490-C7167BEA0DB4", new Guid("18AACB9C-2989-4322-A490-C7167BEA0DB4") },
            new object?[]{typeof(Guid?), "18AACB9C-2989-4322-A490-C7167BEA0DB4", new Guid("18AACB9C-2989-4322-A490-C7167BEA0DB4") },
            new object?[]{typeof(Guid), "nope", null },
            new object?[]{typeof(Guid?), "nope", null },

            new object?[]{typeof(int), "1", 1 },
            new object?[]{typeof(int?), "1", 1 },
            new object?[]{typeof(int), "nope", null },
            new object?[]{typeof(int?), "nope", null },
            new object?[]{typeof(int), 1.1d, 1 },

            new object?[]{typeof(double), "1", 1d },
            new object?[]{typeof(double?), "1", 1d },
            new object?[]{typeof(double), "nope", null },
            new object?[]{typeof(double?), "nope", null },

            new object?[]{typeof(decimal), "1", 1m },
            new object?[]{typeof(decimal?), "1", 1m },
            new object?[]{typeof(decimal), "nope", null },
            new object?[]{typeof(decimal?), "nope", null },
            new object?[]{typeof(decimal), 1.0d, 1m },
            new object?[]{typeof(decimal), 1L, 1m },
            new object?[]{typeof(decimal), (byte)1, 1m },
            new object?[]{typeof(decimal), (short)1, 1m },

            new object?[]{typeof(DateTime), new DateTime(2022,3,16).ToString(), new DateTime(2022,3,16)},
            new object?[]{typeof(DateTimeOffset), new DateTimeOffset(new DateTime(2022, 3, 16), new TimeSpan(5,0,0)).ToString(), new DateTimeOffset(new DateTime(2022, 3, 16), new TimeSpan(5,0,0))},
            new object?[]{typeof(DateTime), "3/16/2022", new DateTime(2022,3,16)},
            new object?[]{typeof(TimeSpan), "16:00", new TimeSpan(16,0,0)},

            new object?[]{typeof(AttributeTargets), AttributeTargets.Enum, AttributeTargets.Enum },
            new object?[]{typeof(AttributeTargets), AttributeTargets.Enum.ToString(), AttributeTargets.Enum },
            new object?[]{typeof(AttributeTargets), (int)AttributeTargets.Enum, AttributeTargets.Enum },
            new object?[]{typeof(AttributeTargets?), AttributeTargets.Enum, AttributeTargets.Enum },
            new object?[]{typeof(AttributeTargets), "nope", null },
            new object?[]{typeof(AttributeTargets?), "nope", null },
        };

        [DataTestMethod]
        [TestCategory(TestCategories.Unit)]
        [DynamicData(nameof(MakeSafeTestData), DynamicDataSourceType.Method)]
        public void MakeSafeTest(Type? type, object? input, object? expected)
        {
            var result = ReflectionExtensions.MakeSafe(type, input);

            if (expected is not string && expected is Array expectedCollection && result is Array resultCollection)
            {
                CollectionAssert.AreEquivalent(expectedCollection, resultCollection);
            }
            else
            {
                Assert.AreEqual(expected, result);
            }
        }

        public static IEnumerable<object?[]> MakeSafeArrayTestData() => new[]
        {
            new object[]{typeof(string), new object[] { "Hello World", 1 },new[] { "Hello World", "1" } },
            new object[]{typeof(string), Array.Empty<object>(), Array.Empty<string>() },
            new object[]{typeof(decimal), new object[] { 1,2.3,2.4m, "1.2" }, new decimal[] {1m, 2.3m,2.4m,1.2m, } },
        };

        [DataTestMethod]
        [TestCategory(TestCategories.Unit)]
        [DynamicData(nameof(MakeSafeArrayTestData), DynamicDataSourceType.Method)]
        public void MakeSafeArrayTest(Type? type, Array? input, Array? expected)
        {
            var result = (Array?)ReflectionExtensions.MakeSafeArray(type, input);
            CollectionAssert.AreEquivalent(expected, result);
        }

        public static IEnumerable<object?[]> TryParseTestData() => new[]
        {
            new object?[]{typeof(Guid), "18AACB9C-2989-4322-A490-C7167BEA0DB4", true, new Guid("18AACB9C-2989-4322-A490-C7167BEA0DB4") },
            new object?[]{typeof(Guid?), "18AACB9C-2989-4322-A490-C7167BEA0DB4", true, new Guid("18AACB9C-2989-4322-A490-C7167BEA0DB4") },
            new object?[]{typeof(Guid), "nope", false, null },
            new object?[]{typeof(Guid?), "nope", false, null },

            new object?[]{typeof(int), "1", true, 1 },
            new object?[]{typeof(int?), "1", true, 1 },
            new object?[]{typeof(int), "nope", false, null },
            new object?[]{typeof(int?), "nope", false, null },

            new object?[]{typeof(double), "1", true, 1d },
            new object?[]{typeof(double?), "1", true, 1d },
            new object?[]{typeof(double), "nope", false, null },
            new object?[]{typeof(double?), "nope", false, null },

            new object?[]{typeof(decimal), "1", true, 1m },
            new object?[]{typeof(decimal?), "1", true, 1m },
            new object?[]{typeof(decimal), "nope", false, null },
            new object?[]{typeof(decimal?), "nope", false, null },

            new object?[]{typeof(AttributeTargets), AttributeTargets.Enum.ToString(), true, AttributeTargets.Enum },
        };


        [DataTestMethod]
        [TestCategory(TestCategories.Unit)]
        [DynamicData(nameof(TryParseTestData), DynamicDataSourceType.Method)]
        public void TryParseTest(Type? type, string? input, bool passed, object? expected)
        {
            var output = ReflectionExtensions.TryParse(type, input, out var result);
            Assert.AreEqual(passed, output);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [TestCategory(TestCategories.Unit)]
        [DataRow(typeof(string), "System.String, System.Private.CoreLib")]
        [DataRow(typeof(ReflectionExtensionsTests), "Eliassen.System.Tests.Reflection.ReflectionExtensionsTests, Eliassen.System.Tests")]
        public void GetShortTypeNameTests(Type type, string expected)
        {
            Assert.AreEqual(type.GetShortTypeName(), expected);
        }
    }
}
