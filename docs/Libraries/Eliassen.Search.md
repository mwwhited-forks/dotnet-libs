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


## Class: Search.ServiceCollectionExtensions
Provides extension methods for configuring search-related services. 

### Methods


#### TryAddSearchServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Configures services for search functionality. 


##### Parameters
* *services:* The to add the services to.




##### Return value
The modified .

