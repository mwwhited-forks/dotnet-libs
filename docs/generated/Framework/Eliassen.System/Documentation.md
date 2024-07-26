**Class Diagrams using PlantUML**

Here are the class diagrams generated using PlantUML for the provided source code files.

**Eliassen.System**

```plantuml
@startuml
class HashTypes {
  - hash
  + int Equals(HashTypes other)
  + string ToString()
}
class IHash {
  + byte[] ComputeHash(byte[] data)
}
class Md5Hash {
  + byte[] ComputeHash(byte[] data) : IHash
}
class Sha256Hash {
  + byte[] ComputeHash(byte[] data) : IHash
}
class Sha512Hash {
  + byte[] ComputeHash(byte[] data) : IHash
}

class ServiceCollection {
  - services
  + IServiceCollection TryAddSystemExtensions(IConfiguration config)
  + IServiceCollection TryAddSecurityExtensions(HashTypes defaultHashType)
  + IServiceCollection TryAddSerializerExtensions(SerializerTypes defaultSerializerType)
  + IServiceCollection TryAddTemplatingExtensions(IConfiguration configuration)
}

class ServiceCollectionExtensions {
  + static ServiceCollection TryAddSystemExtensions(IServiceCollection services, IConfiguration config)
  + static ServiceCollection TryAddSecurityExtensions(HashTypes defaultHashType)
  + static ServiceCollection TryAddSerializerExtensions(SerializerTypes defaultSerializerType)
  + static ServiceCollection TryAddTemplatingExtensions(IConfiguration configuration)
}

@enduml
```

**SystemExtensionBuilder**

```plantuml
@startuml
class SystemExtensionBuilder {
  - FileTemplatingConfigurationSection
  - DefaultHashType
  - DefaultSerializerType
}

@enduml
```

**FileTemplatingOptions**

```plantuml
@startuml
class FileTemplatingOptions {
  - options
}

@enduml
```

**TempFileFactory**

```plantuml
@startuml
class TempFileFactory {
  + IFileStream CreateTempFileStream()
}

@enduml
```

These class diagrams represent the classes, relationships, and methods defined in the provided source code files. Note that some classes and relationships may be missing from the diagrams if they are not explicitly mentioned in the source code.