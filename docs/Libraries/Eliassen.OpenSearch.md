# Eliassen.OpenSearch


## Class: OpenSearch.IOpenSearchClientFactory
Factory interface for creating instances of the 
 *See: T:OpenSearch.Net.IOpenSearchLowLevelClient*. 

### Methods


#### Create
Creates a new instance of the 
 *See: T:OpenSearch.Net.IOpenSearchLowLevelClient*. 


##### Return value
A new instance of the .



## Class: OpenSearch.LexicalProvider
Provides functionality for storing and searching lexical content using OpenSearch. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.OpenSearch.LexicalProvider*class. 


##### Parameters
* *config:* The configuration options for OpenSearch.
* *client:* The low-level OpenSearch client.




#### QueryAsync(System.String,System.Int32,System.Int32)
Queries the OpenSearch index for lexical content matching the specified query string. 


##### Parameters
* *queryString:* The query string to search for.
* *limit:* The maximum number of results to return.
* *page:* The page number of results to retrieve.




##### Return value
An asynchronous enumerable of SearchResultModel objects representing the search results.



#### Eliassen#Search#ISearchContent{System#Text#Json#Nodes#JsonNode}#QueryAsync(System.String,System.Int32,System.Int32)
Queries the OpenSearch index for lexical content matching the specified query string. 


##### Parameters
* *queryString:* The query string to search for.
* *limit:* The maximum number of results to return.
* *page:* The page number of results to retrieve.




##### Return value
An asynchronous enumerable of JsonNode objects representing the search results.



#### TryStoreAsync(System.String,System.String,System.String)
Stores the content in the OpenSearch index if it doesn't already exist. 


##### Parameters
* *full:* The full path of the content to store.
* *file:* The name of the file to store.
* *pathHash:* The hash value of the file path.




##### Return value
A boolean value indicating whether the content was successfully stored.



## Class: OpenSearch.OpenSearchClientFactory
Implementation of the 
 *See: T:Eliassen.OpenSearch.IOpenSearchClientFactory*interface for creating instances of the 
 *See: T:OpenSearch.Net.IOpenSearchLowLevelClient*. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.OpenSearch.OpenSearchClientFactory*class. 


##### Parameters
* *config:* The configuration options for the OpenSearch client.




#### Create
Creates a new instance of the 
 *See: T:OpenSearch.Net.IOpenSearchLowLevelClient*. 


##### Return value
A new instance of the .



## Class: OpenSearch.OpenSearchOptions
Configuration options for the OpenSearch client. 

### Properties

#### HostName
Gets or sets the hostname of the OpenSearch server.
#### Port
Gets or sets the port number of the OpenSearch server.
#### IndexName
Gets or sets the index name used for OpenSearch operations.
#### UserName
Gets or sets the password for authentication (if required).
#### Password
Gets or sets the password for authentication (if required).

## Class: OpenSearch.ServiceCollectionExtensions
Provides extension methods for configuring services related to OpenSearch. 

### Methods


#### TryAddOpenSearchServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Configures services for OpenSearch. 


##### Parameters
* *services:* The to add the services to.
* *configuration:* The to bind OpenSearch options from.
* *openSearchOptionSections:* The configuration section name containing OpenSearch options.




##### Return value
The modified .

