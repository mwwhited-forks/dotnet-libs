# Eliassen.SBert


## Class: SBert.SBertClient
Client for interacting with SBert. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.SBert.SBertClient*class. 


##### Parameters
* *options:* The SBert options.




#### GetEmbeddingAsync(System.String)
Retrieves the embedding vector for the given input as an array of single-precision floats. 


##### Parameters
* *input:* The input text.




##### Return value
An array of single-precision floats representing the embedding.



#### GetEmbeddingDoubleAsync(System.String)
Retrieves the embedding vector for the given input as an array of double-precision floats. 


##### Parameters
* *input:* The input text.




##### Return value
An array of double-precision floats representing the embedding.



## Class: SBert.SBertOptions
Options for configuring SBert. 

### Properties

#### Url
Gets or sets the URL for SBert. Example: http://sbert.example.com:5080

## Class: SBert.SentenceEmbeddingProvider
Provides sentence embeddings using SBert. 

### Properties

#### Length
Gets the length of the embeddings.
### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.SBert.SentenceEmbeddingProvider*class. 


##### Parameters
* *client:* The SBertClient instance for obtaining embeddings.




#### GetEmbeddingAsync(System.String)
Gets the embedding for the given content asynchronously. 


##### Parameters
* *content:* The content for which to obtain the embedding.




##### Return value
A task representing the asynchronous operation. The task result contains the embedding as an array of floats.



## Class: SBert.ServiceCollectionExtensions
Provides extension methods for configuring services related to SBERT (Sentence-BERT). 

### Methods


#### TryAddSbertServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Configures services for SBERT (Sentence-BERT). 


##### Parameters
* *services:* The to add the services to.
* *configuration:* The to bind SBERT options from.
* *sbertOptionsSection:* The configuration section name containing SBERT options.




##### Return value
The modified .

