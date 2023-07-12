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
Explicitly exclude fields from filter selection.

## Class: System.ComponentModel.Search.NotSearchableAttribute
explicitly exclude properties from search
### Properties

#### TargetName
Target name required only if this is used on the class

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

## Class: System.Security.Cryptography.IHash
Simplified hash generator
### Methods


#### GetHash(System.String)
cryptographic has for input value
    #####Parameters
    **value:** value to hash

    ##### Return value
    hash input

## Class: System.Text.Json.Serialization.IJsonSerializer
interface to identify shared JSON serialization process.

## Class: System.Text.Xml.Serialization.IXmlSerializer
interface to identify shared XML serialization process.

## Class: Dataloader.Cli.ISerializer
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
    