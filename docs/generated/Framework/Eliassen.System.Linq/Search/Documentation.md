Here is the documentation for the provided source code files:

**OperatorExtensions.cs**

This static class provides extensions for the `Operators` enum, allowing for the creation of `FilterParameter` instances based on the enum values.

**Operators.cs**

This enum represents the available operators for building search queries.

**QueryBuilder.cs**

This abstract class provides a base implementation for building and executing queries based on search, filter, sort, and page criteria.

**Constructor**

`public QueryBuilder<TModel>(ISortBuilder<TModel> sortBuilder, IExpressionTreeBuilder<TModel> expressionBuilder, IEnumerable<IPostBuildExpressionVisitor>? postBuildVisitors, ILogger<QueryBuilder>? logger, ICaptureResultMessage? capture)`

This constructor takes in various dependencies necessary for building and executing queries.

**Methods**

* `Execute(IQueryable query, ISearchQuery searchQuery)`: This method executes the query based on the provided search query.
* `ExecuteBy(IQueryable<TModel> query, ISearchQuery searchQuery)`: This method executes the query and returns a typed result.
* `BuildFrom(IQueryable<TModel> query, ISearchQuery searchQuery, StringComparison stringComparison)`: This method builds a query expression based on the provided search query.
* `PageBy(IOrderedQueryable<TModel> query, IPageQuery? pager)`: This method paginates the query results based on the provided pager settings.
* `SearchBy(IQueryable<TModel> query, ISearchTermQuery? search, StringComparison stringComparison, bool isSearchTerm)`: This method applies search terms to the query.
* `FilterBy(IQueryable<TModel> query, IFilterQuery? filter, StringComparison stringComparison)`: This method applies filter criteria to the query.
* `SortBy(IQueryable<TModel> query, ISortQuery? sortBy, StringComparison keyStringComparer)`: This method applies sorting criteria to the query.

**SortBuilder.cs**

This class provides a builder for sorting `IQueryable` instances based on a provided sort query.

**Constructor**

`public SortBuilder<TModel>(ILogger<SortBuilder<TModel>>? logger = null, ICaptureResultMessage? messages = null)`

This constructor takes in logger and message capturer dependencies.

**Methods**

* `SortBy(IQueryable<TModel> query, ISortQuery searchRequest, IExpressionTreeBuilder<TModel> treeBuilder, StringComparison stringComparison)`: This method sorts the query based on the provided sort query.

**Class Diagrams (PlantUML)**

Here is a class diagram for the `QueryBuilder` and `SortBuilder` classes:

```plantuml
@startuml
class QueryBuilder {
  + Execute(IQueryable query, ISearchQuery searchQuery)
  + ExecuteBy(IQueryable<TModel> query, ISearchQuery searchQuery)
  + BuildFrom(IQueryable<TModel> query, ISearchQuery searchQuery, StringComparison stringComparison)
  + PageBy(IOrderedQueryable<TModel> query, IPageQuery? pager)
  + SearchBy(IQueryable<TModel> query, ISearchTermQuery? search, StringComparison stringComparison, bool isSearchTerm)
  + FilterBy(IQueryable<TModel> query, IFilterQuery? filter, StringComparison stringComparison)
  + SortBy(IQueryable<TModel> query, ISortQuery? sortBy, StringComparison keyStringComparer)
}

class SortBuilder {
  + SortBy(IQueryable<TModel> query, ISortQuery searchRequest, IExpressionTreeBuilder<TModel> treeBuilder, StringComparison stringComparison)
}

Query Builder --* Sort Builder
IQueryable  --* Query Builder
IQueryable<TModel> --* Query Builder
ISearchQuery --* Query Builder
ISortQuery  --* Sort Builder
IExpressionTreeBuilder<TModel> --* Sort Builder

@enduml
```
This diagram shows the relationships between the `QueryBuilder` and `SortBuilder` classes, as well as their dependencies on other interfaces and classes.