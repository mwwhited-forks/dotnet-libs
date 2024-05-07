# Eliassen.OpenAI.AI


## Class: OpenAI.AI.ServiceCollectionExtensions
Provides extension methods for configuring OpenAI services. 

### Methods


#### TryAddOpenAIServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Tries to add OpenAI-related services to the specified service collection. 


##### Parameters
* *services:* The service collection to which OpenAI services should be added.
* *configuration:* The configuration used to bind options.
* *openAIOptionSection:* The name of the configuration section containing OpenAI options. Defaults to "OpenAIOptions".




##### Return value
The updated service collection.



## Class: OpenAI.AI.Services.OpenAIManager
Provides methods for interacting with the OpenAI language model. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.OpenAI.AI.Services.OpenAIManager*class. 


##### Parameters
* *config:* The OpenAI configuration options.




#### GetResponseAsync(System.String,System.String)
Gets a response asynchronously based on the provided prompt details and user input. 


##### Parameters
* *promptDetails:* The details of the prompt.
* *userInput:* The user input.




##### Return value
A task representing the asynchronous operation. The task result contains the generated response.



#### GetStreamedResponseAsync(System.String,System.String,System.Threading.CancellationToken)
Gets a streamed response asynchronously based on the provided prompt details and user input. 


##### Parameters
* *promptDetails:* The details of the prompt.
* *userInput:* The user input.
* *cancellationToken:* The cancellation token.




##### Return value
An asynchronous enumerable of response messages.



## Class: OpenAI.AI.Services.OpenAIOptions
Represents options for configuring the OpenAI service. 

### Properties

#### APIKey
Gets or sets the APIKey to be used.
#### DeploymentName
Gets or sets the deployment model to be used for the text generation.