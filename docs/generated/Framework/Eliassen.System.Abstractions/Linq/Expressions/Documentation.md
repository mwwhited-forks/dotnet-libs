Here is the generated documentation for the provided source code files:

**IExpressionTreeBuilder.cs**

* **Class Diagram in PlantUML:**
```
@startuml
interface "IExpressionTreeBuilder" {
  - GetSearchablePropertyNames(): IReadOnlyCollection<string>
  - GetSortablePropertyNames(): IReadOnlyCollection<string>
  - GetFilterablePropertyNames(): IReadOnlyCollection<string>
  - DefaultSortOrder(): IReadOnlyCollection<(string, OrderDirections)>
}
@enduml
```

**Interface Documentation:**

The `IExpressionTreeBuilder` interface represents a builder for constructing expression trees used in querying and filtering. It provides methods for getting the names of properties that can be used for searching, sorting, and filtering, as well as the default sort order.

**IExpressionTreeBuilder<TModel>.cs**

* **Class Diagram in PlantUML:**
```
@startuml
interface "IExpressionTreeBuilder<TModel>" <|-- "IExpressionTreeBuilder">
  - GetPredicateExpression(string, FilterParameter, StringComparison, bool): Expression<Func<TModel, bool>>?
  - BuildExpression(object?, StringComparison, bool): Expression<Func<TModel, bool>>?
  - PropertyExpressions(): IReadOnlyDictionary<string, Expression<Func<TModel, object>>>
end

IExpressionTreeBuilder <|-- IExpressionTreeBuilder<TModel>
@enduml
```

**Interface Documentation:**

The `IExpressionTreeBuilder<TModel>` interface represents a typed builder for constructing expression trees used in querying and filtering for a specific model type `TModel`. It extends the `IExpressionTreeBuilder` interface and adds methods for getting a predicate expression and building an expression tree based on a query parameter.

**IPostBuildExpressionVisitor.cs**

* **Class Diagram in PlantUML:**
```
@startuml
interface "IPostBuildExpressionVisitor" {
  - Visit(Expression?): Expression?
}
@enduml
```

**Interface Documentation:**

The `IPostBuildExpressionVisitor` interface represents an interface for a visitor that processes an expression tree after it has been built. It provides a single method for visiting an expression node and returning a modified expression node.

I hope this helps! Let me know if you have any further questions or need any additional documentation.