using Eliassen.System.Linq.Expressions;
using Eliassen.System.Tests.Linq.TestTargets;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.System.Tests.Linq.Expressions
{
    [TestClass]
    public class ExpressionTreeBuilderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetFilterablePropertyNamesTest_TestTargetModel()
        {
            var results = ExpressionTreeBuilder.GetFilterablePropertyNames<TestTargetModel>();
            Assert.AreEqual("Index;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetFilterablePropertyNamesTest_TestTarget2Model()
        {
            var results = ExpressionTreeBuilder.GetFilterablePropertyNames<TestTarget2Model>();
            Assert.AreEqual("Fake;Index;Name", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetFilterablePropertyNamesTest_TestTarget3Model()
        {
            var results = ExpressionTreeBuilder.GetFilterablePropertyNames<TestTarget3Model>();
            Assert.AreEqual("Index;Name", string.Join(";", results));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSearchablePropertyNames_TestTargetModel()
        {
            var results = ExpressionTreeBuilder.GetSearchablePropertyNames<TestTargetModel>();
            Assert.AreEqual("Index;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSearchablePropertyNames_TestTarget2Model()
        {
            var results = ExpressionTreeBuilder.GetSearchablePropertyNames<TestTarget2Model>();
            Assert.AreEqual("Fake;Name", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSearchablePropertyNames_TestTarget3Model()
        {
            var results = ExpressionTreeBuilder.GetSearchablePropertyNames<TestTarget3Model>();
            Assert.AreEqual("Name;Email", string.Join(";", results));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSortablePropertyNamesTest_TestTargetModel()
        {
            var results = ExpressionTreeBuilder.GetSortablePropertyNames<TestTargetModel>();
            Assert.AreEqual("Index;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSortablePropertyNamesTest_TestTarget2Model()
        {
            var results = ExpressionTreeBuilder.GetSortablePropertyNames<TestTarget2Model>();
            Assert.AreEqual("Fake;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSortablePropertyNamesTest_TestTarget3Model()
        {
            var results = ExpressionTreeBuilder.GetSortablePropertyNames<TestTarget3Model>();
            Assert.AreEqual("Index;Email", string.Join(";", results));
        }
    }
}
