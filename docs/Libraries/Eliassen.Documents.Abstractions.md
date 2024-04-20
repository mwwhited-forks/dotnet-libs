# Eliassen.Documents.Abstractions


## Class: Documents.IContentProvider
Represents a provider for content retrieval and summarization. 

### Methods


#### DownloadAsync(System.String)
Downloads the content referenced by the specified file. 


##### Parameters
* *file:* The file to download.




##### Return value
A task representing the asynchronous operation. The task result contains a reference to the downloaded content, or null if the content could not be downloaded.



#### SummaryAsync(System.String)
Generates a summary for the content referenced by the specified file. 


##### Parameters
* *file:* The file for which to generate a summary.




##### Return value
A task representing the asynchronous operation. The task result contains a reference to the summarized content, or null if a summary could not be generated.



## Class: Documents.IDocumentConversion
Represents a service for document conversion. 

### Properties

#### 
Gets the supported source content types for document conversion.
#### 
Gets the supported destination content types for document conversion.
### Methods


#### ConvertAsync(System.IO.Stream,System.String,System.IO.Stream,System.String)
Converts a document from one format to another. 


##### Parameters
* *source:* The source stream containing the document to convert.
* *sourceContentType:* The content type of the source document.
* *destination:* The destination stream where the converted document will be written.
* *destinationContentType:* The desired content type of the converted document.




##### Return value
A task representing the asynchronous operation.



#### 
Determines whether the specified content type is supported as a source for document conversion. 


##### Parameters
* *contentType:* The content type to check.




##### Return value
True if the content type is supported; otherwise, false.



#### 
Determines whether the specified content type is supported as a destination for document conversion. 


##### Parameters
* *contentType:* The content type to check.




##### Return value
True if the content type is supported; otherwise, false.



## Class: Documents.IDocumentConversionHandler
Represents a handler for document conversion. 

### Properties

#### Sources
Gets the supported source content types for document conversion.
#### Destinations
Gets the supported destination content types for document conversion.
### Methods


#### SupportedSource(System.String)
Determines whether the specified content type is supported as a source for document conversion. 


##### Parameters
* *contentType:* The content type to check.




##### Return value
True if the content type is supported; otherwise, false.



#### SupportedDestination(System.String)
Determines whether the specified content type is supported as a destination for document conversion. 


##### Parameters
* *contentType:* The content type to check.




##### Return value
True if the content type is supported; otherwise, false.



## Class: Documents.IDocumentType
Represents a document type. 

### Properties

#### Name
Gets the name of the document type.
#### ContentTypes
Gets the supported content types for documents of this type.
#### FileExtensions
Gets the supported file extensions for documents of this type.
#### FileHeader
Gets the file header bytes that identify documents of this type.
### Methods


#### 
Retrieves the document type associated with the specified content type. 


##### Parameters
* *contentType:* The content type to search for.




##### Return value
The document type associated with the specified content type, or null if no matching document type is found.



#### 
Retrieves the document type associated with the specified file extension. 


##### Parameters
* *fileExtension:* The file extension to search for.




##### Return value
The document type associated with the specified file extension, or null if no matching document type is found.



#### 
Retrieves the document type associated with the content identified by the file header in the specified stream. 


##### Parameters
* *stream:* The stream containing the file header.




##### Return value
The document type associated with the content identified by the file header, or null if no matching document type is found.



## Class: Documents.IDocumentTypeTools
Provides tools for working with document types. 

### Methods


#### GetByContentType(System.String)
Retrieves the document type associated with the specified content type. 


##### Parameters
* *contentType:* The content type to search for.




##### Return value
The document type associated with the specified content type, or null if no matching document type is found.



#### GetByFileExtension(System.String)
Retrieves the document type associated with the specified file extension. 


##### Parameters
* *fileExtension:* The file extension to search for.




##### Return value
The document type associated with the specified file extension, or null if no matching document type is found.



#### GetByFileHeader(System.IO.Stream)
Retrieves the document type associated with the content identified by the file header in the specified stream. 


##### Parameters
* *stream:* The stream containing the file header.




##### Return value
The document type associated with the content identified by the file header, or null if no matching document type is found.



## Class: Documents.IGetContent`1
Represents a provider for retrieving content of type 
. 
The type of content to retrieve. 

### Methods


#### GetContentAsync(System.String)
Retrieves the content of type 
associated with the specified file. 


##### Parameters
* *file:* The file for which to retrieve the content.




##### Return value
A task representing the asynchronous operation. The task result contains the content of type , or null if the content could not be retrieved.



## Class: Documents.IGetSummary`1
Represents a provider for retrieving summaries of content of type 
. 
The type of content summary to retrieve. 

### Methods


#### GetSummaryAsync(System.String)
Retrieves the summary of content of type 
associated with the specified file. 


##### Parameters
* *file:* The file for which to retrieve the summary.




##### Return value
A task representing the asynchronous operation. The task result contains the summary of content of type , or null if the summary could not be retrieved.



## Class: Documents.Models.ContentReference
Represents a content reference containing information about content such as a stream, content type, and file name. 

### Properties

#### Content
Gets or initializes the content type of the content.
#### ContentType
Gets or initializes the content type of the content.
#### FileName
Gets or initializes the file name associated with the content.

## Class: Documents.Models.DocumentType
Represents a document type, including its name, supported content types, file extensions, and file header. 

### Properties

#### Name
Gets or sets the name of the document type.
#### ContentTypes
Gets or sets the MIME content types supported by this document type.
#### FileExtensions
Gets or sets the file extensions commonly associated with this document type.
#### FileHeader
Gets or sets the unique byte sequence at the beginning of files of this type.