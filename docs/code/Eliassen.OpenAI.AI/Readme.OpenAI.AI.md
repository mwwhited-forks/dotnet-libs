# Eliassen.OpenAI.AI

Eliassen.OpenAI.AI provides functionalities for interacting with OpenAI's language model. Here's an overview of its key components:

## ServiceCollectionExtensions
Extension methods for configuring OpenAI services.

### Methods
- **TryAddOpenAIServices**: Tries to add OpenAI-related services to the specified service collection.

## OpenAIManager
Provides methods for interacting with the OpenAI language model.

### Methods
- **Constructor**: Initializes a new instance of the class.
- **GetResponseAsync**: Gets a response asynchronously based on the provided prompt details and user input.
- **GetStreamedResponseAsync**: Gets a streamed response asynchronously based on the provided prompt details and user input.

## OpenAIOptions
Represents options for configuring the OpenAI service.

### Properties
- **APIKey**: Gets or sets the APIKey to be used.
- **DeploymentName**: Gets or sets the deployment model to be used for the text generation.

Eliassen.OpenAI.AI facilitates seamless integration with OpenAI's powerful language model, allowing developers to leverage advanced text generation capabilities within their applications.
