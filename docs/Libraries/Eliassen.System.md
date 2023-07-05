# Eliassen.System


## Class: System.Configuration.CommandLine
builder pattern for command parameter arguments
### Methods


#### AddParameters``1(System.Collections.Generic.IDictionary{System.String,System.String})
add additional configurable parameters
    #####Parameters
    **items:** 

    ##### Return value
    

#### BuildParameters``1
entry point or defining configurable parameters
    ##### Return value
    

## Class: System.IO.StreamJsonDeserializeExtensions
Set of extension method to centralize deserialize of stream using System.Text.Json
### Methods


#### AsJsonAsync``1(System.IO.Stream,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object
    #####Parameters
    **stream:** 

    **options:** 

    ##### Return value
    

#### AsJson``1(System.IO.Stream,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object
    #####Parameters
    **stream:** 

    **options:** 

    ##### Return value
    

#### AsJsonAsync(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object
    #####Parameters
    **stream:** 

    **type:** 

    **options:** 

    ##### Return value
    

#### AsJson(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object
    #####Parameters
    **stream:** 

    **type:** 

    **options:** 

    ##### Return value
    

## Class: System.IO.StreamXmlDeserializeExtensions
Set of extension method to centralize deserialize of stream using System.Xml
### Methods


#### AsXmlAsync``1(System.IO.Stream,System.Type[])
Convert XML Stream to .Net Object
    #####Parameters
    **stream:** 

    **extraTypes:** 

    ##### Return value
    

#### AsXml``1(System.IO.Stream,System.Type[])
Convert XML Stream to .Net Object
    #####Parameters
    **stream:** 

    **extraTypes:** 

    ##### Return value
    

#### AsXmlAsync(System.IO.Stream,System.Type,System.Type[])
Convert XML Stream to .Net Object
    #####Parameters
    **stream:** 

    **type:** 

    **extraTypes:** 

    ##### Return value
    

#### AsXml(System.IO.Stream,System.Type,System.Type[])
Convert XML Stream to .Net Object
    #####Parameters
    **stream:** 

    **type:** 

    **extraTypes:** 

    ##### Return value
    

## Class: System.Linq.AsyncEnumerableExtensions
Extensions to add async support to existing IEnumerable{T}
### Methods


#### ToListAsync``1(System.Linq.IQueryable{``0},System.Threading.CancellationToken)
Process IQueryable{T} to a List{T} as async
    #####Parameters
    **source:** 

    **cancellationToken:** 

    ##### Return value
    

#### AsEnumerableAsync``1(System.Collections.Generic.IAsyncEnumerable{``0},System.Threading.CancellationToken)
Convert IAsyncEnumerable{TModel} to Task{IEnumerable{TModel}}
    #####Parameters
    **items:** 

    **token:** 

    ##### Return value
    

#### AsAsyncEnumerable``1(System.Threading.Tasks.Task{System.Collections.Generic.IEnumerable{``0}},System.Threading.CancellationToken)
Convert Task{IEnumerable{TModel}} to IAsyncEnumerable{TModel}
    #####Parameters
    **items:** 

    **cancellationToken:** 

    ##### Return value
    

#### AsAsyncEnumerable``1(System.Collections.Generic.IEnumerable{``0},System.Threading.CancellationToken)
Convert IEnumerable{TModel} to IAsyncEnumerable{TModel}
    #####Parameters
    **items:** 

    **cancellationToken:** 

    ##### Return value
    

## Class: System.Linq.DictionaryExtensions
Reusable extensions for Generic Dictionaries
### Methods


#### TryGetValue``2(System.Collections.Generic.IDictionary{``0,``1},``0,``1@,System.Collections.Generic.IEqualityComparer{``0})
extend try get value to allow for using a different IEqualityComparer{TKey}
    #####Parameters
    **dictionary:** 

    **key:** 

    **value:** 

    **comparer:** 

    ##### Return value
    

#### ChangeComparer``2(System.Collections.Generic.IDictionary{``0,``1},System.Collections.Generic.IEqualityComparer{``0})
Rebuild dictionary to use a different IEqualityComparer{TKey}
    #####Parameters
    **dictionary:** 

    **comparer:** 

    ##### Return value
    

## Class: System.Linq.Expressions.ExpressionExtensions
Extensions for System.Linq.Expressions.Expression
### Methods


#### OrElse``1(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}})

#### AndAlso``1(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}})

## Class: System.Linq.Expressions.StringComparisonReplacementExpressionVisitor
Expression visitor to replace string functions with the matching functions that end with a StringComparison parameter
### Methods


####Constructor

#### VisitBinary(System.Linq.Expressions.BinaryExpression)
Replace `string == string` with `string.Equals(string, StringComparison)`
    #####Parameters
    **node:** 

    ##### Return value
    

#### VisitMethodCall(System.Linq.Expressions.MethodCallExpression)
Replace `string.Xyz(string)` with `string.Xyz(string, StringComparison)`
    #####Parameters
    **input:** 

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
    #####Parameters
    **item:** 

    ##### Return value
    

#### MakeSafeArray(System.Type,System.Array)
safely create new array for a given element type.
    #####Parameters
    **type:** 

    **inputs:** 

    ##### Return value
    

#### MakeSafe(System.Type,System.Object)
Make safe will try to convert input to target type as best as possible.
    #####Parameters
    **type:** 

    **input:** 

    ##### Return value
    

#### GetShortTypeName(System.Type)
Type name with full namespace, name and assembly. version is not included
    #####Parameters
    **type:** 

    ##### Return value
    

## Class: System.Reflection.ResourceExtensions
Set of extension methods for embedded resources
### Methods


#### GetResourceStream(System.Object,System.String)
Lookup resource stream based on filename relative the scope of context
    #####Parameters
    **context:** 

    **resourceName:** 

    ##### Return value
    

#### GetResourceStream(System.Type,System.String)
Lookup resource stream based on filename relative the scope of Type
    #####Parameters
    **type:** 

    **resourceName:** 

    ##### Return value
    

#### GetResourceStream(System.Reflection.Assembly,System.String)
Lookup resource stream based on filename relative the scope of Type
    #####Parameters
    **assembly:** 

    **resourceName:** 

    ##### Return value
    

#### GetResourceAsStringAsync(System.Object,System.String)
Lookup resource content based on filename relative the scope of context
    #####Parameters
    **context:** 

    **resourceName:** 

    ##### Return value
    

#### GetResourceAsString(System.Object,System.String)
Lookup resource content based on filename relative the scope of context
    #####Parameters
    **context:** 

    **resourceName:** 

    ##### Return value
    

## Class: System.Security.Claims.ClaimsPrincipalExtensions
Extensions to manage on
### Methods


#### GetAllClaims(System.Security.Claims.ClaimsPrincipal)
Iterate all for provided
    #####Parameters
    **principal:** 

    ##### Return value
    

#### GetClaimValues(System.Security.Claims.ClaimsPrincipal,System.String[])
Get for matched on
    #####Parameters
    **principal:** 

    **claims:** 

    ##### Return value
    

#### GetClaimValue(System.Security.Claims.ClaimsPrincipal,System.String[])
Get first matched on
    #####Parameters
    **principal:** 

    **claims:** 

    ##### Return value
    

## Class: System.Security.Cryptography.Hash
Default hash of input value. Base64 encoded MD5 Hash
### Methods


#### GetHash(System.String)

## Class: System.ServiceCollectionExtensions
Suggested IOC configurations
### Methods


#### TryAllSystemExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
This will add all available extensions to the IOC container
    #####Parameters
    **services:** 

    **config:** 

    ##### Return value
    

#### TryAddSearchQueryExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared SearchQuery Extensions
    #####Parameters
    **services:** 

    ##### Return value
    

#### TrySecurityExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared security extensions
    #####Parameters
    **services:** 

    ##### Return value
    

#### TrySerializerExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared Serializer
    #####Parameters
    **services:** 

    ##### Return value
    

#### TryTemplatingExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Add support for shared Templating
    #####Parameters
    **services:** 

    **config:** 

    ##### Return value
    

#### AddAccessor``1(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Register accessor type that is scoped to as AsyncLocal
    #####Parameters
    **services:** 

    ##### Return value
    

#### AddConfiguration``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Extend configuration options
    #####Parameters
    **services:** 

    **config:** 

    ##### Return value
    

#### GetSingletonInstance``2(Microsoft.Extensions.DependencyInjection.IServiceCollection,``1@)
Get singleton instance from IOC container
    #####Parameters
    **services:** 

    **instance:** 

    ##### Return value
    

## Class: System.Text.Json.BsonIdConverter
This type converter for System.Text.Json to support BSON ObjectID to JSON safe export/import
### Methods


#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)

#### Write(System.Text.Json.Utf8JsonWriter,System.String,System.Text.Json.JsonSerializerOptions)

## Class: System.Text.Json.JsonDocumentExtensions
shared extension methods for System.Text.Json
### Methods


#### ToXmlDocument(System.Text.Json.JsonElement,System.String)
Convert System.Test.Json.JsonDocument to System.Xml.XmlDocument
    #####Parameters
    **json:** 

    **rootName:** 

    ##### Return value
    

## Class: System.Text.Templating.FileTemplateSource
Access template from file system
### Methods


#### Get(System.String)

## Class: System.Text.Templating.TemplateEngine
Generate templating engine that will try to use best match for source and provider
### Methods


####Constructor

#### ApplyAsync(System.String,System.Object,System.IO.Stream)

#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)

#### Get(System.String)

#### GetAll(System.String)