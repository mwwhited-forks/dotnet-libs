# Eliassen.Documents


## Class: Documents.Conversion.ChainStep
Represents a step in a document conversion chain. 

### Properties

#### Handler
Gets or sets the document conversion handler for this step.
#### SourceContentType
Gets or sets the content type of the source document for this step.
#### DestinationContentType
Gets or sets the content type of the destination document for this step.

## Class: Documents.Conversion.DocumentConversion
Represents a document conversion service. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Documents.Conversion.DocumentConversion*class with the specified document conversion chain builder. 


##### Parameters
* *chain:* The document conversion chain builder.
* *logger:* The logger.




#### ConvertAsync(System.IO.Stream,System.String,System.IO.Stream,System.String)
Converts the content of a source stream to a destination stream asynchronously. 


##### Parameters
* *source:* The source stream containing the content to be converted.
* *sourceContentType:* The content type of the source content.
* *destination:* The destination stream where the converted content will be written.
* *destinationContentType:* The content type of the converted content.




##### Return value
A representing the asynchronous operation.



#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Documents.Conversion.DocumentConversionChainBuilder*class. 


##### Parameters
* *handlers:* The available document conversion handlers.




#### 
Constructs the document conversion steps for converting from the specified source content type to the destination content type. 


##### Parameters
* *sourceContentType:* The content type of the source document.
* *destinationContentType:* The desired content type of the converted document.




##### Return value
An array of ChainStep objects representing the conversion steps.



## Class: Documents.Conversion.DocumentConversionChainBuilder
Represents a builder for constructing document conversion chains. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Documents.Conversion.DocumentConversionChainBuilder*class. 


##### Parameters
* *handlers:* The available document conversion handlers.




#### Steps(System.String,System.String)
Constructs the document conversion steps for converting from the specified source content type to the destination content type. 


##### Parameters
* *sourceContentType:* The content type of the source document.
* *destinationContentType:* The desired content type of the converted document.




##### Return value
An array of ChainStep objects representing the conversion steps.



## Class: Documents.Conversion.IDocumentConversionChainBuilder
Represents a document conversion chain builder. 

### Methods


#### Steps(System.String,System.String)
Gets the conversion steps from a source content type to a destination content type. 


##### Parameters
* *sourceContentType:* The content type of the source content.
* *destinationContentType:* The content type of the destination content.




##### Return value
An array of representing the conversion steps.



## Class: Documents.Conversion.ToTextConversionHandler
Represents a conversion handler for converting documents to text format. 

### Properties

#### Destinations
Array of supported destination content types (text/plain).
#### Sources
Array of supported source content types (application/octet-stream).
### Methods


#### ConvertAsync(System.IO.Stream,System.String,System.IO.Stream,System.String)
Converts the content of the source stream to text format and writes it to the destination stream asynchronously. 


##### Parameters
* *source:* The source stream containing the document content.
* *sourceContentType:* The content type of the source document.
* *destination:* The destination stream where the converted text will be written.
* *destinationContentType:* The content type of the destination format (text).




##### Return value
A task representing the asynchronous operation.



#### SupportedDestination(System.String)
Checks if the provided content type is supported as a destination format (text/plain). 


##### Parameters
* *contentType:* The content type to check.




##### Return value
True if the content type is supported; otherwise, false.



#### SupportedSource(System.String)
Checks if the provided content type is supported as a source format (any content type is supported). 


##### Parameters
* *contentType:* The content type to check.




##### Return value
Always returns true because any content type is supported as a source format.



## Class: Documents.Depercated.ContentProvider
Represents a content provider for downloading and summarizing content. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Documents.Depercated.ContentProvider*class with the specified content and summary providers. 


##### Parameters
* *content:* The provider for retrieving content.
* *summary:* The provider for retrieving content summaries.




#### DownloadAsync(System.String)
Downloads the specified content asynchronously. 


##### Parameters
* *file:* The name of the file to download.




##### Return value
A representing the asynchronous operation. The task result contains the downloaded content reference, or null if the content does not exist.



#### SummaryAsync(System.String)
Retrieves a summary of the specified content asynchronously. 


##### Parameters
* *file:* The name of the file to summarize.




##### Return value
A representing the asynchronous operation. The task result contains the content summary, or null if the content does not exist.



## Class: Documents.DocumentTypeTools
Represents a toolset for managing document types. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.Documents.DocumentTypeTools*class with the specified document types. 


##### Parameters
* *types:* The collection of document types.




#### GetByContentType(System.String)
Retrieves the document type associated with the specified content type. 


##### Parameters
* *contentType:* The content type to search for.




##### Return value
The document type associated with the content type, if found; otherwise, null.



#### GetByFileExtension(System.String)
Retrieves the document type associated with the specified file extension. 


##### Parameters
* *fileExtension:* The file extension to search for.




##### Return value
The document type associated with the file extension, if found; otherwise, null.



#### GetByFileHeader(System.IO.Stream)
Retrieves the document type associated with the specified file header. 


##### Parameters
* *stream:* The stream containing the file header.




##### Return value
The document type associated with the file header, if found; otherwise, null.



## Class: Documents.ServiceCollectionExtensions
Provides extension methods for configuring document-related services. 

### Methods


#### TryAddDocumentServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Configures services for document processing. 


##### Parameters
* *services:* The to add the services to.




##### Return value
The modified .

