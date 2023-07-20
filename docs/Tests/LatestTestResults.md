# Test Results

## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,InDeX,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2614235
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:InDeX: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567957651205.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567958079742.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567959591779.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,InSet,System.String[],3,1,2,3)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2788669
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: InSet: Name1; Name2; Name3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => value(System.String[]).Contains(n.Name)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567964549771.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567964897187.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567965917746.json: Attached
resultKeys: 1,2,3


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetHash (hello world,XrY7u+Ae7tCTyyK7j1rNww==)

* Name: GetHash (hello world,XrY7u+Ae7tCTyyK7j1rNww==)
* Test Class: Eliassen.System.Tests.Security.Cryptography.HashTests
  * Method: GetHash
* Details: 
  * Duration: 00:00:00.0243718
  * Outcome: Passed


#### Standard Out

TestContext Messages:
"hello world" => "XrY7u+Ae7tCTyyK7j1rNww=="


## Test Name: MakeSafeTest (System.Nullable`1[System.Int32],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0021722
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Decimal],1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000314
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Decimal],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0037803
  * Outcome: Passed


## Test Name: AddResultFileTest_FileContentOutFile

* Name: AddResultFileTest_FileContentOutFile
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultFileTest_FileContentOutFile
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0112478
  * Outcome: Passed


#### Standard Out

TestContext Messages:
D:\Repos\Nu2\NetApi\TestResults\Deploy_MWhited 20230712T110633\In\LW-18560\test-file.txt


## Test Name: MakeSafeTest (System.Nullable`1[System.Double],1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000685
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Int32],1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001268
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,Name1*,10,1,10,11,12,13,14,15,16,17,18)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0845987
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: Name1*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.StartsWith("Name1")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567975625476.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567975810117.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567976247796.json: Attached
resultKeys: 1,10,11,12,13,14,15,16,17,18


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,*3,10,0,1,2,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0756548
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo: *3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => Not(n.Name.EndsWith("3"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567976478692.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567976640699.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567977048524.json: Attached
resultKeys: 0,1,2,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: MakeSafeTest (System.DateTime,3/16/2022 12:00:00 AM,3/16/2022 12:00:00 AM)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000955
  * Outcome: Passed


## Test Name: ToEnumTest (Val2, Val1,Val1, Val2)

* Name: ToEnumTest (Val2, Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000552
  * Outcome: Passed


## Test Name: GetSortablePropertyNamesTest_TestTarget3Model

* Name: GetSortablePropertyNamesTest_TestTarget3Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSortablePropertyNamesTest_TestTarget3Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007743
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,FC,EqualTo,ame1,2,-1,0)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1434967
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:FC: EqualTo: ame1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(e => e.FName.Contains(value(Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel+<>c__DisplayClass34_0).value.ToString())).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567992668794.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567992893828.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567993840717.json: Attached
resultKeys: -1,0


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,NotEqualTo,1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0903558
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: NotEqualTo: 1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567978723641.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567978876967.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567979340391.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetResourceFromJsonAsyncTest

* Name: GetResourceFromJsonAsyncTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0575967
  * Outcome: Passed


## Test Name: GetResourceStreamTest

* Name: GetResourceStreamTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceStreamTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0014059
  * Outcome: Passed


## Test Name: GetResourceAsStringAsyncTest

* Name: GetResourceAsStringAsyncTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceAsStringAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0161742
  * Outcome: Passed


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name3*,12,111,10,3,30,31,32,33,34,35,36,37,38)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1073805
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = Name3*, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Name.StartsWith("Name3") OrElse n.Email.StartsWith("Name3"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(181)-638247568009023958.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(183)-638247568009158046.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(185)-638247568009749074.json: Attached
resultKeys: 3,30,31,32,33,34,35,36,37,38


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: MakeSafeArrayTest (System.String,System.Object[],System.String[])

* Name: MakeSafeArrayTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeArrayTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0193057
  * Outcome: Passed


## Test Name: DeserializeTest_Nullable ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},)

* Name: DeserializeTest_Nullable ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Nullable
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0255438
  * Outcome: Passed


#### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Nullable(65)-638247568028085034.json: Attached
result-BsonDateConverterTests_DeserializeTest_Nullable(67)-638247568028182014.json: Attached


## Test Name: TryParseTest (System.Double,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0016584
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Double],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0052150
  * Outcome: Passed


## Test Name: AddResultTest_Object

* Name: AddResultTest_Object
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0207072
  * Outcome: Passed


#### Standard Out

TestContext Messages:
TestData-TextContextExtensionsTests_AddResultTest_Object(30)-638247567946301400.json: Attached


## Test Name: ToEnumTest (Val1,Val1)

* Name: ToEnumTest (Val1,Val1)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0061712
  * Outcome: Passed


## Test Name: ToEnumTest (-1,-1)

* Name: ToEnumTest (-1,-1)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0052858
  * Outcome: Passed


## Test Name: AddResultTest_Json

* Name: AddResultTest_Json
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Json
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1826720
  * Outcome: Passed


#### Standard Out

TestContext Messages:
JObject-TextContextExtensionsTests_AddResultTest_Json(190)-638247567943934450.json: Attached


## Test Name: TryParseTest (System.Nullable`1[System.Double],1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000283
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,Name3,1,3)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2174185
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: Name3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.Equals("Name3")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567962299727.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567962597314.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567963618867.json: Attached
resultKeys: 3


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetResourceFromJsonAsyncTest_NotFound

* Name: GetResourceFromJsonAsyncTest_NotFound
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonAsyncTest_NotFound
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0052905
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.AttributeTargets],Enum,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000097
  * Outcome: Passed


## Test Name: GetResourceFromXmlAsyncTest

* Name: GetResourceFromXmlAsyncTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromXmlAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1341558
  * Outcome: Passed


## Test Name: VisitTest_EqualOperator (Hello,HELLO,True)

* Name: VisitTest_EqualOperator (Hello,HELLO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EqualOperator
* Details: 
  * Duration: 00:00:00.0133434
  * Outcome: Passed


#### Standard Out

TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)


## Test Name: MakeSafeTest (System.Guid,18AACB9C-2989-4322-A490-C7167BEA0DB4,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001292
  * Outcome: Passed


## Test Name: ExecuteByTest_Page (1,-1,,,,1000,)

* Name: ExecuteByTest_Page (1,-1,,,,1000,)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1141292
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 1
PageSize: -1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute : System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(211)-638247568005892786.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(213)-638247568006288593.json: Attached
QueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(215)-638247568006621468.json: Attached


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 1
PageSize: -1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: VisitTest_Equals (Hello,HELLO,True)

* Name: VisitTest_Equals (Hello,HELLO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Equals
* Details: 
  * Duration: 00:00:00.0014920
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)


## Test Name: ToEnumTest (name,WithEnumValue)

* Name: ToEnumTest (name,WithEnumValue)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0069459
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel,Children,EqualTo,*001,10,2,3,4,5,6,7,8,9,12,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2781722
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Children: EqualTo: *001

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel].Where(n => n.Children.Any(child => child.EndsWith("001"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567996765771.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567997017945.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567999002612.json: Attached
resultKeys: 2,3,4,5,6,7,8,9,12,13


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel


## Test Name: ToEnumTest (name2,WithMemberName)

* Name: ToEnumTest (name2,WithMemberName)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0005680
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Decimal],1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001063
  * Outcome: Passed


## Test Name: ToEnumTest (Val2,Val1,Val1, Val2)

* Name: ToEnumTest (Val2,Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000411
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Int32,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026129
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,GreaterThanOrEqualTo,3/1/2020,10,2,3,4,5,6,7,8,9,10,11)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1510409
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: GreaterThanOrEqualTo: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date >= 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567981915859.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567982103965.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567982850025.json: Attached
resultKeys: 2,3,4,5,6,7,8,9,10,11


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: MakeSafeTest (System.Int32,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001887
  * Outcome: Passed


## Test Name: VisitTest_EndsWith (Hello,LO,True)

* Name: VisitTest_EndsWith (Hello,LO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Details: 
  * Duration: 00:00:00.0034644
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)


## Test Name: ToEnumTest (test name,WithDisplay)

* Name: ToEnumTest (test name,WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0004977
  * Outcome: Passed


## Test Name: ExecuteByTest_Sort (Name,Descending,999,998,997,996,995,994,993,992,991,990)

* Name: ExecuteByTest_Sort (Name,Descending,999,998,997,996,995,994,993,992,991,990)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0986902
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Descending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderByDescending(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(255)-638247568014121892.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(257)-638247568014682340.json: Attached


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Descending


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01,3,-1,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1193293
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 2020-03-01

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567984749100.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567984947112.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567985661050.json: Attached
resultKeys: -1,0,1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: DeserializeTest ({"_id":"Hello World"},Hello World)

* Name: DeserializeTest ({"_id":"Hello World"},Hello World)
* Test Class: Eliassen.System.Tests.Text.Json.BsonIdConverterTests
  * Method: DeserializeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0267229
  * Outcome: Passed


#### Standard Out

TestContext Messages:
input-BsonIdConverterTests_DeserializeTest(41)-638247568029332615.json: Attached
result-BsonIdConverterTests_DeserializeTest(43)-638247568029489779.json: Attached


## Test Name: ToEnumTest (Val2 , Val1,Val1, Val2)

* Name: ToEnumTest (Val2 , Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000360
  * Outcome: Passed


## Test Name: AddResultTest_String

* Name: AddResultTest_String
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_String
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0202248
  * Outcome: Passed


#### Standard Out

TestContext Messages:
String-TextContextExtensionsTests_AddResultTest_String(50)-638247567948852326.txt: Attached


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,INDEX,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1426289
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:INDEX: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567956225341.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567956463124.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567957274082.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,index,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1434057
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:index: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567954787913.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567954982661.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567955431690.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01T01:01:01,4,-1,0,1,2)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1343516
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 2020-03-01T01:01:01

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 3/1/2020 1:01:01 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567985944104.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567986171934.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567986968358.json: Attached
resultKeys: -1,0,1,2


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01 parsed to 03/01/2020 01:01:01 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: VisitTest_StartsWith (Hello,He,True)

* Name: VisitTest_StartsWith (Hello,He,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_StartsWith
* Details: 
  * Duration: 00:00:00.0020644
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)


## Test Name: ToEnumTest (4,WithEnumValue)

* Name: ToEnumTest (4,WithEnumValue)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000463
  * Outcome: Passed


## Test Name: ExecuteByTest_Sort (Name,Ascending,0,1,10,100,101,102,103,104,105,106)

* Name: ExecuteByTest_Sort (Name,Ascending,0,1,10,100,101,102,103,104,105,106)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0628245
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Ascending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(255)-638247568016386008.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(257)-638247568016727752.json: Attached


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:Name: Ascending


## Test Name: ToEnumTest (test description,WithDescription)

* Name: ToEnumTest (test description,WithDescription)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0004226
  * Outcome: Passed


## Test Name: ToEnumTest (Val2,Val2)

* Name: ToEnumTest (Val2,Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000488
  * Outcome: Passed


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name3,1,1,1,3)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1937259
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = Name3, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Name.Equals("Name3") OrElse n.Email.Equals("Name3"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(181)-638247568007174199.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(183)-638247568007323913.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(185)-638247568008652355.json: Attached
resultKeys: 3


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000614
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,EqualTo,1,1,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2028571
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: EqualTo: 1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index == 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567960271776.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567960986615.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567961791284.json: Attached
resultKeys: 1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetResourceStreamTest_NotFound

* Name: GetResourceStreamTest_NotFound
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceStreamTest_NotFound
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0007559
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.AttributeTargets],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008087
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0100237
  * Outcome: Passed


## Test Name: GetSearchablePropertyNames_TestTarget2Model

* Name: GetSearchablePropertyNames_TestTarget2Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSearchablePropertyNames_TestTarget2Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0009825
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Guid],18AACB9C-2989-4322-A490-C7167BEA0DB4,True,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001221
  * Outcome: Passed


## Test Name: ExecuteByTest_Sort (name,Descending,999,998,997,996,995,994,993,992,991,990)

* Name: ExecuteByTest_Sort (name,Descending,999,998,997,996,995,994,993,992,991,990)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0518019
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:name: Descending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderByDescending(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(255)-638247568014992212.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(257)-638247568015275226.json: Attached


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:name: Descending


## Test Name: GetTestDataAsyncTest_Stream

* Name: GetTestDataAsyncTest_Stream
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest_Stream
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0182221
  * Outcome: Passed


## Test Name: SerializeTest_Nullable

* Name: SerializeTest_Nullable
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: SerializeTest_Nullable
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0271438
  * Outcome: Passed


#### Standard Out

TestContext Messages:
result-BsonDateConverterTests_SerializeTest_Nullable(26)-638247568028925971.json: Attached
2023-07-12T11:06:42.8902284-04:00


## Test Name: ToEnumTest (0,Val0)

* Name: ToEnumTest (0,Val0)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000799
  * Outcome: Passed


## Test Name: MakeSafeArrayTest (System.String,System.Object[],System.String[])

* Name: MakeSafeArrayTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeArrayTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000490
  * Outcome: Passed


## Test Name: GetResourceStreamTest_ByType

* Name: GetResourceStreamTest_ByType
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceStreamTest_ByType
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008168
  * Outcome: Passed


## Test Name: TryParseTest (System.Decimal,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0065487
  * Outcome: Passed


## Test Name: DeserializeTest_Value ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},2023-07-05T14:17:05.2315812-04:00)

* Name: DeserializeTest_Value ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},2023-07-05T14:17:05.2315812-04:00)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Value
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0175730
  * Outcome: Passed


#### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Value(79)-638247568028679080.json: Attached
result-BsonDateConverterTests_DeserializeTest_Value(81)-638247568028759244.json: Attached


## Test Name: DeserializeTest_Value ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},0001-01-01T00:00:00+00:00)

* Name: DeserializeTest_Value ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},0001-01-01T00:00:00+00:00)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Value
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0271840
  * Outcome: Passed


#### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Value(79)-638247568028384020.json: Attached
result-BsonDateConverterTests_DeserializeTest_Value(81)-638247568028479491.json: Attached


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,DateTimeOffsetNullable,LessThan,2020-03-01T01:01:01.4356493+02:00,2,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1314789
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:DateTimeOffsetNullable: LessThan: 2020-03-01T01:01:01.4356493+02:00

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.DateTimeOffsetNullable < Convert(3/1/2020 1:01:01 AM +02:00, Nullable`1))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567990054205.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567990242757.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567990966046.json: Attached
resultKeys: 0,1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01.4356493+02:00 parsed to 03/01/2020 01:01:01 +02:00 (System.DateTimeOffset)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: GetFilterablePropertyNamesTest_TestTarget2Model

* Name: GetFilterablePropertyNamesTest_TestTarget2Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetFilterablePropertyNamesTest_TestTarget2Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0240904
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000640
  * Outcome: Passed


## Test Name: MakeSafeTest (System.String,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000333
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,Enum,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000236
  * Outcome: Passed


## Test Name: VisitTest_Equals (Hello,hello,True)

* Name: VisitTest_Equals (Hello,hello,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Equals
* Details: 
  * Duration: 00:00:00.0014378
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)


## Test Name: MakeSafeTest (System.Int32,1.1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000901
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Guid,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0025715
  * Outcome: Passed


## Test Name: TryParseTest (System.Guid,18AACB9C-2989-4322-A490-C7167BEA0DB4,True,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0079053
  * Outcome: Passed


## Test Name: AddResultTest_Lines

* Name: AddResultTest_Lines
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Lines
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0076169
  * Outcome: Passed


#### Standard Out

TestContext Messages:
String[]-TextContextExtensionsTests_AddResultTest_Lines(70)-638247567946193906.txt: Attached


## Test Name: VisitTest_EndsWith (Hello,lo,True)

* Name: VisitTest_EndsWith (Hello,lo,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Details: 
  * Duration: 00:00:00.0075542
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01T01:01:01.4356493+02:00,3,-1,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1480420
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 2020-03-01T01:01:01.4356493+02:00

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 2/29/2020 6:01:01 PM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567987289768.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567987527653.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567988459655.json: Attached
resultKeys: -1,0,1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01.4356493+02:00 parsed to 02/29/2020 18:01:01 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: VisitTest_StartsWith (Hello,he,True)

* Name: VisitTest_StartsWith (Hello,he,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_StartsWith
* Details: 
  * Duration: 00:00:00.0045418
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)


## Test Name: GetShortTypeNameTests (Eliassen.System.Tests.Reflection.ReflectionExtensionsTests,Eliassen.System.Tests.Reflection.ReflectionExtensionsTests, Eliassen.System.Tests)

* Name: GetShortTypeNameTests
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: GetShortTypeNameTests
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001502
  * Outcome: Passed


## Test Name: VisitTest_EndsWith (Hello,Lo,True)

* Name: VisitTest_EndsWith (Hello,Lo,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Details: 
  * Duration: 00:00:00.0018041
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)


## Test Name: GetShortTypeNameTests (System.String,System.String, System.Private.CoreLib)

* Name: GetShortTypeNameTests
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: GetShortTypeNameTests
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0039865
  * Outcome: Passed


## Test Name: GetTestDataAsyncTest

* Name: GetTestDataAsyncTest
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:01.6318273
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Int32],1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000272
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Guid],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0022885
  * Outcome: Passed


## Test Name: VisitTest_EndsWith (Hello,lO,True)

* Name: VisitTest_EndsWith (Hello,lO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EndsWith
* Details: 
  * Duration: 00:00:00.0021461
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)


## Test Name: ToEnumTest (no data,)

* Name: ToEnumTest (no data,)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0114190
  * Outcome: Passed


## Test Name: AddResultTest_Object_WithFileNameAndExtension

* Name: AddResultTest_Object_WithFileNameAndExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameAndExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0068952
  * Outcome: Passed


#### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameAndExtension(110)-638247567946646704.txt: Attached


## Test Name: GetHash (Hello World!,7Qdih1MuhjZehB6Sv8UNjA==)

* Name: GetHash (Hello World!,7Qdih1MuhjZehB6Sv8UNjA==)
* Test Class: Eliassen.System.Tests.Security.Cryptography.HashTests
  * Method: GetHash
* Details: 
  * Duration: 00:00:00.0001925
  * Outcome: Passed


#### Standard Out

TestContext Messages:
"Hello World!" => "7Qdih1MuhjZehB6Sv8UNjA=="


## Test Name: TryParseTest (System.AttributeTargets,Enum,True,Enum)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000328
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,16,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000560
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Decimal,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0059042
  * Outcome: Passed


## Test Name: GetTestDataAsyncTest_String

* Name: GetTestDataAsyncTest_String
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest_String
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0475681
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,*e2*,10,0,1,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0711599
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo: *e2*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => Not(n.Name.Contains("e2"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567977232293.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567977371163.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567977732852.json: Attached
resultKeys: 0,1,3,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ToEnumTest (,)

* Name: ToEnumTest (,)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0098109
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Double,nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0027535
  * Outcome: Passed


## Test Name: GetTestDataAsyncTest_Targeted

* Name: GetTestDataAsyncTest_Targeted
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: GetTestDataAsyncTest_Targeted
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0784110
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThanOrEqualTo,5,6,0,1,2,3,4,5)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0850898
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: LessThanOrEqualTo: 5

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index <= 5)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567971283982.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567971462433.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567971863512.json: Attached
resultKeys: 0,1,2,3,4,5


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	5 parsed to 5 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: AddResultTest_ValueOutFile

* Name: AddResultTest_ValueOutFile
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_ValueOutFile
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0146133
  * Outcome: Passed


#### Standard Out

TestContext Messages:
TestData-TextContextExtensionsTests_AddResultTest_ValueOutFile(210)-638247567949084698.json: Attached
D:\Repos\Nu2\NetApi\TestResults\Deploy_MWhited 20230712T110633\In\LW-18560\TestData-TextContextExtensionsTests_AddResultTest_ValueOutFile(210)-638247567949084698.json


## Test Name: TryParseTest (System.Decimal,1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0001593
  * Outcome: Passed


## Test Name: ToEnumTest (3,Val1, Val2)

* Name: ToEnumTest (3,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000416
  * Outcome: Passed


## Test Name: MakeSafeTest (System.AttributeTargets,Enum,Enum)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000475
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:01.0575626
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: EqualTo: !1

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index != 1)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567944529374.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567947225457.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567953107075.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,10


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	1 parsed to 1 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetFilterablePropertyNamesTest_TestTarget3Model

* Name: GetFilterablePropertyNamesTest_TestTarget3Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetFilterablePropertyNamesTest_TestTarget3Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0016481
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,GreaterThan,995,4,996,997,998,999)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0812923
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: GreaterThan: 995

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index > 995)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567972138118.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567972327765.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567972712531.json: Attached
resultKeys: 996,997,998,999


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	995 parsed to 995 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: TryParseTest (System.Double,1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000482
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Decimal],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026501
  * Outcome: Passed


## Test Name: TryParseTest (System.Guid,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026750
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThan,5,5,0,1,2,3,4)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1034151
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: LessThan: 5

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index < 5)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567970240439.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567970502148.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567970978777.json: Attached
resultKeys: 0,1,2,3,4


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	5 parsed to 5 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetResourceFromJsonTest

* Name: GetResourceFromJsonTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0027213
  * Outcome: Passed


## Test Name: ToEnumTest (test display,WithDisplay)

* Name: ToEnumTest (test display,WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0004915
  * Outcome: Passed


## Test Name: AsModelsTest

* Name: AsModelsTest
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: AsModelsTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0478540
  * Outcome: Passed


#### Standard Out

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


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000474
  * Outcome: Passed


## Test Name: GetSortablePropertyNamesTest_TestTargetModel

* Name: GetSortablePropertyNamesTest_TestTargetModel
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSortablePropertyNamesTest_TestTargetModel
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0015119
  * Outcome: Passed


## Test Name: SerializeTest

* Name: SerializeTest
* Test Class: Eliassen.System.Tests.Text.Json.BsonIdConverterTests
  * Method: SerializeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0115889
  * Outcome: Passed


#### Standard Out

TestContext Messages:
result-BsonIdConverterTests_SerializeTest(26)-638247568029821558.json: Attached
Hello World


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,GreaterThan,3/1/2020,10,3,4,5,6,7,8,9,10,11,12)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2283972
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: GreaterThan: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date > 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567979635332.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567979812891.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567981569462.json: Attached
resultKeys: 3,4,5,6,7,8,9,10,11,12


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,GreaterThanOrEqualTo,995,5,995,996,997,998,999)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0875081
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: GreaterThanOrEqualTo: 995

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index >= 995)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567972955746.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567973131560.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567973528045.json: Attached
resultKeys: 995,996,997,998,999


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	995 parsed to 995 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Page (0,1,1000,1000,0,1,0)

* Name: ExecuteByTest_Page (0,1,1000,1000,0,1,0)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0943776
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(0).Take(1)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(211)-638247568003985325.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(213)-638247568004218743.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(215)-638247568004638670.json: Attached
resultKeys: 0


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: GetResourceFromXmlTest

* Name: GetResourceFromXmlTest
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromXmlTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0259772
  * Outcome: Passed


## Test Name: VisitTest_Equals (Hello,HeLlO,True)

* Name: VisitTest_Equals (Hello,HeLlO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Equals
* Details: 
  * Duration: 00:00:00.0042712
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)


## Test Name: MakeSafeTest (System.String,Hello World,Hello World)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008465
  * Outcome: Passed


## Test Name: GetSearchablePropertyNames_TestTargetModel

* Name: GetSearchablePropertyNames_TestTargetModel
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSearchablePropertyNames_TestTargetModel
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008040
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter_Range_Bounds

* Name: ExecuteByTest_Filter_Range_Bounds
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter_Range_Bounds
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1930201
  * Outcome: Passed


#### Standard Out

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
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Filter_Range_Bounds(142)-638247568000844660.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Filter_Range_Bounds(144)-638247568002199746.json: Attached


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	7/1/2020 12:00:00 AM parsed to 07/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 12:00:00 AM parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,DateTimeNullable,LessThan,2020-03-01T01:01:01.4356493+02:00,2,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1280470
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:DateTimeNullable: LessThan: 2020-03-01T01:01:01.4356493+02:00

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.DateTimeNullable < Convert(2/29/2020 6:01:01 PM, Nullable`1))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567988771973.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567988953438.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567989744512.json: Attached
resultKeys: 0,1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	2020-03-01T01:01:01.4356493+02:00 parsed to 02/29/2020 18:01:01 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: ToEnumTest (test short,WithDisplay)

* Name: ToEnumTest (test short,WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0008912
  * Outcome: Passed


## Test Name: VisitTest_StartsWith (Hello,HE,True)

* Name: VisitTest_StartsWith (Hello,HE,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_StartsWith
* Details: 
  * Duration: 00:00:00.0018916
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000461
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Nullable`1[System.Guid],18AACB9C-2989-4322-A490-C7167BEA0DB4,18aacb9c-2989-4322-a490-c7167bea0db4)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000488
  * Outcome: Passed


## Test Name: GetSortablePropertyNamesTest_TestTarget2Model

* Name: GetSortablePropertyNamesTest_TestTarget2Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSortablePropertyNamesTest_TestTarget2Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0117506
  * Outcome: Passed


## Test Name: ToEnumTest (1,Val1)

* Name: ToEnumTest (1,Val1)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000550
  * Outcome: Passed


## Test Name: DeserializeTest ({"_id":{"$oid":"Hello World"}},Hello World)

* Name: DeserializeTest ({"_id":{"$oid":"Hello World"}},Hello World)
* Test Class: Eliassen.System.Tests.Text.Json.BsonIdConverterTests
  * Method: DeserializeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0119528
  * Outcome: Passed


#### Standard Out

TestContext Messages:
input-BsonIdConverterTests_DeserializeTest(41)-638247568029603731.json: Attached
result-BsonIdConverterTests_DeserializeTest(43)-638247568029658480.json: Attached


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,*3,10,100,10,3,13,23,33,43,53,63,73,83,93)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1094281
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = *3, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Name.EndsWith("3") OrElse n.Email.EndsWith("3"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(181)-638247568010099162.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(183)-638247568010239232.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(185)-638247568010702139.json: Attached
resultKeys: 3,13,23,33,43,53,63,73,83,93


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: TryParseTest (System.Int32,1,True,1)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000495
  * Outcome: Passed


## Test Name: GetFilterablePropertyNamesTest_TestTargetModel

* Name: GetFilterablePropertyNamesTest_TestTargetModel
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetFilterablePropertyNamesTest_TestTargetModel
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0028632
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,Name1*,10,0,2,3,4,5,6,7,8,9,20)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0775005
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: NotEqualTo: Name1*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => Not(n.Name.StartsWith("Name1"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567977946879.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567978106378.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567978474534.json: Attached
resultKeys: 0,2,3,4,5,6,7,8,9,20


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*03,9,103,203,303,403,503,603,703,803,903)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0933789
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: *03

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.EndsWith("03")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567973823618.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567973998788.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567974535798.json: Attached
resultKeys: 103,203,303,403,503,603,703,803,903


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,3/1/2020,3,-1,0,1)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1319319
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThan: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date < 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567983428080.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567983619747.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567984392186.json: Attached
resultKeys: -1,0,1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThanOrEqualTo,3/1/2020,4,-1,0,1,2)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1295854
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Date: LessThanOrEqualTo: 3/1/2020

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => (n.Date <= 3/1/2020 12:00:00 AM)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567991371338.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567991556399.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567992320838.json: Attached
resultKeys: -1,0,1,2


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	3/1/2020 parsed to 03/01/2020 00:00:00 (System.DateTime)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,InSet,System.Int32[],3,1,2,3)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1529508
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: InSet: 1; 2; 3

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => value(System.Int32[]).Contains(n.Index)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567967267205.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567967652963.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567968530415.json: Attached
resultKeys: 1,2,3


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: DefaultPageSizeTest

* Name: DefaultPageSizeTest
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: DefaultPageSizeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0338763
  * Outcome: Passed


## Test Name: MakeSafeTest (System.Decimal,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000400
  * Outcome: Passed


## Test Name: ToEnumTest (2,Val2)

* Name: ToEnumTest (2,Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000492
  * Outcome: Passed


## Test Name: MakeSafeTest (System.DateTimeOffset,3/16/2022 12:00:00 AM +05:00,3/16/2022 12:00:00 AM +05:00)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000751
  * Outcome: Passed


## Test Name: ExecuteByTest_Sort (NAME,Descending,999,998,997,996,995,994,993,992,991,990)

* Name: ExecuteByTest_Sort (NAME,Descending,999,998,997,996,995,994,993,992,991,990)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Sort
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0771611
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:NAME: Descending

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderByDescending(n => n.Name).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Sort(255)-638247568015581720.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Sort(257)-638247568016024342.json: Attached


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	S:NAME: Descending


## Test Name: MakeSafeTest (System.Byte[],QUJD,System.Byte[])

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0005600
  * Outcome: Passed


## Test Name: TryParseTest (System.Nullable`1[System.Int32],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0016936
  * Outcome: Passed


## Test Name: VisitTest_Contains (Hello,el,True)

* Name: VisitTest_Contains (Hello,el,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Contains
* Details: 
  * Duration: 00:00:00.0021349
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)


## Test Name: TryParseTest (System.Nullable`1[System.Double],nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0064999
  * Outcome: Passed


## Test Name: VisitTest_Contains (Hello,eL,True)

* Name: VisitTest_Contains (Hello,eL,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Contains
* Details: 
  * Duration: 00:00:00.0014508
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)


## Test Name: ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)

* Name: ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0025215
  * Outcome: Passed


## Test Name: AddResultTest_Object_WithFileNameRemoveExtension

* Name: AddResultTest_Object_WithFileNameRemoveExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameRemoveExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0069176
  * Outcome: Passed


#### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameRemoveExtension(150)-638247567946879081: Attached


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,*e3*,12,111,10,3,30,31,32,33,34,35,36,37,38)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0997327
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = *e3*, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Name.Contains("e3") OrElse n.Email.Contains("e3"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(181)-638247568011194185.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(183)-638247568011323421.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(185)-638247568011818065.json: Attached
resultKeys: 3,30,31,32,33,34,35,36,37,38


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: ExecuteByTest_Page (1,1,1000,1000,1,1,1)

* Name: ExecuteByTest_Page (1,1,1000,1000,1,1,1)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0818672
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 1
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(1).Take(1)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(211)-638247568004968564.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(213)-638247568005088427.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(215)-638247568005493037.json: Attached
resultKeys: 1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 1
PageSize: 1
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: MakeSafeTest (System.Nullable`1[System.Guid],nope,)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0026292
  * Outcome: Passed


## Test Name: AddResultTest_Object_WithFileNameAndChangeExtension

* Name: AddResultTest_Object_WithFileNameAndChangeExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameAndChangeExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0091701
  * Outcome: Passed


#### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameAndChangeExtension(130)-638247567946534290.html: Attached


## Test Name: ToEnumTest (Val2 ,Val1,Val1, Val2)

* Name: ToEnumTest (Val2 ,Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000423
  * Outcome: Passed


## Test Name: DeserializeTest_Nullable ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},2023-07-05T14:16:32.2015217-04:00)

* Name: DeserializeTest_Nullable ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},2023-07-05T14:16:32.2015217-04:00)
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: DeserializeTest_Nullable
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0539169
  * Outcome: Passed


#### Standard Out

TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Nullable(65)-638247568027609741.json: Attached
result-BsonDateConverterTests_DeserializeTest_Nullable(67)-638247568027864806.json: Attached


## Test Name: AddResultTest_Object_WithFileNameNoExtension

* Name: AddResultTest_Object_WithFileNameNoExtension
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Object_WithFileNameNoExtension
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0111645
  * Outcome: Passed


#### Standard Out

TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameNoExtension(90)-638247567946740995.json: Attached


## Test Name: VisitTest_EqualOperator (Hello,HeLlO,True)

* Name: VisitTest_EqualOperator (Hello,HeLlO,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EqualOperator
* Details: 
  * Duration: 00:00:00.0014210
  * Outcome: Passed


#### Standard Out

TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel,Children,EqualTo,*001,10,2,3,4,5,6,7,8,9,12,13)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.2634661
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Children: EqualTo: *001

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel].Where(n => n.Children.Any(child => child.EndsWith("001"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567994112552.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567994303134.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567995674011.json: Attached
resultKeys: 2,3,4,5,6,7,8,9,12,13


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel


## Test Name: ExecuteByTest_Page (0,0,100,1000,0,10,0,1,2,3,4,5,6,7,8,9)

* Name: ExecuteByTest_Page (0,0,100,1000,0,10,0,1,2,3,4,5,6,7,8,9)
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Page
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0990369
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTest_Page(211)-638247568002958217.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTest_Page(213)-638247568003170566.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTest_Page(215)-638247568003572705.json: Attached
resultKeys: 0,1,2,3,4,5,6,7,8,9


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Warning:>
	No filtering detected: System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]: CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: VisitTest_Contains (Hello,EL,True)

* Name: VisitTest_Contains (Hello,EL,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_Contains
* Details: 
  * Duration: 00:00:00.0293831
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)


## Test Name: SerializeTest_Value

* Name: SerializeTest_Value
* Test Class: Eliassen.System.Tests.Text.Json.BsonDateConverterTests
  * Method: SerializeTest_Value
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0079929
  * Outcome: Passed


#### Standard Out

TestContext Messages:
result-BsonDateConverterTests_SerializeTest_Value(48)-638247568029203651.json: Attached
2023-07-12T11:06:42.9202505-04:00


## Test Name: GetSearchablePropertyNames_TestTarget3Model

* Name: GetSearchablePropertyNames_TestTarget3Model
* Test Class: Eliassen.System.Tests.Linq.Expressions.ExpressionTreeBuilderTests
  * Method: GetSearchablePropertyNames_TestTarget3Model
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0079109
  * Outcome: Passed


## Test Name: AddResultFileTest_FileContent

* Name: AddResultFileTest_FileContent
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultFileTest_FileContent
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0542095
  * Outcome: Passed


## Test Name: MakeSafeTest (System.DateTime,3/16/2022,3/16/2022 12:00:00 AM)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000283
  * Outcome: Passed


## Test Name: TryParseTest (System.Int32,nope,False,)

* Name: TryParseTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: TryParseTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0030511
  * Outcome: Passed


## Test Name: GetResourceFromJsonTest_NotFound

* Name: GetResourceFromJsonTest_NotFound
* Test Class: Eliassen.System.Tests.Reflection.ResourceExtensionsTests
  * Method: GetResourceFromJsonTest_NotFound
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0021356
  * Outcome: Passed


## Test Name: MakeSafeTest (System.TimeSpan,16:00,16:00:00)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0022575
  * Outcome: Passed


## Test Name: MakeSafeArrayTest (System.Decimal,System.Object[],System.Decimal[])

* Name: MakeSafeArrayTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeArrayTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0005310
  * Outcome: Passed


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThan,5,5,0,1,2,3,4)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1440065
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Index: LessThan: 5

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => (n.Index < 5)).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567968803073.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567969036874.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567969808491.json: Attached
resultKeys: 0,1,2,3,4


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.ExpressionTreeBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	5 parsed to 5 (System.Int32)
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


## Test Name: MakeSafeTest (System.Double,1,1)

* Name: MakeSafeTest
* Test Class: Eliassen.System.Tests.Reflection.ReflectionExtensionsTests
  * Method: MakeSafeTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0003408
  * Outcome: Passed


## Test Name: ToEnumTest (Val2|Val1,Val1, Val2)

* Name: ToEnumTest (Val2|Val1,Val1, Val2)
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: ToEnumTest
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0000456
  * Outcome: Passed


## Test Name: AsModelsTest2

* Name: AsModelsTest2
* Test Class: Eliassen.System.Tests.Reflection.EnumExtensionsTests
  * Method: AsModelsTest2
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0213169
  * Outcome: Passed


#### Standard Out

TestContext Messages:
EnumModel { Id = 0, Name = Val0, Code = VAL0, Description = , Order = 0, Value = Val0, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val0 }
EnumModel { Id = 1, Name = Val1, Code = VAL1, Description = , Order = 0, Value = Val1, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val1 }
EnumModel { Id = 2, Name = Val2, Code = VAL2, Description = , Order = 0, Value = Val2, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val2 }
EnumModel { Id = 4, Name = WithEnumValue, Code = name, Description = , Order = 0, Value = WithEnumValue, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithEnumValue }
EnumModel { Id = 8, Name = WithMemberName, Code = name2, Description = , Order = 0, Value = WithMemberName, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithMemberName }
EnumModel { Id = 16, Name = WithDescription, Code = WITHDESCRIPTION, Description = test description, Order = 0, Value = WithDescription, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithDescription }
EnumModel { Id = 32, Name = test name, Code = test short, Description = test display, Order = 0, Value = WithDisplay, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithDisplay }


## Test Name: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,FName0999 LName0001,1,1,1,1)

* Name: ExecuteByTest_SearchTerm
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_SearchTerm
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.1487581
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for SearchQuery { CurrentPage = 0, PageSize = 0, ExcludePageCount = False, SearchTerm = FName0999 LName0001, Filter = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.FilterParameter], OrderBy = System.Collections.Generic.Dictionary`2[System.String,Eliassen.System.Linq.Search.OrderDirections] }
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel].Where(n => ((((((n.FName + " ") + n.LName).Equals("FName0999 LName0001") OrElse ((n.LName + " ") + n.FName).Equals("FName0999 LName0001")) OrElse n.FName.Equals("FName0999 LName0001")) OrElse n.LName.Equals("FName0999 LName0001")) OrElse n.Email.Equals("FName0999 LName0001"))).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(181)-638247568012199061.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(183)-638247568012331827.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestSearchTerm(185)-638247568013311292.json: Attached
resultKeys: 1


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel


## Test Name: AddResultTest_Stream

* Name: AddResultTest_Stream
* Test Class: Eliassen.TestUtilities.Tests.TextContextExtensionsTests
  * Method: AddResultTest_Stream
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0084463
  * Outcome: Passed


#### Standard Out

TestContext Messages:
MemoryStream-TextContextExtensionsTests_AddResultTest_Stream(170)-638247567948720187.bin: Attached


## Test Name: VisitTest_EqualOperator (Hello,hello,True)

* Name: VisitTest_EqualOperator (Hello,hello,True)
* Test Class: Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests
  * Method: VisitTest_EqualOperator
* Details: 
  * Duration: 00:00:00.0026159
  * Outcome: Passed


#### Standard Out

TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)


## Test Name: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*e2*,10,2,20,21,22,23,24,25,26,27,28)

* Name: ExecuteByTest_Filter
* Test Class: Eliassen.System.Tests.Linq.QueryableExtensionsTests
  * Method: ExecuteByTest_Filter
* Categories
  * Unit
* Details: 
  * Duration: 00:00:00.0864408
  * Outcome: Passed


#### Standard Out

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Build query for CurrentPage: 0
PageSize: 0
ExcludePageCount: False
SearchTerm: (null)
	F:Name: EqualTo: *e2*

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.QueryBuilder]:Information:>
	Execute (paged): System.Linq.Enumerable+SelectRangeIterator`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel].Where(n => n.Name.Contains("e2")).OrderBy(_ => 0).Skip(0).Take(10)



TestContext Messages:
SearchQuery-QueryableExtensionsTests_ExecuteByTestFilter(110)-638247567974759603.json: Attached
EnumerableQuery_1-QueryableExtensionsTests_ExecuteByTestFilter(112)-638247567974938314.json: Attached
PagedQueryResult_1-QueryableExtensionsTests_ExecuteByTestFilter(114)-638247567975371904.json: Attached
resultKeys: 2,20,21,22,23,24,25,26,27,28


#### Standard Error

Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Search.SortBuilder`1[Eliassen.System.Tests.Linq.TestTargets.TestTargetModel]]:Warning:>
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel


