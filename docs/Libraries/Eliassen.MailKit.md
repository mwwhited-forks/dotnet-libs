﻿# Eliassen.MailKit


## Class: MailKit.ServiceCollectionExtensions
Extensions for adding MailKit services to the .
### Methods


#### TryAddMailKitExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Tries to add MailKit extensions to the .

##### Parameters
* *services:* The service collection to which MailKit services will be added.
* *configuration:* The configuration.
* *configurationSection:* The configuration section name for MailKit options.




##### Return value
The modified .



## Class: MailKit.Services.IMimeMessageFactory
Represents a factory for creating instances from .
### Methods


#### Create(Eliassen.Communications.Models.EmailMessageModel)
Creates a from the specified .

##### Parameters
* *message:* The email message model.




##### Return value
A instance.



## Class: MailKit.Services.ISmtpClientFactory
Represents a factory for creating instances of .
### Methods


#### Create
Creates a new instance of .

##### Return value
A task that represents the asynchronous operation and contains the created .



## Class: MailKit.Services.MailKitProvider
Implementation of for sending email messages using MailKit.
            Initializes a new instance of the  *See: T:Eliassen.MailKit.Services.MailKitProvider* class.
            
### Methods


#### Constructor
Implementation of for sending email messages using MailKit.

##### Parameters
* *email:* The factory for creating instances.
* *smtp:* The factory for creating instances.
* *log:* The logger for logging messages.




#### SendAsync(Eliassen.Communications.Models.EmailMessageModel)
Sends an email asynchronously using MailKit.

##### Parameters
* *message:* The email message to be sent.




##### Return value
A task representing the asynchronous operation, containing a reference or identifier for the sent email.



## Class: MailKit.Services.MailKitSmtpClientOptions
Represents options for configuring a MailKit SMTP client.
### Properties

#### Host
Gets or sets the host address of the SMTP server.
#### Port
Gets or sets the port number for the SMTP server.
#### SecureSocketOption
Gets or sets the secure socket options for the SMTP connection.
#### Uri
Gets or sets the URI of the SMTP server.
#### Password
Gets or sets the password used for authentication with the SMTP server.
#### UserName
Gets or sets the username used for authentication with the SMTP server.
#### DefaultFromEmailAddress
Gets or sets the default email address to use as the sender in outgoing emails.

## Class: MailKit.Services.MimeMessageFactory
Implementation of for creating MimeMessage instances for email messages.
            Initializes a new instance of the  *See: T:Eliassen.MailKit.Services.MimeMessageFactory* class.
            
### Methods


#### Constructor
Implementation of for creating MimeMessage instances for email messages.

##### Parameters
* *config:* The configuration options for the MailKit SMTP client.




#### Create(Eliassen.Communications.Models.EmailMessageModel)
Creates a MimeMessage instance from the specified .

##### Parameters
* *message:* The email message model containing information for creating the MimeMessage.




##### Return value
A MimeMessage instance representing the email message.



## Class: MailKit.Services.SmtpClientFactory
Implementation of for creating instances of the SmtpClient class.
            Initializes a new instance of the  *See: T:Eliassen.MailKit.Services.SmtpClientFactory* class.
            
### Methods


#### Constructor
Implementation of for creating instances of the SmtpClient class.

##### Parameters
* *config:* The configuration options for the MailKit SMTP client.




#### Create
Creates a new instance of the SmtpClient class and configures it based on the provided options.

##### Return value
An asynchronous task that represents the creation of the SmtpClient instance.
