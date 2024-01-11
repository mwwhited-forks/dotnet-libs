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
* should have support for impersonate the originating ClaimsPrincipal

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

* https://eliassenps.atlassian.net/browse/NIT-12
* MailKit - IMAP (inbound) / SMTP (Outbound)  Requires `Eliassen.MailKit`
  * IMAP support is currently in design and is not fully supported at this time.
  * should have the ability to read, dispatch to queue then either delete or mark read
  * should have the ability to read more than the inbox
  * should have the ability to read filter by inbound email address
  * should have the ability to monitor multiple accounts

### MongoDB Extensions

Define a common means to support mongo collections from within .Net applications.  Also provides 
serialization and query extensions. `Eliassen.MongoDB.Extensions`

### Common Query Extension

Common query support is build into the base framework.  `Eliassen.System.Linq.Search`  This
extension also provides a common means for not only search and filter but also sorting and paging.

* want to add support for claims based predicates
* want to add support for claims based redaction/masking
* [Initiative: Data Authorization pattern](https://eliassenps.atlassian.net/browse/NIT-26)

### MS Test Extensions

`Eliassen.TestUtilities`

* current extensions only exist for easily attaching result content as attachments to the test results
* should add support to present the content back in the reports

## Tooling

### TextTemplating

`Eliassen.TemplateEngine.Cli`

* support exists for XSLT and Handlebars
* add support for T4?
* add support for razor?
* add support for custom HTML?
* add support for python?
* https://en.wikipedia.org/wiki/Template_processor
* add translation support
  * custom extensions with callbacks to allow translation a code value into a language based on a culture

### FixSourceLinking

`Eliassen.FixSourceLinks.Cli`

not needed as long as UseSourceLinks is not enabled in .runsettings for MSTest

### Software Bill of Materials

* [Initiative: Centralized location to track packages/versioning/licensing](https://eliassenps.atlassian.net/browse/NIT-25)
* https://spdx.dev/use/tools/
* https://devblogs.microsoft.com/engineering-at-microsoft/generating-software-bills-of-materials-sboms-with-spdx-at-microsoft/
* https://github.com/microsoft/sbom-tool
* https://www.howtogeek.com/devops/how-to-generate-an-sbom-with-microsofts-open-source-tool/
* https://github.com/topics/sbom-generator
* https://github.com/CycloneDX/cyclonedx-dotnet

## Proposed Features

### Event Scheduler

* assign default rules as attribute based on event generator
  * allow overriding though configuration
  * possibly allow extensions to override the schedule provider
* provide means to know last run time so the system can catch up
* add support for NCrontab but also allow other options for recurrence calculation such as RRule
  * https://github.com/atifaziz/NCrontab
  * https://icalendar.org/rrule-tool.html

### Document Management and Conversion

* [Initiative: Notifications](https://eliassenps.atlassian.net/browse/NIT-17)
* normalize blob storage
* https://github.com/okhosting/awesome-storage
* https://github.com/topics/blob-storage
* upload/download support
* restore support for transforming documents 
  * example, markdown to html, html to pdf
* add support to create/read zip files

### Resource Translation

* add support for server side translation.  key/culture => value mapping
* allow for use from within the text engine

### Communication Channels

* finish support for SMS, in application and chat
* allow chat to work with teams, skype, discord, slack...
* add twillio support for outbound email
* add the ability for "channel extensions" these would be multiple instances of the same protocol 
  but a different test of configurations.  This would for sending/receiving messages from multiple
  accounts with the same provider.

### Analytics and Health monitoring

* [Initiative: Application Analytics](https://eliassenps.atlassian.net/browse/NIT-19)
* add support for checking the status of dependent services like message queues, email servers and the like
* add context correlation support to allow flowing a correlation ID from the client to dependent services and logs
  * https://stackoverflow.com/questions/56068619/should-i-use-request-id-x-request-id-or-x-correlation-id-in-the-request-header
  * https://devcenter.heroku.com/articles/http-request-id
  * https://www.rapid7.com/blog/post/2016/12/23/the-value-of-correlation-ids/
  * https://hilton.org.uk/blog/microservices-correlation-id
  * https://stackoverflow.com/questions/25433258/what-is-the-x-request-id-http-header

### Authorization Support

* create a extension point for providing additional claims to a user account.

### Ticket Tracking and Bug Reporting

* create services to submit/check status of work items
* [Initiative: Issue Reporting / Feedback Integration](https://eliassenps.atlassian.net/browse/NIT-13)

### Chat Bots

### websocket/signalr/socket.io

## Role management/claims composition