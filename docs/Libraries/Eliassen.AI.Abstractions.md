# Eliassen.AI.Abstractions


## Class: AI.IEmbeddingProvider
Represents a provider for word embeddings. 

### Properties

#### Length
Gets the length of the embeddings.
### Methods


#### GetEmbeddingAsync(System.String)
Retrieves the embedding vector for the given content. 


##### Parameters
* *content:* The content for which to retrieve the embedding.




##### Return value
A task representing the asynchronous operation. The task result contains the embedding vector as an array of single-precision floats.



## Class: AI.ILanguageModelProvider
Represents a provider for a language model. 

### Methods


#### GetResponseAsync(System.String,System.String)
Gets a response asynchronously based on the provided prompt details and user input. 


##### Parameters
* *promptDetails:* The details of the prompt.
* *userInput:* The user input.




##### Return value
A task representing the asynchronous operation that returns the response.



#### GetStreamedResponseAsync(System.String,System.String,System.Threading.CancellationToken)
Gets a streamed response asynchronously based on the provided prompt details and user input. 


##### Parameters
* *promptDetails:* The details of the prompt.
* *userInput:* The user input.
* *cancellationToken:* The Cancellation Token.




##### Return value
An asynchronous enumerable of strings representing the streamed response.



## Class: AI.IMessageCompletion
Represents a provider for message completion. 

### Methods


#### GetCompletionAsync(System.String,System.String)
Retrieves a completion for the given prompt from the specified model. 


##### Parameters
* *modelName:* The name of the model used for completion.
* *prompt:* The prompt for which to retrieve the completion.




##### Return value
A task representing the asynchronous operation. The task result contains the completion for the prompt.

