# Eliassen.System.Abstractions


## Class: System.Accessors.IAccessor`1
IAccessor[T] is a type that allows for a instance to be bound to a async context
### Properties

#### Value
accessible value

## Class: System.ComponentModel.EndStateAttribute
this attribute tags valid end states for enum based state machines

## Class: System.ComponentModel.EnumValueAttribute
output enum string as this value when serialized as json
### Properties

#### Name
value to output in place of Enum.ToString() with Json Serializer

## Class: System.ComponentModel.IVersionProvider
Provides information about the version of an assembly.
### Properties

#### Title
Gets the title of the assembly.
#### Version
Gets the version of the assembly.
#### Description
Gets the description of the assembly.
#### Assembly
Gets the associated with the version information.

## Class: System.ComponentModel.Search.DefaultSortAttribute
part of default sort for entity
### Properties

#### TargetName
property name to use for mapping
#### Priority
sort column position priority
#### Order
direction to order this mapped column

## Class: System.ComponentModel.Search.FilterableAttribute
Allow tagging entity classes to enumerate filterable fields/properties.
### Properties

#### TargetName
column mapping override

## Class: System.ComponentModel.Search.IgnoreStringComparisonReplacementAttribute
exclude from string comparison replacement visitor

## Class: System.ComponentModel.Search.ISearchQueryIntercept
Provide entry point to commonly intercept and override search definitions. Example
### Methods


#### Intercept(Eliassen.System.Linq.Search.ISearchQuery)
modify or pass though search query before processing.
    #####Parameters
    **searchQuery:** 

    ##### Return value
    

## Class: System.ComponentModel.Search.NotFilterableAttribute
Specifies that a property or class should be explicitly excluded from filter selection.
### Properties

#### TargetName
Gets the target name to be excluded from filter selection.
### Methods


####Constructor
Initializes a new instance of the class with a target name.
    #####Parameters
    **targetName:** The target name to be excluded from filter selection.


####Constructor
Initializes a new instance of the class without a target name.

## Class: System.ComponentModel.Search.NotSearchableAttribute
explicitly exclude properties from search
### Properties

#### TargetName
Target name required only if this is used on the class

## Class: System.ComponentModel.Search.NotSortableAttribute
Specifies that a property or class should not be sortable.
### Properties

#### TargetName
Gets the name of the target property that should not be sortable.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **targetName:** The name of the target property that should not be sortable.


####Constructor
Initializes a new instance of the class.

## Class: System.ComponentModel.Search.SearchableAttribute
include field to be searchable for "SearchTerm"
### Properties

#### TargetName
Target name required only if this is used on the class

## Class: System.ComponentModel.Search.SearchTermDefaultAttribute
provide the ability to control how search terms are handled if not wilded carded
### Properties

#### Default
rule to use for provided search term if not quoted
### Methods


#### Intercept(Eliassen.System.Linq.Search.ISearchQuery)
use the `Default` to control pattern for searches without provided wild cards
    #####Parameters
    **searchQuery:** 

    ##### Return value
    

## Class: System.ComponentModel.Search.SearchTermDefaults
Specifies default search term options for comparison.
### Fields

#### EqualTo
Represents an equal comparison for search terms.
#### Contains
Represents a contains comparison for search terms.
#### StartsWith
Represents a starts-with comparison for search terms.
#### EndsWith
Represents an ends-with comparison for search terms.

## Class: System.Configuration.CommandParameterAttribute
Specifies that a property represents a command parameter.
### Properties

#### Short
Gets or sets the short representation of the command parameter.
#### Value
Gets or sets the value of the command parameter.
#### TypeId
Gets a unique identifier for this attribute.

## Class: System.Configuration.ConfigurationSectionAttribute
Specifies the configuration section associated with a class.
### Properties

#### ConfigurationSection
Gets the configuration section name.
#### TypeId
Gets a unique identifier for this attribute.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **configurationSection:** The configuration section name.


## Class: System.Linq.Search.FilterParameter
Filter parameter
### Properties

#### EqualTo
`Equal To`: pass in the value to match for a given property If you are using string values you may also use wild cards \*bc -&gt; Ends with \*b\* -&gt; Contains ab\* -&gt; Starts with
#### NotEqualTo
`Not Equal To`: pass in the value to match for a given property If you are using string values you may also use wild cards \*bc -&gt; Ends with \*b\* -&gt; Contains ab\* -&gt; Starts with
#### InSet
This allows for providing a set of values where the value from the queries data must match at least one of provided values
#### GreaterThan
`Greater than`
#### GreaterThanOrEqualTo
`Greater than or equal to`
#### LessThan
`Less than`
#### LessThanOrEqualTo
`Less than or equal to`

## Class: System.Linq.Search.OrderDirections
Enumeration to control sort order
### Fields

#### Ascending
sort related items in ascending order
#### Descending
sort related items in descending order

## Class: System.Reflection.EnumExtensions
Provides extension methods for working with enumerations.
### Methods


#### AsString``1(``0)
Converts an enumeration value to its associated string representation.
    #####Parameters
    **input:** The enumeration value.

    ##### Return value
    The string representation of the enumeration value.

#### ToEnum``1(System.Int32)
Converts an integer value to an enumeration value.
    #####Parameters
    **input:** The integer value.

    ##### Return value
    The corresponding enumeration value.

#### ToEnum``1(System.String)
Converts a string to an enumeration value.
    #####Parameters
    **input:** The string representation of the enumeration value.

    ##### Return value
    The corresponding enumeration value.

#### AsModel``1(``0)
Gets the enumeration model for a specific enumeration value.
    #####Parameters
    **enum:** The enumeration value.

    ##### Return value
    The enumeration model.

#### AsModels``1
Gets a collection of enumeration models for all values of a specific enumeration type.
    ##### Return value
    A collection of enumeration models.

## Class: System.ResponseModel.ICaptureResultMessage
Represents an interface for capturing and publishing result messages.
### Methods


#### Publish(Eliassen.System.ResponseModel.ResultMessage[])
Publishes the specified result messages.
    #####Parameters
    **resultMessage:** The result messages to publish.


#### Peek
Peeks at the captured result messages without removing them.
    ##### Return value
    An IReadOnlyCollection of result messages.

#### Clear
Clears the captured result messages.

#### Capture
Captures and returns the result messages, removing them from the capture.
    ##### Return value
    An IReadOnlyCollection of captured result messages.

## Class: System.ResponseModel.MessageLevels
response message level
### Fields

#### Trace
extra detailed information
#### Debug
information to assist in troubleshooting
#### Information
extra information about process
#### Warning
notifications and assumptions about processing that did not effect output
#### Error
errors that caused the system to not complete your request as you may have expected
#### Critical
information about processing that failed
#### None
unknown value

## Class: System.ResponseModel.ModelResult`1
Represents a result containing a single model.The type of the model.
### Properties

#### Data
Gets the model data.
#### Eliassen#System#ResponseModel#IModelResult#Data
Gets the model data as an object.
#### Messages
Gets or sets the collection of result messages.
### Methods


####Constructor
Initializes a new instance of the class with the specified data.
    #####Parameters
    **data:** The model data.


## Class: System.ResponseModel.QueryResult`1
Represents the result of a query operation, containing a collection of items and optional result messages.The type of items in the result.
### Properties

#### Rows
Gets the collection of items in the result.
#### Eliassen#System#ResponseModel#IQueryResult#Rows
Gets the collection of items in the result as a non-generic enumerable.
#### Messages
Gets or sets the collection of result messages associated with the query result.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **items:** The collection of items in the result.


####Constructor
Initializes a new instance of the class by wrapping another .
    #####Parameters
    **toWrap:** The query result to wrap.


####Constructor
Initializes a new instance of the class with an empty collection of items.

## Class: System.ResponseModel.ResultMessage
additional details about response
### Properties

#### Level
importance level related to response
#### Message
Simple English message about issue.
#### MessageCode
unique code that may be used to assist in translating issue
#### Context
Property or path related to this message
#### MetaData
additional properties related to response

## Class: System.Security.Claims.CommonClaims
Contains constants for common claims used in authentication.
### Fields

#### UserId
Represents the claim for user ID.
#### Culture
Represents the claim for user culture.
#### ExtendedProperties
Represents the claim for extended properties.
#### ApplicationRight
Represents the claim for application rights.
#### ObjectId
Represents the claim for object ID.
#### ObjectIdentifier
Represents the claim for object identifier.

## Class: System.Security.Cryptography.IHash
Simplified hash generator
### Methods


#### GetHash(System.String)
cryptographic has for input value
    #####Parameters
    **value:** value to hash

    ##### Return value
    hash input

## Class: System.Text.ISerializer
Interface to identify shared serialization process.
### Properties

#### ContentType
Content type supported by this serializer
### Methods


#### Serialize(System.Object,System.Type)
convert the object based on the type definition
    #####Parameters
    **obj:** object to serialize

    **type:** template model to serialize

    ##### Return value
    

#### Serialize``1(``0)
convert the object based on the type definition
    #####Parameters
    **obj:** object to serialize

    ##### Return value
    

#### SerializeAsync(System.Object,System.Type,System.IO.Stream,System.Threading.CancellationToken)
convert the object based on the type definition
    #####Parameters
    **obj:** object to serialize

    **type:** template model to serialize

    **stream:** 

    **cancellationToken:** 

    ##### Return value
    

#### SerializeAsync``1(``0,System.IO.Stream,System.Threading.CancellationToken)
convert the object based on the type definition
    #####Parameters
    **obj:** object to serialize

    **stream:** 

    **cancellationToken:** 

    ##### Return value
    

#### Deserialize``1(System.IO.Stream)
convert stream into object
    #####Parameters
    **stream:** 

    ##### Return value
    

#### Deserialize(System.IO.Stream,System.Type)
convert stream into object
    #####Parameters
    **stream:** 

    **type:** template model to deserialize

    ##### Return value
    

#### DeserializeAsync``1(System.IO.Stream,System.Threading.CancellationToken)
convert stream into object
    #####Parameters
    **stream:** 

    **cancellationToken:** 

    ##### Return value
    

#### DeserializeAsync(System.IO.Stream,System.Type,System.Threading.CancellationToken)
convert stream into object
    #####Parameters
    **stream:** 

    **type:** template model to deserialize

    **cancellationToken:** 

    ##### Return value
    

#### Deserialize``1(System.String)
convert stream into object
    #####Parameters
    **input:** 

    ##### Return value
    

#### Deserialize(System.String,System.Type)
convert stream into object
    #####Parameters
    **input:** 

    **type:** template model to deserialize

    ##### Return value
    

## Class: System.Text.Json.Serialization.IBsonSerializer
interface to identify shared BSON serialization process.

## Class: System.Text.Json.Serialization.IJsonSerializer
interface to identify shared JSON serialization process.

## Class: System.Text.Json.Serialization.JsonStringEnumConverterEx`1
A custom JSON converter for serializing and deserializing enums as strings or numbers.The enum type to convert.
### Methods


#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)
Reads the JSON representation of the enum value and converts it to the specified enum type.
    #####Parameters
    **reader:** The JSON reader.

    **typeToConvert:** The type of the object to convert.

    **options:** The serializer options.

    ##### Return value
    The deserialized enum value.

#### Write(System.Text.Json.Utf8JsonWriter,`0,System.Text.Json.JsonSerializerOptions)
Writes the JSON representation of the enum value.
    #####Parameters
    **writer:** The JSON writer.

    **value:** The enum value to serialize.

    **options:** The serializer options.


## Class: System.Text.Templating.ITemplateContext
Represents the context for a template, including information about the template and target content types, source, and priority.
### Properties

#### TemplateName
Gets the name of the template.
#### TemplateContentType
Gets the content type of the template.
#### TemplateFileExtension
Gets the file extension of the template.
#### TemplateSource
Gets the source of the template.
#### TemplateReference
Gets the reference identifier for the template.
#### OpenTemplate
Gets the function that opens the template as a stream.
#### TargetContentType
Gets the content type of the target.
#### TargetFileExtension
Gets the file extension of the target.
#### Priority
Gets the priority of the template, used to determine the order of template application.

## Class: System.Text.Templating.ITemplateEngine
Represents a template engine for generating content based on templates.
### Methods


#### Get(System.String)
Gets the template context for the specified template name.
    #####Parameters
    **templateName:** The name of the template.

    ##### Return value
    The template context for the specified template name or null if not found.

#### GetAll(System.String)
Gets all template contexts associated with the specified template name.
    #####Parameters
    **templateName:** The name of the template.

    ##### Return value
    An enumeration of all template contexts associated with the specified template name.

#### ApplyAsync(System.String,System.Object,System.IO.Stream)
Applies the specified data to the template identified by its name and writes the result to the target stream asynchronously.
    #####Parameters
    **templateName:** The name of the template.

    **data:** The data to apply to the template.

    **target:** The stream where the result will be written.

    ##### Return value
    A task representing the asynchronous operation, containing the template context for the applied template or null if not found.

#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)
Applies the specified data to the given template context and writes the result to the target stream asynchronously.
    #####Parameters
    **context:** The template context to apply.

    **data:** The data to apply to the template.

    **target:** The stream where the result will be written.

    ##### Return value
    A task representing the asynchronous operation, indicating whether the application was successful.

## Class: System.Text.Templating.ITemplateProvider
Represents a template provider that can apply templates based on a specified context.
### Methods


#### CanApply(Eliassen.System.Text.Templating.ITemplateContext)
Determines whether the template provider can apply a template based on the provided context.
    #####Parameters
    **context:** The template context.

    ##### Return value
    true if the template provider can apply the template; otherwise, false.

#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)
Applies the template associated with the specified context, using the provided data, and writes the result to the target stream asynchronously.
    #####Parameters
    **context:** The template context.

    **data:** The data to apply to the template.

    **target:** The stream where the result will be written.

    ##### Return value
    A task representing the asynchronous operation, indicating whether the application was successful.

## Class: System.Text.Xml.Serialization.IXmlSerializer
interface to identify shared XML serialization process.