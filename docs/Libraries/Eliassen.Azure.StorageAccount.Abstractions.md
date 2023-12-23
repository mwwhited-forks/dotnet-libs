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