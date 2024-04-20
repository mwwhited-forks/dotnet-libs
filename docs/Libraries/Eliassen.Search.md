# Eliassen.Search


## Class: Search.Providers.DocumentSummaryGenerationProvider
Provides functionality to generate summaries for documents. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Providers.DocumentSummaryGenerationProvider*class. 


##### Parameters
* *messageCompletion:* The message completion service.
* *modelName:* The name of the model to use for completion.
* *promptTemplate:* The template for the completion prompt.




#### GenerateSummaryAsync(System.String)
Generates a summary for the provided content asynchronously. 


##### Parameters
* *content:* The content for which to generate a summary.




##### Return value
A summary of the content.



## Class: Search.Providers.HybridProvider
Represents a hybrid provider that combines results from lexical and semantic search providers. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Providers.HybridProvider*class. 


##### Parameters
* *lexicalProvider:* The lexical search provider.
* *semanticStoreProvider:* The semantic search provider.




#### QueryAsync(System.String,System.Int32,System.Int32)
Queries the hybrid provider asynchronously. 


##### Parameters
* *queryString:* The query string.
* *limit:* The maximum number of results to return.
* *page:* The page number of results to retrieve.




##### Return value
An asynchronous enumerable of SearchResultModel objects representing the search results.



## Class: Search.Providers.SearchProvider
Provides search functionality combining semantic, lexical, and hybrid search approaches. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Providers.SearchProvider*class. 


##### Parameters
* *semantic:* The semantic search content.
* *lexical:* The lexical search content.
* *hybrid:* The hybrid search content.
* *embedding:* The embedding provider.
* *contentStore:* The content store.




#### ListAsync
Lists all available search results. 


##### Return value
An enumerable collection of search results.



#### EmbedAsync(System.String)
Generates an embedding for the given text. 


##### Parameters
* *text:* The text to embed.




##### Return value
An array representing the embedding.



#### SemanticSearchAsync(System.String,System.Int32)
Performs a semantic search with the given query. 


##### Parameters
* *query:* The search query.
* *limit:* The maximum number of results to return.




##### Return value
An enumerable collection of search results.



#### LexicalSearchAsync(System.String,System.Int32)
Performs a lexical search with the given query. 


##### Parameters
* *query:* The search query.
* *limit:* The maximum number of results to return.




##### Return value
An enumerable collection of search results.



#### HybridSearchAsync(System.String,System.Int32)
Performs a lexical search with the given query. 


##### Parameters
* *query:* The search query.
* *limit:* The maximum number of results to return.




##### Return value
An enumerable collection of search results.



## Class: Search.ServiceCollectionExtensions
Provides extension methods for configuring search-related services. 

### Methods


#### TryAddSearchServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Configures services for search functionality. 


##### Parameters
* *services:* The to add the services to.




##### Return value
The modified .

