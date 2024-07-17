Here is the documentation for the provided source code files, including class diagrams in PlantUML:

**HashTypes.cs**

Class Diagram:
```plantuml
@startuml
class HashTypes {
  - Md5
  - Sha256
  - Sha512
}
@enduml
```

Description: `HashTypes` is an enumeration that specifies different types of hash algorithms. It contains three members: `Md5`, `Sha256`, and `Sha512`.

**Md5Hash.cs**

Class Diagram:
```plantuml
@startuml
class Md5Hash implements IHash {
  + GetHash(string value) : string
}
interface IHash {
  + GetHash(string value) : string
}
@enduml
```

Description: `Md5Hash` is a class that implements the `IHash` interface. It has a single method `GetHash` that computes the default hash of the input value using the MD5 algorithm and returns the Base64 encoded hash as a string.

**Sha256Hash.cs**

Class Diagram:
```plantuml
@startuml
class Sha256Hash implements IHash {
  + GetHash(string value) : string
}
interface IHash {
  + GetHash(string value) : string
}
@enduml
```

Description: `Sha256Hash` is a class that implements the `IHash` interface. It has a single method `GetHash` that computes the default hash of the input value using the SHA256 algorithm and returns the Base64 encoded hash as a string.

**Sha512Hash.cs**

Class Diagram:
```plantuml
@startuml
class Sha512Hash implements IHash {
  + GetHash(string value) : string
}
interface IHash {
  + GetHash(string value) : string
}
@enduml
```

Description: `Sha512Hash` is a class that implements the `IHash` interface. It has a single method `GetHash` that computes the default hash of the input value using the SHA512 algorithm and returns the Base64 encoded hash as a string.

**Interfaces and Classes Hierarchy**

Class Diagram:
```plantuml
@startuml
interface IHash {
  + GetHash(string value) : string
}

class HashTypes {
  - Md5
  - Sha256
  - Sha512
}

class Md5Hash implements IHash {
  + GetHash(string value) : string
}

class Sha256Hash implements IHash {
  + GetHash(string value) : string
}

class Sha512Hash implements IHash {
  + GetHash(string value) : string
}

@enduml
```

Description: The above class diagram shows the hierarchy of classes and interfaces. `IHash` is an interface that defines a single method `GetHash`. `HashTypes` is an enumeration that specifies different hash algorithms. `Md5Hash`, `Sha256Hash`, and `Sha512Hash` are classes that implement the `IHash` interface, each providing a specific hash algorithm.