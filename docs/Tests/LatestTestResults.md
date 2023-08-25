# Test Results

## Test Name: VisitTest_EndsWith (Hello,lo,True)

* Name: VisitTest_EndsWith (Hello,lo,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0035054
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)

## Test Name: MakeSafeTest (System.Nullable`1[System.Double],1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000565
  * Outcome: Passed


## Test Name: GetHash (Hello World!,7Qdih1MuhjZehB6Sv8UNjA==)

* Name: GetHash (Hello World!,7Qdih1MuhjZehB6Sv8UNjA==)
* Test Class: Eliassen.System.Tests.Security.Cryptography.HashTests
  * Method: GetHash
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000715
  * Outcome: Passed


### Standard Out

TestContext Messages:
"Hello World!" => "7Qdih1MuhjZehB6Sv8UNjA=="

## Test Name: SerializeTest_Value

* Name: SerializeTest_Value
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: SerializeTest_Value
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0038403
  * Outcome: Passed


### Standard Out

TestContext Messages:
result-BsonDateConverterTests_SerializeTest_Value(48)-638285573234682591.json: Attached
2023-08-25T10:48:43.4681816-04:00

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,DateTimeOffsetNullable,LessThan,2020-03-01T01:01:01.4356493+02:00,2,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0359238
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:DateTimeOffsetNullable: LessThan: 2020-03-01T01:01:01.4356493+02:00

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.DateTimeOffsetNullable < Convert(3/1/2020 1:01:01 AM +02:00, Nullable`1))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573222190031.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573222228612.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573222470439.json: Attached
resultKeys: 0,1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01.4356493+02:00 parsed to 03/01/2020 01:01:01 +02:00 (System.DateTimeOffset)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: TryParseTest (System.Nullable`1[System.Int32],1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000252
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel,Children,EqualTo,*001,10,2,3,4,5,6,7,8,9,12,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0338673
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Children: EqualTo: *001

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel].Where(n => n.Children.Any(child => child.EndsWith("001"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573223612491.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573223651273.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573223892560.json: Attached
resultKeys: 2,3,4,5,6,7,8,9,12,13

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,InSet,System.String[],3,1,2,3)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0231691
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: InSet: Name1; Name2; Name3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => value(System.String[]).Contains(n.Name)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573215656852.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573215695222.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573215819894.json: Attached
resultKeys: 1,2,3

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: GetResourceFromJsonTest_NotFound

* Name: GetResourceFromJsonTest_NotFound
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonTest_NotFound
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003573
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,*e2*,10,0,1,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0223964
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo: *e2*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => Not(n.Name.Contains("e2"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573218844891.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573218886739.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573219016882.json: Attached
resultKeys: 0,1,3,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: GetResourceStreamTest_ByType

* Name: GetResourceStreamTest_ByType
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceStreamTest_ByType
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003515
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Int32],1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000496
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Guid],18AACB9C-2989-4322-A490-C7167BEA0DB4,True,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001194
  * Outcome: Passed


## Test Name: VisitTest_Contains (Hello,eL,True)

* Name: VisitTest_Contains (Hello,eL,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Contains
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0009376
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)

## Test Name: MakeSafeTest (System.Guid,18AACB9C-2989-4322-A490-C7167BEA0DB4,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001182
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*03,9,103,203,303,403,503,603,703,803,903)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0262460
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: *03

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.EndsWith("03")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573217802126.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573217863559.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573217999906.json: Attached
resultKeys: 103,203,303,403,503,603,703,803,903

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,Name1*,10,1,10,11,12,13,14,15,16,17,18)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0262016
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: Name1*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.StartsWith("Name1")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573218333535.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573218380242.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573218530289.json: Attached
resultKeys: 1,10,11,12,13,14,15,16,17,18

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThan,5,5,0,1,2,3,4)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0440095
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: LessThan: 5

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index < 5)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573216561587.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573216640131.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573216898070.json: Attached
resultKeys: 0,1,2,3,4

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	5 parsed to 5 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,InSet,System.Int32[],3,1,2,3)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0269741
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: InSet: 1; 2; 3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => value(System.Int32[]).Contains(n.Index)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573215878860.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573215920680.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573216077138.json: Attached
resultKeys: 1,2,3

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: DeserializeTest ({"_id":"Hello World"},Hello World)

* Name: DeserializeTest ({"_id":"Hello World"},Hello World)
* Test Class: Eliassen.System.Tests.Text.Json.BsonIdConverterTests
  * Method: DeserializeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0150721
  * Outcome: Passed


### Standard Out

TestContext Messages:
input-BsonIdConverterTests_DeserializeTest(41)-638285573234740649.json: Attached
result-BsonIdConverterTests_DeserializeTest(43)-638285573234845956.json: Attached

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThanOrEqualTo,5,6,0,1,2,3,4,5)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0321068
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: LessThanOrEqualTo: 5

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index <= 5)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573217005232.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573217094527.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573217256173.json: Attached
resultKeys: 0,1,2,3,4,5

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	5 parsed to 5 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: VisitTest_Equals (Hello,HeLlO,True)

* Name: VisitTest_Equals (Hello,HeLlO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0016369
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)

## Test Name: VisitTest_EndsWith (Hello,lO,True)

* Name: VisitTest_EndsWith (Hello,lO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0013967
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)

## Test Name: GetTestDataAsyncTest_Targeted

* Name: GetTestDataAsyncTest_Targeted
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest_Targeted
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0033810
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,GreaterThanOrEqualTo,3/1/2020,10,2,3,4,5,6,7,8,9,10,11)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0330689
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: GreaterThanOrEqualTo: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date >= 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573220140418.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573220180264.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573220390239.json: Attached
resultKeys: 2,3,4,5,6,7,8,9,10,11

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)

* Name: ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0012169
  * Outcome: Passed


## Test Name: AsModelsTest

* Name: AsModelsTest
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: AsModelsTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0164321
  * Outcome: Passed


### Standard Out

TestContext Messages:
EnumModel { Id = 1, Name = Assembly, Code = ASSEMBLY, Description = , Order = 0, Value = Assembly, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Assembly }
EnumModel { Id = 2, Name = Module, Code = MODULE, Description = , Order = 0, Value = Module, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Module }
EnumModel { Id = 4, Name = Class, Code = CLASS, Description = , Order = 0, Value = Class, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Class }
EnumModel { Id = 8, Name = Struct, Code = STRUCT, Description = , Order = 0, Value = Struct, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Struct }
EnumModel { Id = 16, Name = Enum, Code = ENUM, Description = , Order = 0, Value = Enum, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Enum }
EnumModel { Id = 32, Name = Constructor, Code = CONSTRUCTOR, Description = , Order = 0, Value = Constructor, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Constructor }
EnumModel { Id = 64, Name = Method, Code = METHOD, Description = , Order = 0, Value = Method, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Method }
EnumModel { Id = 128, Name = Property, Code = PROPERTY, Description = , Order = 0, Value = Property, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Property }
EnumModel { Id = 256, Name = Field, Code = FIELD, Description = , Order = 0, Value = Field, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Field }
EnumModel { Id = 512, Name = Event, Code = EVENT, Description = , Order = 0, Value = Event, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Event }
EnumModel { Id = 1024, Name = Interface, Code = INTERFACE, Description = , Order = 0, Value = Interface, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Interface }
EnumModel { Id = 2048, Name = Parameter, Code = PARAMETER, Description = , Order = 0, Value = Parameter, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Parameter }
EnumModel { Id = 4096, Name = Delegate, Code = DELEGATE, Description = , Order = 0, Value = Delegate, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Delegate }
EnumModel { Id = 8192, Name = ReturnValue, Code = RETURNVALUE, Description = , Order = 0, Value = ReturnValue, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = ReturnValue }
EnumModel { Id = 16384, Name = GenericParameter, Code = GENERICPARAMETER, Description = , Order = 0, Value = GenericParameter, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = GenericParameter }
EnumModel { Id = 32767, Name = All, Code = ALL, Description = , Order = 0, Value = All, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = All }

## Test Name: AddResultTest_Object_WithFileNameNoExtension

* Name: AddResultTest_Object_WithFileNameNoExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameNoExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0035035
  * Outcome: Passed


### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameNoExtension(90)-638285573212437782.json: Attached

## Test Name: MakeSafeTest (System.Nullable`1[System.Guid],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0045066
  * Outcome: Passed


## Test Name: AddResultTest_Object_WithFileNameAndExtension

* Name: AddResultTest_Object_WithFileNameAndExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameAndExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0035695
  * Outcome: Passed


### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameAndExtension(110)-638285573212388542.txt: Attached

## Test Name: MakeSafeArrayTest (System.String,System.Object[],System.String[])

* Name: MakeSafeArrayTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeArrayTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0031734
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,May,NotEqualTo,,10,-1,1,2,4,5,7,8,10,11,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0314024
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:May: NotEqualTo:

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.May != "")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573224999437.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573225038712.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573225229652.json: Attached
resultKeys: -1,1,2,4,5,7,8,10,11,13

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: TryParseTest (System.Decimal,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007568
  * Outcome: Passed


## Test Name: ToEnumTest (test display,WithDisplay)

* Name: ToEnumTest (test display,WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002728
  * Outcome: Passed


## Test Name: GetTestDataAsyncTest

* Name: GetTestDataAsyncTest
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2465610
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThanOrEqualTo,3/1/2020,4,-1,0,1,2)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0342460
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThanOrEqualTo: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date <= 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573222550733.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573222608061.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573222820964.json: Attached
resultKeys: -1,0,1,2

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: MakeSafeTest (System.Nullable`1[System.Decimal],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007470
  * Outcome: Passed


## Test Name: GetResourceFromXmlAsyncTest

* Name: GetResourceFromXmlAsyncTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromXmlAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0282473
  * Outcome: Passed


## Test Name: ToEnumTest (-1,-1)

* Name: ToEnumTest (-1,-1)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000471
  * Outcome: Passed


## Test Name: MakeSafeArrayTest (System.String,System.Object[],System.String[])

* Name: MakeSafeArrayTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeArrayTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000322
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01T01:01:01.4356493+02:00,3,-1,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0354493
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 2020-03-01T01:01:01.4356493+02:00

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 2/29/2020 6:01:01 PM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573221506774.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573221565556.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573221796952.json: Attached
resultKeys: -1,0,1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01.4356493+02:00 parsed to 02/29/2020 18:01:01 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: VisitTest_EndsWith (Hello,Lo,True)

* Name: VisitTest_EndsWith (Hello,Lo,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0018466
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)

## Test Name: VisitTest_Equals (Hello,hello,True)

* Name: VisitTest_Equals (Hello,hello,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0013590
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)

## Test Name: AddResultFileTest_FileContentOutFile

* Name: AddResultFileTest_FileContentOutFile
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultFileTest_FileContentOutFile
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0025813
  * Outcome: Passed


### Standard Out

TestContext Messages:
D:\Repos\Nu2\NetApi\TestResults\Deploy_MWhited 20230825T104841\In\LW-18560\test-file.txt

## Test Name: ExecuteByTest_Filter_Range_Bounds

* Name: ExecuteByTest_Filter_Range_Bounds
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter_Range_Bounds
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0445543
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: GreaterThanOrEqualTo: 3/1/2020 12:00:00 AM 
LessThanOrEqualTo: 7/1/2020 12:00:00 AM

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => ((n.Date <= 7/1/2020 12:00:00 AM) AndAlso (n.Date >= 3/1/2020 12:00:00 AM))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Filter_Range_Bounds(153)-638285573226046762.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Filter_Range_Bounds(155)-638285573226367830.json: Attached

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	7/1/2020 12:00:00 AM parsed to 07/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 12:00:00 AM parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: TryParseTest (System.Nullable`1[System.Double],1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000264
  * Outcome: Passed


## Test Name: DeserializeTest_Value ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},0001-01-01T00:00:00+00:00)

* Name: DeserializeTest_Value ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},0001-01-01T00:00:00+00:00)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Value
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0074631
  * Outcome: Passed


### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Value(79)-638285573234384139.json: Attached
result-BsonDateConverterTests_DeserializeTest_Value(81)-638285573234414453.json: Attached

## Test Name: VisitTest_Equals (Hello,HELLO,True)

* Name: VisitTest_Equals (Hello,HELLO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008949
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)

## Test Name: ToEnumTest (test name,WithDisplay)

* Name: ToEnumTest (test name,WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0006619
  * Outcome: Passed


## Test Name: GetResourceStreamTest

* Name: GetResourceStreamTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceStreamTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002249
  * Outcome: Passed


## Test Name: ToEnumTest (1,Val1)

* Name: ToEnumTest (1,Val1)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000782
  * Outcome: Passed


## Test Name: GetShortTypeNameTests (System.String,System.String, System.Private.CoreLib)

* Name: GetShortTypeNameTests
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: GetShortTypeNameTests
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008916
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01,3,-1,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0317587
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 2020-03-01

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573220800292.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573220841309.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573221055100.json: Attached
resultKeys: -1,0,1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThan,5,5,0,1,2,3,4)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0410704
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: LessThan: 5

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index < 5)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573216151430.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573216236452.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573216461973.json: Attached
resultKeys: 0,1,2,3,4

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	5 parsed to 5 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: MakeSafeTest (System.Decimal,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0006672
  * Outcome: Passed


## Test Name: ExecuteByTest_Sort (Name,Ascending,0,1,10,100,101,102,103,104,105,106)

* Name: ExecuteByTest_Sort (Name,Ascending,0,1,10,100,101,102,103,104,105,106)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0246038
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Ascending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(266)-638285573229682683.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(268)-638285573229813424.json: Attached

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Ascending

## Test Name: GetResourceFromJsonAsyncTest

* Name: GetResourceFromJsonAsyncTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0189344
  * Outcome: Passed


## Test Name: VisitTest_Equals (Hello,,False)

* Name: VisitTest_Equals (Hello,,False)
* Test Class: Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007287
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => ((e != null) AndAlso e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched))
result: False

## Test Name: AddResultTest_Stream

* Name: AddResultTest_Stream
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Stream
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0036526
  * Outcome: Passed


### Standard Out

TestContext Messages:
MemoryStream-TextContextExtensionsTests_AddResultTest_Stream(170)-638285573212974026.bin: Attached

## Test Name: ToEnumTest (Val2,Val1,Val1, Val2)

* Name: ToEnumTest (Val2,Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000269
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,FC,EqualTo,ame1,2,-1,0)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0284167
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:FC: EqualTo: ame1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(e => e.FName.Contains(value(Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel+<>c__DisplayClass38_0).value.ToString())).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573222893847.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573222942974.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573223128021.json: Attached
resultKeys: -1,0

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: AddResultTest_Lines

* Name: AddResultTest_Lines
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Lines
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0023768
  * Outcome: Passed


### Standard Out

TestContext Messages:
String[]-TextContextExtensionsTests_AddResultTest_Lines(70)-638285573212209832.txt: Attached

## Test Name: MakeSafeTest (System.Nullable`1[System.AttributeTargets],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001619
  * Outcome: Passed


## Test Name: VisitTest_EndsWith (Hello,LO,True)

* Name: VisitTest_EndsWith (Hello,LO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0013690
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)

## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000286
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Guid,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0013027
  * Outcome: Passed


## Test Name: TryParseTest (System.Double,1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001098
  * Outcome: Passed


## Test Name: DeserializeTest_Nullable ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},)

* Name: DeserializeTest_Nullable ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Nullable
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0077747
  * Outcome: Passed


### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Nullable(65)-638285573234289308.json: Attached
result-BsonDateConverterTests_DeserializeTest_Nullable(67)-638285573234313888.json: Attached

## Test Name: GetHash (hello world,XrY7u+Ae7tCTyyK7j1rNww==)

* Name: GetHash (hello world,XrY7u+Ae7tCTyyK7j1rNww==)
* Test Class: Eliassen.System.Tests.Security.Cryptography.HashTests
  * Method: GetHash
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0122501
  * Outcome: Passed


### Standard Out

TestContext Messages:
"hello world" => "XrY7u+Ae7tCTyyK7j1rNww=="

## Test Name: VisitTest_StartsWith (Hello,HE,True)

* Name: VisitTest_StartsWith (Hello,HE,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_StartsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0004939
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)

## Test Name: DeserializeTest ({"_id":{"$oid":"Hello World"}},Hello World)

* Name: DeserializeTest ({"_id":{"$oid":"Hello World"}},Hello World)
* Test Class: Eliassen.System.Tests.Text.Json.BsonIdConverterTests
  * Method: DeserializeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0088466
  * Outcome: Passed


### Standard Out

TestContext Messages:
input-BsonIdConverterTests_DeserializeTest(41)-638285573234893787.json: Attached
result-BsonIdConverterTests_DeserializeTest(43)-638285573234919029.json: Attached

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,May,EqualTo,!,10,-1,1,2,4,5,7,8,10,11,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0289470
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:May: EqualTo: !

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.May != "")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573225314214.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573225358215.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573225546292.json: Attached
resultKeys: -1,1,2,4,5,7,8,10,11,13

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: ToEnumTest (test description,WithDescription)

* Name: ToEnumTest (test description,WithDescription)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0004489
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,May,NotEqualTo,!,10,-1,1,2,4,5,7,8,10,11,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0301841
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:May: NotEqualTo: !

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.May != "")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573225604341.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573225642919.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573225815576.json: Attached
resultKeys: -1,1,2,4,5,7,8,10,11,13

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: VisitTest_Equals (Hello,Hello,True)

* Name: VisitTest_Equals (Hello,Hello,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0035232
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => ((e != null) AndAlso e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched))
result: True

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,GreaterThanOrEqualTo,995,5,995,996,997,998,999)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0262717
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: GreaterThanOrEqualTo: 995

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index >= 995)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573217540142.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573217595734.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573217736570.json: Attached
resultKeys: 995,996,997,998,999

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	995 parsed to 995 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,EqualTo,1,1,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0257656
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: EqualTo: 1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index == 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573215125949.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573215165277.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573215309949.json: Attached
resultKeys: 1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ToEnumTest (Val2, Val1,Val1, Val2)

* Name: ToEnumTest (Val2, Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000205
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel,Children,EqualTo,*001,10,2,3,4,5,6,7,8,9,12,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0431831
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Children: EqualTo: *001

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel].Where(n => n.Children.Any(child => child.EndsWith("001"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573223180979.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573223239807.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573223552650.json: Attached
resultKeys: 2,3,4,5,6,7,8,9,12,13

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel

## Test Name: ToEnumTest (,)

* Name: ToEnumTest (,)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000184
  * Outcome: Passed


## Test Name: ToEnumTest (name2,WithMemberName)

* Name: ToEnumTest (name2,WithMemberName)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002323
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Double,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007948
  * Outcome: Passed


## Test Name: ToEnumTest (Val2|Val1,Val1, Val2)

* Name: ToEnumTest (Val2|Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000500
  * Outcome: Passed


## Test Name: ToEnumTest (0,Val0)

* Name: ToEnumTest (0,Val0)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0108611
  * Outcome: Passed


## Test Name: VisitTest_EqualOperator (Hello,HeLlO,True)

* Name: VisitTest_EqualOperator (Hello,HeLlO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EqualOperator
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0005337
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)

## Test Name: MakeSafeTest (System.String,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000133
  * Outcome: Passed


## Test Name: ExecuteByTest_Page (0,0,100,1000,0,10,0,1,2,3,4,5,6,7,8,9)

* Name: ExecuteByTest_Page (0,0,100,1000,0,10,0,1,2,3,4,5,6,7,8,9)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0222160
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(222)-638285573227568021.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(224)-638285573227600700.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(226)-638285573227716827.json: Attached
resultKeys: 0,1,2,3,4,5,6,7,8,9

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: GetResourceFromJsonTest

* Name: GetResourceFromJsonTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0006759
  * Outcome: Passed


## Test Name: AddResultTest_Object_WithFileNameAndChangeExtension

* Name: AddResultTest_Object_WithFileNameAndChangeExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameAndChangeExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0044649
  * Outcome: Passed


### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameAndChangeExtension(130)-638285573212330705.html: Attached

## Test Name: ExecuteByTest_Page (1,-1,,,,1000,)

* Name: ExecuteByTest_Page (1,-1,,,,1000,)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0320119
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 1
PageSize: -1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute : System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(222)-638285573226541362.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(224)-638285573226634238.json: Attached
QueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(226)-638285573226746340.json: Attached

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 1
PageSize: -1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*e2*,10,2,20,21,22,23,24,25,26,27,28)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0267258
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: *e2*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.Contains("e2")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573218065436.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573218117166.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573218271373.json: Attached
resultKeys: 2,20,21,22,23,24,25,26,27,28

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: AddResultTest_ValueOutFile

* Name: AddResultTest_ValueOutFile
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_ValueOutFile
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0028572
  * Outcome: Passed


### Standard Out

TestContext Messages:
TestData-TextContextExtensionsTests_AddResultTest_ValueOutFile(210)-638285573213195119.json: Attached
D:\Repos\Nu2\NetApi\TestResults\Deploy_MWhited 20230825T104841\In\LW-18560\TestData-TextContextExtensionsTests_AddResultTest_ValueOutFile(210)-638285573213195119.json

## Test Name: AddResultFileTest_FileContent

* Name: AddResultFileTest_FileContent
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultFileTest_FileContent
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0172944
  * Outcome: Passed


## Test Name: MakeSafeArrayTest (System.Decimal,System.Object[],System.Decimal[])

* Name: MakeSafeArrayTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeArrayTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002360
  * Outcome: Passed


## Test Name: GetResourceFromXmlTest

* Name: GetResourceFromXmlTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromXmlTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0047929
  * Outcome: Passed


## Test Name: VisitTest_StartsWith (Hello,he,True)

* Name: VisitTest_StartsWith (Hello,he,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_StartsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0015373
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)

## Test Name: GetTestDataAsyncTest_Stream

* Name: GetTestDataAsyncTest_Stream
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest_Stream
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0041318
  * Outcome: Passed


## Test Name: GetResourceStreamTest_NotFound

* Name: GetResourceStreamTest_NotFound
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceStreamTest_NotFound
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002433
  * Outcome: Passed


## Test Name: ToEnumTest (Val1,Val1)

* Name: ToEnumTest (Val1,Val1)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000266
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Int32],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0010759
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Int32,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0019062
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Int32,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001524
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,16,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000251
  * Outcome: Passed


## Test Name: ToEnumTest (name,WithEnumValue)

* Name: ToEnumTest (name,WithEnumValue)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0011656
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,Enum,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000206
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Double],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0009336
  * Outcome: Passed


## Test Name: ToEnumTest (no data,)

* Name: ToEnumTest (no data,)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0013571
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.AttributeTargets],Enum,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000033
  * Outcome: Passed


## Test Name: ToEnumTest (Val2 , Val1,Val1, Val2)

* Name: ToEnumTest (Val2 , Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000184
  * Outcome: Passed


## Test Name: SerializeTest

* Name: SerializeTest
* Test Class: Eliassen.System.Tests.Text.Json.BsonIdConverterTests
  * Method: SerializeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0044306
  * Outcome: Passed


### Standard Out

TestContext Messages:
result-BsonIdConverterTests_SerializeTest(26)-638285573235000733.json: Attached
Hello World

## Test Name: MakeSafeTest (System.AttributeTargets,Enum,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000122
  * Outcome: Passed


## Test Name: AddResultTest_String

* Name: AddResultTest_String
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_String
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0074872
  * Outcome: Passed


### Standard Out

TestContext Messages:
String-TextContextExtensionsTests_AddResultTest_String(50)-638285573213025993.txt: Attached

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,*3,10,0,1,2,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0247508
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo: *3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => Not(n.Name.EndsWith("3"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573218597927.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573218659366.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573218789500.json: Attached
resultKeys: 0,1,2,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: VisitTest_EqualOperator (Hello,HELLO,True)

* Name: VisitTest_EqualOperator (Hello,HELLO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EqualOperator
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026499
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)

## Test Name: GetSortablePropertyNamesTest_TestTarget2Model

* Name: GetSortablePropertyNamesTest_TestTarget2Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSortablePropertyNamesTest_TestTarget2Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0033424
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,INDEX,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0220307
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:INDEX: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573214682399.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573214721312.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573214849918.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: MakeSafeTest (System.Int32,1.1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000593
  * Outcome: Passed


## Test Name: ToEnumTest (Val2 ,Val1,Val1, Val2)

* Name: ToEnumTest (Val2 ,Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000270
  * Outcome: Passed


## Test Name: ExecuteByTest_Sort (NAME,Descending,999,998,997,996,995,994,993,992,991,990)

* Name: ExecuteByTest_Sort (NAME,Descending,999,998,997,996,995,994,993,992,991,990)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0189649
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:NAME: Descending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderByDescending(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(266)-638285573230089202.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(268)-638285573230205832.json: Attached

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:NAME: Descending

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2148493
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573212435591.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573212925266.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573214196061.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: VisitTest_EqualOperator (Hello,hello,True)

* Name: VisitTest_EqualOperator (Hello,hello,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EqualOperator
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0005474
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)

## Test Name: VisitTest_Contains (Hello,el,True)

* Name: VisitTest_Contains (Hello,el,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Contains
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007905
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*,10,0,1,2,3,4,5,6,7,8,9)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0257493
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: *

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573224435249.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573224484585.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573224624374.json: Attached
resultKeys: 0,1,2,3,4,5,6,7,8,9

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filter mapped for property: Name => EqualTo: *
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: *

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: GetSortablePropertyNamesTest_TestTargetModel

* Name: GetSortablePropertyNamesTest_TestTargetModel
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSortablePropertyNamesTest_TestTargetModel
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003799
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Decimal],1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000228
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,GreaterThan,3/1/2020,10,3,4,5,6,7,8,9,10,11,12)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0672732
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: GreaterThan: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date > 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573219468741.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573219522203.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573220055118.json: Attached
resultKeys: 3,4,5,6,7,8,9,10,11,12

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: ToEnumTest (3,Val1, Val2)

* Name: ToEnumTest (3,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000261
  * Outcome: Passed


## Test Name: VisitTest_StartsWith (Hello,He,True)

* Name: VisitTest_StartsWith (Hello,He,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_StartsWith
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0006431
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)

## Test Name: MakeSafeTest (System.Nullable`1[System.Decimal],1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000389
  * Outcome: Passed


## Test Name: GetShortTypeNameTests (Eliassen.System.Tests.Reflection.ReflectionExtensionsTests,Eliassen.System.Tests.Reflection.ReflectionExtensionsTests, Eliassen.System.Tests)

* Name: GetShortTypeNameTests
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: GetShortTypeNameTests
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000212
  * Outcome: Passed


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,*e3*,12,111,10,3,30,31,32,33,34,35,36,37,38)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0274838
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = *e3*, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Debug:>
	Visited by: Eliassen.System.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitor
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (((n.Name != null) AndAlso n.Name.Contains("e3")) OrElse ((n.Email != null) AndAlso n.Email.Contains("e3")))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(192)-638285573228834841.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(194)-638285573228869345.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(196)-638285573229041148.json: Attached
resultKeys: 3,30,31,32,33,34,35,36,37,38

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: AddResultTest_Object

* Name: AddResultTest_Object
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0066674
  * Outcome: Passed


### Standard Out

TestContext Messages:
TestData-TextContextExtensionsTests_AddResultTest_Object(30)-638285573212243240.json: Attached

## Test Name: MakeSafeTest (System.Byte[],QUJD,System.Byte[])

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002180
  * Outcome: Passed


## Test Name: VisitTest_Equals (,hello,False)

* Name: VisitTest_Equals (,hello,False)
* Test Class: Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0009065
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => ((e != null) AndAlso e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched))
result: False

## Test Name: VisitTest_Contains (Hello,EL,True)

* Name: VisitTest_Contains (Hello,EL,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Contains
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0094271
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)

## Test Name: GetFilterablePropertyNamesTest_TestTarget2Model

* Name: GetFilterablePropertyNamesTest_TestTarget2Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetFilterablePropertyNamesTest_TestTarget2Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0038297
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,,0,)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0203306
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo:

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Name == "")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573223950353.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573223988778.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573224095114.json: Attached
resultKeys:

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: TryParseTest (System.Nullable`1[System.Guid],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008588
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01T01:01:01,4,-1,0,1,2)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0386979
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 2020-03-01T01:01:01

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 3/1/2020 1:01:01 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573221118672.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573221187886.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573221420027.json: Attached
resultKeys: -1,0,1,2

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01 parsed to 03/01/2020 01:01:01 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: GetSearchablePropertyNames_TestTarget3Model

* Name: GetSearchablePropertyNames_TestTarget3Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSearchablePropertyNames_TestTarget3Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0009636
  * Outcome: Passed


## Test Name: MakeSafeTest (System.DateTimeOffset,3/16/2022 12:00:00 AM +05:00,3/16/2022 12:00:00 AM +05:00)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000201
  * Outcome: Passed


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,FName0999 LName0001,1,1,1,1)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0474767
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = FName0999 LName0001, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Debug:>
	Visited by: Eliassen.System.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitor
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (((((((((n.FName + " ") + n.LName) != null) AndAlso ((n.FName + " ") + n.LName).Equals("FName0999 LName0001")) OrElse ((((n.LName + " ") + n.FName) != null) AndAlso ((n.LName + " ") + n.FName).Equals("FName0999 LName0001"))) OrElse ((n.FName != null) AndAlso n.FName.Equals("FName0999 LName0001"))) OrElse ((n.LName != null) AndAlso n.LName.Equals("FName0999 LName0001"))) OrElse ((n.Email != null) AndAlso n.Email.Equals("FName0999 LName0001"))) OrElse ((n.May != null) AndAlso n.May.Equals("FName0999 LName0001")))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(192)-638285573229112815.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(194)-638285573229178163.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(196)-638285573229513310.json: Attached
resultKeys: 1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: AddResultTest_Json

* Name: AddResultTest_Json
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Json
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0530115
  * Outcome: Passed


### Standard Out

TestContext Messages:
JObject-TextContextExtensionsTests_AddResultTest_Json(190)-638285573211735346.json: Attached

## Test Name: DeserializeTest_Value ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},2023-07-05T14:17:05.2315812-04:00)

* Name: DeserializeTest_Value ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},2023-07-05T14:17:05.2315812-04:00)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Value
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0057806
  * Outcome: Passed


### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Value(79)-638285573234469509.json: Attached
result-BsonDateConverterTests_DeserializeTest_Value(81)-638285573234493032.json: Attached

## Test Name: GetFilterablePropertyNamesTest_TestTargetModel

* Name: GetFilterablePropertyNamesTest_TestTargetModel
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetFilterablePropertyNamesTest_TestTargetModel
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003272
  * Outcome: Passed


## Test Name: ToEnumTest (2,Val2)

* Name: ToEnumTest (2,Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000202
  * Outcome: Passed


## Test Name: TryParseTest (System.Int32,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007381
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0021103
  * Outcome: Passed


## Test Name: MakeSafeTest (System.TimeSpan,16:00,16:00:00)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008258
  * Outcome: Passed


## Test Name: TryParseTest (System.Decimal,1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001105
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000392
  * Outcome: Passed


## Test Name: VisitTest_Equals (,,False)

* Name: VisitTest_Equals (,,False)
* Test Class: Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008294
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => ((e != null) AndAlso e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched))
result: False

## Test Name: ExecuteByTest_Page (1,1,1000,1000,1,1,1)

* Name: ExecuteByTest_Page (1,1,1000,1000,1,1,1)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0323773
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 1
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(1).Take(1)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(222)-638285573227233139.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(224)-638285573227276562.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(226)-638285573227461326.json: Attached
resultKeys: 1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 1
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: MakeSafeTest (System.DateTime,3/16/2022,3/16/2022 12:00:00 AM)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000095
  * Outcome: Passed


## Test Name: TryParseTest (System.AttributeTargets,Enum,True,Enum)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000492
  * Outcome: Passed


## Test Name: DefaultPageSizeTest

* Name: DefaultPageSizeTest
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: DefaultPageSizeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0076088
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Double,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0002070
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,3/1/2020,3,-1,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0327465
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573220472025.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573220526077.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573220740304.json: Attached
resultKeys: -1,0,1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: TryParseTest (System.Nullable`1[System.Double],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008581
  * Outcome: Passed


## Test Name: AsModelsTest2

* Name: AsModelsTest2
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: AsModelsTest2
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0082427
  * Outcome: Passed


### Standard Out

TestContext Messages:
EnumModel { Id = 0, Name = Val0, Code = VAL0, Description = , Order = 0, Value = Val0, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val0 }
EnumModel { Id = 1, Name = Val1, Code = VAL1, Description = , Order = 0, Value = Val1, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val1 }
EnumModel { Id = 2, Name = Val2, Code = VAL2, Description = , Order = 0, Value = Val2, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val2 }
EnumModel { Id = 4, Name = WithEnumValue, Code = name, Description = , Order = 0, Value = WithEnumValue, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithEnumValue }
EnumModel { Id = 8, Name = WithMemberName, Code = name2, Description = , Order = 0, Value = WithMemberName, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithMemberName }
EnumModel { Id = 16, Name = WithDescription, Code = WITHDESCRIPTION, Description = test description, Order = 0, Value = WithDescription, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithDescription }
EnumModel { Id = 32, Name = test name, Code = test short, Description = test display, Order = 0, Value = WithDisplay, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithDisplay }

## Test Name: TryParseTest (System.Guid,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026516
  * Outcome: Passed


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name3*,12,111,10,3,30,31,32,33,34,35,36,37,38)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0246584
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = Name3*, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Debug:>
	Visited by: Eliassen.System.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitor
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (((n.Name != null) AndAlso n.Name.StartsWith("Name3")) OrElse ((n.Email != null) AndAlso n.Email.StartsWith("Name3")))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(192)-638285573228295881.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(194)-638285573228333492.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(196)-638285573228482374.json: Attached
resultKeys: 3,30,31,32,33,34,35,36,37,38

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,Name3,1,3)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0261342
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: Name3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.Equals("Name3")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573215384476.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573215438481.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573215594602.json: Attached
resultKeys: 3

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Page (0,1,1000,1000,0,1,0)

* Name: ExecuteByTest_Page (0,1,1000,1000,0,1,0)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0344953
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(0).Take(1)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(222)-638285573226874501.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(224)-638285573226919815.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(226)-638285573227102236.json: Attached
resultKeys: 0

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,InDeX,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0221844
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:InDeX: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573214903420.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573214943836.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573215069744.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: GetResourceFromJsonAsyncTest_NotFound

* Name: GetResourceFromJsonAsyncTest_NotFound
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonAsyncTest_NotFound
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0010132
  * Outcome: Passed


## Test Name: TryParseTest (System.Int32,1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000998
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Int32],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008746
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000256
  * Outcome: Passed


## Test Name: GetResourceAsStringAsyncTest

* Name: GetResourceAsStringAsyncTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceAsStringAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0050826
  * Outcome: Passed


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name3,1,1,1,3)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0495691
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = Name3, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Debug:>
	Visited by: Eliassen.System.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitor
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (((n.Name != null) AndAlso n.Name.Equals("Name3")) OrElse ((n.Email != null) AndAlso n.Email.Equals("Name3")))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(192)-638285573227818835.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(194)-638285573227928153.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(196)-638285573228217664.json: Attached
resultKeys: 3

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: DeserializeTest_Nullable ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},2023-07-05T14:16:32.2015217-04:00)

* Name: DeserializeTest_Nullable ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},2023-07-05T14:16:32.2015217-04:00)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Nullable
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0179986
  * Outcome: Passed


### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Nullable(65)-638285573234105412.json: Attached
result-BsonDateConverterTests_DeserializeTest_Nullable(67)-638285573234185699.json: Attached

## Test Name: MakeSafeTest (System.DateTime,3/16/2022 12:00:00 AM,3/16/2022 12:00:00 AM)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000546
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,May,EqualTo,,10,0,3,6,9,12,15,18,21,24,27)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0305357
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:May: EqualTo:

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.May == "")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573224693352.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573224732257.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573224941605.json: Attached
resultKeys: 0,3,6,9,12,15,18,21,24,27

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000187
  * Outcome: Passed


## Test Name: TryParseTest (System.Guid,18AACB9C-2989-4322-A490-C7167BEA0DB4,True,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026210
  * Outcome: Passed


## Test Name: GetSortablePropertyNamesTest_TestTarget3Model

* Name: GetSortablePropertyNamesTest_TestTarget3Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSortablePropertyNamesTest_TestTarget3Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003609
  * Outcome: Passed


## Test Name: SerializeTest_Nullable

* Name: SerializeTest_Nullable
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: SerializeTest_Nullable
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0111272
  * Outcome: Passed


### Standard Out

TestContext Messages:
result-BsonDateConverterTests_SerializeTest_Nullable(26)-638285573234549942.json: Attached
2023-08-25T10:48:43.4545014-04:00

## Test Name: TryParseTest (System.Double,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0011438
  * Outcome: Passed


## Test Name: GetSearchablePropertyNames_TestTargetModel

* Name: GetSearchablePropertyNames_TestTargetModel
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSearchablePropertyNames_TestTargetModel
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0004715
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000362
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Decimal],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0011655
  * Outcome: Passed


## Test Name: ToEnumTest (Val2,Val2)

* Name: ToEnumTest (Val2,Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000246
  * Outcome: Passed


## Test Name: GetFilterablePropertyNamesTest_TestTarget3Model

* Name: GetFilterablePropertyNamesTest_TestTarget3Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetFilterablePropertyNamesTest_TestTarget3Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0005256
  * Outcome: Passed


## Test Name: VisitTest_Equals (Hello,hello,False)

* Name: VisitTest_Equals (Hello,hello,False)
* Test Class: Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests
  * Method: VisitTest_Equals
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007975
  * Outcome: Passed


### Standard Out

TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => ((e != null) AndAlso e.Equals(value(Eliassen.System.Tests.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitorTests+<>c__DisplayClass4_0).matched))
result: False

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,DateTimeNullable,LessThan,2020-03-01T01:01:01.4356493+02:00,2,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0327509
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:DateTimeNullable: LessThan: 2020-03-01T01:01:01.4356493+02:00

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.DateTimeNullable < Convert(2/29/2020 6:01:01 PM, Nullable`1))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573221861857.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573221902023.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573222112805.json: Attached
resultKeys: 0,1

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01.4356493+02:00 parsed to 02/29/2020 18:01:01 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,index,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0262531
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:index: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573214419123.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573214461615.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573214623420.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Sort (Name,Descending,999,998,997,996,995,994,993,992,991,990)

* Name: ExecuteByTest_Sort (Name,Descending,999,998,997,996,995,994,993,992,991,990)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0202820
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Descending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderByDescending(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(266)-638285573230293930.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(268)-638285573230406974.json: Attached

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Descending

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,GreaterThan,995,4,996,997,998,999)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0213634
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: GreaterThan: 995

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index > 995)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573217325535.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573217366339.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573217480171.json: Attached
resultKeys: 996,997,998,999

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	995 parsed to 995 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,,10,0,1,2,3,4,5,6,7,8,9)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0279564
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo:

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Name != "")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573224155108.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573224210773.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573224375990.json: Attached
resultKeys: 0,1,2,3,4,5,6,7,8,9

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: GetTestDataAsyncTest_String

* Name: GetTestDataAsyncTest_String
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest_String
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0032029
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,Name1*,10,0,2,3,4,5,6,7,8,9,20)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0199199
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo: Name1*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => Not(n.Name.StartsWith("Name1"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573219069631.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573219112880.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573219223163.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,20

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: MakeSafeTest (System.Nullable`1[System.Guid],18AACB9C-2989-4322-A490-C7167BEA0DB4,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000447
  * Outcome: Passed


## Test Name: AddResultTest_Object_WithFileNameRemoveExtension

* Name: AddResultTest_Object_WithFileNameRemoveExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameRemoveExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0028416
  * Outcome: Passed


### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameRemoveExtension(150)-638285573212481806: Attached

## Test Name: ExecuteByTest_Sort (name,Descending,999,998,997,996,995,994,993,992,991,990)

* Name: ExecuteByTest_Sort (name,Descending,999,998,997,996,995,994,993,992,991,990)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0171245
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:name: Descending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderByDescending(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(266)-638285573229905548.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(268)-638285573229997625.json: Attached

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:name: Descending

## Test Name: ToEnumTest (4,WithEnumValue)

* Name: ToEnumTest (4,WithEnumValue)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000255
  * Outcome: Passed


## Test Name: GetSearchablePropertyNames_TestTarget2Model

* Name: GetSearchablePropertyNames_TestTarget2Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSearchablePropertyNames_TestTarget2Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003741
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,NotEqualTo,1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0197110
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: NotEqualTo: 1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(121)-638285573219269493.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(123)-638285573219309891.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(125)-638285573219413834.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,*3,10,100,10,3,13,23,33,43,53,63,73,83,93)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0290953
  * Outcome: Passed


### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = *3, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Debug:>
	Visited by: Eliassen.System.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitor
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (((n.Name != null) AndAlso n.Name.EndsWith("3")) OrElse ((n.Email != null) AndAlso n.Email.EndsWith("3")))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(192)-638285573228543186.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(194)-638285573228602806.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(196)-638285573228757473.json: Attached
resultKeys: 3,13,23,33,43,53,63,73,83,93

### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel

## Test Name: MakeSafeTest (System.String,Hello World,Hello World)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003314
  * Outcome: Passed


## Test Name: ToEnumTest (test short,WithDisplay)

* Name: ToEnumTest (test short,WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0018929
  * Outcome: Passed


