# Eliassen.Qdrant


## Class: Qdrant.IPointStructFactory
Interface for a factory that creates instances of 
 *See: T:Qdrant.Client.Grpc.PointStruct*. 

### Methods


#### CreateFileChunk(Eliassen.System.IO.FileMetaData,Eliassen.System.IO.ContentChunk,System.IO.FileInfo,System.Single[])
Creates a new instance of 
 *See: T:Qdrant.Client.Grpc.PointStruct*for a file chunk. 


##### Parameters
* *metadata:* Metadata associated with the file.
* *chunk:* Content chunk of the file.
* *fileInfo:* Information about the file.
* *vector:* Vector representation of the content chunk.




##### Return value
A new instance of representing a file chunk.



#### CreateQuestion(System.Guid,System.String,System.Single[],System.String)
Creates a new instance of 
 *See: T:Qdrant.Client.Grpc.PointStruct*for a question. 


##### Parameters
* *uuid:* Unique identifier of the question.
* *question:* The question text.
* *vector:* Vector representation of the question.
* *type:* Optional type of the question.




##### Return value
A new instance of representing a question.



#### CreateServiceReference(System.Guid,System.Type,System.String,System.Single[])
Creates a new instance of 
 *See: T:Qdrant.Client.Grpc.PointStruct*for a service reference. 


##### Parameters
* *uuid:* Unique identifier of the service reference.
* *serviceType:* Type of the service.
* *description:* Description of the service.
* *vector:* Vector representation of the service reference.




##### Return value
A new instance of representing a service reference.



## Class: Qdrant.IQdrantGrpcClientFactory
Interface for a factory that creates instances of 
 *See: T:Qdrant.Client.Grpc.QdrantGrpcClient*. 

### Methods


#### Create
Creates a new instance of 
 *See: T:Qdrant.Client.Grpc.QdrantGrpcClient*. 


##### Return value
A new instance of .



## Class: Qdrant.ISemanticStoreProviderFactory
Interface for a factory that creates instances of 
 *See: T:Eliassen.Qdrant.SemanticStoreProvider*. 

### Methods


#### Create(System.Boolean)
Creates a new instance of 
 *See: T:Eliassen.Qdrant.SemanticStoreProvider*. 


##### Parameters
* *forSummary:* A flag indicating whether the provider is for summary or not.




##### Return value
A new instance of .



## Class: Qdrant.PointStructFactory
Factory for creating instances of 
 *See: T:Qdrant.Client.Grpc.PointStruct*. 

### Fields

#### ServiceInstanceType
Represents the constant value indicating service instance type.
### Methods


#### CreateFileChunk(Eliassen.System.IO.FileMetaData,Eliassen.System.IO.ContentChunk,System.IO.FileInfo,System.Single[])
Creates a 
 *See: T:Qdrant.Client.Grpc.PointStruct*instance representing a file chunk. 


##### Parameters
* *metaData:* The metadata of the file.
* *chunk:* The content chunk.
* *fileInfo:* Information about the file.
* *vector:* The vector representing the file chunk.




##### Return value
The created .



#### CreateServiceReference(System.Guid,System.Type,System.String,System.Single[])
Creates a 
 *See: T:Qdrant.Client.Grpc.PointStruct*instance representing a service reference. 


##### Parameters
* *uuid:* The UUID of the service reference.
* *serviceType:* The type of the service.
* *description:* The description of the service reference.
* *vector:* The vector representing the service reference.




##### Return value
The created .



#### CreateQuestion(System.Guid,System.String,System.Single[],System.String)
Creates a 
 *See: T:Qdrant.Client.Grpc.PointStruct*instance representing a question. 


##### Parameters
* *uuid:* The UUID of the question.
* *question:* The question text.
* *vector:* The vector representing the question.
* *type:* The type of the question.




##### Return value
The created .



## Class: Qdrant.QdrantGrpcClientExtensions
Extension methods for Qdrant gRPC client. 

### Methods


#### EnsureCollectionExistsAsync(Qdrant.Client.Grpc.QdrantGrpcClient,System.String,System.UInt64,Qdrant.Client.Grpc.Distance,Microsoft.Extensions.Logging.ILogger)
Ensures that the specified collection exists in Qdrant. If it doesn't exist, creates the collection with the specified parameters. 


##### Parameters
* *qdrant:* The Qdrant gRPC client.
* *collectionName:* The name of the collection to ensure exists.
* *vectorSize:* The size of the vectors in the collection.
* *distanceCalculation:* The distance calculation method for the collection.
* *logger:* The logger to use for logging messages.




##### Return value
The Qdrant gRPC client.



## Class: Qdrant.QdrantGrpcClientFactory
Factory for creating instances of the Qdrant gRPC client. 

### Methods


#### Constructor
Creates a new instance of the Qdrant gRPC client. 


##### Return value
A new instance of the Qdrant gRPC client.



#### Create
Creates a new instance of the Qdrant gRPC client. 


##### Return value
A new instance of the Qdrant gRPC client.



## Class: Qdrant.QdrantOptions
Options for configuring Qdrant. 

### Properties

#### Url
Gets or sets the URL for Qdrant.
#### CollectionName
Gets or sets the collection name for Qdrant.

## Class: Qdrant.SemanticStoreProvider
Provides storage and search functionality for semantic content. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Qdrant.SemanticStoreProvider*class. 


##### Parameters
* *vectorStore:* The QdrantGrpcClient instance for accessing vector storage.
* *embedding:* The embedding provider for generating embeddings.
* *storeName:* The name of the store.
* *forSummary:* Indicates whether the provider is for summary.




#### QueryAsync(System.String,System.Int32,System.Int32)
Queries the semantic store asynchronously for search results. 


##### Parameters
* *queryString:* The search query string.
* *limit:* The maximum number of results to return.
* *page:* The page number of results.




##### Return value
An asynchronous enumerable collection of search results.



#### Eliassen#Search#ISearchContent{Qdrant#Client#Grpc#ScoredPoint}#QueryAsync(System.String,System.Int32,System.Int32)
Queries the semantic store asynchronously for scored points. 


##### Parameters
* *queryString:* The search query string.
* *limit:* The maximum number of results to return.
* *page:* The page number of results.




##### Return value
An asynchronous enumerable collection of scored points.



#### TryStoreAsync(System.String,System.String,System.String)
Stores content in the semantic store asynchronously. 


##### Parameters
* *full:* The full content.
* *file:* The file name.
* *pathHash:* The path hash.




##### Return value
A task representing the asynchronous operation. Returns true if the content is stored successfully, otherwise false.



#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Qdrant.SemanticStoreProviderFactory*class. 


##### Parameters
* *serviceProvider:* The service provider for creating instances.
* *options:* The Qdrant options.




#### 
Creates a new instance of SemanticStoreProvider. 


##### Parameters
* *forSummary:* Indicates whether the provider is for summary.




##### Return value
A new instance of SemanticStoreProvider.



## Class: Qdrant.SemanticStoreProviderFactory
Factory for creating instances of SemanticStoreProvider. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Qdrant.SemanticStoreProviderFactory*class. 


##### Parameters
* *serviceProvider:* The service provider for creating instances.
* *options:* The Qdrant options.




#### Create(System.Boolean)
Creates a new instance of SemanticStoreProvider. 


##### Parameters
* *forSummary:* Indicates whether the provider is for summary.




##### Return value
A new instance of SemanticStoreProvider.



## Class: Qdrant.ServiceCollectionExtensions
Provides extension methods for configuring services related to Qdrant. 

### Methods


#### TryAddQdrantServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Configures services for Qdrant. 


##### Parameters
* *services:* The to add the services to.
* *configuration:* The to bind Qdrant options from.
* *qdrantOptionSection:* The configuration section name containing Qdrant options.




##### Return value
The modified .

