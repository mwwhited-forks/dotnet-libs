# Eliassen.Azure.StorageAccount.Abstractions


## Class: Azure.StorageAccount.AzureStorageGlobals
Contains global constants related to Azure Storage.
### Fields

#### MessageProviderKey
The key associated with the Azure Storage message provider.

## Class: Azure.StorageAccount.BlobStorage.BlobDto
Represents a Data Transfer Object (DTO) for handling blob-related information.
### Properties

#### Uri
Gets or sets the URI of the blob.
#### Name
Gets or sets the name of the blob.
#### ContentType
Gets or sets the content type of the blob.
#### Content
Gets or sets the content stream of the blob.

## Class: Azure.StorageAccount.BlobStorage.BlobResponseDto
Represents a Data Transfer Object (DTO) for a blob response.
### Properties

#### Status
Gets or sets the status of the blob response.
#### Error
Gets or sets a value indicating whether an error occurred in the blob response.
#### Blob
Gets or sets the blob information associated with the response.

## Class: Azure.StorageAccount.BlobStorage.ConfigKeys
Contains constant keys for configuration settings.
### Fields

#### Container.DefaultProvider
Represents the key for the default storage provider configuration.
#### Container.DefaultConnectionString
Represents the key for the default storage connection string configuration.
#### Container.DefaultContainerName
Represents the key for the default storage container name configuration.
#### Container.Directories._Base
Represents the base key for container directories configuration.
#### Container.Directories.Misc
Represents the key for the miscellaneous directory within the storage container.

## Class: Azure.StorageAccount.BlobStorage.ConfigKeys.Container
Contains keys related to storage container configuration.
### Fields

#### DefaultProvider
Represents the key for the default storage provider configuration.
#### DefaultConnectionString
Represents the key for the default storage connection string configuration.
#### DefaultContainerName
Represents the key for the default storage container name configuration.
#### Directories._Base
Represents the base key for container directories configuration.
#### Directories.Misc
Represents the key for the miscellaneous directory within the storage container.

## Class: Azure.StorageAccount.BlobStorage.ConfigKeys.Container.Directories
Contains keys related to storage container directories configuration.
### Fields

#### _Base
Represents the base key for container directories configuration.
#### Misc
Represents the key for the miscellaneous directory within the storage container.

## Class: Azure.StorageAccount.BlobStorage.DocumentModel
Represents a document with associated metadata.
### Properties

#### DocumentId
Gets or sets the unique identifier of the document.
#### DocumentKey
Gets or sets the key associated with the document.
#### DocumentName
Gets or sets the name of the document.
#### DocumentType
Gets or sets the type of the document.
#### DocumentSize
Gets or sets the size of the document in bytes.
#### DocumentRepository
Gets or sets the repository where the document is stored.
#### DocumentCategory
Gets or sets the category of the document.
#### CreatedOn
Gets or sets the date and time when the document was created.

## Class: Azure.StorageAccount.BlobStorage.DocumentUploadModel
Represents a document upload model, extending the with additional data.
### Properties

#### Data
Gets or sets the binary data of the document.

## Class: Azure.StorageAccount.BlobStorage.IDocumentProvider
Provides functionality for managing documents, including listing, uploading, downloading, and deleting.
### Methods


#### ListAsync
Retrieves a list of BlobDto representing the available documents.

##### Return value
A task that represents the asynchronous operation, containing the list of BlobDto.



#### UploadAsync(Eliassen.Azure.StorageAccount.BlobStorage.DocumentModel,System.IO.Stream)
Uploads a document with the specified metadata and content.

##### Parameters
* *document:* The metadata of the document to upload.
* *content:* The content stream of the document.




##### Return value
A task that represents the asynchronous operation, containing the BlobResponseDto for the uploaded document.



#### DownloadAsync(System.String)
Downloads the document with the specified filename.

##### Parameters
* *blobFilename:* The filename of the document to download.




##### Return value
A task that represents the asynchronous operation, containing the BlobDto for the downloaded document. Returns null if the document with the specified filename is not found.



#### DeleteAsync(System.String)
Deletes the document with the specified filename.

##### Parameters
* *blobFilename:* The filename of the document to delete.




##### Return value
A task that represents the asynchronous operation, containing the BlobResponseDto for the deletion result.

