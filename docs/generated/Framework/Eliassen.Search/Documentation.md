**Documentation for Eliassen.Search**

**Class Diagram**

Below is the class diagram for the Eliassen.Search namespace, generated using PlantUML:

```plantuml
@startuml
class ServiceCollectionExtensions {
  - IServiceCollection services
}

class IVectorStoreFactory {
  + vectorStoreFactory(): IVectorStoreFactory
}

class IVectorStore<T> {
  + IVectorStore(T storage)
}

class WrappedVectorStore<T> {
  - IVectorStore<T> wrappedStore
  + WrappedVectorStore(IVectorStore<T> wrappedStore)
}

class VectorStoreFactory {
  + IVectorStoreFactory()
  + Create<T>(T storage): IVectorStore<T>
}

class SemanticSearchProvider {
  + SemanticSearchProvider()
}

class HybridSearchProvider {
  + HybridSearchProvider()
}

class IntegratedSearchProvider {
  + IntegratedSearchProvider()
}

class DocumentSummaryGenerator {
  + DocumentSummaryGenerator()
  + GenerateSummary(AsyncReturnType asyncReturnType=async): SummaryResult
}

Eliassen.Search --* ServiceCollectionExtensions
Eliassen.Search --* IVectorStoreFactory
Eliassen.Search --* IVectorStore<T>
Eliassen.Search --* WrappedVectorStore<T>
Eliassen.Search --* VectorStoreFactory
Eliassen.Search --* SemanticSearchProvider
Eliassen.Search --* HybridSearchProvider
Eliassen.Search --* IntegratedSearchProvider
Eliassen.Search --* DocumentSummaryGenerator
@enduml
```

**Documentation for ServiceCollectionExtensions.cs**

**ServiceCollectionExtensions**

Provides extension methods for configuring search-related services.

**TryAddSearchServices**

Configures services for search functionality.

* **Parameters:** `services` - The IServiceCollection to add the services to.
* **Returns:** The modified IServiceCollection.

This method adds the following services to the IServiceCollection:

* `IVectorStoreFactory`: Creates vector stores based on specified containers or types.
* `IVectorStore<T>`: Creates a wrapped vector store to provide additional functionality.

The `TryAddTransient` method is used to add the services, which allows for lazy evaluation of the services.

**IVectorStoreFactory**

Interface that defines the factory method for creating vector stores.

**IVectorStore<T>**

Interface that defines the vector store functionality.

**WrappedVectorStore<T>**

Wraps another vector store to provide additional functionality.

**VectorStoreFactory**

Creates vector stores based on specified containers or types.

**SemanticSearchProvider**

Search provider that uses semantic search.

**HybridSearchProvider**

Search provider that combines results from lexical and semantic search providers.

**IntegratedSearchProvider**

Search provider that combines semantic, lexical, and hybrid search approaches.

**DocumentSummaryGenerator**

Generates summaries for documents asynchronously.

Each of these classes has its own documentation, but I will not repeat it here as it is not directly related to the ServiceCollectionExtensions class.

**Readme/Search.md**

The Readme/Search.md file provides a summary of the Eliassen.Search namespace, including an overview of the document summary generation provider, hybrid provider, search provider, vector store factory, vector store provider factory, wrapped vector store, and service collection extensions.

The Eliassen.Search namespace provides a set of classes and interfaces that enable search functionality. The namespace is designed to be modular, allowing for easy extension and modification of the search functionality.

The classes and interfaces in the Eliassen.Search namespace work together to provide a comprehensive search solution. The semantic search provider uses semantic search to find relevant documents, while the hybrid search provider combines results from lexical and semantic search providers. The integrated search provider combines semantic, lexical, and hybrid search approaches to provide a comprehensive search solution.

The vector store factory creates vector stores based on specified containers or types, while the vector store provider factory creates vector store providers for dependency injection. The wrapped vector store wraps another vector store to provide additional functionality.

The document summary generator generates summaries for documents asynchronously.

The service collection extensions provide a way to configure search-related services for dependency injection.

Overall, the Eliassen.Search namespace provides a powerful and flexible search solution that can be easily integrated into other applications.