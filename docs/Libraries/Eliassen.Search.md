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


## Class: Search.Providers.SearchProvider
Provides search functionality combining semantic, lexical, and hybrid search approaches. 


## Class: Search.Semantic.VectorStoreFactory
Represents a factory for creating vector stores. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Semantic.VectorStoreFactory*class. 


##### Parameters
* *factory:* The factory to create vector store provider.




#### Create(System.String)
Creates a vector store based on the specified container name. 


##### Parameters
* *containerName:* The name of the container.




##### Return value
The created vector store.



#### Create``1
Creates a vector store based on the specified type. 


##### Return value
The created vector store.



## Class: Search.Semantic.VectorStoreProviderFactory
Represents a factory for creating vector store providers. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Semantic.VectorStoreProviderFactory*class. 


##### Parameters
* *serviceProvider:* The service provider used for dependency injection.




#### Create(System.String)
Creates a vector store provider with the specified container name. 


##### Parameters
* *containerName:* The name of the container.




##### Return value
An instance of .



## Class: Search.Semantic.WrappedVectorStore
Represents a vector store that wraps another vector store. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Semantic.WrappedVectorStore*class. 


##### Parameters
* *wrapped:* The vector store to wrap.




#### FindNeighborsAsync(System.Single[])
Finds nearest neighbors asynchronously based on the specified vector. 


##### Parameters
* *find:* The vector to search for neighbors.




##### Return value
An asynchronous enumerable collection of search results representing nearest neighbors.



#### FindNeighborsAsync(System.Single[],System.String)
Finds nearest neighbors asynchronously based on the specified vector and groups the results by a specified field. 


##### Parameters
* *find:* The vector to search for neighbors.
* *groupBy:* The field to group the results by.




##### Return value
An asynchronous enumerable collection of search results representing nearest neighbors grouped by the specified field.



#### ListAsync
Retrieves all items asynchronously. 


##### Return value
An asynchronous enumerable collection of search results.



#### StoreVectorsAsync(System.Collections.Generic.IEnumerable{System.Single[]},System.Collections.Generic.Dictionary{System.String,System.Object})
Stores vectors asynchronously along with their associated metadata. 


##### Parameters
* *embeddings:* The vector embeddings to store.
* *metadata:* The metadata associated with the vectors.




##### Return value
A task representing the asynchronous operation. The task result contains the IDs of the stored vectors.



#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Semantic.WrappedVectorStore`1*class. 


##### Parameters
* *factory:* The factory used to create the wrapped vector store.




## Class: Search.Semantic.WrappedVectorStore`1
Represents a typed vector store that wraps another vector store. 
The type of objects stored in the vector store. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Search.Semantic.WrappedVectorStore`1*class. 


##### Parameters
* *factory:* The factory used to create the wrapped vector store.




## Class: Search.ServiceCollectionExtensions
Provides extension methods for configuring search-related services. 

### Methods


#### TryAddSearchServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Configures services for search functionality. 


##### Parameters
* *services:* The to add the services to.




##### Return value
The modified .

