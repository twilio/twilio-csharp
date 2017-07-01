twilio-csharp Changelog
=======================

[2017-06-30] Version 5.5.3-alpha1
----------------------------------
- Fix Url parameters with percent encoded characters not being properly serialized before being sent to the API.
- Fix Iso8601 date time serialization not enforcing expected culture, timezone. Issue #372.
- Allow empty string `finishOnKey` Gather Twiml attribute. Thanks @barclayadam!
- Fix Enums comparison with `==` not working. Issue #376.
- Support Recording encryption. Add `EncryptionType` and `EncryptionDetails` parameters to call recordings.
- Add new usage record categories for rooms and speech recognition.

**Video**
- Filter recordings by date using the parameters `DateCreatedAfter` and `DateCreatedBefore`.
- Override the default time-to-live of a recording's media URL through the `Ttl` parameter (in seconds, default value is 3600).
- Add query parameters `SourceSid`, `Status`, `DateCreatedAfter` and `DateCreatedBefore` to the convenience method for retrieving Room recordings.

**Wireless**
- Added national and international data limits to the RatePlans resource.

**Messaging**
- Add `SynchronousValidation` property and parameter to Messaging Service.

**Hosted Numbers**
- Add `VerificationCode` parameter and property to HostedNumberOrder

[2017-06-16] Version 5.5.2-alpha1
---------------------------------
- Make url parameter optional in Play Twiml.
- Add support for reentrant paging, fetching a specific page when listing resources.
- Add Gather Twiml input attribute.
- Make url parameter of Message Redirect Twiml the xml tag value.
- Remove max page size coercion from library when listing resources.
- Add `locality` property to available phone numbers and allow filter by `inLocality` option when searching available phone numbers.
- Add `origin` parameter to incoming phone numbers.
- Support `announceUrl` and `announcUrlMethod` properties for conference participants.
- Add new usage categories.
- Alpha Changes:
    - Change Wireless usage api list key to `usage_records`
    - Add alexa support to notify

[2017-05-24] Version 5.5.1-alpha1
----------------------------------

- Add HostedNumbers preview support.
- Add Proxy preview support.
- Add BulkExports preview support.
- Rename RecordingList to RoomRecordingList.

[2017-05-22] Version 5.4.3-alpha1
----------------------------------
- Added support for video.twilio.com.
- Updated Usage Trigger enums with missing categories.
- Alpha Changes:
    - Add wireless domain.
    - Add fax domain.
    - Add sync domain.
    - Add `area_code_geomatch` to messaging `Service`.

[2017-05-08] Version 5.4.2-alpha1
--------------------------
- Set AssemblyVersion in dll correctly.
- Add new categories in Usage Trigger enums.
- Add missing Twiml Dial Conference attributes.

[2017-04-27] Version 5.4.1-alpha1
---------------------------------
- Add support for Chat V2
- Remove conference participant `Beep` and `ConferenceRecord` enums, use `String` instead (backwards incompatible).
- Add `recordingChannels`, `recordingStatusCallback`, `recordingStatusCallbackMethod`, `sipAuthUsername`, `sipAuthPassword`, `region`, `conferenceRecordingStatusCallback`, `conferenceRecordingStatusCallbackMethod` parameter support to conference participant creation.
- Update missing categories in Usage Trigger enums.
- Deprecate ConversationsGrant, use VideoGrant instead.
- Alpha Changes:
    - Add `smartEncoding` parameter to messaging Service.
    - Make `endpoint ` parameter optional for notify service bindings (backwards incompatible).
    - Add `segments` property to notify service notifications.
    - Add `logEnabled` property to notify services.
    - New Notify resources: Segment, SegmentMembership, UserBinding, User
    - Add ability to delete Wireless RatePlans
    - Add `groupingSid` parameter to Video Recordings.
    - Remove `startTime` property from Video Rooms (backwards incompatible).
    - Replace `startTimeBefore/After` filtering with `dateCreatedBefore/After` on Video Rooms (backwards incompatible).

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
