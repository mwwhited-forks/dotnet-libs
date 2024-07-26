Here is the documentation for the `CommandLineTests.cs` and `ConfigurationBuilderExtensionsTests.cs` files, including class diagrams in PlantUML:

**CommandLineTests.cs**

### Purpose

The `CommandLineTests` class contains unit tests for the `Eliassen.Extensions.Configuration` library, specifically for the `CommandLine` class and its related methods.

### Classes

#### `CommandLineTests`

*   Extends `TestClass` from `Microsoft.VisualStudio.TestTools.UnitTesting`
*   Contains two test methods:
    *   `BuildParametersTests`: Tests the `BuildParameters` method of the `CommandLine` class.
    *   `AddParametersTests`: Tests the `AddParameters` method of the `CommandLine` class.

#### `TestHarness`

*   A simple class that contains two properties, `Prop1` and `Prop2`, which are used as test values.

### Methods

#### `BuildParametersTests`

*   Tests the `BuildParameters` method of the `CommandLine` class, which takes an instance of `TestHarness` as a parameter.
*   Verifies that the method returns a dictionary with the correct key-value pairs.

#### `AddParametersTests`

*   Tests the `AddParameters` method of the `CommandLine` class, which takes an instance of `TestHarness` as a parameter.
*   Verifies that the method returns a dictionary with the correct key-value pairs.

### Class Diagram in PlantUML

```
@startuml
class CommandLineTests {
  - testContext: TestContext
  + BuildParametersTests()
  + AddParametersTests()
}

class TestHarness {
  - Prop1: string?
  - Prop2: string?
}

CommandLineTests -> TestHarness: uses
@enduml
```

**ConfigurationBuilderExtensionsTests.cs**

### Purpose

The `ConfigurationBuilderExtensionsTests` class contains unit tests for the `Eliassen.Extensions.Configuration` library, specifically for the `AddInMemoryCollection` extension method of the `ConfigurationBuilder` class.

### Classes

#### `ConfigurationBuilderExtensionsTests`

*   Extends `TestClass` from `Microsoft.VisualStudio.TestTools.UnitTesting`
*   Contains two test methods:
    *   `AddInMemoryCollectionTest_KeyValuePair`: Tests the `AddInMemoryCollection` method with a dictionary.
    *   `AddInMemoryCollectionTest_Tuple`: Tests the `AddInMemoryCollection` method with a tuple.

### Methods

#### `AddInMemoryCollectionTest_KeyValuePair`

*   Tests the `AddInMemoryCollection` method with a dictionary containing a single key-value pair.
*   Verifies that the method returns a `ConfigurationBuilder` instance with the correct settings.

#### `AddInMemoryCollectionTest_Tuple`

*   Tests the `AddInMemoryCollection` method with a tuple containing a key and a value.
*   Verifies that the method returns a `ConfigurationBuilder` instance with the correct settings.

### Class Diagram in PlantUML

```
@startuml
class ConfigurationBuilderExtensionsTests {
  - testContext: TestContext
  + AddInMemoryCollectionTest_KeyValuePair()
  + AddInMemoryCollectionTest_Tuple()
}

class ConfigurationBuilder {
  + AddInMemoryCollection(Dictionary<string, string>): ConfigurationBuilder
}

ConfigurationBuilderExtensionsTests -> ConfigurationBuilder: uses
@enduml
```

Note: The class diagrams are simplified and only show the essential relationships between the classes.