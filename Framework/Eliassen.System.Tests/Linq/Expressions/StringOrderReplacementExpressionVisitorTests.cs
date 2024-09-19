using Eliassen.System.Linq.Expressions;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Eliassen.System.Tests.Linq.Expressions;

[TestClass]
public class StringOrderReplacementExpressionVisitorTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void VisitTest_EqualOperator()
    {
        var data = new[] {
            new { Prop1 = "upper", Prop2 = 1, Prop3="ABC" },
            new { Prop1 = "Upper", Prop2 = 2, Prop3="abc" },
            new { Prop1 = "UPPER", Prop2 = 3, Prop3="AbC" },
            new { Prop1 = "Upper", Prop2 = 4, Prop3="aBc" },
            new { Prop1 = "upper", Prop2 = 5, Prop3="ABB" },
        }.AsQueryable();

        var queryRaw = data.OrderBy(x => x.Prop1).ThenBy(x => x.Prop2).ThenBy(x => x.Prop3);
        TestContext.WriteLine("---- 1");
        TestContext.WriteLine($"{queryRaw.Expression}");

        var queryFixed = data.OrderBy(x => x.Prop1.ToUpper()).ThenBy(x => x.Prop2).ThenBy(x => x.Prop3);
        TestContext.WriteLine("---- 2");
        TestContext.WriteLine($"{queryFixed.Expression}");

        var queryCompare = data.OrderBy(x => x.Prop1, StringComparer.OrdinalIgnoreCase).ThenBy(x => x.Prop2).ThenBy(x => x.Prop3, StringComparer.OrdinalIgnoreCase);
        TestContext.WriteLine("---- 3");
        TestContext.WriteLine($"{queryCompare.Expression}");

        var visitor = new StringOrderReplacementExpressionVisitor(StringCasing.Upper);

        var visitedRaw = visitor.Visit(queryRaw.Expression);
        TestContext.WriteLine("++++ 1v");
        TestContext.WriteLine($"{visitedRaw}");

        var visitedFixed = visitor.Visit(queryFixed.Expression);
        TestContext.WriteLine("++++ 2v");
        TestContext.WriteLine($"{visitedFixed}");

        var visitedCompare = visitor.Visit(queryCompare.Expression);
        TestContext.WriteLine("++++ 3v");
        TestContext.WriteLine($"{visitedCompare}");

        var testRaw = queryRaw.ToList();
        var testFixed = queryFixed.ToList();
        var testCompare = queryCompare.ToList();

        //var resultRaw = visitedRaw..ToList();
        //var resultFixed = visitedFixed.ToList();
        //var resultCompare = visitedCompare.ToList();

        //Assert.AreEqual(expected, result);
        Assert.Inconclusive();
    }
}
