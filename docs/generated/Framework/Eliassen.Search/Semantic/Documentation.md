Here is the documentation for the provided source code files, including class diagrams in Plant UML:

**VectorStoreFactory.cs**

**Class Diagram**

```
@startuml
class VectorStoreFactory {
    - private readonly IServiceProvider _serviceProvider
    - private readonly IEnumerable<IVectorStoreProviderFactory> _factories

    + VectorStoreFactory(IServiceProvider, IEnumerable<IVectorStoreProviderFactory>)
    + IVectorStore Create(string)
    + IVectorStore Create<T>()
}

class IVectorStoreFactory {
    + IVectorStore Create(string)
    + IVectorStore Create<T>()
}

interface IVectorStoreProviderFactory {
    IVectorStoreProvider Create(string)
}

interface IVectorStore {
    // methods
}

@enduml
```

**Summary**

The `VectorStoreFactory` class is responsible for creating instances of `IVectorStore` based on a given collection name or type. It uses an IOC container (`IServiceProvider`) to resolve instances of `IVectorStoreProvider` and create vector stores.

**Properties and Methods**

* `IVectorStoreFactory Create(string collectionName)`: Creates a vector store based on the specified collection name.
* `IVectorStore Create<T>()`: Creates a vector store based on the specified type.

**WrappedVectorStore.cs**

**Class Diagram**

```
@startuml
class WrappedVectorStore<T> {
    - private readonly IVectorStore _wrapped

    + WrappedVectorStore(IVectorStoreFactory)
    + WrappedVectorStore(IVectorStore)
    + IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(ReadOnlyMemory<float>)
    + IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(ReadOnlyMemory<float>, string)
    + IAsyncEnumerable<SearchResultModel> ListAsync()
    + Task<string[]> StoreVectorsAsync(IEnumerable<ReadOnlyMemory<float>>, Dictionary<string, object>)
    + Task<string[]> StoreVectorsAsync(IEnumerable<(ReadOnlyMemory<float>, Dictionary<string, object>)>, Dictionary<string, object>)
}

class IVectorStore {
    // methods
}

class IVectorStore<T> {
    // methods
}

interface IVectorStoreProvider {
    // methods
}

interface IVectorStoreFactory {
    IVectorStore Create(string)
}

class SearchResultModel {
    // properties
}

@enduml
```

**Summary**

The `WrappedVectorStore<T>` class is a wrapper around another `IVectorStore` instance, providing a simpler interface for accessing the underlying vector store.

**Properties and Methods**

* `WrappedVectorStore(IVectorStoreFactory)`: Constructor that creates a new instance of the wrapped vector store using the factory.
* `WrappedVectorStore(IVectorStore)`: Constructor that creates a new instance of the wrapped vector store using an existing instance.
* `IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(ReadOnlyMemory<float>)`: Finds nearest neighbors asynchronously based on the specified vector.
* `IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(ReadOnlyMemory<float>, string)`: Finds nearest neighbors asynchronously based on the specified vector and groups the results by a specified field.
* `IAsyncEnumerable<SearchResultModel> ListAsync()`: Retrieves all items asynchronously.
* `Task<string[]> StoreVectorsAsync(IEnumerable<ReadOnlyMemory<float>>, Dictionary<string, object>)`: Stores vectors asynchronously along with their associated metadata.
* `Task<string[]> StoreVectorsAsync(IEnumerable<(ReadOnlyMemory<float>, Dictionary<string, object>)>, Dictionary<string, object>)`: Stores the specified embeddings and metadata.

Note that these class diagrams assume that `IVectorStore`, `IVectorStore<T>`, and `IVectorStoreProvider` are interfaces, while `IVectorStoreFactory` is an interface or abstract class. The actual implementation details may vary depending on the specific use case.