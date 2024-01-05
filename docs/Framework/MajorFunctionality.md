# Eliassen - Shared Framework for .Net

## Summary

This is a collection of libraries designed to allow for faster and more consistent development using .Net 

## Major Features

### Message Queueing

Messages and business event supported is provided by the `Eliassen.MessageQueueing` libraries.  

Handlers are provided in process though an Hosting Engine extension.

#### Current Implementations

* In Process `ConcurrentQueue` - Built in
* Azure Storage Queues - Requires `Eliassen.Azure.StorageAccount`

### Text Templating

Text Templating is a native portion of the framework.  It is designed to provide a common way to 
generate simple text content. `Eliassen.System.Text.Templating`

#### Current Implementations

* XSLT 1.0 - Built in `XsltTemplateProvider`
* Handlebars.Net - Requires `Eliassen.Handlebars.Extensions`

### ASP.Net Core Extensions

These extensions include

* Common query though IQueryable<T> support as controller actions
* SwaggerGen extensions for oauth2 authentication as well as enumeration of options for querying 
* CultureInfo mapping based on request/response headers
* Application Permission filtering based on Claims authorization
* Improved OAuth/JWT configuration support

### Communications 

The communications provides a common means for sending and receiving messages between users 
and your application. `Eliassen.Communications`

Additional queue mapping provided from `Eliassen.Communications.MessageQueueing`

#### Current Implementations

* MailKit - IMAP (inbound) / SMTP (Outbound)  Requires `Eliassen.MailKit`
  * IMAP support is currently in design and is not fully supported at this time.

### MongoDB Extensions

Define a common means to support mongo collections from within .Net applications.  Also provides 
serialization and query extensions. `Eliassen.MongoDB.Extensions`

### Common Query Extension

Common query support is build into the base framework.  `Eliassen.System.Linq.Search`  This
extension also provides a common means for not only search and filter but also sorting and paging.

### MS Test Extensions

`Eliassen.TestUtilities`

## Tooling

### TextTemplating

`Eliassen.TemplateEngine.Cli`

### FixSourceLinking

`Eliassen.FixSourceLinks.Cli`

## Proposed Features

### Event Scheduler
### Permission Based Redaction