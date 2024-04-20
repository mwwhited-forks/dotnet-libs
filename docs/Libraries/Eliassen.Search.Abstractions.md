# Eliassen.Search.Abstractions


## Class: Search.ISearchContent`1
Represents a provider for searching content of type 
. 
The type of content to search. 

### Methods


#### QueryAsync(System.String,System.Int32,System.Int32)
Queries the content provider asynchronously to retrieve search results. 


##### Parameters
* *queryString:* The query string used to search for content.
* *limit:* The maximum number of search results to retrieve. Defaults to 25.
* *page:* The page number of search results to retrieve. Defaults to 0.




##### Return value
An asynchronous enumerable that yields search results of type .



## Class: Search.ISearchProvider
Represents a provider for conducting searches. 

### Methods


#### HybridSearchAsync(System.String,System.Int32)
Performs a hybrid search based on the specified query and limit. 


##### Parameters
* *query:* The search query.
* *limit:* The maximum number of search results to retrieve.




##### Return value
A task that represents the asynchronous operation. The task result contains the search results.



#### LexicalSearchAsync(System.String,System.Int32)
Performs a lexical search based on the specified query and limit. 


##### Parameters
* *query:* The search query.
* *limit:* The maximum number of search results to retrieve.




##### Return value
A task that represents the asynchronous operation. The task result contains the search results.



#### ListAsync
Retrieves a list of search results. 


##### Return value
A task that represents the asynchronous operation. The task result contains the list of search results.



#### SemanticSearchAsync(System.String,System.Int32)
Performs a semantic search based on the specified query and limit. 


##### Parameters
* *query:* The search query.
* *limit:* The maximum number of search results to retrieve.




##### Return value
A task that represents the asynchronous operation. The task result contains the search results.



## Class: Search.IStoreContent
Represents a provider for storing content. 

### Methods


#### TryStoreAsync(System.String,System.String,System.String)
Attempts to store the content associated with the specified file. 


##### Parameters
* *full:* The full content to store.
* *file:* The file name associated with the content.
* *pathHash:* The hash of the file path.




##### Return value
A task representing the asynchronous operation. The task result indicates whether the content was successfully stored.



## Class: Search.ISummarizeContent
Represents a provider for summarizing content. 

### Methods


#### GenerateSummaryAsync(System.String)
Generates a summary for the specified input content asynchronously. 


##### Parameters
* *input:* The input content for which to generate the summary.




##### Return value
A task representing the asynchronous operation. The task result contains the generated summary.



## Class: Search.Models.SearchResultModel
Represents a search result model containing information about a search result. 

### Properties

#### Score
Gets or initializes the score of the search result.
#### PathHash
Gets or initializes the hash of the path where the search result was found.
#### File
Gets or initializes the name of the file where the search result was found.
#### Content
Gets or initializes the content of the file where the search result was found.
#### Type
Gets or initializes the type of the search result.

## Class: Search.Models.SearchTypes
Specifies the types of search. 

### Fields

#### None
Indicates no specific search type.
#### Semantic
Indicates a semantic search type.
#### Lexical
Indicates a lexical search type.
#### Hybrid
Indicates a hybrid search type combining semantic and lexical searches.