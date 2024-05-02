# Eliassen - Complete

## Summary

This one reference add the direct Eliassen features for the Shared Framework excluding 
ASP.Net Core and Third Party Extensions.  This functionality and more is included in the 
`Eliassen.Common.Complete` library

## Usage

Adding the reference do your project as well as adding the following to your IoC container 
will enable all of the functionality from this framework.  All framework features will be 
available for use, configuration and replacement as required for your application.

### Example

```csharp
using Eliassen.Common;


//Add this after you IServiceCollection registation
        services.TryCommonExtensions();
```