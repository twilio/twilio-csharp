twilio-csharp Changelog
=======================

[2018-02-23] Version 5.9.7
---------------------------
**Api**
- Add `trim` param to Outbound Calls API

**Lookups**
- Add support for `fraud` lookup type

**Numbers**
- Initial Release

**Video**
- [composer] Add `SEQUENCE` value to available layouts, and `trim` and `reuse` params.


[2018-02-09] Version 5.9.6
---------------------------
**Api**
- Add `AnnounceUrl` and `AnnounceMethod` params for conference announce

**Chat**
- Add support to looking up user channels by identity in v1


[2018-01-30] Version 5.9.5
---------------------------
**Api**
- Add `studio-engagements` usage key

**Preview**
- Remove Studio Engagement Deletion

**Studio**
- Initial Release

**Video**
- [omit] Beta: Allow updates to `SubscribedTracks`.
- Add `SubscribedTracks`.
- Add track name to Video Recording resource
- Add Composition and Composition Media resources


[2018-01-22] Version 5.9.4
---------------------------
**Library**
- PR #407: Remove "$" String Interpolation to Support Compilation in .NET <4.6. Thanks @tjhalva!

[2018-01-22] Version 5.9.3
---------------------------
**Api**
- Add `conference_sid` property on Recordings
- Add proxy and sms usage key

**Chat**
- Make user channels accessible by identity
- Add notifications logs flag parameter

**Fax**
- Added `ttl` parameter
  `ttl` is the number of minutes a fax is considered valid.

**Preview**
- Add `call_delay`, `extension`, `verification_code`, and `verification_call_sids`.
- Add `failure_reason` to HostedNumberOrders.
- Add DependentHostedNumberOrders endpoint for AuthorizationDocuments preview API.


[2017-12-15] Version 5.9.2
---------------------------
**Api**
- Add `voip`, `national`, `shared_cost`, and `machine_to_machine` sub-resources to `/2010-04-01/Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/`
- Add programmable video keys

**Preview**
- Add `verification_type` and `verification_document_sid` to HostedNumberOrders.

**Proxy**
- Fixed typo in session status enum value

**Twiml**
- Fix Dial record property incorrectly typed as accepting TrimEnum values when it actually has its own enum of values. *(breaking change)*
- Add `priority` and `timeout` properties to Task TwiML.
- Add support for `recording_status_callback_event` for Dial verb and for Conference


[2017-12-01] Version 5.9.1
---------------------------
**Api**
- Use the correct properties for Dependent Phone Numbers of an Address *(breaking change)*
- Update Call Recordings with the correct properties

**Preview**
- Add `status` and `email` query param filters for AuthorizationDocument list endpoint

**Proxy**
- Added DELETE support to Interaction
- Standardized enum values to dash-case
- Rename Service#friendly_name to Service#unique_name

**Video**
- Remove beta flag from `media_region` and `video_codecs`

**Wireless**
- Bug fix: Changed `operator_mcc` and `operator_mnc` in `DataSessions` subresource from `integer` to `string`


[2017-11-17] Version 5.9.0
---------------------------
**Sync**
- Add TTL support for Sync objects *(breaking change)*
  - The required `data` parameter on the following actions is now optional: "Update Document", "Update Map Item", "Update List Item"
  - New actions available for updating TTL of Sync objects: "Update List", "Update Map", "Update Stream"

**Video**
- [bi] Rename `RoomParticipant` to `Participant`
- Add Recording Settings resource
- Expose EncryptionKey and MediaExternalLocation properties in Recording resource


[2017-11-10] Version 5.8.3
---------------------------
**Accounts**
- Add AWS credential type

**Preview**
- Removed `iso_country` as required field for creating a HostedNumberOrder.

**Proxy**
- Added new fields to Service: geo_match_level, number_selection_behavior, intercept_callback_url, out_of_session_callback_url


[2017-11-03] Version 5.8.2
---------------------------
**Api**
- Add programmable video keys

**Video**
- Add `Participants`


[2017-10-27] Version 5.8.1
---------------------------
**Chat**
- Add Binding resource
- Add UserBinding resource


[2017-10-20] Version 5.8.0
---------------------------
**TwiML**
- Update all TwiML resources with latest changes and parameters *(breaking change)*.
- Autogenerate TwiML for faster updates and consistency.

**Api**
- Add `address_sid` param to IncomingPhoneNumbers create and update
- Add 'fax_enabled' option for Phone Number Search


[2017-10-13] Version 5.7.2
---------------------------
**Api**
- Add `smart_encoded` param for Messages
- Add `identity_sid` param to IncomingPhoneNumbers create and update

**Preview**
- Make 'address_sid' and 'email' optional fields when creating a HostedNumberOrder
- Add AuthorizationDocuments preview API.

**Proxy**
- Initial Release

**Wireless**
- Added `ip_address` to sim resource


[2017-10-06] Version 5.7.1
---------------------------
**Preview**
- Add `acc_security` (authy-phone-verification) initial api-definitions

**Taskrouter**
- [bi] Less verbose naming of cumulative and real time statistics


[2017-09-29] Version 5.7.0
---------------------------
**Chat**
- Make member accessible through identity
- Make channel subresources accessible by channel unique name
- Set get list 'max_page_size' parameter to 100
- Add service instance webhook retry configuration
- Add media message capability
- Make `body` an optional parameter on Message creation. *(breaking change)*

**Notify**
- `data`, `apn`, `gcm`, `fcm`, `sms` parameters in `Notifications` create resource are objects instead of strings. Passing manually stringified JSON will continue to work.

**Taskrouter**
- Add new query ability by TaskChannelSid or TaskChannelUniqueName
- Move Events, Worker, Workers endpoint over to CPR
- Add new RealTime and Cumulative Statistics endpoints

**Video**
- Create should allow an array of video_codecs.
- Add video_codecs as a property of room to make it externally visible.


[2017-09-15] Version 5.6.5
---------------------------
**Api**
- Add `sip_registration` property on SIP Domains
- Add new video and market usage category keys


[2017-09-01] Version 5.6.4
---------------------------
**Sync**
- Add support for Streams

**Wireless**
- Added DataSessions sub-resource to Sims.


[2017-08-25] Version 5.6.3
---------------------------
**Library**
- Fix warning on inclusive lower bound for Newtonsoft
- Throw more specific subclasses of TwilioException when exceptions occur at the HTTP layer.
- Poperly set root cause Exception as `innerException` on HTTP client exceptions. Issue #361.
- Correct typo in HttpClient interface `MakeRequestAysnc` -> `MakeRequestAsync`.
- Add `LastRequest` and `LastResponse` to `HttpClient` Interface. Set these in bundled http clients.

**Api**
- Update `status` enum for Recordings to include 'failed'
- Add `error_code` property on Recordings

**Chat**
- Add mutable parameters for channel, members and messages

**Video**
- New `media_region` parameter when creating a room, which controls which region media will be served out of.


[2017-08-18] Version 5.6.2
---------------------------
**Api**
- Add VoiceReceiveMode {'voice', 'fax'} option to IncomingPhoneNumber UPDATE requests

**Chat**
- Add channel message media information
- Add service instance message media information

**Preview**
- Add DeployedDevices.

**Sync**
- Add support for Service Instance unique names


[2017-08-11] Version 5.6.1
---------------------------
Updated requirements for NewtonSoft and DotNet

**TwiML**
- Add missing Gather attributes

**Api**
- Add New wireless usage keys added
- Add `auto_correct_address` param for Addresses create and update
- Add ChatGrant grant and deprecate IpMessagingGrant

**Preview**
- Removed 'email' from bulk_exports configuration api [bi]. No migration plan needed because api has not been used yet.
- Add AvailableNumbers resource.

**Video**
- Add `video_codec` enum and `video_codecs` parameter, which can be set to either `VP8` or `H264` during room creation.
- Restrict recordings page size to 100


[2017-07-27] Version 5.6.0
---------------------------
This release adds Beta and Preview products to main artifact.

Previously, Beta and Preview products were only included in the alpha artifact.
They are now being included in the main artifact to ease product
discoverability and the collective operational overhead of maintaining multiple
artifacts per library.

**Api**
- Remove unused `encryption_type` property on Recordings *(breaking change)*
- Update `status` enum for Messages to include 'accepted'
- Update `AnnounceMethod` parameter naming for consistency

**Messaging**
- Fix incorrectly typed capabilities property for PhoneNumbers.

**Notify**
- Add `ToBinding` optional parameter on Notifications resource creation. Accepted values are json strings.

**Preview**
- Add `sms_application_sid` to HostedNumberOrders.
- Add `verification_attempts` to HostedNumberOrders.
- Add `status_callback_url` and `status_callback_method` to HostedNumberOrders.

**Taskrouter**
- Fully support conference functionality in reservations.


[2017-06-30] Version 5.5.2
---------------------------
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

[2017-06-16] Version 5.5.1
--------------------------
- Make url parameter optional in Play Twiml.
- Add support for reentrant paging, fetching a specific page when listing resources.
- Add Gather Twiml input attribute.
- Make url parameter of Message Redirect Twiml the xml tag value.
- Remove max page size coercion from library when listing resources.
- Add `locality` property to available phone numbers and allow filter by `inLocality` option when searching available phone numbers.
- Add `origin` parameter to incoming phone numbers.
- Support `announceUrl` and `announcUrlMethod` properties for conference participants.
- Add new usage categories.

[2017-05-22] Version 5.5.0
--------------------------
- Rename room `Recordings` resource to `RoomRecordings` to avoid class name conflict (backwards incompatible).

[2017-05-19] Version 5.4.2
--------------------------
- Added support for `video.twilio.com`.
- Updated Usage Trigger enums with missing categories.

[2017-05-08] Version 5.4.1
--------------------------
- Set AssemblyVersion in dll correctly.
- Add new categories in Usage Trigger enums.
- Add missing Twiml Dial Conference attributes.

[2017-04-27] Version 5.4.0
--------------------------
- Add support for Chat V2
- Remove conference participant `Beep` and `ConferenceRecord` enums, use `String` instead (backwards incompatible).
- Add `recordingChannels`, `recordingStatusCallback`, `recordingStatusCallbackMethod`, `sipAuthUsername`, `sipAuthPassword`, `region`, `conferenceRecordingStatusCallback`, `conferenceRecordingStatusCallbackMethod` parameter support to conference participant creation.
- Update missing categories in Usage Trigger enums.

[2017-04-17] Version 5.3.0
--------------------------
- Allow moving Phone Numbers to subaccounts

[2017-04-12] Version 5.2.1
--------------------------
- Add `validityPeriod` to Message creation
- Update VideoGrant.
    - Add `room` as preferred grant granularity.
    - Deprecate setting `configurationProfileSid` on grant.

[2017-04-01] Version 5.2.0
--------------------------
 - Add answering machine detection to Programmable Voice
 - Add channel limits to Programmable Chat

[2017-03-21] Version 5.1.1
--------------------------
 - Add `Equals` and `GetHashCode` to `StringEnum`

[2017-03-09] Version 5.1.0
--------------------------
 - Fix bug with reading `AvailablePhoneNumbers`
 - Add `accounts.twilio.com` subdomain
    - Add `PublicKeyResource`
 - Remove `SandboxResource`


[2017-02-24] Version 5.0.2
--------------------------
 - Fix async/await for MVC/WPF apps


[2017-02-24] Version 5.0.1
--------------------------
 - URL encode all parameters
 - Remove erroneous JWT header in .NET 3.5


[2017-02-21] Version 5.0.0
--------------------------
**New Major Version**

The newest version of the `twilio-csharp` helper library!

This version brings a host of changes to update and modernize the `twilio-csharp` helper library. It is auto-generated to produce a more consistent and correct product.

- [Migration Guide](https://www.twilio.com/docs/libraries/csharp/migrating-your-csharp-dot-net-application-twilio-sdk-4x-5x)
- [Full API Documentation](https://twilio.github.io/twilio-csharp/)
- [General Documentation](https://www.twilio.com/docs/libraries/csharp)
