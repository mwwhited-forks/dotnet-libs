﻿using Eliassen.System.Linq.Expressions;
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
            var results = new ExpressionTreeBuilder<TestTargetModel>().GetFilterablePropertyNames();
            Assert.AreEqual("Index;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetFilterablePropertyNamesTest_TestTarget2Model()
        {
            var results = new ExpressionTreeBuilder<TestTarget2Model>().GetFilterablePropertyNames();
            Assert.AreEqual("Fake;Index;Name", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetFilterablePropertyNamesTest_TestTarget3Model()
        {
            var results = new ExpressionTreeBuilder<TestTarget3Model>().GetFilterablePropertyNames();
            Assert.AreEqual("Index;Name", string.Join(";", results));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSearchablePropertyNames_TestTargetModel()
        {
            var results = new ExpressionTreeBuilder<TestTargetModel>().GetSearchablePropertyNames();
            Assert.AreEqual("Index;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSearchablePropertyNames_TestTarget2Model()
        {
            var results = new ExpressionTreeBuilder<TestTarget2Model>().GetSearchablePropertyNames();
            Assert.AreEqual("Fake;Name", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSearchablePropertyNames_TestTarget3Model()
        {
            var results = new ExpressionTreeBuilder<TestTarget3Model>().GetSearchablePropertyNames();
            Assert.AreEqual("Name;Email", string.Join(";", results));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSortablePropertyNamesTest_TestTargetModel()
        {
            var results = new ExpressionTreeBuilder<TestTargetModel>().GetSortablePropertyNames();
            Assert.AreEqual("Index;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSortablePropertyNamesTest_TestTarget2Model()
        {
            var results = new ExpressionTreeBuilder<TestTarget2Model>().GetSortablePropertyNames();
            Assert.AreEqual("Fake;Name;Email", string.Join(";", results));
        }
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetSortablePropertyNamesTest_TestTarget3Model()
        {
            var results = new ExpressionTreeBuilder<TestTarget3Model>().GetSortablePropertyNames();
            Assert.AreEqual("Index;Email", string.Join(";", results));
        }
    }
}