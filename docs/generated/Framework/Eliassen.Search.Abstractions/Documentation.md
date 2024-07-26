Here is the documentation for the source code files:

**Eliassen.Search.Abstractions.csproj**

This is a .NET Core project file that defines the Abstractions project for the Eliassen.Search library. The project targets .NET 8.0 and includes references to Microsoft.Extensions.Configuration.Abstractions and InternalsVisibleTo attributes to allow internal access to classes in the Eliassen.Search namespace.

**IVectorStore.cs**

This is an interface that defines the contract for storing and querying vectors. It provides several methods for storing vectors and metadata, listing stored vectors, finding neighbors of a specified vector, and finding neighbors of a specified vector grouped by a key. The interface is generic and can be extended to work with any type of data.

**PlantUML Class Diagram**

```
@startuml
class IVectorStore {
  - storeVectorsAsync(IEnumerable<ReadOnlyMemory<float>>, Dictionary<string, object>)
  - storeVectorsAsync(IEnumerable<(ReadOnlyMemory<float>, Dictionary<string, object>)>, Dictionary<string, object>)
  - listAsync()
  - findNeighborsAsync(ReadOnlyMemory<float>)
  - findNeighborsAsync(ReadOnlyMemory<float>, string)
}

class IVectorStore<T> {
  .. IVectorStore
}

@enduml
```

**Readme.Search.Abstractions.md**

This is a README file for the Abstractions project of the Eliassen.Search library. It provides an overview of the library and its components, including the IVectorStore interface, which defines the contract for storing and querying vectors. It also mentions other interfaces and classes, such as IVectorStoreFactory, IVectorStoreProvider, VectorStoreAttribute, and SearchResultModel.

**VectorStoreAttribute.cs**

This is an attribute that can be applied to a class that implements IVectorStore. It provides a way to specify the name of the container for the vector store. The attribute is marked with the [AttributeUsage] attribute to indicate that it can only be applied to classes and can only be applied once.

**PlantUML Class Diagram**

```
@startuml
class VectorStoreAttribute {
  - Get/Set CollectionName
}

@enduml
```

Note: The above class diagrams are created using PlantUML, a popular tool for generating diagrams from plain text. The class diagrams show the relationships between the classes and interfaces in the Eliassen.Search library.