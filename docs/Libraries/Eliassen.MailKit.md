# Eliassen.MailKit


## Class: MailKit.ServiceCollectionExtensions
Extensions for adding MailKit services to the 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 

### Methods


#### TryAddMailKitExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String,System.String)
Tries to add MailKit extensions to the 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The service collection to which MailKit services will be added.
* *configuration:* The configuration.
* *smtpConfigurationSection:* The configuration section name for MailKit SMTP options.
* *imapConfigurationSection:* The configuration section name for MailKit IMAP options.




##### Return value
The modified .



## Class: MailKit.Services.IImapClientFactory
Represents a factory for creating instances of 
 *See: T:MailKit.Net.Imap.ImapClient*. 

### Methods


#### CreateAsync
Creates a new instance of 
 *See: T:MailKit.Net.Imap.ImapClient*. 


##### Return value
A task that represents the asynchronous operation and contains the created .



## Class: MailKit.Services.ImapClientFactory
Implementation of 
 *See: T:Eliassen.MailKit.Services.IImapClientFactory*for creating instances of the ImapClient class. 
Initializes a new instance of the 
 *See: T:Eliassen.MailKit.Services.ImapClientFactory*class. 

### Methods


#### Constructor
Implementation of 
 *See: T:Eliassen.MailKit.Services.IImapClientFactory*for creating instances of the ImapClient class. 


##### Parameters
* *config:* The configuration options for the MailKit Imap client.




#### CreateAsync
Creates a new instance of the ImapClient class and configures it based on the provided options. 


##### Return value
An asynchronous task that represents the creation of the ImapClient instance.



## Class: MailKit.Services.IMimeMessageFactory
Represents a factory for creating 
 *See: T:MimeKit.MimeMessage*instances from 
 *See: T:Eliassen.Communications.Models.EmailMessageModel*. 

### Methods


#### Create(Eliassen.Communications.Models.EmailMessageModel)
Creates a 
 *See: T:MimeKit.MimeMessage*from the specified 
 *See: T:Eliassen.Communications.Models.EmailMessageModel*. 


##### Parameters
* *message:* The email message model.




##### Return value
A instance.



#### ToReceived(MimeKit.MimeMessage,System.String,System.String)
Creates a 
 *See: T:Eliassen.Communications.Models.ReceivedEmailMessageModel*from the specified 
 *See: T:MimeKit.MimeMessage*. and inbound metadata such as host and mailbox path. 


##### Parameters
* *message:* 
* *server:* 
* *path:* 




##### Return value




## Class: MailKit.Services.ISmtpClientFactory
Represents a factory for creating instances of 
 *See: T:MailKit.Net.Smtp.SmtpClient*. 

### Methods


#### CreateAsync
Creates a new instance of 
 *See: T:MailKit.Net.Smtp.SmtpClient*. 


##### Return value
A task that represents the asynchronous operation and contains the created .



## Class: MailKit.Services.MailKitImapClientOptions
Represents options for configuring a MailKit IMAP client. 

### Properties

#### Host
Gets or sets the host address of the IMAP server.
#### Port
Gets or sets the port number for the IMAP server.
#### SecureSocketOption
Gets or sets the secure socket options for the IMAP connection.
#### Uri
Gets or sets the URI of the IMAP server.
#### Password
Gets or sets the password used for authentication with the IMAP server.
#### UserName
Gets or sets the username used for authentication with the IMAP server.

## Class: MailKit.Services.MailKitProvider
Implementation of 
 *See: T:Eliassen.Communications.Services.ICommunicationSender`1*for sending email messages using MailKit. 
Initializes a new instance of the 
 *See: T:Eliassen.MailKit.Services.MailKitProvider*class. 

### Methods


#### Constructor
Implementation of 
 *See: T:Eliassen.Communications.Services.ICommunicationSender`1*for sending email messages using MailKit. 


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
Implementation of 
 *See: T:Eliassen.MailKit.Services.IMimeMessageFactory*for creating MimeMessage instances for email messages. 
Initializes a new instance of the 
 *See: T:Eliassen.MailKit.Services.MimeMessageFactory*class. 

### Methods


#### Constructor
Implementation of 
 *See: T:Eliassen.MailKit.Services.IMimeMessageFactory*for creating MimeMessage instances for email messages. 


##### Parameters
* *config:* The configuration options for the MailKit SMTP client.




#### Create(Eliassen.Communications.Models.EmailMessageModel)
Creates a MimeMessage instance from the specified 
 *See: T:Eliassen.Communications.Models.EmailMessageModel*. 


##### Parameters
* *message:* The email message model containing information for creating the MimeMessage.




##### Return value
A MimeMessage instance representing the email message.



#### ToReceived(MimeKit.MimeMessage,System.String,System.String)
Creates a 
 *See: T:Eliassen.Communications.Models.ReceivedEmailMessageModel*from the specified 
 *See: T:MimeKit.MimeMessage*. and inbound metadata such as host and mailbox path. 


##### Parameters
* *message:* 
* *server:* 
* *path:* 




##### Return value




## Class: MailKit.Services.SmtpClientFactory
Implementation of 
 *See: T:Eliassen.MailKit.Services.ISmtpClientFactory*for creating instances of the SmtpClient class. 
Initializes a new instance of the 
 *See: T:Eliassen.MailKit.Services.SmtpClientFactory*class. 

### Methods


#### Constructor
Implementation of 
 *See: T:Eliassen.MailKit.Services.ISmtpClientFactory*for creating instances of the SmtpClient class. 


##### Parameters
* *config:* The configuration options for the MailKit SMTP client.




#### CreateAsync
Creates a new instance of the SmtpClient class and configures it based on the provided options. 


##### Return value
An asynchronous task that represents the creation of the SmtpClient instance.

