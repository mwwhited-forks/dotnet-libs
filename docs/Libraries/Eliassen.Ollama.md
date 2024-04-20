# Eliassen.Ollama


## Class: Ollama.IOllamaApiClientFactory
Represents a factory for creating instances of the OllamaApiClient. 

### Methods


#### Build(System.String)
Builds an instance of the OllamaApiClient for the specified host. 


##### Parameters
* *host:* The host address where the Ollama API is hosted.




##### Return value
An instance of the OllamaApiClient.



## Class: Ollama.MessageCompletion
Represents a class responsible for generating message completions using the Ollama API. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Ollama.MessageCompletion*class. 


##### Parameters
* *client:* The OllamaApiClient instance used for communication with the Ollama API.




#### GetCompletionAsync(System.String,System.String)
Generates a completion for the given prompt using the specified model. 


##### Parameters
* *modelName:* The name of the model to use for completion.
* *prompt:* The prompt for which completion is requested.




##### Return value
A task representing the asynchronous operation. The task result contains the completion response.



## Class: Ollama.OllamaApiClientExtensions
Provides extension methods for the 
 *See: T:OllamaSharp.OllamaApiClient*class. 

### Methods


#### EnsureModelExistsAsync(OllamaSharp.OllamaApiClient,System.String,Microsoft.Extensions.Logging.ILogger)
Ensures that the specified model exists in the Ollama API client. If the model does not exist locally, it is copied from the 'llama2' model. 


##### Parameters
* *ollama:* The Ollama API client.
* *modelName:* The name of the model to ensure exists.
* *logger:* The logger instance for logging information.




##### Return value
The Ollama API client.



#### GetEmbeddingSingle(OllamaSharp.OllamaApiClient,System.String,System.String)
Synchronously retrieves the embedding for the specified text using the specified model. 


##### Parameters
* *client:* The Ollama API client.
* *text:* The text for which the embedding is requested.
* *modelName:* The name of the model to use for embedding.




##### Return value
The embedding as an array of floats.



#### GetEmbeddingSingleAsync(OllamaSharp.OllamaApiClient,System.String,System.String)
Asynchronously retrieves the embedding for the specified text using the specified model. 


##### Parameters
* *client:* The Ollama API client.
* *text:* The text for which the embedding is requested.
* *modelName:* The name of the model to use for embedding.




##### Return value
A task representing the asynchronous operation. The task result contains the embedding as an array of floats.



#### GetEmbeddingDoubleAsync(OllamaSharp.OllamaApiClient,System.String,System.String)
Asynchronously retrieves the embedding for the specified text using the specified model. 


##### Parameters
* *client:* The Ollama API client.
* *text:* The text for which the embedding is requested.
* *modelName:* The name of the model to use for embedding.




##### Return value
A task representing the asynchronous operation. The task result contains the embedding as an array of doubles.



#### GetEmbeddingDouble(OllamaSharp.OllamaApiClient,System.String,System.String)
Synchronously retrieves the embedding for the specified text using the specified model. 


##### Parameters
* *client:* The Ollama API client.
* *text:* The text for which the embedding is requested.
* *modelName:* The name of the model to use for embedding.




##### Return value
The embedding as an array of doubles.



## Class: Ollama.OllamaApiClientFactory
Factory class for creating instances of the 
 *See: T:OllamaSharp.OllamaApiClient*. 

### Methods


#### Build(System.String)
Builds a new instance of the 
 *See: T:OllamaSharp.OllamaApiClient*with the specified host. 


##### Parameters
* *host:* The host address where the Ollama API is hosted.




##### Return value
A new instance of the .



## Class: Ollama.ServiceCollectionExtensions
Provides extension methods for configuring services related to Ollama. 

### Methods


#### TryAddOllamaServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Configures services for Ollama. 


##### Parameters
* *services:* The to add the services to.




##### Return value
The modified .

