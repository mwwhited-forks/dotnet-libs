Here is the documentation for the provided source code files, along with the class diagrams in PlantUML:

**EnumExtensions.cs**

Provides extension methods for working with enumerations.

```
public static class EnumExtensions
{
    // Extension methods for converting between enumeration values and their string representations.
}
```

Class Diagram:
```plantuml
@startuml
class EnumExtensions {
  - AsString<T>(T input)
  - ToEnum<T>(int input)
  - ToEnum<T>(string input)
  - AsModel<T>(T enumValue)
  - AsModels<T>()
}

@enduml
```

**EnumModel.cs**

Represents an enumeration model.

```
internal record EnumModel : IEnumModel
{
    // Properties and fields for representing an enumeration value.
}

internal record EnumModel<TEnum> : EnumModel, IEnumModel<TEnum> where TEnum : struct, Enum
{
    // The strongly-typed value of the enumeration.
}
```

Class Diagram:
```plantuml
@startuml
class EnumModel {
  - int Id
  - string Name
  - string Code
  - string Description
  - int? Order
  - object Value
  - bool IsEndState
  - bool IsExcludeFromUnique
  - IReadOnlyCollection<string> PossibleNames
}

class EnumModel<TEnum> {
  - TEnum Value
  - int Id
  - string Name
  - string Code
  - string Description
  - int? Order
  - object Value
  - bool IsEndState
  - bool IsExcludeFromUnique
  - IReadOnlyCollection<string> PossibleNames
}

interface IEnumModel {
  - string? Code
  - string? Description
  - int Id
  - bool IsEndState
  - bool IsExcludeFromUnique
  - string? Name
  - int? Order
  - object Value
  - IReadOnlyCollection<string> PossibleNames
}

interface IEnumModel<TEnum> {
  - TEnum Value
  <TEnum> where TEnum : struct, Enum
}

@enduml
```

**IEnumModel.cs**

Represents an interface for providing information about an enumeration value.

```
public interface IEnumModel
{
    // Properties and methods for representing an enumeration value.
}

public interface IEnumModel<TEnum> : IEnumModel
    where TEnum : struct, Enum
{
    // The strongly-typed value of the enumeration.
}
```

Class Diagram:
```plantuml
@startuml
interface IEnumModel {
  - string? Code
  - string? Description
  - int Id
  - bool IsEndState
  - bool IsExcludeFromUnique
  - string? Name
  - int? Order
  - object Value
  - IReadOnlyCollection<string> PossibleNames
}

interface IEnumModel<TEnum> {
  - TEnum Value
}

@enduml
```

**IResolveType.cs**

Represents an interface for resolving a `Type`.

```
public interface IResolveType
{
    // Method for resolving and returning the associated `Type`.
}
```

Class Diagram:
```plantuml
@startuml
interface IResolveType {
  - Type ResolveType()
}

@enduml
```

Note: The PlantUML diagrams are provided in a simplified format to illustrate the relationships between the classes and interfaces. For a more detailed and accurate representation, please consult the official PlantUML documentation or use a PlantUML tool to generate the diagrams.