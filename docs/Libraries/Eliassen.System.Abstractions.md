# Eliassen.System.Abstractions


## Class: System.Accessors.IAccessor`1
IAccessor[T] is a type that allows for a instance to be bound to a async context
### Properties

#### Value
accessible value

## Class: System.ComponentModel.Search.FilterableAttribute
Allow tagging entity classes to enumerate filterable fields/properties.

## Class: System.ComponentModel.Search.NotFilterableAttribute
Explicitly exclude fields from filter selection.

## Class: System.ComponentModel.Search.NotSearchableAttribute
explicitly exclude properties from search
### Properties

#### TargetName
Target name required only if this is used on the class
### Methods


####Constructor

####Constructor

## Class: System.ComponentModel.Search.SearchableAttribute
include field to be searchable for "SearchTerm"
### Properties

#### TargetName
Target name required only if this is used on the class
### Methods


####Constructor

####Constructor

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
### Methods


#### ToString

## Class: System.Linq.Search.OrderDirections
Enumeration to control sort order
### Fields

#### Ascending
sort related items in ascending order
#### Descending
sort related items in descending order
#### 

#### 

#### 

#### 


## Class: System.Security.Cryptography.IHash
Simplified hash generator
### Methods


#### GetHash(System.String)
cryptographic has for input value
    #####Parameters
    **value:** value to hash

    ##### Return value
    hash input