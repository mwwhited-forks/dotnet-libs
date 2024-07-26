Here is the documentation for the provided source code files, along with class diagrams in PlantUML:

**EndStateAttribute.cs**

* **Class Diagram:** `@startuml` `class EndStateAttribute extends Attribute` `@enduml`
* **Documentation:**
The `EndStateAttribute` is a custom attribute used to tag valid end states for enum-based state machines. It is inherited from the `Attribute` class and can be applied to enum fields. This attribute is used by the system to determine the valid end states for an enum-based state machine.

**EnumValueAttribute.cs**

* **Class Diagram:** `@startuml` `class EnumValueAttribute extends Attribute` `string Name` `@enduml`
* **Documentation:**
The `EnumValueAttribute` is a custom attribute used to specify a custom output value for an enum field when serialized as JSON. The attribute takes a single string parameter, `name`, which represents the value to be output instead of the enum's default `ToString()` output. This attribute can be applied to enum fields.

**ExcludeFromUniqueAttribute.cs**

* **Class Diagram:** `@startuml` `class ExcludeFromUniqueAttribute extends Attribute` `@enduml`
* **Documentation:**
The `ExcludeFromUniqueAttribute` is a custom attribute used to exclude an enum or enum field from being considered for uniqueness checks. This attribute can be applied to enum fields or the enum type itself.

**IVersionProvider.cs**

* **Class Diagram:** `@startuml` `interface IVersionProvider { +string? Title; +string? Version; +string? Description; +Assembly? Assembly; }` `@enduml`
* **Documentation:**
The `IVersionProvider` is an interface that provides information about the version of an assembly. The interface defines four properties: `Title`, `Version`, `Description`, and `Assembly`, which return the title, version, description, and assembly associated with the version information, respectively.

Here is the complete PlantUML code:
```plantuml
@startuml
class EndStateAttribute extends Attribute
endclass

class EnumValueAttribute extends Attribute
string Name
endclass

class ExcludeFromUniqueAttribute extends Attribute
endclass

interface IVersionProvider {
  +string? Title
  +string? Version
  +string? Description
  +Assembly? Assembly
}

@enduml
```
Note: The `@startuml` and `@enduml` keywords are used to delimit the PlantUML code. The `class` and `interface` keywords are used to define classes and interfaces, respectively. The `extends` keyword is used to indicate inheritance. The `string?` keyword is used to indicate a nullable string property. The `+` symbol is used to indicate a getter-only property.