# Eliassen.MongoDB.Extensions


## Class: MongoDB.Extensions.CollectionNameAttribute
declarative attribute for labeling properties as MongoDB Collections
### Properties

#### CollectionName
Name to use for MongoDB collection

## Class: MongoDB.Extensions.DefaultMongoDatabaseSettings
Default connection information for MongoDatabases, Duplicating this class with a different ConfigurationSectionAttribute value will allow for declaring secondary connection configurations

## Class: MongoDB.Extensions.IMongoDatabaseFactory
provide a centralized means to created MongoDB instances
### Methods


#### Create``1
factory method to create a instance.
    ##### Return value
    

#### Create``2
factory method to create a MongoDB Database abstraction.
    ##### Return value
    

## Class: MongoDB.Extensions.IMongoDatabaseRegistration
Internal registry for MongoDatabase connections.
### Properties

#### Types
List of registered interfaces for MongoDatabase instances.

## Class: MongoDB.Extensions.IMongoSettings
Common pattern for declaring MongoDB Settings
### Properties

#### ConnectionString
MongoDB Connection String
#### DatabaseName
Name of database to map for MongoDB

## Class: MongoDB.Extensions.MongoDispatchProxy
This proxy allow for dynamic creation of wrapper classes to expose MongoDatabase instances

## Class: MongoDB.Extensions.ServiceCollectionExtensions
Common libraries to enable MongoDB Support
### Methods


#### TryAddMongoServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Enable common infrastructure.
    #####Parameters
    **services:** 

    **config:** 

    ##### Return value
    

#### TryAddMongoDatabase``2(Microsoft.Extensions.DependencyInjection.IServiceCollection)
register MongoDatabase instance with custom configuration options
    #####Parameters
    **services:** 

    ##### Return value
    

#### TryAddMongoDatabase``1(Microsoft.Extensions.DependencyInjection.IServiceCollection)
register MongoDatabase instance that will use the configuration options
    #####Parameters
    **services:** 

    ##### Return value
    