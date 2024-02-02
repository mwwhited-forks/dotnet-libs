# Eliassen - Communications

See [back](MajorFunctionality.md)

## Summary

The communications provides a common means for sending and receiving messages between users 
and your application. `Eliassen.Communications`

Additional queue mapping provided from `Eliassen.Communications.MessageQueueing`

## Notes

* Readme
  * [Communications](..\code\Eliassen.Communications\Readme.Communications.md)
  * [Communications.Abstractions](..\code\Eliassen.Communications.Abstractions\Readme.Communications.Abstractions.md)
  * [MailKit](..\code\Eliassen.MailKit\Readme.MailKit.md)
  * [MailKit.Hosting](..\code\Eliassen.MailKit.Hosting\Readme.MailKit.Hosting.md)
* Libraries
  * [Eliassen.Communications](..\Libraries\Eliassen.Communications.md)
  * [Eliassen.Communications.Abstractions](..\Libraries\Eliassen.Communications.Abstractions.md)
  * [Eliassen.MailKit](..\Libraries\Eliassen.MailKit.md)
  * [Eliassen.MailKit.Hosting](..\Libraries\Eliassen.MailKit.Hosting.md)

## Current Implementations

* [Initiative: Notifications](https://eliassenps.atlassian.net/browse/NIT-12)
* MailKit - IMAP (inbound) / SMTP (Outbound)  Requires `Eliassen.MailKit`
  * IMAP support is currently in design and is not fully supported at this time.
  * should have the ability to read, dispatch to queue then either delete or mark read
  * should have the ability to read more than the inbox
  * should have the ability to read filter by inbound email address
  * should have the ability to monitor multiple accounts

## Proposed Changes

* finish support for SMS, in application and chat
* allow chat to work with teams, skype, discord, slack...
* add twillio support for outbound email
* add the ability for "channel extensions" these would be multiple instances of the same protocol 
  but a different test of configurations.  This would for sending/receiving messages from multiple
  accounts with the same provider.

---

See [back](MajorFunctionality.md)