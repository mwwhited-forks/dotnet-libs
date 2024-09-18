using Eliassen.System.Linq.Expressions;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

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
            new { Prop1 = "upper" },
            new { Prop1 = "Upper" },
            new { Prop1 = "UPPER" },
        }.AsQueryable();

        var queryRaw = data.OrderBy(x => x.Prop1);
        var testRaw = queryRaw.ToList();

        var queryFixed = data.OrderBy(x => x.Prop1.ToUpper());
        var testFixed = queryFixed.ToList();

        //var visitor = new StringComparisonReplacementExpressionVisitor();
        //Expression<Func<string, bool>> expression = e => e == matched;
        //var visited = visitor.Visit(expression);
        //TestContext.WriteLine($"{nameof(expression)}: {expression}");
        //TestContext.WriteLine($"{nameof(visited)}: {visited}");
        //var result = ((LambdaExpression)visited).Compile().DynamicInvoke(input);
        //Assert.AreEqual(expected, result);
    }
}
