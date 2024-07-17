**DocumentSummaryGenerationProvider Class Diagram**

Class diagram for DocumentSummaryGenerationProvider:
```
@startuml
class DocumentSummaryGenerationProvider {
  - MessageCompletion _messageCompletion
  - string _modelName
  - string _promptTemplate
  + GenerateSummaryAsync(string content)
  + GetCompletionAsync(string modelName, string promptTemplate, string content)
}

@enduml
```

**HybridProvider Class Diagram**

Class diagram for HybridProvider:
```
@startuml
class HybridProvider {
  //+ QueryAsync(string? queryString, int limit = 25, int page = 0)
  //+ ISearchContent<SearchResultModel> _lexicalProvider
  //+ ISearchContent<SearchResultModel> _semanticStoreProvider
}

@enduml
```

**SearchProvider Class Diagram**

Class diagram for SearchProvider:
```
@startuml
class SearchProvider {
  //+ ISearchContent<SearchResultModel> _semantic
  //+ ISearchContent<SearchResultModel> _lexical
  //+ ISearchContent<SearchResultModel> _hybrid
  //+ IEmbeddingProvider _embedding
  //+ ISearchContent<SearchResultModel> _contentStore
  + ListAsync()
  + EmbedAsync(string text)
  + SemanticSearchAsync(string? query, int limit)
  + LexicalSearchAsync(string? query, int limit)
  + HybridSearchAsync(string? query, int limit)
}

@enduml
```

**Class Diagram for the entire solution**

Here is the class diagram for the entire solution:
```
@startuml
class DocumentSummaryGenerationProvider {
  - MessageCompletion _messageCompletion
  - string _modelName
  - string _promptTemplate
  + GenerateSummaryAsync(string content)
  + GetCompletionAsync(string modelName, string promptTemplate, string content)
}

class HybridProvider {
  //+ QueryAsync(string? queryString, int limit = 25, int page = 0)
  //+ ISearchContent<SearchResultModel> _lexicalProvider
  //+ ISearchContent<SearchResultModel> _semanticStoreProvider
}

class SearchProvider {
  //+ ISearchContent<SearchResultModel> _semantic
  //+ ISearchContent<SearchResultModel> _lexical
  //+ ISearchContent<SearchResultModel> _hybrid
  //+ IEmbeddingProvider _embedding
  //+ ISearchContent<SearchResultModel> _contentStore
  + ListAsync()
  + EmbedAsync(string text)
  + SemanticSearchAsync(string? query, int limit)
  + LexicalSearchAsync(string? query, int limit)
  + HybridSearchAsync(string? query, int limit)
}

SearchProvider --* DocumentSummaryGenerationProvider
SearchProvider --* HybridProvider

note "SearchProvider uses DocumentSummaryGenerationProvider"
note "SearchProvider uses HybridProvider"

@enduml
```
This class diagram shows the relationships between the classes in the solution. The `SearchProvider` class uses the `DocumentSummaryGenerationProvider` class to generate summaries and the `HybridProvider` class to perform hybrid search queries.