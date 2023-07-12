# Test Results

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,InDeX,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3f78e8fa-e5db-4ccd-b96d-b25dfe2e1a3b |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2614235 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,InSet,System.String[],3,1,2,3)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 956dbd42-7507-4b61-9a73-e7ace76046f3 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2788669 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetHash (hello world,XrY7u+Ae7tCTyyK7j1rNww==)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 85402472-3cbc-4a1e-9ba2-390fef860389 |
| TestID       | 4ec775bf-44bd-e2cb-9974-71998d0ab555 |
| Duration     | 00:00:00.0243718 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
"hello world" => "XrY7u+Ae7tCTyyK7j1rNww=="---

## Test: MakeSafeTest (System.Nullable`1[System.Int32],nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 0146519c-098a-4d44-8e24-31f0230a4153 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0021722 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Nullable`1[System.Decimal],1,True,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ad59c57d-2e7b-4578-af50-8ec8cf665c07 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0000314 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Nullable`1[System.Decimal],nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 6259d801-9083-4af0-917f-5a8f66432e6b |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0037803 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultFileTest_FileContentOutFile

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 10c4aafa-7e31-4401-b88c-54b8cb4badde |
| TestID       | 726abc2c-502d-4a5c-e2c7-073f21d793da |
| Duration     | 00:00:00.0112478 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
D:\Repos\Nu2\NetApi\TestResults\Deploy_MWhited 20230712T110633\In\LW-18560\test-file.txt---

## Test: MakeSafeTest (System.Nullable`1[System.Double],1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 5750ea4e-97cb-42f3-9089-c54b1ab0650b |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000685 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.Int32],1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b9120847-5941-4fb2-8c81-d607df68a062 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0001268 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,Name1*,10,1,10,11,12,13,14,15,16,17,18)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 81191c27-1887-4e82-b7d4-5e8dfbca3711 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0845987 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,*3,10,0,1,2,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 415dc47b-f87a-4dab-a6f5-3ae86abea618 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0756548 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: MakeSafeTest (System.DateTime,3/16/2022 12:00:00 AM,3/16/2022 12:00:00 AM)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 2ccc903f-2872-4a44-a58f-5136db4178da |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000955 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (Val2, Val1,Val1, Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 5a0a2ebf-0916-49e5-a75c-500f956e1ddd |
| TestID       | 43cddb60-93d3-07dc-800e-d7f3fb0979de |
| Duration     | 00:00:00.0000552 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetSortablePropertyNamesTest_TestTarget3Model

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e1a81fe4-6ffd-4088-a595-769d6da7a6b0 |
| TestID       | 53c31e49-be7f-689b-3cd7-03a9033ae78d |
| Duration     | 00:00:00.0007743 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,FC,EqualTo,ame1,2,-1,0)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b593ab75-93e4-459e-a2b4-3e9f847f3fc2 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1434967 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,NotEqualTo,1,10,0,2,3,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3d81b8d0-95ec-4d35-aa4b-8ecf347ab4e5 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0903558 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetResourceFromJsonAsyncTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | cc3ffd60-dc16-4df2-83ce-4ac9d7faab7a |
| TestID       | f664882a-a952-a76f-bc8f-fcf0578ff20f |
| Duration     | 00:00:00.0575967 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetResourceStreamTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 556942de-d590-4c92-ba84-e12d17bd3576 |
| TestID       | 5745a05f-6078-14a6-d124-e23b5e51504a |
| Duration     | 00:00:00.0014059 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetResourceAsStringAsyncTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a42e1403-79d5-4ff4-be7e-c9ef456ca523 |
| TestID       | c32d9ec7-cf3f-0b90-7da7-80e3553b5fe6 |
| Duration     | 00:00:00.0161742 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name3*,12,111,10,3,30,31,32,33,34,35,36,37,38)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9ac11bc4-90f3-4afd-8090-a378656ec1b4 |
| TestID       | f5306a38-7e9d-ad71-73c6-1c694342dc21 |
| Duration     | 00:00:00.1073805 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: MakeSafeArrayTest (System.String,System.Object[],System.String[])

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 4f35e72b-d35f-4022-b7b3-84a0c630aba5 |
| TestID       | 2f56b32e-ea97-c552-8dea-074dcb4e0dc0 |
| Duration     | 00:00:00.0193057 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: DeserializeTest_Nullable ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b7659781-366b-4947-8eba-d5d5ee9d3f92 |
| TestID       | 9ca98e2e-39fe-bd70-5dbf-6651f02a6f82 |
| Duration     | 00:00:00.0255438 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Nullable(65)-638247568028085034.json: Attached
result-BsonDateConverterTests_DeserializeTest_Nullable(67)-638247568028182014.json: Attached---

## Test: TryParseTest (System.Double,nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 88cc1405-7f44-4f92-b619-e0e81d728ac2 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0016584 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.Double],nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 090ef499-31ae-43ef-b80a-adb57816fb9c |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0052150 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_Object

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 72a0bbeb-b743-46b1-840c-6e2ac2a9d2d6 |
| TestID       | 419ef0dc-c4eb-bdc4-db64-68fe0fa43397 |
| Duration     | 00:00:00.0207072 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
TestData-TextContextExtensionsTests_AddResultTest_Object(30)-638247567946301400.json: Attached---

## Test: ToEnumTest (Val1,Val1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 87a31c65-868d-40d6-8f81-10c1681b1594 |
| TestID       | dd44d882-bbf0-8d3f-81b5-fca621eb814a |
| Duration     | 00:00:00.0061712 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (-1,-1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | fb7bb55b-efd6-4738-a983-5c90e17dbed6 |
| TestID       | 03664e08-d1d6-b6ed-2542-bbfffc2eeffd |
| Duration     | 00:00:00.0052858 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_Json

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9e3e56a8-4136-40a7-9020-7c6f89ea5940 |
| TestID       | 8aec3498-0c1a-9091-2458-51d1c67933bf |
| Duration     | 00:00:00.1826720 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
JObject-TextContextExtensionsTests_AddResultTest_Json(190)-638247567943934450.json: Attached---

## Test: TryParseTest (System.Nullable`1[System.Double],1,True,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 2db90b4a-985b-4af8-966b-278f20107fcf |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0000283 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,Name3,1,3)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 79efe88f-cdf4-4dd4-a781-84edbe07e611 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2174185 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetResourceFromJsonAsyncTest_NotFound

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 667bbd69-5333-48d7-8d80-39ced3298fb2 |
| TestID       | d1d4b925-a073-2286-7de7-05497c979951 |
| Duration     | 00:00:00.0052905 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.AttributeTargets],Enum,Enum)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 7e675aa5-b21f-4809-b20f-6ad765480bcd |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000097 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetResourceFromXmlAsyncTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | cfbdcc6f-0d74-46e8-b85d-1e5dca6c4ef7 |
| TestID       | 3dc461cc-f900-b7f4-a669-e9cf3ad5e21f |
| Duration     | 00:00:00.1341558 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_EqualOperator (Hello,HELLO,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 8e277837-d79d-4c54-bcdf-10edd76dd190 |
| TestID       | f1ca7862-7012-fca3-bc64-c4b909ce113e |
| Duration     | 00:00:00.0133434 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)---

## Test: MakeSafeTest (System.Guid,18AACB9C-2989-4322-A490-C7167BEA0DB4,18aacb9c-2989-4322-a490-c7167bea0db4)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 8b20d2b5-8865-4781-a145-9b5ac5f0b239 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0001292 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Page (1,-1,,,,1000,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 6bf6336c-6ff2-48f2-9ea7-2466ef62437a |
| TestID       | 097c6a10-18a9-39a7-0ebb-a3f23d7fe62c |
| Duration     | 00:00:00.1141292 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: VisitTest_Equals (Hello,HELLO,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | baf4235a-548c-4dac-8046-b0618bd764b2 |
| TestID       | 18395153-d175-05ff-ac08-0ac1a4735878 |
| Duration     | 00:00:00.0014920 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)---

## Test: ToEnumTest (name,WithEnumValue)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a8a77cc7-0c20-491d-b999-cdc1e39aa4d2 |
| TestID       | 21093773-0ccb-bba8-f879-81b437245fa9 |
| Duration     | 00:00:00.0069459 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel,Children,EqualTo,*001,10,2,3,4,5,6,7,8,9,12,13)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 310d3bfc-47ab-4eb8-88fa-2c194c5d07ec |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2781722 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerListModel---

## Test: ToEnumTest (name2,WithMemberName)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | bbfde67b-ae98-4ae3-b6b6-b115bf0c9536 |
| TestID       | e1fb2b94-155b-c3bc-ea67-b51d24fb0ee1 |
| Duration     | 00:00:00.0005680 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.Decimal],1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 71ac0593-a3d5-4d76-a212-70b43525f01b |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0001063 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (Val2,Val1,Val1, Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a4c75fa1-8519-48d8-8868-f14695464aaa |
| TestID       | a408f564-63a3-b73e-8bba-2ae24f999c82 |
| Duration     | 00:00:00.0000411 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Int32,nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 427fdde6-fdfe-42f5-9b4f-bf8d55104a45 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0026129 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,GreaterThanOrEqualTo,3/1/2020,10,2,3,4,5,6,7,8,9,10,11)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ef420b27-9798-425f-86c1-d34af337c468 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1510409 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: MakeSafeTest (System.Int32,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 71840290-ca2d-4e6a-b1ed-fe3614dadd22 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0001887 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_EndsWith (Hello,LO,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 08af171b-79ba-4836-a4ed-faba21e8609a |
| TestID       | 953b145f-93a1-d81f-df20-a99b55b1c613 |
| Duration     | 00:00:00.0034644 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)---

## Test: ToEnumTest (test name,WithDisplay)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 8ce2ff43-fbf8-4292-b398-987608e60869 |
| TestID       | 5c331900-1a47-ba58-8070-fe2be9107810 |
| Duration     | 00:00:00.0004977 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Sort (Name,Descending,999,998,997,996,995,994,993,992,991,990)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f8f6dd3e-1ae2-4807-a8b8-527c9ab6134d |
| TestID       | 041558fb-75d3-1396-4b97-c58fb702cd03 |
| Duration     | 00:00:00.0986902 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	S:Name: Descending---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01,3,-1,0,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 663529b7-c9a4-44b3-8c48-131a69691454 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1193293 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: DeserializeTest ({"_id":"Hello World"},Hello World)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3ff59c32-b5a9-4110-9b3d-5ac8dd491e11 |
| TestID       | ab883833-a001-7ba4-cd79-87ec0d12e81b |
| Duration     | 00:00:00.0267229 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
input-BsonIdConverterTests_DeserializeTest(41)-638247568029332615.json: Attached
result-BsonIdConverterTests_DeserializeTest(43)-638247568029489779.json: Attached---

## Test: ToEnumTest (Val2 , Val1,Val1, Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 4baf6d29-f3b9-45d4-a789-409fbbe6cf1d |
| TestID       | 2a43b0ee-f597-df06-c33f-a55b164294f1 |
| Duration     | 00:00:00.0000360 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_String

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e5dfd803-b578-40f4-a62a-055a90a359fd |
| TestID       | de980556-11bb-d6e9-c03a-e5592a3218d5 |
| Duration     | 00:00:00.0202248 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
String-TextContextExtensionsTests_AddResultTest_String(50)-638247567948852326.txt: Attached---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,INDEX,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ff838289-8106-43cf-bbf9-0e52629d758f |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1426289 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,index,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f1a6e21c-ba6b-430b-822e-535a87fa7e03 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1434057 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01T01:01:01,4,-1,0,1,2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | cc45cded-4ffb-41ca-9cac-3c5f4efdcdaf |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1343516 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: VisitTest_StartsWith (Hello,He,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 45db4109-1e30-4433-8c67-60ea0cd1a985 |
| TestID       | bbc4116e-a4fd-75c7-a01b-47e4e035c23b |
| Duration     | 00:00:00.0020644 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)---

## Test: ToEnumTest (4,WithEnumValue)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | bbc3a679-30bc-4c53-80e1-b56fb710a9ac |
| TestID       | a31f7ce6-9bfa-7f83-b06d-d43b4a9750e7 |
| Duration     | 00:00:00.0000463 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Sort (Name,Ascending,0,1,10,100,101,102,103,104,105,106)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 21f1c67f-c7a6-4868-ac67-0b44ded22f4e |
| TestID       | 5ad17c80-8edc-b4f5-e4b2-24df2e341980 |
| Duration     | 00:00:00.0628245 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	S:Name: Ascending---

## Test: ToEnumTest (test description,WithDescription)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 267f738f-f986-4c49-af5e-47522015a986 |
| TestID       | 539512be-65dd-8721-c925-480212898c01 |
| Duration     | 00:00:00.0004226 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (Val2,Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 09efa394-f14e-4f85-9e1d-7cb4cdaf3f21 |
| TestID       | d8b130e5-1205-8d83-88a5-79b4398dd526 |
| Duration     | 00:00:00.0000488 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name3,1,1,1,3)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f369bf1b-7c35-4a3e-91c8-8695eeb2473d |
| TestID       | f5306a38-7e9d-ad71-73c6-1c694342dc21 |
| Duration     | 00:00:00.1937259 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: MakeSafeTest (System.Decimal,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9e555d2c-cc90-44b5-89cb-ae00dc828859 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000614 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,EqualTo,1,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 6cd26b79-1d0d-4061-8bfc-7453a488e980 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2028571 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetResourceStreamTest_NotFound

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a2e93b39-8014-4392-9559-5f0234feb594 |
| TestID       | 9576cb6d-ffa5-4a23-9c7a-c5c6b213d46b |
| Duration     | 00:00:00.0007559 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.AttributeTargets],nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b828f101-a0a1-4267-b670-e52e5af65c97 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0008087 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.AttributeTargets,nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 37805564-521d-4290-aa6e-2aff0658c4f1 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0100237 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetSearchablePropertyNames_TestTarget2Model

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a56591ba-709b-4ef1-ad8b-cdc80ebdfee1 |
| TestID       | 7a9a1822-3db2-a438-faf7-05813fd14fc1 |
| Duration     | 00:00:00.0009825 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Nullable`1[System.Guid],18AACB9C-2989-4322-A490-C7167BEA0DB4,True,18aacb9c-2989-4322-a490-c7167bea0db4)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3d6a00e6-95d9-4bc4-9daf-d417a60f67a4 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0001221 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Sort (name,Descending,999,998,997,996,995,994,993,992,991,990)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | dae0136c-be4b-445e-b44d-ef07379ccba9 |
| TestID       | c0e5070f-df70-9b7f-a6bc-bd35abb11bb1 |
| Duration     | 00:00:00.0518019 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	S:name: Descending---

## Test: GetTestDataAsyncTest_Stream

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 659281c4-3129-4bbf-a521-175358e0c74a |
| TestID       | 09f85366-159b-5dce-cdaa-bbbd3e98347c |
| Duration     | 00:00:00.0182221 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: SerializeTest_Nullable

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 986bf5f7-714a-45a1-b592-8889737899d9 |
| TestID       | c07bd30b-1999-489c-e66f-17f7d59077a7 |
| Duration     | 00:00:00.0271438 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
result-BsonDateConverterTests_SerializeTest_Nullable(26)-638247568028925971.json: Attached
2023-07-12T11:06:42.8902284-04:00---

## Test: ToEnumTest (0,Val0)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 26f7fa49-483e-4ca1-86e1-e1a4c2531bb1 |
| TestID       | 3b9032c6-6dc6-1325-82e0-83e9947cd135 |
| Duration     | 00:00:00.0000799 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeArrayTest (System.String,System.Object[],System.String[])

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | edd9ba91-341a-46ab-8970-2bd6969d0179 |
| TestID       | 2f56b32e-ea97-c552-8dea-074dcb4e0dc0 |
| Duration     | 00:00:00.0000490 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetResourceStreamTest_ByType

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 7a791485-b9f1-4c4f-a087-2b7f0862b08e |
| TestID       | 63fad722-7037-7050-fa28-b32ff1a4ec2f |
| Duration     | 00:00:00.0008168 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Decimal,nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 00c3e965-ad6c-430c-8b54-7c32338da2fc |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0065487 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: DeserializeTest_Value ({"Nullable":null,"Value":{"$date":"2023-07-05T14:17:05.2315812-04:00"}},2023-07-05T14:17:05.2315812-04:00)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f5e38960-8742-4fd3-9b4b-a194a186e228 |
| TestID       | 316f1657-6542-4a79-deae-f2562a47d307 |
| Duration     | 00:00:00.0175730 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Value(79)-638247568028679080.json: Attached
result-BsonDateConverterTests_DeserializeTest_Value(81)-638247568028759244.json: Attached---

## Test: DeserializeTest_Value ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},0001-01-01T00:00:00+00:00)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 40414dbd-d3d2-4c9f-ba4e-6017d37a6ada |
| TestID       | 24115af0-d667-38c5-d65c-a4684a0e99cd |
| Duration     | 00:00:00.0271840 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Value(79)-638247568028384020.json: Attached
result-BsonDateConverterTests_DeserializeTest_Value(81)-638247568028479491.json: Attached---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,DateTimeOffsetNullable,LessThan,2020-03-01T01:01:01.4356493+02:00,2,0,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 050aa87b-ff84-4d77-9ffa-1b55f1043134 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1314789 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: GetFilterablePropertyNamesTest_TestTarget2Model

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 66d7d034-313b-4452-80bc-e498e825a59d |
| TestID       | b5b73f46-926e-b166-c509-00a2b6834bdd |
| Duration     | 00:00:00.0240904 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Decimal,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f9e3da33-eb5e-4bdf-a3cd-d5ba683cea44 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000640 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.String,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 42909a7d-21d8-4080-adf4-7e0bbfaf4691 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000333 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.AttributeTargets,Enum,Enum)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | d5f05044-c57e-4433-bfd8-1ed19eb39e05 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000236 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_Equals (Hello,hello,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b48770bb-f7c2-454d-a970-223f3e02a7b4 |
| TestID       | 1393df45-3e4c-b47c-4dac-45aa808b946e |
| Duration     | 00:00:00.0014378 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)---

## Test: MakeSafeTest (System.Int32,1.1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 79cc1528-a148-490a-b524-d17ae6aeb617 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000901 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Guid,nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 56c76334-eb9b-45cc-a20f-7bdb885932cb |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0025715 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Guid,18AACB9C-2989-4322-A490-C7167BEA0DB4,True,18aacb9c-2989-4322-a490-c7167bea0db4)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e3f08749-bce8-4b25-99de-524c3eee0142 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0079053 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_Lines

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 32262f63-1aa1-4ed1-833c-a6bdebd42c48 |
| TestID       | ed2eb3a8-9a8f-8428-0d0a-7e6a2f6200e2 |
| Duration     | 00:00:00.0076169 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
String[]-TextContextExtensionsTests_AddResultTest_Lines(70)-638247567946193906.txt: Attached---

## Test: VisitTest_EndsWith (Hello,lo,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 360b8e4a-d0e5-4023-9f5f-c01b9388efc9 |
| TestID       | faaecb11-889b-0448-0a52-a9472d72fc1a |
| Duration     | 00:00:00.0075542 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,2020-03-01T01:01:01.4356493+02:00,3,-1,0,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ad28aabc-e69a-4a80-a390-29a30d473027 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1480420 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: VisitTest_StartsWith (Hello,he,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | c631aa4c-9da3-4c2f-9184-4fa1320dea75 |
| TestID       | e8450689-da78-a4e3-273a-a1a992c142e8 |
| Duration     | 00:00:00.0045418 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)---

## Test: GetShortTypeNameTests (Eliassen.System.Tests.Reflection.ReflectionExtensionsTests,Eliassen.System.Tests.Reflection.ReflectionExtensionsTests, Eliassen.System.Tests)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e6f0dd02-2b35-4420-8263-d1240229f0d3 |
| TestID       | 67b6a854-1fe4-5528-77d6-501bd90b9a20 |
| Duration     | 00:00:00.0001502 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_EndsWith (Hello,Lo,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | bb350709-9981-4527-bad6-4c56e983e5b8 |
| TestID       | 49e4cf53-9c37-c250-3e09-ceb7ceaa3ed0 |
| Duration     | 00:00:00.0018041 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)---

## Test: GetShortTypeNameTests (System.String,System.String, System.Private.CoreLib)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 7be3161b-dc0c-42b2-a5c4-5df8b1330ba7 |
| TestID       | 67b6a854-1fe4-5528-77d6-501bd90b9a20 |
| Duration     | 00:00:00.0039865 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetTestDataAsyncTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | d212bf96-3169-4ee5-a627-07e170fee926 |
| TestID       | b14f6909-8be4-5d0a-1d4e-766cb1e4abd6 |
| Duration     | 00:00:01.6318273 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Nullable`1[System.Int32],1,True,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ed3e72a3-1dca-43b8-b395-5bd9f5f5864e |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0000272 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Nullable`1[System.Guid],nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 8b79c30a-4f12-4e6f-b893-fcb21295c8ab |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0022885 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_EndsWith (Hello,lO,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | c8944a82-6d4e-48c2-89c1-c4cedc0bb8bc |
| TestID       | 858bbd00-320c-bebc-b248-b9a147428a36 |
| Duration     | 00:00:00.0021461 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched) with e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched)
visited: e => e.EndsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass8_0).matched, CurrentCultureIgnoreCase)---

## Test: ToEnumTest (no data,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 40a58702-62c6-4659-8ef5-47c679e5dc8e |
| TestID       | 63b92630-a4a1-cac5-6116-10b2041768f2 |
| Duration     | 00:00:00.0114190 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_Object_WithFileNameAndExtension

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 1a619e5b-1658-46bd-b58e-d9fc703b2f79 |
| TestID       | bfc7f80f-e281-5816-dc57-387e099d2a10 |
| Duration     | 00:00:00.0068952 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameAndExtension(110)-638247567946646704.txt: Attached---

## Test: GetHash (Hello World!,7Qdih1MuhjZehB6Sv8UNjA==)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 70b12b79-b7ac-462d-aafc-ae13494d6abd |
| TestID       | 9518e1d2-e9c8-2c63-c450-f14492a5f26f |
| Duration     | 00:00:00.0001925 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
"Hello World!" => "7Qdih1MuhjZehB6Sv8UNjA=="---

## Test: TryParseTest (System.AttributeTargets,Enum,True,Enum)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 0d3f0ee6-7ef6-462a-9a58-0385543d0818 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0000328 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.AttributeTargets,16,Enum)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e4d24024-2e0f-491b-af07-6973557fca71 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000560 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Decimal,nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3bd4f409-80ad-480c-9473-5902197ef987 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0059042 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetTestDataAsyncTest_String

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 75b44a6f-985c-4fb1-b7db-502953d11ebb |
| TestID       | 5bb4fd62-5d31-f92e-3aec-4b3c222ba16c |
| Duration     | 00:00:00.0475681 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,*e2*,10,0,1,3,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b1b5abec-4cfb-45fc-8d47-5a4a383834fd |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0711599 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ToEnumTest (,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9b0a810b-380b-4981-8e25-3abad541bfa1 |
| TestID       | a29d2822-126a-1900-33c2-f20f68d10c99 |
| Duration     | 00:00:00.0098109 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Double,nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3560e3ee-6723-4df9-b74a-acacea7e58dc |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0027535 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetTestDataAsyncTest_Targeted

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | bb015205-0b2a-4851-8c46-f3cf4bf7125b |
| TestID       | 01e51d56-c992-5e2d-f6ea-cf3f1977a589 |
| Duration     | 00:00:00.0784110 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThanOrEqualTo,5,6,0,1,2,3,4,5)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e6067eff-3552-4064-95f7-0b888c283f39 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0850898 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: AddResultTest_ValueOutFile

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 1bfe9d20-8964-4c3e-ad0a-ffefb9bdeee1 |
| TestID       | 35da343a-5826-ac4c-688a-c2bbf7572a30 |
| Duration     | 00:00:00.0146133 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
TestData-TextContextExtensionsTests_AddResultTest_ValueOutFile(210)-638247567949084698.json: Attached
D:\Repos\Nu2\NetApi\TestResults\Deploy_MWhited 20230712T110633\In\LW-18560\TestData-TextContextExtensionsTests_AddResultTest_ValueOutFile(210)-638247567949084698.json---

## Test: TryParseTest (System.Decimal,1,True,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e26c26f6-f21b-426b-98c2-a8dd0539fe43 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0001593 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (3,Val1, Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 4c3178a9-4032-4143-9daf-17d7f125f58b |
| TestID       | 5149ec15-5f36-7659-426f-c0787e7bd777 |
| Duration     | 00:00:00.0000416 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.AttributeTargets,Enum,Enum)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 0309fdac-a152-4ef2-b35e-067a4ceb4c45 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000475 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,EqualTo,!1,10,0,2,3,4,5,6,7,8,9,10)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 64442a63-825c-4369-9d1e-5a7fdc6cc00e |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:01.0575626 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetFilterablePropertyNamesTest_TestTarget3Model

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 4257fda4-c0b0-4271-9eee-2f351f157daf |
| TestID       | dcab6442-3647-193e-5b50-9725bbfda52b |
| Duration     | 00:00:00.0016481 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,GreaterThan,995,4,996,997,998,999)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | eef36dca-09b1-459b-94de-000479b50e3b |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0812923 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: TryParseTest (System.Double,1,True,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e5aa14e0-2343-40ac-8ddb-2ed99368b1df |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0000482 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.Decimal],nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e12a1a03-f105-4a68-8716-e9bd18f7ac0e |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0026501 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Guid,nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | dfdcb146-c00b-42ea-b8a1-ed441c40670b |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0026750 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThan,5,5,0,1,2,3,4)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9b143a4e-ce39-4b67-b3d4-f5227e56a0cf |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1034151 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetResourceFromJsonTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9c94ad7f-89ed-4571-9dfd-fe79d1f45402 |
| TestID       | 65b4a990-8424-f23f-9b61-155855edf172 |
| Duration     | 00:00:00.0027213 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (test display,WithDisplay)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 7040707a-31c7-4561-a290-ea4310458d87 |
| TestID       | e46e9fc0-7a7b-dbca-ece1-c0d26bc16931 |
| Duration     | 00:00:00.0004915 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AsModelsTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ddc2b73c-cf87-474c-a599-85985607fdc3 |
| TestID       | 08742191-32e9-b72f-e313-52355290b27f |
| Duration     | 00:00:00.0478540 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
EnumModel { Id = 32767, Name = All, Code = ALL, Description = , Order = 0, Value = All, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = All }---

## Test: MakeSafeTest (System.Decimal,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 050f7fcf-ddcd-403d-9c68-80d70922ba01 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000474 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetSortablePropertyNamesTest_TestTargetModel

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 03b7854b-0056-4be3-a813-7797eb56fe72 |
| TestID       | f90f5d2f-9a6e-b4bc-022c-ce37e3e49a29 |
| Duration     | 00:00:00.0015119 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: SerializeTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 85501b23-1899-4203-bcb3-4db77a5c92bd |
| TestID       | 83cb0395-740b-4b48-1b9a-9d0379b2c4b0 |
| Duration     | 00:00:00.0115889 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
result-BsonIdConverterTests_SerializeTest(26)-638247568029821558.json: Attached
Hello World---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,GreaterThan,3/1/2020,10,3,4,5,6,7,8,9,10,11,12)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 343b74b3-069d-459c-8287-b5af8e4f6f2a |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2283972 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,GreaterThanOrEqualTo,995,5,995,996,997,998,999)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | fb0bc792-0bfa-410d-81ca-9bd3ebabe292 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0875081 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Page (0,1,1000,1000,0,1,0)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 7b2e1a05-dd2f-4a60-b7d8-fb17dcb71488 |
| TestID       | 1473bf71-e1c1-f1c7-3c9b-e4b672449167 |
| Duration     | 00:00:00.0943776 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: GetResourceFromXmlTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 69915db7-a21b-4cd2-a854-2c569555a4a9 |
| TestID       | 8ef63a3f-2208-ac88-5a22-493d4beeaeda |
| Duration     | 00:00:00.0259772 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_Equals (Hello,HeLlO,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 2aff6e1e-c736-42db-b09d-0e297396e597 |
| TestID       | f7d628e1-cba3-1586-4745-5c2b041ec4a5 |
| Duration     | 00:00:00.0042712 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched) with e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass5_0).matched, CurrentCultureIgnoreCase)---

## Test: MakeSafeTest (System.String,Hello World,Hello World)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 7ba3ee95-06ea-4f13-aa34-25933ddf6dd3 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0008465 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetSearchablePropertyNames_TestTargetModel

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 242602ed-c04a-4719-a96c-3a825a9a244d |
| TestID       | 9c016915-9649-a737-5d1d-30f1b46f0f52 |
| Duration     | 00:00:00.0008040 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter_Range_Bounds

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9edeffd3-5295-4abc-a4aa-9feb8e02af7a |
| TestID       | b8ce6298-5288-a9c6-3afb-62b35d380a81 |
| Duration     | 00:00:00.1930201 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,DateTimeNullable,LessThan,2020-03-01T01:01:01.4356493+02:00,2,0,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 6075ed8e-5910-414f-acb7-74c734e76af5 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1280470 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: ToEnumTest (test short,WithDisplay)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e8b5edb2-25ad-481f-acf8-3b812bb69b63 |
| TestID       | a0869721-ebb3-c304-6fe7-b73efe80b63d |
| Duration     | 00:00:00.0008912 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_StartsWith (Hello,HE,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 5ed5aab6-207e-4603-93b9-f239173dbe41 |
| TestID       | 9fc312dd-bf28-c94d-1e1d-b286e827484a |
| Duration     | 00:00:00.0018916 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched) with e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched)
visited: e => e.StartsWith(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass7_0).matched, CurrentCultureIgnoreCase)---

## Test: MakeSafeTest (System.Decimal,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e2554cdd-98e5-41ff-b5c3-56d4454bb934 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000461 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Nullable`1[System.Guid],18AACB9C-2989-4322-A490-C7167BEA0DB4,18aacb9c-2989-4322-a490-c7167bea0db4)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | d8102396-3d87-41b8-9ed5-bf93b04d49f1 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000488 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetSortablePropertyNamesTest_TestTarget2Model

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 400b66d7-acdc-4b24-8541-0eb3a91b819f |
| TestID       | f3dca1bb-5884-67f2-50ab-603f9fbc49dc |
| Duration     | 00:00:00.0117506 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (1,Val1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 725bd38c-bb59-4aee-8632-5589059fea37 |
| TestID       | 092bb187-4bf7-a53b-2140-63f4ef89daf4 |
| Duration     | 00:00:00.0000550 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: DeserializeTest ({"_id":{"$oid":"Hello World"}},Hello World)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 1e5fab80-2cf1-42e2-b5bf-54e60a40bf5e |
| TestID       | c432e4b0-7429-baaf-edf0-c5836fb7f61e |
| Duration     | 00:00:00.0119528 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
input-BsonIdConverterTests_DeserializeTest(41)-638247568029603731.json: Attached
result-BsonIdConverterTests_DeserializeTest(43)-638247568029658480.json: Attached---

## Test: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,*3,10,100,10,3,13,23,33,43,53,63,73,83,93)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e08f48ce-69b7-4a26-8bf0-5d3b8efd3881 |
| TestID       | f5306a38-7e9d-ad71-73c6-1c694342dc21 |
| Duration     | 00:00:00.1094281 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: TryParseTest (System.Int32,1,True,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f41f4948-57f5-45d9-b406-561e145c2f87 |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0000495 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetFilterablePropertyNamesTest_TestTargetModel

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b4bf550f-2926-4dc5-a568-bb8bc9c348b6 |
| TestID       | f3383018-7bb0-86e7-cb57-311d72bf2f87 |
| Duration     | 00:00:00.0028632 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,NotEqualTo,Name1*,10,0,2,3,4,5,6,7,8,9,20)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b3a4a2b3-23ca-4574-bfa3-57af84e05296 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0775005 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*03,9,103,203,303,403,503,603,703,803,903)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 0efa8bdc-ce0b-4f0c-a3ea-364f535358ba |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0933789 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThan,3/1/2020,3,-1,0,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a4288736-a710-4786-98f0-343e0c29654e |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1319319 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,Date,LessThanOrEqualTo,3/1/2020,4,-1,0,1,2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | cfcaa208-2348-42cf-9444-bc6dea044f8d |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1295854 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,InSet,System.Int32[],3,1,2,3)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 4e2a7245-ce5e-4214-b49c-0919c5cff632 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1529508 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: DefaultPageSizeTest

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 5dd0d4a2-d51c-409c-9ba3-dba23befb89c |
| TestID       | 7cdd2ae3-f105-0db6-4f1d-4db0ed6728a3 |
| Duration     | 00:00:00.0338763 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.Decimal,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f276d300-a25c-41a9-9bc0-9425cfda1c87 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000400 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (2,Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 977cba07-6eba-4dc7-b18b-eedcadc1755d |
| TestID       | d65243d8-08b2-e03e-f449-f990f2a0e0db |
| Duration     | 00:00:00.0000492 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.DateTimeOffset,3/16/2022 12:00:00 AM +05:00,3/16/2022 12:00:00 AM +05:00)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 122dd9d4-6298-421b-a9e2-d50a442acb7e |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000751 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Sort (NAME,Descending,999,998,997,996,995,994,993,992,991,990)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b5ab29fb-bb59-4f30-9f7e-760ea5ddb035 |
| TestID       | a4fab2fd-d643-e553-9cc8-037b3e07814b |
| Duration     | 00:00:00.0771611 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	S:NAME: Descending---

## Test: MakeSafeTest (System.Byte[],QUJD,System.Byte[])

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 5a6f8795-a5bb-4521-8a68-921351e42166 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0005600 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Nullable`1[System.Int32],nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 5b0c7477-360d-4468-be0b-d6b89400a48e |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0016936 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_Contains (Hello,el,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 1d194796-1552-4797-b30a-38fcf4cbb901 |
| TestID       | 367dc493-6e21-f5fb-452f-b7a61cb9d35e |
| Duration     | 00:00:00.0021349 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)---

## Test: TryParseTest (System.Nullable`1[System.Double],nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 61cbbaba-def5-47ae-b095-c54e442749af |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0064999 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: VisitTest_Contains (Hello,eL,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 34b39b70-eb31-4a44-814f-b9d419fe91ba |
| TestID       | be141f1a-8c8f-b715-2946-f4796a27756e |
| Duration     | 00:00:00.0014508 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)---

## Test: ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 19590074-e059-4494-95e2-40203c27bfd6 |
| TestID       | 4921d2de-4fc9-a1f6-942a-be92da908484 |
| Duration     | 00:00:00.0025215 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_Object_WithFileNameRemoveExtension

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | fda4d8fc-7ac5-4993-a081-c70f08378444 |
| TestID       | 94603f64-5739-e688-dcfd-6687308b4a9a |
| Duration     | 00:00:00.0069176 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameRemoveExtension(150)-638247567946879081: Attached---

## Test: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,*e3*,12,111,10,3,30,31,32,33,34,35,36,37,38)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | deaf4b5b-13ba-41fa-9592-c59f1b52a4a0 |
| TestID       | f5306a38-7e9d-ad71-73c6-1c694342dc21 |
| Duration     | 00:00:00.0997327 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: ExecuteByTest_Page (1,1,1000,1000,1,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a7a8a47d-40ef-4bb5-bdc8-e8104b01dff9 |
| TestID       | 4a7c0434-7d26-1cbe-b9e2-6ff6e082a2e4 |
| Duration     | 00:00:00.0818672 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: MakeSafeTest (System.Nullable`1[System.Guid],nope,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a11f826c-b1b0-446a-9474-dca30b1ea384 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0026292 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultTest_Object_WithFileNameAndChangeExtension

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | a77267e4-1cb1-487f-87c7-94a94176b88f |
| TestID       | 6e40d08d-5283-ed81-5042-cf4b25b8a9b0 |
| Duration     | 00:00:00.0091701 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameAndChangeExtension(130)-638247567946534290.html: Attached---

## Test: ToEnumTest (Val2 ,Val1,Val1, Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 933bfbc5-a35d-458f-90fa-7d08f40b51f7 |
| TestID       | fed3e1e7-3d22-83b0-5d5b-c487b5a51e1d |
| Duration     | 00:00:00.0000423 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: DeserializeTest_Nullable ({"Nullable":{"$date":"2023-07-05T14:16:32.2015217-04:00"},"Value":{"$date":"0001-01-01T00:00:00+00:00"}},2023-07-05T14:16:32.2015217-04:00)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f4877a9b-3920-4619-a8f3-f93c4678d9cf |
| TestID       | 91af5cd6-c94f-eaba-472b-5f760a9837f2 |
| Duration     | 00:00:00.0539169 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
input-BsonDateConverterTests_DeserializeTest_Nullable(65)-638247568027609741.json: Attached
result-BsonDateConverterTests_DeserializeTest_Nullable(67)-638247568027864806.json: Attached---

## Test: AddResultTest_Object_WithFileNameNoExtension

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 99873fa4-881d-4792-b7c9-170a3ff1b550 |
| TestID       | 4756cbfe-51aa-abcc-147f-e97a51057db5 |
| Duration     | 00:00:00.0111645 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
TestFileName-TextContextExtensionsTests_AddResultTest_Object_WithFileNameNoExtension(90)-638247567946740995.json: Attached---

## Test: VisitTest_EqualOperator (Hello,HeLlO,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | e4cf5ec5-9acb-43ab-98ed-17f76a876664 |
| TestID       | c16c011e-ef45-90da-6cbe-adb8ad060ed2 |
| Duration     | 00:00:00.0014210 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel,Children,EqualTo,*001,10,2,3,4,5,6,7,8,9,12,13)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 601fbe42-d273-4153-9c7f-03b44d215bfc |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.2634661 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetWithInnerArrayModel---

## Test: ExecuteByTest_Page (0,0,100,1000,0,10,0,1,2,3,4,5,6,7,8,9)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 8914465c-c2a3-4616-8d22-ad1c8dcaa2b9 |
| TestID       | 88c82662-090f-edbe-18ea-fdea89f28272 |
| Duration     | 00:00:00.0990369 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: VisitTest_Contains (Hello,EL,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | ac87e903-3488-4afa-abab-56004e1c3b11 |
| TestID       | 208e37c2-1168-d0c8-60dd-a2cbc4004adf |
| Duration     | 00:00:00.0293831 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
Eliassen.System.Internal.ConsoleLogger`1[Eliassen.System.Linq.Expressions.StringComparisonReplacementExpressionVisitor]:Debug:>
	Replace: e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched) with e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)



TestContext Messages:
expression: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched)
visited: e => e.Contains(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass6_0).matched, CurrentCultureIgnoreCase)---

## Test: SerializeTest_Value

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 9c54d290-71ce-4e54-9262-28916b433892 |
| TestID       | 8da0fbaf-acd6-9154-0805-f306ce39ad46 |
| Duration     | 00:00:00.0079929 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
result-BsonDateConverterTests_SerializeTest_Value(48)-638247568029203651.json: Attached
2023-07-12T11:06:42.9202505-04:00---

## Test: GetSearchablePropertyNames_TestTarget3Model

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 27f936d2-a553-42fa-8dae-a5192da95cbb |
| TestID       | 94eba969-c82f-9e81-1248-494bdd4f32c8 |
| Duration     | 00:00:00.0079109 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AddResultFileTest_FileContent

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | fcadeaef-6cf4-413c-8417-77985811da85 |
| TestID       | 4173abf6-6eee-31f5-7205-ad46c7104d49 |
| Duration     | 00:00:00.0542095 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.DateTime,3/16/2022,3/16/2022 12:00:00 AM)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 23503a07-d2c3-4ca0-8a17-79ed14073152 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0000283 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: TryParseTest (System.Int32,nope,False,)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 33232e6c-532c-44ac-9650-4b0b5f8b186a |
| TestID       | 7fd160bc-3b5b-e6e2-40ae-1974536260f2 |
| Duration     | 00:00:00.0030511 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: GetResourceFromJsonTest_NotFound

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | dffd2063-b71c-4695-a95b-5edcb608a23a |
| TestID       | 838644d9-6365-e4a6-691a-5f9e9cba540d |
| Duration     | 00:00:00.0021356 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeTest (System.TimeSpan,16:00,16:00:00)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | b07ab4cf-5720-4efa-a5ba-a9fbc13d4702 |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0022575 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: MakeSafeArrayTest (System.Decimal,System.Object[],System.Decimal[])

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 29f211b6-515b-4231-89ec-f3a5b6839097 |
| TestID       | 2f56b32e-ea97-c552-8dea-074dcb4e0dc0 |
| Duration     | 00:00:00.0005310 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Index,LessThan,5,5,0,1,2,3,4)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 61700fdf-8f7d-48c5-b2b7-a5c53b72c852 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.1440065 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

## Test: MakeSafeTest (System.Double,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 326f73f0-d8b8-423e-99b2-9a76ce0cb5af |
| TestID       | e350703c-47df-56f0-b995-a52c38b53eca |
| Duration     | 00:00:00.0003408 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: ToEnumTest (Val2|Val1,Val1, Val2)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 116bc1ac-4e4f-4c11-975f-933a85b21ced |
| TestID       | 7c5e3c9e-e684-2685-2fae-2d932d0ebcac |
| Duration     | 00:00:00.0000456 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 
---

## Test: AsModelsTest2

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 95501509-3f5d-4834-a237-d0781976a791 |
| TestID       | 870b9428-08e8-f91f-14b9-7fcf33dc2d0f |
| Duration     | 00:00:00.0213169 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
EnumModel { Id = 0, Name = Val0, Code = VAL0, Description = , Order = 0, Value = Val0, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val0 }
EnumModel { Id = 1, Name = Val1, Code = VAL1, Description = , Order = 0, Value = Val1, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val1 }
EnumModel { Id = 2, Name = Val2, Code = VAL2, Description = , Order = 0, Value = Val2, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = Val2 }
EnumModel { Id = 4, Name = WithEnumValue, Code = name, Description = , Order = 0, Value = WithEnumValue, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithEnumValue }
EnumModel { Id = 8, Name = WithMemberName, Code = name2, Description = , Order = 0, Value = WithMemberName, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithMemberName }
EnumModel { Id = 16, Name = WithDescription, Code = WITHDESCRIPTION, Description = test description, Order = 0, Value = WithDescription, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithDescription }
EnumModel { Id = 32, Name = test name, Code = test short, Description = test display, Order = 0, Value = WithDisplay, IsEndState = False, IsExcludeFromUnique = False, PossibleNames = System.String[], Value = WithDisplay }---

## Test: ExecuteByTest_SearchTerm (Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel,FName0999 LName0001,1,1,1,1)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | f05be6da-5099-4a72-842a-deabdf654cb5 |
| TestID       | f5306a38-7e9d-ad71-73c6-1c694342dc21 |
| Duration     | 00:00:00.1487581 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetExtendedModel---

## Test: AddResultTest_Stream

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | dc985b12-1ee9-4935-884c-dc63a5ea3421 |
| TestID       | bb6d8621-db33-2366-8e82-a87beebdef19 |
| Duration     | 00:00:00.0084463 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
MemoryStream-TextContextExtensionsTests_AddResultTest_Stream(170)-638247567948720187.bin: Attached---

## Test: VisitTest_EqualOperator (Hello,hello,True)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | efe1db61-a2d9-4763-bef0-14b510989ead |
| TestID       | 70cc1b9f-29cb-ca2e-6207-97111a5b7792 |
| Duration     | 00:00:00.0026159 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

#### Standard Out
TestContext Messages:
expression: e => (e == value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched)
visited: e => e.Equals(value(Eliassen.System.Tests.Linq.Expressions.StringComparisonReplacementExpressionVisitorTests+<>c__DisplayClass4_0).matched, CurrentCultureIgnoreCase)---

## Test: ExecuteByTest_Filter (Eliassen.System.Tests.Linq.TestTargets.TestTargetModel,Name,EqualTo,*e2*,10,2,20,21,22,23,24,25,26,27,28)

| Key          | Value                   |
| -------------| ----------------------- |
| ExecutionID  | 3d4d954d-0d9a-42e8-9030-eb3a58e24495 |
| TestID       | b6498f29-1231-5fcf-4954-1746daa0500d |
| Duration     | 00:00:00.0864408 |
| Outcome      | Passed |
### UnitTest: 
### Class: 
### Method: 

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
	Force sort by 0 applied for Eliassen.System.Tests.Linq.TestTargets.TestTargetModel---

