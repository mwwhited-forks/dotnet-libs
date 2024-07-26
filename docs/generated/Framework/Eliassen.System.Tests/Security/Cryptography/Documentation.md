Here is the documentation for the provided source code files, including class diagrams in PlantUML:

**HashSelectorTest.cs**

The `HashSelectorTest` class is a test class that tests the `HashSelector` class. It uses the `System.Security.Cryptography` namespace and the `Microsoft.Extensions.DependencyInjection` namespace.

**Class Diagram:**

```plantuml
@startuml
class HashSelectorTest {
  -TestContext: TestContext
  +DefaultHashTest(HashTypes targetType, Type expectedType)
  +KeyedHashTest(object targetSerializerType, Type expectedType)
}

class IConfiguration {
  +GetService<T>()
}

class IHash {
  +GetHash(string input)
}

class ServiceCollection {
  +AddTransient<IConfiguration>(_ => config)
  +TryAddSystemExtensions(config, new())
  +BuildServiceProvider()
}

class ServiceProvider {
  +GetRequiredService<T>()
}

@enduml
```

**Md5HashTests.cs**

The `Md5HashTests` class is a test class that tests the `Md5Hash` class. It uses the `Eliassen.System.Security.Cryptography` namespace and the `Microsoft.VisualStudio.TestTools.UnitTesting` namespace.

**Class Diagram:**

```plantuml
@startuml
class Md5HashTests {
  -TestContext: TestContext
  +GetHash(string input, string expected)
}

class Md5Hash {
  +GetHash(string input)
}
@enduml
```

**Sha256HashTests.cs**

The `Sha256HashTests` class is a test class that tests the `Sha256Hash` class. It uses the `Eliassen.System.Security.Cryptography` namespace and the `Microsoft.VisualStudio.TestTools.UnitTesting` namespace.

**Class Diagram:**

```plantuml
@startuml
class Sha256HashTests {
  -TestContext: TestContext
  +GetHash(string input, string expected)
}

class Sha256Hash {
  +GetHash(string input)
}
@enduml
```

**Sha512HashTests.cs**

The `Sha512HashTests` class is a test class that tests the `Sha512Hash` class. It uses the `Eliassen.System.Security.Cryptography` namespace and the `Microsoft.VisualStudio.TestTools.UnitTesting` namespace.

**Class Diagram:**

```plantuml
@startuml
class Sha512HashTests {
  -TestContext: TestContext
  +GetHash(string input, string expected)
}

class Sha512Hash {
  +GetHash(string input)
}
@enduml
```

Note: The `HashSelectorTest` class is not included in the class diagram as it is a test class and does not have any dependencies on other classes.