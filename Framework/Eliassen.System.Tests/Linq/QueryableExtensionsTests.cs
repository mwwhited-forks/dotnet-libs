using Eliassen.System.Linq;
using Eliassen.System.Linq.Search;
using Eliassen.System.Reflection;
using Eliassen.System.Tests.Linq.TestTargets;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eliassen.System.Tests.Linq
{

    [TestClass]
    public class QueryableExtensionsTests
    {
        public TestContext? TestContext { get; set; }

        private static IQueryable GetTestData(Type type) =>
            type == typeof(TestTargetModel) ? GetTestData() :
            type == typeof(TestTargetExtendedModel) ? GetTestDataExtended() :
            throw new NotSupportedException();

        private static IQueryable<TestTargetModel> GetTestData() =>
            Enumerable
            .Range(0, QueryableExtensions.DefaultPageSize * 100)
            .Select(i => new TestTargetModel(i))
            .AsQueryable()
            ;
        private static IQueryable<TestTargetExtendedModel> GetTestDataExtended() =>
            Enumerable
            .Range(0, QueryableExtensions.DefaultPageSize * 100)
            .Select(i => new TestTargetExtendedModel(i))
            .AsQueryable()
            ;

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void DefaultPageSizeTest()
        {
            Assert.AreEqual(10, QueryableExtensions.DefaultPageSize);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_FromJson()
        {
            var json = @"{
  ""CurrentPage"": 0,
  ""PageSize"": 0,
  ""ExcludePageCount"": false,
  ""SearchTerm"": ""Name*"",
  ""Filter"": {
    ""Index"": { ""in"": [
      1,
      2,
      3
    ]}
  },
  ""OrderBy"": {
    ""Email"": ""desc""
  }
}";

            var query = JsonSerializer.Deserialize<SearchQuery>(json);

            this.TestContext.AddResult(query);

            var data = GetTestData();
            var queryResults = data.ExecuteBy(query ?? throw new NotSupportedException());
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(3, results.Rows.Count());
            Assert.AreEqual("3,2,1", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_FromJson_Lowercase()
        {
            var json = @"{
  ""CurrentPage"": 0,
  ""PageSize"": 0,
  ""ExcludePageCount"": false,
  ""SearchTerm"": ""Name*"",
  ""Filter"": {
    ""index"": { ""in"": [
      1,
      2,
      3
    ]}
  },
  ""OrderBy"": {
    ""email"": ""desc""
  }
}";
            var query = JsonSerializer.Deserialize<SearchQuery>(json);

            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query ?? throw new NotSupportedException());
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(3, results.Rows.Count());
            Assert.AreEqual("3,2,1", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public async Task ExecuteByAsyncTest_Filter_FromJson_Async()
        {
            var json = @"{
  ""CurrentPage"": 0,
  ""PageSize"": 0,
  ""ExcludePageCount"": false,
  ""SearchTerm"": ""Name*"",
  ""Filter"": {
    ""Index"": { ""in"": [
      1,
      2,
      3
    ] }
  },
  ""OrderBy"": {
    ""Email"": ""desc""
  }
}";

            var query = JsonSerializer.Deserialize<SearchQuery>(json);

            this.TestContext.AddResult(query);
            var queryResults = await GetTestData().ExecuteByAsync(query ?? throw new NotSupportedException());
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(3, results.Rows.Count());
            Assert.AreEqual("3,2,1", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [DataTestMethod]
        [TestCategory(TestCategories.Unit)]
        [DataRow(nameof(TestTargetModel.Index), Operators.EqualTo, 1, 1, "1", DisplayName = "Filter Equals (int)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.EqualTo, "Name3", 1, "3", DisplayName = "Filter Equals (string)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.InSet, new[] { "Name1", "Name2", "Name3" }, 3, "1,2,3", DisplayName = "Contains in Set (string)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.InSet, new[] { 1, 2, 3 }, 3, "1,2,3", DisplayName = "Contains in Set (int)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.LessThan, 5, 5, "0,1,2,3,4", DisplayName = "LessThan (int)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.LessThan, "5", 5, "0,1,2,3,4", DisplayName = "LessThan (string parsed)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.LessThanOrEqualTo, "5", 6, "0,1,2,3,4,5", DisplayName = "LessThan (string parsed)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.GreaterThan, 995, 4, "996,997,998,999", DisplayName = "GreaterThan  (int)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.GreaterThanOrEqualTo, 995, 5, "995,996,997,998,999", DisplayName = "GreaterThanOrEqualTo  (int)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.EqualTo, "*03", 9, "103,203,303,403,503,603,703,803,903", DisplayName = "Ends With (string)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.EqualTo, "*e2*", 10, "2,20,21,22,23,24,25,26,27,28", DisplayName = "Contains (string)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.EqualTo, "Name1*", 10, "1,10,11,12,13,14,15,16,17,18", DisplayName = "Starts With (string)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.NotEqualTo, "*03", 1, "103,203,303,403,503,603,703,803,903", DisplayName = "Not Ends With (string)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.NotEqualTo, "*e2*", 10, "2,20,21,22,23,24,25,26,27,28", DisplayName = "Not Contains (string)")]
        [DataRow(nameof(TestTargetModel.Name), Operators.NotEqualTo, "Name1*", 10, "1,10,11,12,13,14,15,16,17,18", DisplayName = "Not Starts With (string)")]
        [DataRow(nameof(TestTargetModel.Index), Operators.NotEqualTo, 1, 1, "1", DisplayName = "Not Filter Equals (int)")]
        public void ExecuteByTest_Filter(string propertyName, Operators expressionOperator, object filterValue, int expectedRows, string expectedKeys)
        {
            var query = new SearchQuery
            {
                Filter = new()
                {
                    { propertyName, expressionOperator.AsFilter(filterValue ) }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);
            var resultKeys = string.Join(',', results.Rows.Select(i => i?.GetKeyValue()));
            this.TestContext.WriteLine($"{nameof(resultKeys)}: {resultKeys}");

            Assert.AreEqual(expectedRows, results.Rows.Count());
            if (expectedKeys != null)
                Assert.AreEqual(expectedKeys, resultKeys);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Range_GT()
        {
            var query = new SearchQuery
            {
                Filter =
                {
                    { nameof(TestTargetExtendedModel.Date),
                        new FilterParameter{
                            GreaterThan = TestTargetExtendedModel.BaseDate.AddMonths(2),
                        } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(997, results.TotalRowCount);
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Range_GTE()
        {
            var query = new SearchQuery
            {
                Filter =
                {
                    { nameof(TestTargetExtendedModel.Date),
                        new FilterParameter{
                            GreaterThanOrEqualTo = TestTargetExtendedModel.BaseDate.AddMonths(2),
                        } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(998, results.TotalRowCount);
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Range_LT()
        {
            var query = new SearchQuery
            {
                Filter =
                {
                    { nameof(TestTargetExtendedModel.Date),
                        new FilterParameter{
                            LessThan = TestTargetExtendedModel.BaseDate.AddMonths(2),
                        } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(2, results.TotalRowCount);
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Range_LTE()
        {
            var query = new SearchQuery
            {
                Filter =
                {
                    { nameof(TestTargetExtendedModel.Date),
                        new FilterParameter{
                            LessThanOrEqualTo = TestTargetExtendedModel.BaseDate.AddMonths(2),
                        } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(3, results.TotalRowCount);
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Range_Bounds()
        {
            var query = new SearchQuery
            {
                Filter =
                {
                    { nameof(TestTargetExtendedModel.Date),
                        new FilterParameter{
                            GreaterThanOrEqualTo = TestTargetExtendedModel.BaseDate.AddMonths(2),
                            LessThanOrEqualTo = TestTargetExtendedModel.BaseDate.AddMonths(6),
                        }
                    }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(5, results.TotalRowCount);
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_PredicateLookup()
        {
            var query = new SearchQuery
            {
                Filter =
                {
                    { TestTargetExtendedModel.FC, new FilterParameter{ EqualTo = "ame1" } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(1, results.TotalRowCount);
        }


        [DataTestMethod]
        [TestCategory(TestCategories.Unit)]
        [DataRow(typeof(TestTargetModel), "Name3", 1, 1, 1, "3", DisplayName = "Equals")]
        [DataRow(typeof(TestTargetModel), "Name3*", 12, 111, 10, "3,30,31,32,33,34,35,36,37,38", DisplayName = "Starts With")]
        [DataRow(typeof(TestTargetModel), "*3", 10, 100, 10, "3,13,23,33,43,53,63,73,83,93", DisplayName = "Ends With")]
        [DataRow(typeof(TestTargetModel), "*e3*", 12, 111, 10, "3,30,31,32,33,34,35,36,37,38", DisplayName = "Contains")]
        public void ExecuteByTest_SearchTerm(Type type, string searchTerm, int expectedTotalPages, int expectedTotalRows, int expectedRows, string expectedKeys)
        {
            this.GetType().GetMethods()
                .Where(mi => mi.IsGenericMethod)
                .Where(mi => mi.Name == nameof(ExecuteByTest_SearchTerm))
                .Select(mi => mi.MakeGenericMethod(type))
                .First()
                .Invoke(this, new object[]
                {
                    searchTerm,
                    expectedTotalPages,
                    expectedTotalRows,
                    expectedRows,
                    expectedKeys
                });
        }
        public void ExecuteByTest_SearchTerm<T>(string searchTerm, int expectedTotalPages, int expectedTotalRows, int expectedRows, string expectedKeys)
        {
            var query = new SearchQuery<T>
            {
                SearchTerm = searchTerm,
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData(typeof(T)).ExecuteBy(query);
            this.TestContext.AddResult(queryResults);
            var results = queryResults as IPagedQueryResult<T>;
            Assert.IsNotNull(results);
            var resultKeys = string.Join(',', results.Rows.Select(i => i?.GetKeyValue()));
            this.TestContext.WriteLine($"{nameof(resultKeys)}: {resultKeys}");
            Assert.AreEqual(expectedTotalPages, results.TotalPageCount);
            Assert.AreEqual(expectedTotalRows, results.TotalRowCount);
            Assert.AreEqual(expectedRows, results.Rows.Count());
            Assert.AreEqual(expectedKeys, resultKeys);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Page_Default()
        {
            var query = new SearchQuery
            {
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(100, results.TotalPageCount);
            Assert.AreEqual(1000, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("0,1,2,3,4,5,6,7,8,9", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Page_2()
        {
            var query = new SearchQuery
            {
                CurrentPage = 1,
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(100, results.TotalPageCount);
            Assert.AreEqual(1000, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("10,11,12,13,14,15,16,17,18,19", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Page_2_Length5()
        {
            var query = new SearchQuery
            {
                CurrentPage = 1,
                PageSize = 5
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(200, results.TotalPageCount);
            Assert.AreEqual(1000, results.TotalRowCount);
            Assert.AreEqual(5, results.Rows.Count());
            Assert.AreEqual("5,6,7,8,9", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Sort_Descending_ShortString()
        {
            var query = new SearchQuery
            {
                OrderBy = new()
                {
                    { nameof(TestTargetModel.Name), OrderDirections.Descending }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(100, results.TotalPageCount);
            Assert.AreEqual(1000, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("999,998,997,996,995,994,993,992,991,990", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Sort_Descending_Enum()
        {
            var query = new SearchQuery
            {
                OrderBy = new()
                {
                    { nameof(TestTargetModel.Name), OrderDirections.Descending }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(100, results.TotalPageCount);
            Assert.AreEqual(1000, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("999,998,997,996,995,994,993,992,991,990", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Sort_Descending_Value()
        {
            var query = new SearchQuery
            {
                OrderBy = new Dictionary<string, OrderDirections>
                 {
                    { nameof(TestTargetModel.Name), (OrderDirections)1 }
                 }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(100, results.TotalPageCount);
            Assert.AreEqual(1000, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("999,998,997,996,995,994,993,992,991,990", string.Join(',', results.Rows.Select(i => i.Index)));
        }
    }
}
