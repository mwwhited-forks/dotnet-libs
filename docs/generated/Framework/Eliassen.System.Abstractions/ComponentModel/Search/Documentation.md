Here is the documentation for the source code files, including class diagrams in PlantUML:

**DefaultSortAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class DefaultSortAttribute {
    - targetName: string?
    - priority: int
    - order: OrderDirections
}
@enduml
```

**Summary**

The `DefaultSortAttribute` class is used to specify default sort options for an entity. It allows the user to specify the property name to use for mapping, the sort column position priority, and the direction to order the mapped column.

**Properties**

* `TargetName`: The property name to use for mapping.
* `Priority`: The sort column position priority.
* `Order`: The direction to order the mapped column.

**Methods**

* `DefaultSortAttribute(string? targetName = default, int priority = default, OrderDirections order = OrderDirections.Ascending)` : Initializes a new instance of the `DefaultSortAttribute` class.

**FilterableAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class FilterableAttribute {
    - targetName: string
}
@enduml
```

**Summary**

The `FilterableAttribute` class is used to allow tagging entity classes to enumerate filterable fields/properties. It provides a way to specify the target name for filtering.

**Properties**

* `TargetName`: The target name for filtering.

**Methods**

* `FilterableAttribute(string targetName)` : Initializes a new instance of the `FilterableAttribute` class.
* `FilterableAttribute()` : Initializes a new instance of the `FilterableAttribute` class with no target name.

**IgnoreStringComparisonReplacementAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class IgnoreStringComparisonReplacementAttribute {
}
@enduml
```

**Summary**

The `IgnoreStringComparisonReplacementAttribute` class is used to exclude a property from string comparison replacement.

**Methods**

* None

**ISearchQueryIntercept.cs**

```plaintext
**Class Diagram**

@startuml
interface ISearchQueryIntercept {
    - Intercept(ISearchQuery searchQuery): ISearchQuery
}
@enduml
```

**Summary**

The `ISearchQueryIntercept` interface provides an entry point to commonly intercept and override search definitions.

**Methods**

* `Intercept(ISearchQuery searchQuery)`: Modifies or passes through the search query before processing.

**NotFilterableAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class NotFilterableAttribute {
    - targetName: string?
}
@enduml
```

**Summary**

The `NotFilterableAttribute` class is used to specify that a property or class should be explicitly excluded from filter selection.

**Properties**

* `TargetName`: The target name to be excluded from filter selection.

**Methods**

* `NotFilterableAttribute(string targetName)` : Initializes a new instance of the `NotFilterableAttribute` class.
* `NotFilterableAttribute()` : Initializes a new instance of the `NotFilterableAttribute` class with no target name.

**NotSearchableAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class NotSearchableAttribute {
    - targetName: string?
}
@enduml
```

**Summary**

The `NotSearchableAttribute` class is used to explicitly exclude properties from search.

**Properties**

* `TargetName`: The target name required only if this is used on a class.

**Methods**

* `NotSearchableAttribute(string targetName)` : Initializes a new instance of the `NotSearchableAttribute` class.
* `NotSearchableAttribute()` : Initializes a new instance of the `NotSearchableAttribute` class with no target name.

**NotSortableAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class NotSortableAttribute {
    - targetName: string?
}
@enduml
```

**Summary**

The `NotSortableAttribute` class is used to specify that a property or class should not be sortable.

**Properties**

* `TargetName`: The name of the target property that should not be sortable.

**Methods**

* `NotSortableAttribute(string targetName)` : Initializes a new instance of the `NotSortableAttribute` class.
* `NotSortableAttribute()` : Initializes a new instance of the `NotSortableAttribute` class with no target name.

**SearchableAttribute.cs**

```plaintext
**Class Diagram**

@startuml
class SearchableAttribute {
    - targetName: string?
}
@enduml
```

**Summary**

The `SearchableAttribute` class is used to include a field to be searchable for the "SearchTerm".

**Properties**

* `TargetName`: The target name required only if this is used on a class.

**Methods**

* `SearchableAttribute(string targetName)` : Initializes a new instance of the `SearchableAttribute` class.
* `SearchableAttribute()` : Initializes a new instance of the `SearchableAttribute` class with no target name.

**SearchTermDefaultAttribute.cs