Here is the generated documentation for the source code files:

**ExpressionTreeBuilderTests.cs**

This test class contains a set of unit tests for the ExpressionTreeBuilder class. The tests cover different scenarios and verify the correctness of the methods.

### Class Diagram

```plantuml
@startuml
class TestContext {
    TestContext() : TestContext(null)
    TestContext(TContext context) : TestContext(context)
}
class ExpressionTreeBuilder {
    ExpressionTreeBuilder(TModel model)
    GetFilterablePropertyNames()
    GetSearchablePropertyNames()
    GetSortablePropertyNames()
}
class TestTargetModel
class TestTarget2Model
class TestTarget3Model
@enduml
```

**SkipInstanceMethodOnNullExpressionVisitorTests.cs**

This test class contains a set of unit tests for the SkipInstanceMethodOnNullExpressionVisitor class. The tests cover different scenarios and verify the correctness of the visitor's implementation.

### Class Diagram

```plantuml
@startuml
class TestContext {
    TestContext() : TestContext(null)
    TestContext(TContext context) : TestContext(context)
}
class SkipInstanceMethodOnNullExpressionVisitor {
    Visit(Expression expression)
}
class LambdaExpression
class Test {
    Test()
    Compile()
    DynamicInvoke(object input)
}
@enduml
```

**SkipMemberOnNullExpressionVisitorTests.cs**

This test class contains a set of unit tests for the SkipMemberOnNullExpressionVisitor class. The tests cover different scenarios and verify the correctness of the visitor's implementation.

### Class Diagram

```plantuml
@startuml
class TestContext {
    TestContext() : TestContext(null)
    TestContext(TContext context) : TestContext(context)
}
class SkipMemberOnNullExpressionVisitor {
    Visit(Expression expression)
}
class QueryBuilder {
    Execute(IQueryable rawData, SearchQuery query, SkipMemberOnNullExpressionVisitor visitor)
}
class SearchQuery {
    SearchTerm
}
class IDataProvider {
    AddResult(object result)
}
class TestTarget {
    Name
    Items
}
@enduml
```

**StringComparisonReplacementExpressionVisitorTests.cs**

This test class contains a set of unit tests for the StringComparisonReplacementExpressionVisitor class. The tests cover different scenarios and verify the correctness of the visitor's implementation.

### Class Diagram

```plantuml
@startuml
class TestContext {
    TestContext() : TestContext(null)
    TestContext(TContext context) : TestContext(context)
}
class StringComparisonReplacementExpressionVisitor {
    Visit(Expression expression)
}
class LambdaExpression
class Test {
    Test()
    Compile()
    DynamicInvoke(string input)
}
class Expression<TDelegate> {
    Compile()
}
class Delegate
@enduml
```

Note that the class diagrams are simplified and do not show all the methods and properties of the classes. They are intended to provide a general overview of the classes and their relationships.