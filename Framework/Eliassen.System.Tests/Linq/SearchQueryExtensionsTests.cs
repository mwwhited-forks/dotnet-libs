using Eliassen.System.Linq.Search;
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

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Index_Array()
        {
            var query = new SearchQuery
            {
                Filter = new()
                {
                    { nameof(TestTargetModel.Index), new FilterParameter{ InSet = new object?[] { 1, 2, 3 } } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(3, results.Rows.Count());
            Assert.AreEqual("1,2,3", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Index_Item()
        {
            var query = new SearchQuery
            {
                Filter = new()
                {
                    { nameof(TestTargetModel.Index), new FilterParameter{ EqualTo =  1 } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(1, results.Rows.Count());
            Assert.AreEqual("1", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Name_Array()
        {
            var query = new SearchQuery
            {
                Filter = new()
                {
                    { nameof(TestTargetModel.Name), new FilterParameter{ InSet =  new [] {"Name1","Name2","Name3" } } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(3, results.Rows.Count());
            Assert.AreEqual("1,2,3", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Filter_Name_Item()
        {
            var query = new SearchQuery
            {
                Filter = new()
                {
                    { nameof(TestTargetModel.Name), new FilterParameter{ EqualTo =  "Name3" } }
                }
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(1, results.Rows.Count());
            Assert.AreEqual("3", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Search_Item_Equals()
        {
            var query = new SearchQuery
            {
                SearchTerm = "Name3",
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(1, results.Rows.Count());
            Assert.AreEqual("3", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Search_Item_StartsWith()
        {
            var query = new SearchQuery
            {
                SearchTerm = "Name3*",
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(12, results.TotalPageCount);
            Assert.AreEqual(111, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("3,30,31,32,33,34,35,36,37,38", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Search_Item_EndsWith()
        {
            var query = new SearchQuery
            {
                SearchTerm = "*3",
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(10, results.TotalPageCount);
            Assert.AreEqual(100, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("3,13,23,33,43,53,63,73,83,93", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Search_Item_Contains()
        {
            var query = new SearchQuery
            {
                SearchTerm = "*e3*",
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestData().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(12, results.TotalPageCount);
            Assert.AreEqual(111, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("3,30,31,32,33,34,35,36,37,38", string.Join(',', results.Rows.Select(i => i.Index)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ExecuteByTest_Search_Item_PropertyMap_Contains()
        {
            var query = new SearchQuery
            {
                SearchTerm = "*e03*",
            };
            this.TestContext.AddResult(query);
            var queryResults = GetTestDataExtended().ExecuteBy(query);
            this.TestContext.AddResult(queryResults);

            var results = queryResults as IPagedQueryResult<TestTargetExtendedModel>;
            Assert.IsNotNull(results);

            Assert.AreEqual(20, results.TotalPageCount);
            Assert.AreEqual(200, results.TotalRowCount);
            Assert.AreEqual(10, results.Rows.Count());
            Assert.AreEqual("300,301,302,303,304,305,306,307,308,309", string.Join(',', results.Rows.Select(i => i.Index)));
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
