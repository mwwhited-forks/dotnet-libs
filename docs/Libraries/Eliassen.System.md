# Eliassen.System


## Class: System.Accessors.Accessor`1
Represents an accessor for a value of type .The type of the value to be accessed.
### Properties

#### Value
Gets or sets the value associated with this accessor.

## Class: System.Configuration.CommandLine
builder pattern for command parameter arguments
### Methods


#### AddParameters``1(System.Collections.Generic.IDictionary{System.String,System.String})
add additional configurable parameters

##### Parameters
* *items:* 




##### Return value




#### BuildParameters``1
entry point or defining configurable parameters

##### Return value




## Class: System.Extensions.Configuration.ConfigurationBuilderExtensions
Extension methods for adding in-memory collections to the .
### Methods


#### AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder,System.Collections.Generic.IEnumerable{System.ValueTuple{System.String,System.String}})
Adds an in-memory collection to the using the specified initial data.

##### Parameters
* *configurationBuilder:* The to add the in-memory collection to.
* *initialData:* The initial data to populate the in-memory collection.




##### Return value
The modified .



#### AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder,System.ValueTuple{System.String,System.String},System.ValueTuple{System.String,System.String}[])
Adds an in-memory collection to the using the specified initial data.

##### Parameters
* *configurationBuilder:* The to add the in-memory collection to.
* *item:* The first item of the in-memory collection.
* *initialData:* Additional initial data to populate the in-memory collection.




##### Return value
The modified .



## Class: System.IO.StreamJsonDeserializeExtensions
Set of extension method to centralize deserialize of stream using System.Text.Json
### Methods


#### AsJsonAsync``1(System.IO.Stream,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object

##### Parameters
* *stream:* 
* *options:* 




##### Return value




#### AsJson``1(System.IO.Stream,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object

##### Parameters
* *stream:* 
* *options:* 




##### Return value




#### AsJsonAsync(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object

##### Parameters
* *stream:* 
* *type:* 
* *options:* 




##### Return value




#### AsJson(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object

##### Parameters
* *stream:* 
* *type:* 
* *options:* 




##### Return value




## Class: System.IO.StreamXmlDeserializeExtensions
Set of extension method to centralize deserialize of stream using System.Xml
### Methods


#### AsXmlAsync``1(System.IO.Stream,System.Type[])
Convert XML Stream to .Net Object

##### Parameters
* *stream:* 
* *extraTypes:* 




##### Return value




#### AsXml``1(System.IO.Stream,System.Type[])
Convert XML Stream to .Net Object

##### Parameters
* *stream:* 
* *extraTypes:* 




##### Return value




#### AsXmlAsync(System.IO.Stream,System.Type,System.Type[])
Convert XML Stream to .Net Object

##### Parameters
* *stream:* 
* *type:* 
* *extraTypes:* 




##### Return value




#### AsXml(System.IO.Stream,System.Type,System.Type[])
Convert XML Stream to .Net Object

##### Parameters
* *stream:* 
* *type:* 
* *extraTypes:* 




##### Return value




## Class: System.Linq.AsyncEnumerableExtensions
Extensions to add async support to existing IEnumerable{T}
### Methods


#### ToListAsync``1(System.Linq.IQueryable{``0},System.Threading.CancellationToken)
Process IQueryable{T} to a List{T} as async

##### Parameters
* *source:* 
* *cancellationToken:* 




##### Return value




#### AsEnumerableAsync``1(System.Collections.Generic.IAsyncEnumerable{``0},System.Threading.CancellationToken)
Convert IAsyncEnumerable{TModel} to Task{IEnumerable{TModel}}

##### Parameters
* *items:* 
* *token:* 




##### Return value




#### AsAsyncEnumerable``1(System.Threading.Tasks.Task{System.Collections.Generic.IEnumerable{``0}},System.Threading.CancellationToken)
Convert Task{IEnumerable{TModel}} to IAsyncEnumerable{TModel}

##### Parameters
* *items:* 
* *cancellationToken:* 




##### Return value




#### AsAsyncEnumerable``1(System.Collections.Generic.IEnumerable{``0},System.Threading.CancellationToken)
Convert IEnumerable{TModel} to IAsyncEnumerable{TModel}

##### Parameters
* *items:* 
* *cancellationToken:* 




##### Return value




## Class: System.Linq.DictionaryExtensions
Reusable extensions for Generic Dictionaries
### Methods


#### TryGetValue``2(System.Collections.Generic.IDictionary{``0,``1},``0,``1@,System.Collections.Generic.IEqualityComparer{``0})
extend try get value to allow for using a different IEqualityComparer{TKey}

##### Parameters
* *dictionary:* 
* *key:* 
* *value:* 
* *comparer:* 




##### Return value




#### ChangeComparer``2(System.Collections.Generic.IDictionary{``0,``1},System.Collections.Generic.IEqualityComparer{``0})
Rebuild dictionary to use a different IEqualityComparer{TKey}

##### Parameters
* *dictionary:* 
* *comparer:* 




##### Return value




## Class: System.Linq.Expressions.ExpressionExtensions
Extensions for System.Linq.Expressions.Expression
### Methods


#### OrElse``1(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}})
Build an or'd expression chain

##### Parameters
* *ors:* 




##### Return value




#### AndAlso``1(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}})
Build an and'd expression chain

##### Parameters
* *ands:* 




##### Return value




## Class: System.Linq.Expressions.SkipInstanceMethodOnNullExpressionVisitor
This visitor will modify expressions to add `x.Property != null` before instance method calls for query rewrite
### Methods


#### VisitMethodCall(System.Linq.Expressions.MethodCallExpression)
If expression is an instance method then modify the expression to ensure a

##### Parameters
* *node:* 




##### Return value




## Class: System.Linq.Expressions.StringComparisonReplacementExpressionVisitor
Expression visitor to replace string functions with the matching functions that end with a StringComparison parameter
### Methods


#### Constructor
Expression visitor to replace string functions with the matching functions that end with a StringComparison parameter

#### VisitBinary(System.Linq.Expressions.BinaryExpression)
Replace `string == string` with `string.Equals(string, StringComparison)`

##### Parameters
* *node:* 




##### Return value




#### VisitMethodCall(System.Linq.Expressions.MethodCallExpression)
Replace `string.Xyz(string)` with `string.Xyz(string, StringComparison)`

##### Parameters
* *input:* 




##### Return value




## Class: System.Linq.Search.Operators
Expression builder operator options
### Fields

#### Unknown
Unknown
#### EqualTo
Values are equal
#### InSet
Value is within set
#### LessThan
value is less than provided
#### LessThanOrEqualTo
value is less than or equal to provided
#### GreaterThan
value is greater than provided
#### GreaterThanOrEqualTo
value is less greater or equal to provided
#### NotEqualTo
value not equal to

## Class: System.Linq.Search.QueryBuilder
Provides a base class for building and executing queries based on search, filter, sort, and page criteria.
### Fields

#### DefaultPageSize
Default page size when not defined on request
### Methods


#### Execute(System.Linq.IQueryable,Eliassen.System.Linq.Search.ISearchQuery,System.Collections.Generic.IEnumerable{Eliassen.System.Linq.Expressions.IPostBuildExpressionVisitor},Microsoft.Extensions.Logging.ILogger{Eliassen.System.Linq.Search.QueryBuilder},Eliassen.System.ResponseModel.ICaptureResultMessage)
Composes and executes a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The queryable data source.
* *searchQuery:* The search query parameters.
* *postBuildVisitors:* Optional post-build expression visitors.
* *logger:* Optional logger for logging messages.
* *messages:* Optional message capture for result messages.




##### Return value
The result of the query execution.



#### Execute``1(System.Linq.IQueryable{``0},Eliassen.System.Linq.Search.ISearchQuery,System.Collections.Generic.IEnumerable{Eliassen.System.Linq.Expressions.IPostBuildExpressionVisitor},Microsoft.Extensions.Logging.ILogger{Eliassen.System.Linq.Search.QueryBuilder},Eliassen.System.ResponseModel.ICaptureResultMessage)
Composes and executes a typed query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The typed queryable data source.
* *searchQuery:* The search query parameters.
* *postBuildVisitors:* Optional post-build expression visitors.
* *logger:* Optional logger for logging messages.
* *messages:* Optional message capture for result messages.




##### Return value
The result of the typed query execution.



#### Execute``1(System.Linq.IQueryable{``0},Eliassen.System.Linq.Search.ISearchQuery,Eliassen.System.Linq.Expressions.IPostBuildExpressionVisitor,Eliassen.System.Linq.Expressions.IPostBuildExpressionVisitor[])
Composes and executes a typed query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The typed queryable data source.
* *searchQuery:* The search query parameters.
* *postBuildVisitor:* A single post-build expression visitor.
* *postBuildVisitors:* Additional post-build expression visitors.




##### Return value
The result of the typed query execution.



#### Constructor
Provides a typed implementation for building and executing queries based on search, filter, sort, and page criteria.

#### 
Composes and executes a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The queryable data source.
* *searchQuery:* The search query parameters.




##### Return value
The result of the query execution.



#### 
Composes and executes a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The queryable data source.
* *searchQuery:* The search query parameters.




##### Return value
The result of the query execution.



## Class: System.Linq.Search.QueryBuilder`1
Provides a typed implementation for building and executing queries based on search, filter, sort, and page criteria.The type of the model in the query.
### Methods


#### Constructor
Provides a typed implementation for building and executing queries based on search, filter, sort, and page criteria.

#### ExecuteBy(System.Linq.IQueryable{`0},Eliassen.System.Linq.Search.ISearchQuery)
Composes and executes a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The queryable data source.
* *searchQuery:* The search query parameters.




##### Return value
The result of the query execution.



#### ExecuteBy(System.Linq.IQueryable,Eliassen.System.Linq.Search.ISearchQuery)
Composes and executes a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery.

##### Parameters
* *query:* The queryable data source.
* *searchQuery:* The search query parameters.




##### Return value
The result of the query execution.



## Class: System.Net.Mime.ContentTypesExtensions
Provides constants representing various content types.
### Fields

#### Text.HandlebarsTemplate
Represents the content type for Handlebars templates.
#### Text.Calendar
Represents the content type for calendar data.
#### Text.Html
Represents the content type for HTML.
#### Text.Markdown
Represents the content type for Markdown.
#### Application.XSLT
Represents the content type for XSLT (XML Stylesheet Language Transformations).

## Class: System.Net.Mime.ContentTypesExtensions.Text
Represents text-based content types.
### Fields

#### HandlebarsTemplate
Represents the content type for Handlebars templates.
#### Calendar
Represents the content type for calendar data.
#### Html
Represents the content type for HTML.
#### Markdown
Represents the content type for Markdown.

## Class: System.Net.Mime.ContentTypesExtensions.Application
Represents application-based content types.
### Fields

#### XSLT
Represents the content type for XSLT (XML Stylesheet Language Transformations).

## Class: System.Reflection.ReflectionExtensions
Extensions for reflection and common patterns.
### Fields

#### PublicProperties
flag combination to select public instance properties
#### PublicStaticMethod
flag combination to select public static methods
#### PublicInstanceMethod
flag combination to select public instance methods
### Methods


#### GetKeyValue(System.Object)
lookup key values for provided entity

##### Parameters
* *item:* 




##### Return value




#### MakeSafeArray(System.Type,System.Array)
safely create new array for a given element type.

##### Parameters
* *type:* 
* *inputs:* 




##### Return value




#### MakeSafe(System.Type,System.Object)
Make safe will try to convert input to target type as best as possible.

##### Parameters
* *type:* 
* *input:* 




##### Return value




#### TryParse(System.Type,System.String,System.Object@)
Use best possible match for parsing to provided type

##### Parameters
* *type:* 
* *toParse:* 
* *parsed:* 




##### Return value




#### GetShortTypeName(System.Type)
Type name with full namespace, name and assembly. version is not included

##### Parameters
* *type:* 




##### Return value




#### GetAttributes(System.Type)
Get all attributes for type

##### Parameters
* *type:* 




##### Return value




#### GetAttributes``1(System.Type)
Get all attributes of selected style for reflected type

##### Parameters
* *type:* 




##### Return value




#### GetPropertiesByAttribute``1(System.Type)
get property info where attribute matches

##### Parameters
* *type:* 




##### Return value




#### GetStaticMethod(System.Type,System.String,System.Type[])
get static method

##### Parameters
* *type:* 
* *methodName:* 
* *parameterTypes:* 




##### Return value




#### GetInstanceMethod(System.Type,System.String,System.Type[])
get instance method

##### Parameters
* *type:* 
* *methodName:* 
* *parameterTypes:* 




##### Return value




#### GetParametersTypes(System.Reflection.MethodInfo)
get parameters for method

##### Parameters
* *method:* 




##### Return value




## Class: System.Reflection.ResourceExtensions
Set of extension methods for embedded resources
### Methods


#### GetResourceStream(System.Object,System.String)
Lookup resource stream based on filename relative the scope of context

##### Parameters
* *context:* 
* *resourceName:* 




##### Return value




#### GetResourceStream(System.Type,System.String)
Lookup resource stream based on filename relative the scope of Type

##### Parameters
* *type:* 
* *resourceName:* 




##### Return value




#### GetResourceStream(System.Reflection.Assembly,System.String)
Lookup resource stream based on filename relative the scope of Type

##### Parameters
* *assembly:* 
* *resourceName:* 




##### Return value




#### GetResourceAsStringAsync(System.Object,System.String)
Lookup resource content based on filename relative the scope of context

##### Parameters
* *context:* 
* *resourceName:* 




##### Return value




#### GetResourceAsString(System.Object,System.String)
Lookup resource content based on filename relative the scope of context

##### Parameters
* *context:* 
* *resourceName:* 




##### Return value




## Class: System.Security.Claims.ClaimsPrincipalExtensions
Extensions to manage on
### Methods


#### GetAllClaims(System.Security.Claims.ClaimsPrincipal)
Iterate all for provided

##### Parameters
* *principal:* 




##### Return value




#### GetClaimValues(System.Security.Claims.ClaimsPrincipal,System.String[])
Get for matched on

##### Parameters
* *principal:* 
* *claims:* 




##### Return value




#### GetClaimValue(System.Security.Claims.ClaimsPrincipal,System.String[])
Get first matched on

##### Parameters
* *principal:* 
* *claims:* 




##### Return value




## Class: System.Security.Cryptography.Hash
Default hash of input value. Base64 encoded MD5 Hash

## Class: System.ServiceCollectionExtensions
Suggested IOC configurations
### Methods


#### TryAddSystemExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
This will add all available extensions to the IOC container

##### Parameters
* *services:* 
* *config:* 




##### Return value




#### TryAddSearchQueryExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared SearchQuery Extensions

##### Parameters
* *services:* 




##### Return value




#### TrySecurityExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared security extensions

##### Parameters
* *services:* 




##### Return value




#### TrySerializerExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared Serializer

##### Parameters
* *services:* 




##### Return value




#### TryTemplatingExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Add support for shared Templating

##### Parameters
* *services:* 
* *config:* 




##### Return value




#### AddAccessor``1(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Register accessor type that is scoped to as AsyncLocal

##### Parameters
* *services:* 




##### Return value




#### AddConfiguration``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Extend configuration options

##### Parameters
* *services:* 
* *config:* 




##### Return value




#### GetSingletonInstance``2(Microsoft.Extensions.DependencyInjection.IServiceCollection,``1@)
Get singleton instance from IOC container

##### Parameters
* *services:* 
* *instance:* 




##### Return value




## Class: System.Text.Json.BsonDateTimeOffsetConverter
System.Text.Json converter to support BsonDatetimeOffset
### Methods


#### CanConvert(System.Type)
Determines whether this converter can convert the specified type.

##### Parameters
* *typeToConvert:* The type to check for conversion support.




##### Return value
true if the converter can convert the specified type; otherwise, false.



#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)
Reads the JSON representation of the object.

##### Parameters
* *reader:* The reader to read from.
* *typeToConvert:* The type of the object to convert.
* *options:* The serializer options to use during conversion.




##### Return value
The deserialized object value.



#### Write(System.Text.Json.Utf8JsonWriter,System.Object,System.Text.Json.JsonSerializerOptions)
Writes the JSON representation of the object.

##### Parameters
* *writer:* The writer to write to.
* *value:* The value to convert.
* *options:* The serializer options to use during conversion.




## Class: System.Text.Json.BsonIdConverter
This type converter for System.Text.Json to support BSON ObjectID to JSON safe export/import

## Class: System.Text.Json.BsonTypeInfoResolver
Resolves JSON type information for BSON serialization.

## Class: System.Text.Json.ConfigurationJsonConverter`1
JsonConverter for serializing and deserializing IConfiguration instances.The type of IConfiguration.

## Class: System.Text.Json.DictionaryStringObjectJsonConverter
Custom JSON converter for dictionaries with string keys and object values.

## Class: System.Text.Json.JsonDocumentExtensions
shared extension methods for System.Text.Json
### Methods


#### ToXmlDocument(System.Text.Json.JsonElement,System.String)
Convert System.Test.Json.JsonDocument to System.Xml.XmlDocument

##### Parameters
* *json:* 
* *rootName:* 




##### Return value




## Class: System.Text.Json.Serialization.DefaultBsonSerializer
Default serializer for BSON (Binary JSON).
### Fields

#### DefaultContentType
The default content type for BSON.
### Properties

#### ContentType
Gets the content type for BSON, which is "application/json".
### Methods


#### Constructor
Initializes a new instance of the class.

## Class: System.Text.Json.Serialization.DefaultJsonSerializer
Default serializer for JSON.
Initializes a new instance of the class.
### Fields

#### DefaultContentType
Gets the default content type for JSON.
#### _options
The JSON serializer options.
### Properties

#### DefaultOptions
Gets the default JSON serializer options.
### Methods


#### Constructor
Initializes a new instance of the class.
Default serializer for JSON.

##### Parameters
* *options:* Optional JSON serializer options.




#### AsPropertyName(System.String)
Use the configured property naming policy to change the provided value.

##### Parameters
* *propertyName:* The property name to convert.




##### Return value
The converted property name.



## Class: System.Text.Templating.FileTemplateSource
Access template from file system
### Methods


#### Constructor
Access template from file system

## Class: System.Text.Templating.FileTemplatingSettings
Configuration settings for file templating engine
### Properties

#### TemplatePath
template source path
#### SandboxPath
sandbox root path
#### Priority
template priority

## Class: System.Text.Templating.FileType
Represents a file type, providing information about the file extension, content type, and whether it is a template type.
### Properties

#### Extension
Gets or sets the file extension associated with the file type.
#### ContentType
Gets or sets the content type associated with the file type.
#### IsTemplateType
Gets or sets a value indicating whether the file type is a template type.

## Class: System.Text.Templating.TemplateEngine
Generate templating engine that will try to use best match for source and provider
### Methods


#### Constructor
Generate templating engine that will try to use best match for source and provider

## Class: System.Text.Templating.XsltTemplateProvider
Provides template processing using XSLT (eXtensible Stylesheet Language Transformations).
### Properties

#### SupportedContentTypes
Gets the collection of supported content types by the template provider. application/xslt+xml
### Methods


#### CanApply(Eliassen.System.Text.Templating.ITemplateContext)
Determines whether this template provider can apply template processing to the given context.

##### Parameters
* *context:* The template context.




##### Return value
true if the template processing can be applied; otherwise, false.



#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)
Applies the XSLT template associated with the specified context, using the provided data, and writes the result to the target stream asynchronously.

##### Parameters
* *context:* The template context.
* *data:* The data to apply to the template.
* *target:* The stream where the result will be written.




##### Return value
A task representing the asynchronous operation, indicating whether the application was successful.

