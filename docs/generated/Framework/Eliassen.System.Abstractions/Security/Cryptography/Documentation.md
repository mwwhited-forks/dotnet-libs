Here is the documentation for the `IHash.cs` file:

**Interface: IHash**

**Namespace:** Eliassen.System.Security.Cryptography

**Summary:** Simplified hash generator

**Methods:**

* **GetHash(string value)**: cryptographic hash for input value
	+ **Parameters:** `value`: value to hash
	+ **Returns:** hash input

**Class Diagram:**

[plantuml]
@startuml
interface IHash {
  -+ GetHash(string value): string
}
@enduml

This class diagram shows the `IHash` interface with a single method `GetHash` that takes a `string` parameter and returns a `string`. The interface provides a simplified way to generate cryptographic hashes for input values.

Note: The class diagram is generated using PlantUML syntax. If you want to create a graphical representation of the class diagram, you can use a tool like PlantUML Viewer or Graphviz.