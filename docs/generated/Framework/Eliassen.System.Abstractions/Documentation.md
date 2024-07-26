Here is the generated documentation with a PlantUML class diagram for the `ConfigurationMissingException` class:

**Eliassen.System**

This assembly contains the core interfaces and models for the Eliassen Common Framework.

### ConfigurationMissingException

Represents an exception thrown when a required configuration is missing.

#### Constructors

* `ConfigurationMissingException(string configurationKey)`: Initializes a new instance of the `ConfigurationMissingException` class with the specified configuration key.

#### Properties

* `ConfigurationException`: No specific properties are defined.

#### Methods

* `ToString()`: Returns a string representation of the exception.

**Class Diagram (PlantUML)**
```plantuml
@startuml
class ConfigurationMissingException {
  - configurationKey: string
  + ConfigurationMissingException(string configurationKey)
  + ToString(): string
}

@ConfigurationMissingException ..> ApplicationException
@enduml
```
**README. System Abstractions**

Eliassen System Abstractions

### Summary

This library is the core collection of interface contracts and models to support the Eliassen Common Framework.

### Package Information

* Target Framework: net8.0
* Implicit Usings: False
* Nullable: Enable
* Generate Documentation File: True
* Root Namespace: Eliassen.System
* Package Readme File: Readme.System.Abstractions.md

### Internals

* InternalsVisibleTo: Eliassen.System
* InternalsVisibleTo: Eliassen.System.Tests
* InternalsVisibleTo: Eliassen.System.Linq

Let me know if you'd like me to add anything else!