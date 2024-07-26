**Documentation:**

**Eliassen.AI.Abstractions**

This library contains the abstract definitions for interfacing with ML/AI such as sentence embeddings and language models.

**Classes:**

### IEmbeddingProvider

* **Length**: Retrieves the length of the embeddings.
* **GetEmbeddingAsync(content)**: Retrieves the embedding vector for the given content. Takes content as input and returns an array of single-precision floats representing the embedding vector.

### ILanguageModelProvider

* **GetResponseAsync(promptDetails, userInput)**: Retrieves a response from the language model based on provided prompt details and user input. Takes prompt details and user input as inputs and returns a response from the language model.
* **GetStreamedResponseAsync(promptDetails, userInput)**: Retrieves a streamed response from the language model based on provided prompt details and user input. Takes prompt details and user input as inputs and returns an asynchronous enumerable of strings representing the streamed response.
* **GetEmbeddedResponseAsync(data)**: Retrieves an embedded response for the given data. Takes data as input and returns a float array with the embedding data.
* **GetContextResponseAsync(assistantConfinment, systemInteractions, userInput)**: Retrieves a response from the language model based on provided prompt details, user input, and assistant confinement. Takes assistant confinement, system interactions, user input as inputs and returns a response from the language model.
* **GetRAGResponseAsync(assistantConfinment, ragData, userInput)**: Retrieves a response from the language model based on provided rag data and user input. Takes assistant confinement, rag data, user input as inputs and returns a response from the language model.
* **GetRAGResponseCitiationsAsync(ragData, userQuery)**: Retrieves a response from the language model based on provided rag data and user query. Takes rag data and user query as inputs and returns an asynchronous enumerable of strings representing the response.

### IMessageCompletion

* **GetCompletionAsync(modelName, prompt)**: Retrieves a completion for the given prompt from the specified model. Takes model name and prompt as inputs and returns the completion for the prompt.
* **GetCompletionAsync(model)**: Retrieves a completion for the given prompt from the specified model. Takes completion request model as input and returns the resulting response object.

**Class Diagrams:**

[PlantUML]

@startuml
class IEmbeddingProvider {
  + Length: int
  + GetEmbeddingAsync(content: string): Task<ReadOnlyMemory<float>>
}

class ILanguageModelProvider {
  + GetResponseAsync(promptDetails: string, userInput: string): Task<string>
  + GetStreamedResponseAsync(promptDetails: string, userInput: string): IAsyncEnumerable<string>
  + GetEmbeddedResponseAsync(data: string): Task<float[]>
  + GetContextResponseAsync(assistantConfinment: string, systemInteractions: List<string>, userInput: List<string>): IAsyncEnumerable<string>
  + GetRAGResponseAsync(assistantConfinment: string, ragData: string, userInput: string): Task<string>
  + GetRAGResponseCitiationsAsync(ragData: List<KVPModel>, userQuery: string): IAsyncEnumerable<string>
}

class IMessageCompletion {
  + GetCompletionAsync(modelName: string, prompt: string): Task<string>
  + GetCompletionAsync(model: CompletionRequest): Task<CompletionResponse>
}

@enduml