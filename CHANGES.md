twilio-csharp Changelog
=======================

[2017-04-17] Version 5.3.1-alpha1
--------------------------
- Allow moving Phone Numbers to subaccounts
- Add `SmartEncoding` to Messaging Services
- Allow deleting of Wireless `RatePlans`

[2017-04-13] Version 5.2.2-alpha1
--------------------------
- Add `validityPeriod` to Message creation
- Update VideoGrant.
    - Add `room` as preferred grant granularity.
    - Deprecate setting `configurationProfileSid` on grant.


[2017-04-01] Version 5.2.1-alpha1
--------------------------
 - Add Twilio Programmable Fax
 - Add messaging.twilio.com API
 - Add answering machine detection to Programmable Voice
 - Add channel limits to Programmable Chat
 - Update Twilio Video with recordings


[2017-03-21] Version 5.1.2-alpha1
--------------------------
 - Add `Equals` and `GetHashCode` to `StringEnum`


[2017-03-09] Version 5.1.1-alpha1
--------------------------
 - Fix bug in reading `AvailablePhoneNumbers`
 - Remove `SandboxResource`


[2017-02-24] Version 5.0.3-alpha1
--------------------------
 - Fix async/await for MVC/WPF apps


[2017-02-24] Version 5.0.2-alpha1
--------------------------
 - URL encode all parameters
 - Remove erroneous JWT header in .NET 3.5


[2017-02-21] Version 5.0.1-alpha1
--------------------------
**New Major Version**

The newest version of the `twilio-csharp` helper library!

This version brings a host of changes to update and modernize the `twilio-csharp` helper library. It is auto-generated to produce a more consistent and correct product.

- [Migration Guide](https://www.twilio.com/docs/libraries/csharp/migrating-your-csharp-dot-net-application-twilio-sdk-4x-5x)
- [Full API Documentation](https://twilio.github.io/twilio-csharp/)
- [General Documentation](https://www.twilio.com/docs/libraries/csharp)
