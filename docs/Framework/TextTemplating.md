# Eliassen - Text Templating

## Summary

The text templating engine exists to provide a centralized way to transform object model text.

The engine is extensible to support multiple template providers such as Handlebars and XSLT.

## Features and Components 

### Eliassen.System.Text.Templating.ITemplateEngine

The template engine is the central component.  This allows for resolving the matched templates 
by name and performing the related transformation

### Eliassen.System.Text.Templating.ITemplateSource

Template Sources are a means to lookup/resolve templates for your application. An example template 
source is  FileTemplateSource where the template is defined in a file on the local file system. 

### Eliassen.System.Text.Templating.ITemplateProvider

Template providers are an actual means to perform a transform. Providers could be something such
as XSLT or Handlebars.

### Eliassen.System.Text.Templating.IFileType

File types are a simple registration to help mapping between content types and file extensions as 
well as additional metadata such as "Is Template"

