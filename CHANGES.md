twilio-csharp Changelog
=======================

[2025-05-05] Version 7.11.0
---------------------------
**Library - Chore**
- [PR #786](https://github.com/twilio/twilio-csharp/pull/786): fix .nupkg version. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!
- [PR #785](https://github.com/twilio/twilio-csharp/pull/785): add correct .nupkg name to push signed package. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Api**
- Add `response_key` for `Usage Triggers` fetch endpoint.

**Flex**
- Add Update Interaction API
- Adding `webhook_ttid` as optional parameter in Interactions API

**Serverless**
- Add node22 as a valid Build runtime
- Add node20 as a valid Build runtime

**Video**
- removed `transcribe_participants_on_connect` and `transcriptions_configuration` from the room resource **(breaking change)**
- Added `transcribe_participants_on_connect` and `transcriptions_configuration` to the room resource


[2025-04-07] Version 7.10.0
---------------------------
**Library - Feature**
- [PR #660](https://github.com/twilio/twilio-csharp/pull/660): Optimize request validator + make thread safe (backwards compatible). Thanks to [@Swimburger](https://github.com/Swimburger)!

**Library - Chore**
- [PR #783](https://github.com/twilio/twilio-csharp/pull/783): added patch method support. Thanks to [@sbansla](https://github.com/sbansla)!

**Studio**
- Add documentation for parent_step_sid field in Step resource


[2025-03-20] Version 7.9.1
--------------------------
**Accounts**
- Update Safelist API docs as part of prefix supoort

**Flex**
- Removing `first_name`, `last_name`, and `friendly_name` from the Flex User API

**Messaging**
- Add missing tests under transaction/phone_numbers and transaction/short_code


[2025-03-11] Version 7.9.0
--------------------------
**Api**
- Add the missing `emergency_enabled` field for `Address Service` endpoints

**Messaging**
- Add missing enums for A2P and TF

**Numbers**
- add missing enum values to hosted_number_order_status

**Twiml**
- Convert Twiml Attribute `speechModel` of type enum to string **(breaking change)**


[2025-02-20] Version 7.8.5
--------------------------
**Library - Chore**
- [PR #779](https://github.com/twilio/twilio-csharp/pull/779): upgraded jwt. Thanks to [@sbansla](https://github.com/sbansla)!
- [PR #776](https://github.com/twilio/twilio-csharp/pull/776): convert pageSize from int to long. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Flex**
- Adding Digital Transfers APIs under v1/Interactions

**Numbers**
- Convert webhook_type to ienum type in v1/Porting/Configuration/Webhook/{webhook_type}

**Trusthub**
- Changing TrustHub SupportingDocument status enum from lowercase to uppercase since kyc-orch returns status capitalized and rest proxy requires strict casing


[2025-02-11] Version 7.8.4
--------------------------
**Api**
- Change downstream url and change media type for file `base/api/v2010/validation_request.json`.

**Intelligence**
- Add json_results for Generative JSON operator results

**Messaging**
- Add DestinationAlphaSender API to support Country-Specific Alpha Senders

**Video**
- Change codec type from enum to case-insensitive enum in recording and room_recording apis


[2025-01-28] Version 7.8.3
--------------------------
**Library - Chore**
- [PR #773](https://github.com/twilio/twilio-csharp/pull/773): added bug report issue template. Thanks to [@sbansla](https://github.com/sbansla)!

**Api**
- Add open-api file tag to `conference/call recordings` and `recording_transcriptions`.

**Events**
- Add support for subaccount subscriptions (beta)

**Insights**
- add new region to conference APIs

**Lookups**
- Add new `parnter_sub_id` query parameter to the lookup request


[2025-01-13] Version 7.8.2
--------------------------
**Messaging**
- Adds validity period Default value in service resource documentation


[2025-01-09] Version 7.8.1
--------------------------
**Numbers**
- Change beta feature flag to use v2/BulkHostedNumberOrders


[2024-12-05] Version 7.8.0
--------------------------
**Library - Fix**
- [PR #770](https://github.com/twilio/twilio-csharp/pull/770): Update TwilioRestClient.cs to add overloaded method in rest client. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Library - Feature**
- [PR #767](https://github.com/twilio/twilio-csharp/pull/767): Adding test cases for public oauth uptake. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Api**
- Add optional parameter `intelligence_service` to `transcription`
- Updated `phone_number_sid` to be populated for sip trunking terminating calls.

**Numbers**
- Add Update Hosted Number Order V2 API endpoint
- Update Port in docs

**Twiml**
- Add optional parameter `intelligence_service` to `<Transcription>`
- Add support for new `<ConversationRelay>` and `<Assistant>` noun
- Add `events` attribute to `<Dial>` verb


[2024-11-15] Version 7.7.0
--------------------------
**Library - Feature**
- [PR #769](https://github.com/twilio/twilio-csharp/pull/769): Adding example for using public OAuth. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Api**
- Added `ivr-virtual-agent-custom-voices` and `ivr-virtual-agent-genai` to `usage_record` API.
- Add open-api file tag to realtime_transcriptions

**Taskrouter**
- Add `api-tag` property to workers reservation
- Add `api-tag` property to task reservation


[2024-10-24] Version 7.6.0
--------------------------
**Library - Feature**
- [PR #765](https://github.com/twilio/twilio-csharp/pull/765): Updating documents and examples for Public OAuth feature uptake. Thanks to [@AsabuHere](https://github.com/AsabuHere)!
- [PR #764](https://github.com/twilio/twilio-csharp/pull/764): Modfiying cluster tests for public OAuth in C#. Thanks to [@AsabuHere](https://github.com/AsabuHere)!
- [PR #762](https://github.com/twilio/twilio-csharp/pull/762): Public OAuth uptake for C# libraries. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Conversations**
- Expose ConversationWithParticipants resource that allows creating a conversation with participants


[2024-10-17] Version 7.5.1
--------------------------
**Api**
- Add response key `country` to fetch AvailablePhoneNumber resource by specific country.

**Messaging**
- Make library and doc public for requestManagedCert Endpoint


[2024-10-03] Version 7.5.0
--------------------------
**Library - Feature**
- [PR #760](https://github.com/twilio/twilio-csharp/pull/760): Merging cluster tests for orgs api. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Messaging**
- Add A2P external campaign CnpMigration flag

**Numbers**
- Add address sid to portability API

**Verify**
- Add `SnaClientToken` optional parameter on Verification check.
- Add `EnableSnaClientToken` optional parameter for Verification creation.


[2024-09-25] Version 7.4.0
--------------------------
**Library - Feature**
- [PR #759](https://github.com/twilio/twilio-csharp/pull/759): Adding helper libraries for organization api and support for bearer token auth and no auth rest calls. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Accounts**
- Update docs and mounts.
- Change library visibility to public
- Enable consent and contact bulk upsert APIs in prod.

**Serverless**
- Add is_plugin parameter in deployments api to check if it is plugins deployment


[2024-09-18] Version 7.3.1
--------------------------
**Intelligence**
- Remove public from operator_type
- Update operator_type to include general-availablity and deprecated

**Numbers**
- Remove beta flag for bundle clone API


[2024-09-05] Version 7.3.0
--------------------------
**Iam**
- updated library_visibility public for new public apikeys

**Numbers**
- Add new field in Error Codes for Regulatory Compliance.
- Change typing of Port In Request date_created field to date_time instead of date **(breaking change)**


[2024-08-26] Version 7.2.3
--------------------------
**Library - Fix**
- [PR #752](https://github.com/twilio/twilio-csharp/pull/752): Update Domain.cs to remove orgs api entry. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Api**
- Update documentation of `error_code` and `error_message` on the Message resource.
- Remove generic parameters from `transcription` resource
- Added public documentation for Payload Data retrieval API

**Flex**
- Adding update Flex User api

**Insights**
- Added 'branded', 'business_profile' and 'voice_integrity' fields in List Call Summary

**Intelligence**
- Add `words` array information to the Sentences v2 entity.
- Add `X-Rate-Limit-Limit`, `X-Rate-Limit-Remaining`, and `X-Rate-Limit-Config` headers for Operator Results.
- Change the path parameter when fetching an `/OperatorType/{}` from `sid<EY>` to `string` to support searching by SID or by name
- Add `X-Rate-Limit-Limit`, `X-Rate-Limit-Remaining`, and `X-Rate-Limit-Config` headers for Transcript and Service endpoints.

**Messaging**
- Adds two new channel senders api to add/remove channel senders to/from a messaging service
- Extend ERC api to accept an optional attribute in request body to indicate CNP migration for an ERC

**Numbers**
- Modify visibility to public in bundle clone API
- Add `port_date` field to Port In Request and Port In Phone Numbers Fetch APIs
- Change properties docs for port in phone numbers api
- Add is_test body param to the Bundle Create API
- Change properties docs for port in api

**Trusthub**
- Add new field in themeSetId in compliance_inquiry.

**Verify**
- Update `custom_code_enabled` description on verification docs


[2024-07-02] Version 7.2.2
--------------------------
**Intelligence**
- Deprecate account flag api.twilio-intelligence.v2


[2024-06-27] Version 7.2.1
--------------------------
**Api**
- Add `transcription` resource
- Add beta feature request managed cert

**Flex**
- Changed mount name for flex_team v2 api

**Intelligence**
- Add `X-Rate-Limit-Limit`, `X-Rate-Limit-Remaining`, and `X-Rate-Limit-Config` as Response Headers to Operator resources

**Numbers**
- Added include_constraints query parameter to the Regulations API

**Twiml**
- Add support for `<Transcription>` noun


[2024-06-18] Version 7.2.0
--------------------------
**Events**
- Add `status` and `documentation_url` to Event Types

**Lookups**
- Removed unused `fraud` lookups in V1 only to facilitate rest proxy migration

**Numbers**
- Add date_created field to the Get Port In Request API
- Rename the `status_last_time_updated_timestamp` field to `last_updated` in the Get Port In Phone Number API **(breaking change)**
- Add Rejection reason and rejection reason code to the Get Port In Phone Number API
- Remove the carrier information from the Portability API

**Proxy**
- Change property `type` from enum to ienum

**Trusthub**
- Add skipMessagingUseCase field in compliance_tollfree_inquiry.


[2024-06-06] Version 7.1.1
--------------------------
**Library - Fix**
- [PR #748](https://github.com/twilio/twilio-csharp/pull/748): Adding TaskRouterGrant file. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Api**
- Mark MaxPrice as obsolete

**Lookups**
- Update examples for `phone_number_quality_score`

**Messaging**
- List tollfree verifications on parent account and all sub-accounts


[2024-05-24] Version 7.1.0
--------------------------
**Library - Docs**
- [PR #746](https://github.com/twilio/twilio-csharp/pull/746): adding readme to nuget. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Library - Fix**
- [PR #744](https://github.com/twilio/twilio-csharp/pull/744): updating jwt version. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Api**
- Add ie1 as supported region for UserDefinedMessage and UserDefinedMessageSubscription.

**Flex**
- Adding validated field to `plugin_versions`
- Corrected the data type for `runtime_domain`, `call_recording_webhook_url`, `crm_callback_url`, `crm_fallback_url`, `flex_url` in Flex Configuration
- Making `routing` optional in Create Interactions endpoint

**Intelligence**
- Expose operator authoring apis to public visibility
- Deleted `language_code` parameter from updating service in v2 **(breaking change)**
- Add read_only_attached_operator_sids to v2 services

**Numbers**
- Add API endpoint for GET Porting Webhook Configurations By Account SID
- Remove bulk portability api under version `/v1`. **(breaking change)**
- Removed porting_port_in_fetch.json files and move the content into porting_port_in.json files
- Add API endpoint to deleting Webhook Configurations
- Add Get Phone Number by Port in request SID and Phone Number SID api
- Add Create Porting webhook configuration API
- Added bundle_sid and losing_carrier_information fields to Create PortInRequest api to support Japan porting

**Taskrouter**
- Add back `routing_target` property to tasks
- Add back `ignore_capacity` property to tasks
- Removing `routing_target` property to tasks due to revert
- Removing `ignore_capacity` property to tasks due to revert
- Add `routing_target` property to tasks
- Add `ignore_capacity` property to tasks

**Trusthub**
- Add new field errors to bundle as part of public API response in customer_profile.json and trust_product.json **(breaking change)**
- Add themeSetId field in compliance_tollfree_inquiry.

**Verify**
- Update `friendly_name` description on service docs


[2024-04-18] Version 7.0.5
--------------------------
**Flex**
- Add header `ui_version` to `web_channels` API

**Messaging**
- Redeploy after failed pipeline

**Numbers**
- Add Delete Port In request phone number api and Add Delete Port In request api


[2024-04-04] Version 7.0.4
--------------------------
**Api**
- Correct conference filtering by date_created and date_updated documentation, clarifying that times are UTC.

**Flex**
- Remove optional parameter from `plugins` and it to `plugin_versions`

**Lookups**
- Add new `pre_fill` package to the lookup response

**Messaging**
- Cleanup api.messaging.next-gen from Messaging Services endpoints
- Readd Sending-Window after fixing test failure

**Verify**
- Add `whatsapp.msg_service_sid` and `whatsapp.from` parameters to create, update, get and list of services endpoints

**Voice**
- Correct conference filtering by date_created and date_updated documentation, clarifying that times are UTC.

**Twiml**
- Add new `token_type` value `payment-method` for `Pay` verb


[2024-04-01] Version 7.0.3
--------------------------
**Library - Chore**
- [PR #731](https://github.com/twilio/twilio-csharp/pull/731): Remove deprecated Autopilot references. Thanks to [@alejandroortizmartin](https://github.com/alejandroortizmartin)!

**Api**
- Add property `queue_time` to conference participant resource
- Update RiskCheck documentation
- Correct call filtering by start and end time documentation, clarifying that times are UTC.

**Flex**
- Adding optional parameter to `plugins`

**Media**
- Remove API: MediaProcessor

**Messaging**
- Remove Sending-Window due to test failure
- Add Sending-Window as a response property to Messaging Services, gated by a beta feature flag

**Numbers**
- Correct valid_until_date field to be visible in Bundles resource
- Adding port_in_status field to the Port In resource and phone_number_status and sid fields to the Port In Phone Number resource

**Oauth**
- Modified token endpoint response
- Added refresh_token and scope as optional parameter to token endpoint

**Trusthub**
- Add update inquiry endpoint in compliance_registration.
- Add new field in themeSetId in compliance_registration.

**Voice**
- Correct call filtering by start and end time documentation, clarifying that times are UTC.

**Twiml**
- Add support for new Google voices (Q1 2024) for `Say` verb - gu-IN voices
- Add support for new Amazon Polly and Google voices (Q1 2024) for `Say` verb - Niamh (en-IE) and Sofie (da-DK) voices


[2024-03-14] Version 7.0.2
--------------------------
**Oauth**
- Add new APIs for vendor authorize and token endpoints


[2024-03-12] Version 7.0.1
--------------------------
**Library - Fix**
- [PR #738](https://github.com/twilio/twilio-csharp/pull/738): adding support for net35 net462 and netstandard2.1. Thanks to [@sbansla](https://github.com/sbansla)!

**Library - Chore**
- [PR #735](https://github.com/twilio/twilio-csharp/pull/735): skipping duplicate nuget push. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Api**
- Correct precedence documentation for application_sid vs status_callback in message creation
- Mark MaxPrice as deprecated

**Flex**
- Making `plugins` visibility to public

**Messaging**
- Add new `errors` attribute to the Brand Registration resource.
- Mark `brand_feedback` attribute as deprecated.
- Mark `failure_reason` attribute as deprecated.
- The new `errors` attribute is expected to provide additional information about Brand registration failures and feedback (if any has been provided by The Campaign Registry). Consumers should use this attribute instead of `brand_feedback` and `failure_reason`.

**Numbers**
- Correcting mount_name for porting port in fetch API

**Trusthub**
- Add new field in statusCallbackUrl in compliance_registration.
- Add new field in isvRegisteringForSelfOrTenant in compliance_registration.

**Twiml**
- Expanded description of Action parameter for Message verb


[2024-02-27] Version 7.0.0
--------------------------
**Note:** This release contains breaking changes, check our [upgrade guide](./UPGRADE.md#2024-02-XX-6xx-to-7xx) for detailed migration notes.

**Library - Chore**
- [PR #730](https://github.com/twilio/twilio-csharp/pull/730): add VersionSuffix to csproj file. Thanks to [@sbansla](https://github.com/sbansla)!
- [PR #727](https://github.com/twilio/twilio-csharp/pull/727): cluster tests enabled. Thanks to [@sbansla](https://github.com/sbansla)!
- [PR #725](https://github.com/twilio/twilio-csharp/pull/725): corrected repo name in code-signing workflow. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!
- [PR #722](https://github.com/twilio/twilio-csharp/pull/722): corrected nuget push command. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Library - Feature**
- [PR #728](https://github.com/twilio/twilio-csharp/pull/728): MVR Ready. Thanks to [@sbansla](https://github.com/sbansla)! **(breaking change)**

**Api**
- remove feedback and feedback summary from call resource

**Flex**
- Adding `routing_properties` to Interactions Channels Participant

**Lookups**
- Add new `line_status` package to the lookup response
- Remove `live_activity` package from the lookup response **(breaking change)**

**Messaging**
- Add tollfree multiple rejection reasons response array

**Trusthub**
- Add ENUM for businessRegistrationAuthority in compliance_registration. **(breaking change)**
- Add new field in isIsvEmbed in compliance_registration.
- Add additional optional fields in compliance_registration for Individual business type.

**Twiml**
- Add support for new Amazon Polly and Google voices (Q1 2024) for `Say` verb


[2024-02-09] Version 6.18.0
---------------------------
**Library - Chore**
- [PR #718](https://github.com/twilio/twilio-csharp/pull/718): added code-signing-workflow. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!
- [PR #719](https://github.com/twilio/twilio-csharp/pull/719): disable cluster test. Thanks to [@sbansla](https://github.com/sbansla)!
- [PR #717](https://github.com/twilio/twilio-csharp/pull/717): setup java17 in test workflow. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Api**
- Updated service base url for connect apps and authorized connect apps APIs **(breaking change)**
- Update documentation to reflect RiskCheck GA
- Added optional parameter `CallToken` for create participant api

**Events**
- Marked as GA

**Flex**
- Adding `flex_instance_sid` to Flex Configuration
- Adding `provisioning_status` for Email Manager
- Adding `offline_config` to Flex Configuration

**Insights**
- add flag to restrict access to unapid customers
- decommission voice-qualitystats-endpoint role

**Intelligence**
- Add text-generation operator (for example conversation summary) results to existing OperatorResults collection.

**Lookups**
- Remove `carrier` field from `sms_pumping_risk` and leave `carrier_risk_category` **(breaking change)**
- Remove carrier information from call forwarding package **(breaking change)**

**Messaging**
- Add update instance endpoints to us_app_to_person api
- Add tollfree edit_allowed and edit_reason fields
- Update Phone Number, Short Code, Alpha Sender, US A2P and Channel Sender documentation
- Add DELETE support to Tollfree Verification resource

**Numbers**
- Add Get Port In request api

**Push**
- Migrated to new Push API V4 with Resilient Notification Delivery.

**Serverless**
- Add node18 as a valid Build runtime

**Taskrouter**
- Add `jitter_buffer_size` param in update reservation
- Add container attribute to task_queue_bulk_real_time_statistics endpoint
- Remove beta_feature check on task_queue_bulk_real_time_statistics endpoint

**Trusthub**
- Add optional field NotificationEmail to the POST /v1/ComplianceInquiries/Customers/Initialize API
- Add additional optional fields in compliance_tollfree_inquiry.json
- Rename did to tollfree_phone_number in compliance_tollfree_inquiry.json
- Add new optional field notification_email to compliance_tollfree_inquiry.json

**Verify**
- `Tags` property added again to Public Docs **(breaking change)**
- Remove `Tags` from Public Docs **(breaking change)**
- Add `VerifyEventSubscriptionEnabled` parameter to service create and update endpoints.
- Add `Tags` optional parameter on Verification creation.
- Update Verify TOTP maturity to GA.


[2024-01-25] Version 6.17.0
---------------------------
**Oauth**
- updated openid discovery endpoint uri **(breaking change)**
- Added device code authorization endpoint
- added oauth JWKS endpoint
- Get userinfo resource
- OpenID discovery resource
- Add new API for token endpoint


[2024-01-14] Version 6.16.1
---------------------------
**Library - Fix**
- [PR #712](https://github.com/twilio/twilio-csharp/pull/712): pin sonarscanner version. Thanks to [@shrutiburman](https://github.com/shrutiburman)!

**Push**
- Migrated to new Push API V4 with Resilient Notification Delivery.


[2023-12-14] Version 6.16.0
---------------------------
**Api**
- Updated service base url for connect apps and authorized connect apps APIs **(breaking change)**

**Events**
- Marked as GA

**Insights**
- decommission voice-qualitystats-endpoint role

**Numbers**
- Add Get Port In request api

**Taskrouter**
- Add `jitter_buffer_size` param in update reservation

**Trusthub**
- Add additional optional fields in compliance_tollfree_inquiry.json

**Verify**
- Remove `Tags` from Public Docs **(breaking change)**


[2023-12-05] Version 6.15.2
---------------------------
**Verify**
- Add `VerifyEventSubscriptionEnabled` parameter to service create and update endpoints.


[2023-11-17] Version 6.15.1
---------------------------
**Api**
- Update documentation to reflect RiskCheck GA

**Flex**
- Adding `provisioning_status` for Email Manager

**Intelligence**
- Add text-generation operator (for example conversation summary) results to existing OperatorResults collection.

**Messaging**
- Add tollfree edit_allowed and edit_reason fields
- Update Phone Number, Short Code, Alpha Sender, US A2P and Channel Sender documentation
- Add DELETE support to Tollfree Verification resource

**Serverless**
- Add node18 as a valid Build runtime

**Taskrouter**
- Add container attribute to task_queue_bulk_real_time_statistics endpoint

**Trusthub**
- Rename did to tollfree_phone_number in compliance_tollfree_inquiry.json
- Add new optional field notification_email to compliance_tollfree_inquiry.json

**Verify**
- Add `Tags` optional parameter on Verification creation.
- Update Verify TOTP maturity to GA.


[2023-10-19] Version 6.15.0
---------------------------
**Accounts**
- Updated Safelist metadata to correct the docs.
- Add Global SafeList API changes

**Api**
- Added optional parameter `CallToken` for create participant api

**Flex**
- Adding `offline_config` to Flex Configuration

**Intelligence**
- Deleted `redacted` parameter from fetching transcript in v2 **(breaking change)**

**Lookups**
- Add new `phone_number_quality_score` package to the lookup response
- Remove `disposable_phone_number_risk` package **(breaking change)**

**Messaging**
- Update US App To Person documentation with current `message_samples` requirements

**Taskrouter**
- Remove beta_feature check on task_queue_bulk_real_time_statistics endpoint
- Add `virtual_start_time` property to tasks
- Updating `task_queue_data` format from `map` to `array` in the response of bulk get endpoint of TaskQueue Real Time Statistics API **(breaking change)**


[2023-10-05] Version 6.14.1
---------------------------
**Library - Fix**
- [PR #705](https://github.com/twilio/twilio-csharp/pull/705): Update method comments to reflect new security testing method. Thanks to [@AsabuHere](https://github.com/AsabuHere)!
- [PR #704](https://github.com/twilio/twilio-csharp/pull/704): [C# helper library] Changes in validate ssl certificate method with new url and port. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Library - Chore**
- [PR #700](https://github.com/twilio/twilio-csharp/pull/700): twilio help changes. Thanks to [@kridai](https://github.com/kridai)!

**Lookups**
- Add test api support for Lookup v2


[2023-09-21] Version 6.14.0
---------------------------
**Library - Chore**
- [PR #699](https://github.com/twilio/twilio-csharp/pull/699): removing override from getparams. Thanks to [@sbansla](https://github.com/sbansla)!

**Library - Fix**
- [PR #695](https://github.com/twilio/twilio-csharp/pull/695): Added contentType and removed unused abstract function GetParam. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Library - Feature**
- [PR #693](https://github.com/twilio/twilio-csharp/pull/693): Added Enum file for contentType. Thanks to [@tiwarishubham635](https://github.com/tiwarishubham635)!

**Conversations**
- Enable conversation email bindings, email address configurations and email message subjects

**Flex**
- Adding `console_errors_included` to Flex Configuration field `debugger_integrations`
- Introducing new channel status as `inactive` in modify channel endpoint for leave functionality **(breaking change)**
- Adding `citrix_voice_vdi` to Flex Configuration

**Taskrouter**
- Add Update Queues, Workers, Workflow Real Time Statistics API to flex-rt-data-api-v2 endpoint
- Add Update Workspace Real Time Statistics API to flex-rt-data-api-v2 endpoint


[2023-09-07] Version 6.13.0
---------------------------
**Library - Fix**
- [PR #687](https://github.com/twilio/twilio-csharp/pull/687): Update dotnet version. Thanks to [@kridai](https://github.com/kridai)!

**Api**
- Make message tagging parameters public **(breaking change)**

**Flex**
- Adding `agent_conv_end_methods` to Flex Configuration

**Messaging**
- Mark Mesasging Services fallback_to_long_code feature obsolete

**Numbers**
- Add Create Port In request api
- Renaming sid for bulk_hosting_sid and remove account_sid response field in numbers/v2/BulkHostedNumberOrders **(breaking change)**

**Pricing**
- gate resources behind a beta_feature


[2023-08-24] Version 6.12.0
---------------------------
**Api**
- Add new property `RiskCheck` for SMS pumping protection feature only (public beta to be available soon): Include this parameter with a value of `disable` to skip any kind of risk check on the respective message request

**Flex**
- Changing `sid<UO>` path param to `sid<UT>` in interaction channel participant update endpoint **(breaking change)**

**Messaging**
- Add Channel Sender api
- Fixing country code docs and removing Zipwhip references

**Numbers**
- Request status changed in numbers/v2/BulkHostedNumberOrders **(breaking change)**
- Add bulk hosting orders API under version `/v2


[2023-08-10] Version 6.11.0
---------------------------
**Insights**
- Normalize annotations parameters in list summary api to be prefixed

**Numbers**
- Change Bulk_hosted_sid from BHR to BH prefix in HNO and dependent under version `/v2` API's. **(breaking change)**
- Added parameter target_account_sid to portability and account_sid to response body

**Verify**
- Remove beta feature flag to list attempts API.
- Remove beta feature flag to verifications summary attempts API.


[2023-07-27] Version 6.10.1
---------------------------
**Api**
- Added `voice-intelligence`, `voice-intelligence-transcription` and `voice-intelligence-operators` to `usage_record` API.
- Added `tts-google` to `usage_record` API.

**Lookups**
- Add new `disposable_phone_number_risk` package to the lookup response

**Verify**
- Documentation of list attempts API was improved by correcting `date_created_after` and `date_created_before` expected date format.
- Documentation was improved by correcting `date_created_after` and `date_created_before` expected date format parameter on attempts summary API.
- Documentation was improved by adding `WHATSAPP` as optional valid parameter on attempts summary API.

**Twiml**
- Added support for he-il inside of ssm_lang.json that was missing
- Added support for he-il language in say.json that was missing
- Add `statusCallback` and `statusCallbackMethod` attributes to `<Siprec>`.


[2023-07-13] Version 6.10.0
---------------------------
**Flex**
- Adding `interaction_context_sid` as optional parameter in Interactions API

**Messaging**
- Making visiblity public for tollfree_verification API

**Numbers**
- Remove Sms capability property from HNO creation under version `/v2` of HNO API. **(breaking change)**
- Update required properties in LOA creation under version `/v2` of Authorization document API. **(breaking change)**

**Taskrouter**
- Add api to fetch task queue statistics for multiple TaskQueues

**Verify**
- Add `RiskCheck` optional parameter on Verification creation.

**Twiml**
- Add Google Voices and languages


[2023-06-28] Version 6.9.0
--------------------------
**Lookups**
- Add `reassigned_number` package to the lookup response

**Numbers**
- Add hosted_number_order under version `/v2`.
- Update properties in Porting and Bulk Porting APIs. **(breaking change)**
- Added bulk Portability API under version `/v1`.
- Added Portability API under version `/v1`.


[2023-06-15] Version 6.8.0
--------------------------
**Api**
- Added `content_sid` as conditional parameter
- Removed `content_sid` as optional field **(breaking change)**

**Insights**
- Added `annotation` to list summary output


[2023-06-01] Version 6.7.0
--------------------------
**Library - Fix**
- [PR #680](https://github.com/twilio/twilio-csharp/pull/680): revert the commit Use IEnumerable<T> instead of List<T> for TwiML enums via PR (#671). Thanks to [@AsabuHere](https://github.com/AsabuHere)!
- [PR #672](https://github.com/twilio/twilio-csharp/pull/672): Add `ToString()` override to TwiML class. Thanks to [@Swimburger](https://github.com/Swimburger)!

**Library - Feature**
- [PR #671](https://github.com/twilio/twilio-csharp/pull/671): Use IEnumerable<T> instead of List<T> for TwiML enums. Thanks to [@Swimburger](https://github.com/Swimburger)!

**Api**
- Add `Trim` to create Conference Participant API

**Intelligence**
- First public beta release for Voice Intelligence APIs with client libraries

**Messaging**
- Add new `errors` attribute to us_app_to_person resource. This attribute will provide additional information about campaign registration errors.


[2023-05-18] Version 6.6.1
--------------------------
**Conversations**
- Added  `AddressCountry` parameter to Address Configuration endpoint, to support regional short code addresses
- Added query parameters `start_date`, `end_date` and `state` in list Conversations resource for filtering

**Insights**
- Added annotations parameters to list summary api

**Messaging**
- Add GET domainByMessagingService endpoint to linkShortening service
- Add `disable_https` to link shortening domain_config properties

**Numbers**
- Add bulk_eligibility api under version `/v1`.


[2023-05-04] Version 6.6.0
--------------------------
**Conversations**
- Remove `start_date`, `end_date` and `state` query parameters from list operation on Conversations resource **(breaking change)**

**Twiml**
- Add support for new Amazon Polly voices (Q1 2023) for `Say` verb


[2023-04-19] Version 6.5.0
--------------------------
**Library - Docs**
- [PR #679](https://github.com/twilio/twilio-csharp/pull/679): consolidate. Thanks to [@stern-shawn](https://github.com/stern-shawn)!

**Messaging**
- Remove `messaging_service_sids` and `messaging_service_sid_action` from domain config endpoint **(breaking change)**
- Add error_code and rejection_reason properties to tollfree verification API response

**Numbers**
- Added the new Eligibility API under version `/v1`.


[2023-04-05] Version 6.4.0
--------------------------
**Library - Chore**
- [PR #675](https://github.com/twilio/twilio-csharp/pull/675): Add code signing certificate hash to secrets and decode it for use. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Library - Fix**
- [PR #674](https://github.com/twilio/twilio-csharp/pull/674): Adding timestamper url for nuget package signing. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Conversations**
- Expose query parameters `start_date`, `end_date` and `state` in list operation on Conversations resource for sorting and filtering

**Insights**
- Added answered by filter in Call Summaries

**Lookups**
- Remove `disposable_phone_number_risk` package **(breaking change)**

**Messaging**
- Add support for `SOLE_PROPRIETOR` brand type and `SOLE_PROPRIETOR` campaign use case.
- New Sole Proprietor Brands should be created with `SOLE_PROPRIETOR` brand type. Brand registration requests with `STARTER` brand type will be rejected.
- New Sole Proprietor Campaigns should be created with `SOLE_PROPRIETOR` campaign use case. Campaign registration requests with `STARTER` campaign use case will be rejected.
- Add Brand Registrations OTP API


[2023-03-22] Version 6.3.0
--------------------------
**Library - Chore**
- [PR #673](https://github.com/twilio/twilio-csharp/pull/673): Add step to sign nuget packages before publishing. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Api**
- Revert Corrected the data type for `friendly_name` in Available Phone Number Local, Mobile and TollFree resources
- Corrected the data type for `friendly_name` in Available Phone Number Local, Mobile and TollFree resources **(breaking change)**

**Messaging**
- Add `linkshortening_messaging_service` resource
- Add new endpoint for GetDomainConfigByMessagingServiceSid
- Remove `validated` parameter and add `cert_in_validation` parameter to Link Shortening API **(breaking change)**


[2023-03-09] Version 6.2.5
--------------------------
**Api**
- Add new categories for whatsapp template

**Lookups**
- Remove `validation_results` from the `default_output_properties`

**Supersim**
- Add ESimProfile's `matching_id` and `activation_code` parameters to libraries


[2023-02-22] Version 6.2.4
--------------------------
**Api**
- Remove `scheduled_for` property from message resource
- Add `scheduled_for` property to message resource


[2023-02-08] Version 6.2.3
--------------------------
**Lookups**
- Add `disposable_phone_number_risk` package to the lookup response
- Add `sms_pumping_risk` package to the lookup response


[2023-01-25] Version 6.2.2
--------------------------
**Library - Docs**
- [PR #666](https://github.com/twilio/twilio-csharp/pull/666): use long property descriptions if available. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Api**
- Add `public_application_connect_enabled` param to Application resource

**Messaging**
- Add new tollfree verification API property (ExternalReferenceId)]

**Verify**
- Add `device_ip` parameter and channel `auto` for sna/sms orchestration

**Twiml**
- Add support for `<Application>` noun and `<ApplicationSid>` noun, nested `<Parameter>` to `<Hangup>` and `<Leave>` verb


[2023-01-11] Version 6.2.1
--------------------------
**Library - Fix**
- [PR #663](https://github.com/twilio/twilio-csharp/pull/663): fixed header params with postfix before and after in name. Thanks to [@sbansla](https://github.com/sbansla)!

**Conversations**
- Add support for creating Multi-Channel Rich Content Messages

**Lookups**
- Changed the no data message for match postal code from `no_data` to `data_not_available` in identity match package

**Messaging**
- Add update/edit tollfree verification API


[2022-12-14] Version 6.2.0
--------------------------
**Library - Fix**
- [PR #659](https://github.com/twilio/twilio-csharp/pull/659): handling number parameters serialization. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Api**
- Add `street_secondary` param to address create and update
- Make `method` optional for user defined message subscription **(breaking change)**

**Flex**
- Flex Conversations is now Generally Available
- Adding the ie1 mapping for authorization api, updating service base uri and base url response attribute **(breaking change)**
- Change web channels to GA and library visibility to public
- Changing the uri for authorization api from using Accounts to Insights **(breaking change)**

**Media**
- Gate Twilio Live endpoints behind beta_feature for EOS

**Messaging**
- Mark `MessageFlow` as a required field for Campaign Creation **(breaking change)**

**Oauth**
- updated openid discovery endpoint uri **(breaking change)**
- Added device code authorization endpoint

**Supersim**
- Allow filtering the SettingsUpdates resource by `status`

**Twiml**
- Add new Polly Neural voices
- Add tr-TR, ar-AE, yue-CN, fi-FI languages to SSML `<lang>` element.
- Add x-amazon-jyutping, x-amazon-pinyin, x-amazon-pron-kana, x-amazon-yomigana alphabets to SSML `<phoneme>` element.
- Rename `character` value for SSML `<say-as>` `interpret-as` attribute to `characters`. **(breaking change)**
- Rename `role` attribute to `format` in SSML `<say-as>` element. **(breaking change)**


[2022-11-30] Version 6.1.0
--------------------------
**Library - Feature**
- [PR #649](https://github.com/twilio/twilio-csharp/pull/649): Add `ToXDocument` method to `TwiML`. Thanks to [@Swimburger](https://github.com/Swimburger)!

**Flex**
- Adding new `assessments` api in version `v1`

**Lookups**
- Add `identity_match` package to the lookup response

**Messaging**
- Added `validated` parameter to Link Shortening API

**Serverless**
- Add node16 as a valid Build runtime
- Add ie1 and au1 as supported regions for all endpoints.


[2022-11-16] Version 6.0.1
--------------------------
**Library - Chore**
- [PR #654](https://github.com/twilio/twilio-csharp/pull/654): bump csharp version to 6.0.1. Thanks to [@sbansla](https://github.com/sbansla)!


[2022-11-16] Version 6.0.0
--------------------------
**Note:** This release contains breaking changes, check our [upgrade guide](./UPGRADE.md#2022-11-XX-5xx-to-6xx) for detailed migration notes.

**Library - Chore**
- [PR #653](https://github.com/twilio/twilio-csharp/pull/653): refactored c# comments in options file. Thanks to [@sbansla](https://github.com/sbansla)!
- [PR #646](https://github.com/twilio/twilio-csharp/pull/646): upgrade GitHub Actions dependencies. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Library - Fix**
- [PR #651](https://github.com/twilio/twilio-csharp/pull/651): renamed resource and option file from GoodDatum to GoodData. Thanks to [@sbansla](https://github.com/sbansla)!

**Library - Docs**
- [PR #650](https://github.com/twilio/twilio-csharp/pull/650): update summaries with special characters. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Library - Feature**
- [PR #645](https://github.com/twilio/twilio-csharp/pull/645): Merging RC branch to main. Thanks to [@sbansla](https://github.com/sbansla)! **(breaking change)**

**Api**
- Set the Content resource to have public visibility as Preview

**Flex**
- Adding new parameter `base_url` to 'gooddata' response in version `v1`

**Insights**
- Added `answered_by` field in List Call Summary
- Added `answered_by` field in call summary


[2022-11-10] Version 5.81.2
---------------------------
**Flex**
- Adding two new authorization API 'user_roles' and 'gooddata' in version `v1`

**Messaging**
- Add new Campaign properties (MessageFlow, OptInMessage, OptInKeywords, OptOutMessage, OptOutKeywords, HelpMessage, HelpKeywords)

**Twiml**
- Add new speech models to `Gather`.


[2022-10-31] Version 5.81.1
---------------------------
**Api**
- Added `contentSid` and `contentVariables` to Message resource with public visibility as Beta
- Add `UserDefinedMessageSubscription` and `UserDefinedMessage` resource

**Proxy**
- Remove FailOnParticipantConflict param from Proxy Session create and update and Proxy Participant create

**Supersim**
- Update SettingsUpdates resource to remove PackageSid

**Taskrouter**
- Add `Ordering` query parameter to Workers and TaskQueues for sorting by
- Add `worker_sid` query param for list reservations endpoint

**Twiml**
- Add `url` and `method` attributes to `<Conversation>`


[2022-10-19] Version 5.81.0
---------------------------
**Api**
- Make link shortening parameters public **(breaking change)**

**Oauth**
- added oauth JWKS endpoint
- Get userinfo resource
- OpenID discovery resource
- Add new API for token endpoint

**Supersim**
- Add SettingsUpdates resource

**Verify**
- Update Verify Push endpoints to `ga` maturity
- Verify BYOT add Channels property to the Get Templates response

**Twiml**
- Add `requireMatchingInputs` attribute and `input-matching-failed` errorType to `<Prompt>`


[2022-10-05] Version 5.80.1
---------------------------
**Library - Fix**
- [PR #632](https://github.com/twilio/twilio-csharp/pull/632): handling null 'from' parameter. Thanks to [@isha689](https://github.com/isha689)!
- [PR #636](https://github.com/twilio/twilio-csharp/pull/636): Make sonar exclusions a variable to reuse this file. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Library - Test**
- [PR #634](https://github.com/twilio/twilio-csharp/pull/634): Modifying make command to take project name and token as arguments for reuse. Thanks to [@AsabuHere](https://github.com/AsabuHere)!

**Api**
- Added `virtual-agent` to `usage_record` API.
- Add AMD attributes to participant create request

**Twiml**
- Add AMD attributes to `Number` and `Sip`


[2022-09-07] Version 5.80.0
---------------------------
**Flex**
- Removed redundant `close` status from Flex Interactions flow **(breaking change)**
- Adding `debugger_integration` and `flex_ui_status_report` to Flex Configuration

**Messaging**
- Add create, list and get tollfree verification API

**Verify**
- Verify SafeList API endpoints added.

**Video**
- Add `Anonymize` API

**Twiml**
- Update `event` value `call-in-progress` to `call-answered`


[2022-08-24] Version 5.79.0
---------------------------
**Library - Test**
- [PR #627](https://github.com/twilio/twilio-csharp/pull/627): add test-docker rule. Thanks to [@beebzz](https://github.com/beebzz)!

**Api**
- Remove `beta feature` from scheduling params and remove optimize parameters. **(breaking change)**

**Routes**
- Remove Duplicate Create Method - Update Method will work even if Inbound Processing Region is currently empty/404. **(breaking change)**

**Twiml**
- Add new Polly Neural voices
- Add new languages to SSML `<lang>`.


[2022-08-10] Version 5.78.1
---------------------------
**Library - Test**
- [PR #623](https://github.com/twilio/twilio-csharp/pull/623): Modified Dockerfile to be able to easily build and test. Thanks to [@marcusber](https://github.com/marcusber)!

**Routes**
- Inbound Proccessing Region API - Public GA

**Supersim**
- Allow updating `DataLimit` on a Fleet


[2022-07-21] Version 5.78.0
---------------------------
**Library - Fix**
- [PR #620](https://github.com/twilio/twilio-csharp/pull/620): useragent regrex unit test for RC branch. Thanks to [@claudiachua](https://github.com/claudiachua)!

**Flex**
- Add `status`, `error_code`, and `error_message` fields to Interaction `Channel`
- Adding `messenger` and `gbm` as supported channels for Interactions API

**Messaging**
- Update alpha_sender docs with new valid characters

**Verify**
- Reorder Verification Check parameters so `code` stays as the first parameter **(breaking change)**
- Rollback List Attempts API V2 back to pilot stage.


[2022-07-13] Version 5.77.0
---------------------------
**Library - Chore**
- [PR #618](https://github.com/twilio/twilio-csharp/pull/618): bump Newtonsoft.Json from 10.0.1 to 13.0.1. Thanks to [@dependabot](https://github.com/dependabot)!

**Library - Test**
- [PR #619](https://github.com/twilio/twilio-csharp/pull/619): Adding misc as PR type. Thanks to [@rakatyal](https://github.com/rakatyal)!

**Conversations**
- Allowed to use `identity` as part of Participant's resource **(breaking change)**

**Lookups**
- Remove `enhanced_line_type` from the lookup response **(breaking change)**

**Supersim**
- Add support for `sim_ip_addresses` resource to helper libraries

**Verify**
- Changed summary param `service_sid` to `verify_service_sid` to be consistent with list attempts API **(breaking change)**
- Make `code` optional on Verification check to support `sna` attempts. **(breaking change)**


[2022-06-29] Version 5.76.0
---------------------------
**Library - Fix**
- [PR #616](https://github.com/twilio/twilio-csharp/pull/616): Patching newer versions of JwtHeader including "cty". Thanks to [@marcusber](https://github.com/marcusber)!

**Api**
- Added `amazon-polly` to `usage_record` API.

**Insights**
- Added `annotation` field in call summary
- Added new endpoint to fetch/create/update Call Annotations

**Verify**
- Remove `api.verify.totp` beta flag and set maturity to `beta` for Verify TOTP properties and parameters. **(breaking change)**
- Changed summary param `verify_service_sid` to `service_sid` to be consistent with list attempts API **(breaking change)**

**Twiml**
- Add `maxQueueSize` to `Enqueue`


[2022-06-15] Version 5.75.3
---------------------------
**Lookups**
- Adding support for Lookup V2 API

**Studio**
- Corrected PII labels to be 30 days and added context to be PII

**Twiml**
- Add `statusCallbackMethod` attribute, nested `<Config` and `<Parameter>` elements to `<VirtualAgent>` noun.
- Add support for new Amazon Polly voices (Q2 2022) for `Say` verb
- Add support for `<Conversation>` noun


[2022-06-01] Version 5.75.2
---------------------------
**Library - Chore**
- [PR #611](https://github.com/twilio/twilio-csharp/pull/611): use Docker 'rc' tag for release candidate images. Thanks to [@childish-sambino](https://github.com/childish-sambino)!
- [PR #606](https://github.com/twilio/twilio-csharp/pull/606): update the user agent string for twilio-csharp. Thanks to [@claudiachua](https://github.com/claudiachua)!


[2022-05-18] Version 5.75.1
---------------------------
**Api**
- Add property `media_url` to the recording resources

**Verify**
- Include `silent` as a channel type in the verifications API.


[2022-05-04] Version 5.75.0
---------------------------
**Library - Chore**
- [PR #604](https://github.com/twilio/twilio-csharp/pull/604): Security upgrade Newtonsoft.Json from 9.0.1 to 13.0.1. Thanks to [@twilio-product-security](https://github.com/twilio-product-security)!

**Conversations**
- Expose query parameter `type` in list operation on Address Configurations resource

**Supersim**
- Add `data_total_billed` and `billed_units` fields to Super SIM UsageRecords API response.
- Change ESimProfiles `Eid` parameter to optional to enable Activation Code download method support **(breaking change)**

**Verify**
- Deprecate `push.include_date` parameter in create and update service.


[2022-04-06] Version 5.74.0
---------------------------
**Library - Feature**
- [PR #602](https://github.com/twilio/twilio-csharp/pull/602): support shortcode as an InboundSmsPrice type. Thanks to [@beebzz](https://github.com/beebzz)!

**Api**
- Updated `provider_sid` visibility to private

**Verify**
- Verify List Attempts API summary endpoint added.
- Update PII documentation for `AccessTokens` `factor_friendly_name` property.

**Voice**
- make annotation parameter from /Calls API private


[2022-03-23] Version 5.73.0
---------------------------
**Api**
- Change `stream` url parameter to non optional
- Add `verify-totp` and `verify-whatsapp-conversations-business-initiated` categories to `usage_record` API

**Chat**
- Added v3 Channel update endpoint to support Public to Private channel migration

**Flex**
- Private Beta release of the Interactions API to support the upcoming release of Flex Conversations at the end of Q1 2022.
- Adding `channel_configs` object to Flex Configuration

**Media**
- Add max_duration param to PlayerStreamer

**Supersim**
- Remove Commands resource, use SmsCommands resource instead **(breaking change)**

**Taskrouter**
- Add limits to `split_by_wait_time` for Cumulative Statistics Endpoint

**Video**
- Change recording `status_callback_method` type from `enum` to `http_method` **(breaking change)**
- Add `status_callback` and `status_callback_method` to composition
- Add `status_callback` and `status_callback_method` to recording


[2022-03-09] Version 5.72.1
---------------------------
**Library - Chore**
- [PR #600](https://github.com/twilio/twilio-csharp/pull/600): push Datadog Release Metric upon deploy success. Thanks to [@eshanholtz](https://github.com/eshanholtz)!

**Api**
- Add optional boolean include_soft_deleted parameter to retrieve soft deleted recordings

**Chat**
- Add `X-Twilio-Wehook-Enabled` header to `delete` method in UserChannel resource

**Numbers**
- Expose `failure_reason` in the Supporting Documents resources

**Verify**
- Add optional `metadata` parameter to "verify challenge" endpoint, so the SDK/App can attach relevant information from the device when responding to challenges.
- remove beta feature flag to list atempt api operations.
- Add `ttl` and `date_created` properties to `AccessTokens`.


[2022-02-23] Version 5.72.0
---------------------------
**Api**
- Add `uri` to `stream` resource
- Add A2P Registration Fee category (`a2p-registration-fee`) to usage records
- Detected a bug and removed optional boolean include_soft_deleted parameter to retrieve soft deleted recordings. **(breaking change)**
- Add optional boolean include_soft_deleted parameter to retrieve soft deleted recordings.

**Numbers**
- Unrevert valid_until and sort filter params added to List Bundles resource
- Revert valid_until and sort filter params added to List Bundles resource
- Update sorting params added to List Bundles resource in the previous release

**Preview**
- Moved `web_channels` from preview to beta under `flex-api` **(breaking change)**

**Taskrouter**
- Add `ETag` as Response Header to List of Task, Reservation & Worker

**Verify**
- Remove outdated documentation commentary to contact sales. Product is already in public beta.
- Add optional `metadata` to factors.

**Twiml**
- Add new Polly Neural voices


[2022-02-09] Version 5.71.0
---------------------------
**Api**
- Add `stream` resource

**Conversations**
- Fixed DELETE request to accept "sid_like" params in Address Configuration resources **(breaking change)**
- Expose Address Configuration resource for `sms` and `whatsapp`

**Fax**
- Removed deprecated Programmable Fax Create and Update methods **(breaking change)**

**Insights**
- Rename `call_state` to `call_status` and remove `whisper` in conference participant summary **(breaking change)**

**Numbers**
- Expose valid_until filters as part of provisionally-approved compliance feature on the List Bundles resource

**Supersim**
- Fix typo in Fleet resource docs
- Updated documentation for the Fleet resource indicating that fields related to commands have been deprecated and to use sms_command fields instead.
- Add support for setting and reading `ip_commands_url` and `ip_commands_method` on Fleets resource for helper libraries
- Changed `sim` property in requests to create an SMS Command made to the /SmsCommands to accept SIM UniqueNames in addition to SIDs

**Verify**
- Update list attempts API to include new filters and response fields.


[2022-01-26] Version 5.70.1
---------------------------
**Insights**
- Added new endpoint to fetch Conference Participant Summary
- Added new endpoint to fetch Conference Summary

**Messaging**
- Add government_entity parameter to brand apis

**Verify**
- Add Access Token fetch endpoint to retrieve a previously created token.
- Add Access Token payload to the Access Token creation endpoint, including a unique Sid, so it's addressable while it's TTL is valid.


[2022-01-12] Version 5.70.0
---------------------------
**Library - Chore**
- [PR #595](https://github.com/twilio/twilio-csharp/pull/595): prevent Sonarcloud from running on forks. Thanks to [@JenniferMah](https://github.com/JenniferMah)!

**Library - Feature**
- [PR #591](https://github.com/twilio/twilio-csharp/pull/591): add GitHub release step during deploy. Thanks to [@childish-sambino](https://github.com/childish-sambino)!
- [PR #592](https://github.com/twilio/twilio-csharp/pull/592): Add SonarCloud analysis. Thanks to [@BrimmingDev](https://github.com/BrimmingDev)!

**Api**
- Make fixed time scheduling parameters public **(breaking change)**

**Messaging**
- Add update brand registration API

**Numbers**
- Add API endpoint for List Bundle Copies resource

**Video**
- Enable external storage for all customers


[2021-12-15] Version 5.69.0
---------------------------
**Library - Feature**
- [PR #588](https://github.com/twilio/twilio-csharp/pull/588): run tests before deploying. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Api**
- Add optional boolean send_as_mms parameter to the create action of Message resource **(breaking change)**
- Change team ownership for `call` delete

**Conversations**
- Change wording for `Service Webhook Configuration` resource fields

**Insights**
- Added new APIs for updating and getting voice insights flags by accountSid.

**Media**
- Add max_duration param to MediaProcessor

**Video**
- Add `EmptyRoomTimeout` and `UnusedRoomTimeout` properties to a room; add corresponding parameters to room creation

**Voice**
- Add endpoint to delete archived Calls


[2021-12-01] Version 5.68.2
---------------------------
**Conversations**
- Add `Service Webhook Configuration` resource

**Flex**
- Adding `flex_insights_drilldown` and `flex_url` objects to Flex Configuration

**Messaging**
- Update us_app_to_person endpoints to remove beta feature flag based access

**Supersim**
- Add IP Commands resource

**Verify**
- Add optional `factor_friendly_name` parameter to the create access token endpoint.

**Video**
- Add maxParticipantDuration param to Rooms

**Twiml**
- Unrevert Add supported SSML children to `<emphasis>`, `<lang>`, `<p>`, `<prosody>`, `<s>`, and `<w>`.
- Revert Add supported SSML children to `<emphasis>`, `<lang>`, `<p>`, `<prosody>`, `<s>`, and `<w>`.


[2021-11-17] Version 5.68.1
---------------------------
**Library - Fix**
- [PR #585](https://github.com/twilio/twilio-csharp/pull/585): git log retrieval issues. Thanks to [@shwetha-manvinkurke](https://github.com/shwetha-manvinkurke)!

**Frontline**
- Added `is_available` to User's resource

**Messaging**
- Added GET vetting API

**Verify**
- Add `WHATSAPP` to the attempts API.
- Allow to update `config.notification_platform` from `none` to `apn` or `fcm` and viceversa for Verify Push
- Add `none` as a valid `config.notification_platform` value for Verify Push

**Twiml**
- Add supported SSML children to `<emphasis>`, `<lang>`, `<p>`, `<prosody>`, `<s>`, and `<w>`.


[2021-11-03] Version 5.68.0
---------------------------
**Library - Fix**
- [PR #584](https://github.com/twilio/twilio-csharp/pull/584): nuget deploy script. Thanks to [@shwetha-manvinkurke](https://github.com/shwetha-manvinkurke)!

**Library - Chore**
- [PR #583](https://github.com/twilio/twilio-csharp/pull/583): migrate to using gh actions. Thanks to [@shwetha-manvinkurke](https://github.com/shwetha-manvinkurke)!

**Api**
- Updated `media_url` property to be treated as PII

**Messaging**
- Added a new enum for brand registration status named DELETED **(breaking change)**
- Add a new K12_EDUCATION use case in us_app_to_person_usecase api transaction
- Added a new enum for brand registration status named IN_REVIEW

**Serverless**
- Add node14 as a valid Build runtime

**Verify**
- Fix typos in Verify Push Factor documentation for the `config.notification_token` parameter.
- Added `TemplateCustomSubstitutions` on verification creation
- Make `TemplateSid` parameter public for Verification resource and `DefaultTemplateSid` parameter public for Service resource. **(breaking change)**


[2021-10-18] Version 5.67.0
---------------------------
**Library - Feature**
- [PR #581](https://github.com/twilio/twilio-csharp/pull/581): Add PlaybackGrant. Thanks to [@miguelgrinberg](https://github.com/miguelgrinberg)!

**Api**
- Corrected enum values for `emergency_address_status` values in `/IncomingPhoneNumbers` response. **(breaking change)**
- Clarify `emergency_address_status` values in `/IncomingPhoneNumbers` response.

**Messaging**
- Add PUT and List brand vettings api
- Removes beta feature flag based visibility for us_app_to_person_registered and usecase field.Updates test cases to add POLITICAL usecase. **(breaking change)**
- Add brand_feedback as optional field to BrandRegistrations

**Video**
- Add `AudioOnly` to create room


[2021-10-06] Version 5.66.0
---------------------------
**Api**
- Add `emergency_address_status` attribute to `/IncomingPhoneNumbers` response.
- Add `siprec` resource

**Conversations**
- Added attachment parameters in configuration for `NewMessage` type of push notifications

**Flex**
- Adding `flex_insights_hr` object to Flex Configuration

**Numbers**
- Add API endpoint for Bundle ReplaceItems resource
- Add API endpoint for Bundle Copies resource

**Serverless**
- Add domain_base field to Service response

**Taskrouter**
- Add `If-Match` Header based on ETag for Worker Delete **(breaking change)**
- Add `If-Match` Header based on Etag for Reservation Update
- Add `If-Match` Header based on ETag for Worker Update
- Add `If-Match` Header based on ETag for Worker Delete
- Add `ETag` as Response Header to Worker

**Trunking**
- Added `transfer_caller_id` property on Trunks.

**Verify**
- Document new pilot `whatsapp` channel.


[2021-09-22] Version 5.65.3
---------------------------
**Events**
- Add segment sink

**Messaging**
- Add post_approval_required attribute in GET us_app_to_person_usecase api response
- Add Identity Status, Russell 3000, Tax Exempt Status and Should Skip SecVet fields for Brand Registrations
- Add Should Skip Secondary Vetting optional flag parameter to create Brand API


[2021-09-08] Version 5.65.2
---------------------------
**Api**
- Revert adding `siprec` resource
- Add `siprec` resource

**Messaging**
- Add 'mock' as an optional field to brand_registration api
- Add 'mock' as an optional field to us_app_to_person api
- Adds more Use Cases in us_app_to_person_usecase api transaction and updates us_app_to_person_usecase docs

**Verify**
- Verify List Templates API endpoint added.


[2021-08-25] Version 5.65.1
---------------------------
**Library - Chore**
- [PR #576](https://github.com/twilio/twilio-csharp/pull/576): integrate with sonarcloud. Thanks to [@shwetha-manvinkurke](https://github.com/shwetha-manvinkurke)!

**Api**
- Add Programmabled Voice SIP Refer call transfers (`calls-transfers`) to usage records
- Add Flex Voice Usage category (`flex-usage`) to usage records

**Conversations**
- Add `Order` query parameter to Message resource read operation

**Insights**
- Added `partial` to enum processing_state_request
- Added abnormal session filter in Call Summaries

**Messaging**
- Add brand_registration_sid as an optional query param for us_app_to_person_usecase api

**Pricing**
- add trunking_numbers resource (v2)
- add trunking_country resource (v2)

**Verify**
- Changed to private beta the `TemplateSid` optional parameter on Verification creation.
- Added the optional parameter `Order` to the list Challenges endpoint to define the list order.


[2021-08-11] Version 5.65.0
---------------------------
**Api**
- Corrected the `price`, `call_sid_to_coach`, and `uri` data types for Conference, Participant, and Recording **(breaking change)**
- Made documentation for property `time_limit` in the call api public. **(breaking change)**
- Added `domain_sid` in sip_credential_list_mapping and sip_ip_access_control_list_mapping APIs **(breaking change)**

**Insights**
- Added new endpoint to fetch Call Summaries

**Messaging**
- Add brand_type field to a2p brand_registration api
- Revert brand registration api update to add brand_type field
- Add brand_type field to a2p brand_registration api

**Taskrouter**
- Add `X-Rate-Limit-Limit`, `X-Rate-Limit-Remaining`, and `X-Rate-Limit-Config` as Response Headers to all TaskRouter endpoints

**Verify**
- Add `TemplateSid` optional parameter on Verification creation.
- Include `whatsapp` as a channel type in the verifications API.


[2021-07-28] Version 5.64.1
---------------------------
**Conversations**
- Expose ParticipantConversations resource

**Taskrouter**
- Adding `links` to the activity resource

**Verify**
- Added a `Version` to Verify Factors `Webhooks` to add new fields without breaking old Webhooks.


[2021-07-14] Version 5.64.0
---------------------------
**Conversations**
- Changed `last_read_message_index` and `unread_messages_count` type in User Conversation's resource **(breaking change)**
- Expose UserConversations resource

**Messaging**
- Add brand_score field to brand registration responses


[2021-06-30] Version 5.63.0
---------------------------
**Conversations**
- Read-only Conversation Email Binding property `binding`

**Supersim**
- Add Billing Period resource for the Super Sim Pilot
- Add List endpoint to Billing Period resource for Super Sim Pilot
- Add Fetch endpoint to Billing Period resource for Super Sim Pilot

**Taskrouter**
- Update `transcribe` & `transcription_configuration` form params in Reservation update endpoint to have private visibility **(breaking change)**
- Add `transcribe` & `transcription_configuration` form params to Reservation update endpoint

**Twiml**
- Add `modify` event to `statusCallbackEvent` for `<Conference>`.


[2021-06-16] Version 5.62.0
---------------------------
**Api**
- Update `status` enum for Messages to include 'canceled'
- Update `update_status` enum for Messages to include 'canceled'

**Trusthub**
- Corrected the sid for policy sid in customer_profile_evaluation.json and trust_product_evaluation.json **(breaking change)**


[2021-06-02] Version 5.61.1
---------------------------
**Library - Fix**
- [PR #567](https://github.com/twilio/twilio-csharp/pull/567): requestValidation when hostname URL has any uppercase letters. Thanks to [@thinkingserious](https://github.com/thinkingserious)!

**Events**
- join Sinks and Subscriptions service

**Verify**
- Improved the documentation of `challenge` adding the maximum and minimum expected lengths of some fields.
- Improve documentation regarding `notification` by updating the documentation of the field `ttl`.


[2021-05-19] Version 5.61.0
---------------------------
**Library - Fix**
- [PR #566](https://github.com/twilio/twilio-csharp/pull/566): Propagate Edge and Region properties from client to request when making async request. Thanks to [@xeromorph](https://github.com/xeromorph)!

**Events**
- add query param to return types filtered by Schema Id
- Add query param to return sinks filtered by status
- Add query param to return sinks used/not used by a subscription

**Messaging**
- Add fetch and delete instance endpoints to us_app_to_person api **(breaking change)**
- Remove delete list endpoint from us_app_to_person api **(breaking change)**
- Update read list endpoint to return a list of us_app_to_person compliance objects **(breaking change)**
- Add `sid` field to Preregistered US App To Person response

**Supersim**
- Mark `unique_name` in Sim, Fleet, NAP resources as not PII

**Video**
- [Composer] GA maturity level


[2021-05-05] Version 5.60.0
---------------------------
**Api**
- Corrected the data types for feedback summary fields **(breaking change)**
- Update the conference participant create `from` and `to` param to be endpoint type for supporting client identifier and sip address

**Bulkexports**
- promoting API maturity to GA

**Events**
- Add endpoint to update description in sink
- Remove beta-feature account flag

**Messaging**
- Update `status` field in us_app_to_person api to `campaign_status` **(breaking change)**

**Verify**
- Improve documentation regarding `push` factor and include extra information about `totp` factor.


[2021-04-21] Version 5.59.0
---------------------------
**Api**
- Revert Update the conference participant create `from` and `to` param to be endpoint type for supporting client identifier and sip address
- Update the conference participant create `from` and `to` param to be endpoint type for supporting client identifier and sip address

**Bulkexports**
- moving enum to doc root for auto generating documentation
- adding status enum and default output properties

**Events**
- Change schema_versions prop and key to versions **(breaking change)**

**Messaging**
- Add `use_inbound_webhook_on_number` field in Service API for fetch, create, update, read

**Taskrouter**
- Add `If-Match` Header based on ETag for Task Delete

**Verify**
- Add `AuthPayload` parameter to support verifying a `Challenge` upon creation. This is only supported for `totp` factors.
- Add support to resend the notifications of a `Challenge`. This is only supported for `push` factors.

**Twiml**
- Add Polly Neural voices.


[2021-04-07] Version 5.58.0
---------------------------
**Api**
- Added `announcement` event to conference status callback events
- Removed optional property `time_limit` in the call create request. **(breaking change)**

**Messaging**
- Add rate_limits field to Messaging Services US App To Person API
- Add usecase field in Service API for fetch, create, update, read
- Add us app to person api and us app to person usecase api as dependents in service
- Add us_app_to_person_registered field in service api for fetch, read, create, update
- Add us app to person api
- Add us app to person usecase api
- Add A2P external campaign api
- Add Usecases API

**Supersim**
- Add Create endpoint to Sims resource

**Verify**
- The `Binding` field is now returned when creating a `Factor`. This value won't be returned for other endpoints.

**Video**
- [Rooms] max_concurrent_published_tracks has got GA maturity

**Twiml**
- Add `announcement` event to `statusCallbackEvent` for `<Conference>`.


[2021-03-24] Version 5.57.0
---------------------------
**Api**
- Added optional parameter `CallToken` for create calls api
- Add optional property `time_limit` in the call create request.

**Bulkexports**
- adding two new fields with job api queue_position and estimated_completion_time

**Events**
- Add new endpoints to manage subscribed_events in subscriptions

**Numbers**
- Remove feature flags for RegulatoryCompliance endpoints

**Supersim**
- Add SmsCommands resource
- Add fields `SmsCommandsUrl`, `SmsCommandsMethod` and `SmsCommandsEnabled` to a Fleet resource

**Taskrouter**
- Add `If-Match` Header based on ETag for Task Update
- Add `ETag` as Response Headers to Tasks and Reservations

**Video**
- Recording rule beta flag **(breaking change)**
- [Rooms] Add RecordingRules param to Rooms


[2021-03-15] Version 5.56.0
---------------------------
**Events**
- Set maturity to beta

**Messaging**
- Adjust A2P brand registration status enum **(breaking change)**

**Studio**
- Remove internal safeguards for Studio V2 API usage now that it's GA

**Verify**
- Add support for creating and verifying totp factors. Support for totp factors is behind the `api.verify.totp` beta feature.

**Twiml**
- Add support for `<VirtualAgent>` noun


[2021-02-24] Version 5.55.0
---------------------------
**Library - Fix**
- [PR #559](https://github.com/twilio/twilio-csharp/pull/559): Revert "Remove deploy to nuget". Thanks to [@eshanholtz](https://github.com/eshanholtz)!

**Events**
- Update description of types in the create sink resource

**Messaging**
- Add WA template header and footer
- Remove A2P campaign and use cases API **(breaking change)**
- Add number_registration_status field to read and fetch campaign responses

**Verify**
- Verify List Attempts API endpoints added.


[2021-02-12] Version 5.54.0
---------------------------
**Library - Chore**
- [PR #554](https://github.com/twilio/twilio-csharp/pull/554): update documentation in upgrade.md. Thanks to [@JenniferMah](https://github.com/JenniferMah)!

**Api**
- Revert change that conference participant create `from` and `to` param to be endpoint type for supporting client identifier and sip address
- Update the conference participant create `from` and `to` param to be endpoint type for supporting client identifier and sip address

**Events**
- Documentation should state that no fields are PII

**Flex**
- Adding `notifications` and `markdown` to Flex Configuration

**Messaging**
- Add A2P use cases API
- Add Brand Registrations API
- Add Campaigns API

**Serverless**
- Add runtime field to Build response and as an optional parameter to the Build create endpoint.
- Add @twilio/runtime-handler dependency to Build response example.

**Sync**
- Remove If-Match header for Document **(breaking change)**

**Trusthub**
- Make all resources public

**Twiml**
- Add `refer_url` and `refer_method` to `Dial`.


[2021-01-27] Version 5.53.1
---------------------------
**Studio**
- Studio V2 API is now GA

**Supersim**
- Allow updating `CommandsUrl` and `CommandsMethod` on a Fleet

**Twiml**
- Add `status_callback` and `status_callback_method` to `Stream`.


[2021-01-13] Version 5.53.0
---------------------------
**Api**
- Add 'Electric Imp v1 Usage' to usage categories

**Conversations**
- Changed `last_read_message_index` type in Participant's resource **(breaking change)**

**Insights**
- Added `created_time` to call summary.

**Sync**
- Remove HideExpired query parameter for filtering Sync Documents with expired **(breaking change)**

**Video**
- [Rooms] Expose maxConcurrentPublishedTracks property in Room resource


[2020-12-16] Version 5.52.1
---------------------------
**Api**
- Updated `call_event` default_output_properties to request and response.

**Conversations**
- Added `last_read_message_index` and `last_read_timestamp` to Participant's resource update operation
- Added `is_notifiable` and `is_online` to User's resource
- Added `reachability_enabled` parameters to update method for Conversation Service Configuration resource

**Messaging**
- Added WA template quick reply, URL, and phone number buttons

**Twiml**
- Add `sequential` to `Dial`.


[2020-12-08] Version 5.52.0
---------------------------
**Api**
- Added optional `RecordingTrack` parameter for create calls, create participants, and create call recordings
- Removed deprecated Programmable Chat usage record categories **(breaking change)**

**Twiml**
- Add `recordingTrack` to `Dial`.


[2020-12-02] Version 5.51.0
---------------------------
**Api**
- Remove `RecordingTrack` parameter for create calls, create participants, and create call recordings **(breaking change)**
- Added `RecordingTrack` parameter for create calls and create call recordings
- Add optional property `recording_track` in the participant create request

**Lookups**
- Changed `caller_name` and `carrier` properties type to object **(breaking change)**

**Trunking**
- Added dual channel recording options for Trunks.

**Twiml**
- Add `jitterBufferSize` and `participantLabel` to `Conference`.


[2020-11-18] Version 5.50.0
---------------------------
**Library - Feature**
- [PR #546](https://github.com/twilio/twilio-csharp/pull/546): Add region to access token. Thanks to [@ryan-rowland](https://github.com/ryan-rowland)!

**Api**
- Add new call events resource - GET /2010-04-01/Accounts/{account_sid}/Calls/{call_sid}/Events.json

**Conversations**
- Fixed default response property issue for Service Notifications Configuration

**Insights**
- Removing call_sid from participant summary. **(breaking change)**

**Serverless**
- Allow Service unique name to be used in path (in place of SID) in Service update request

**Sync**
- Added HideExpired query parameter for filtering Sync Documents with expired

**Verify**
- Challenge `Details` and `HiddenDetails` properties are now marked as `PII`
- Challenge `expiration_date` attribute updated to set a default value of five (5) minutes and to allow max dates of one (1) hour after creation.
- Entity `identity` attribute updated to allow values between 8 and 64 characters.
- Verify Service frinedly_name attribute updated from 64 max lenght to 30 characters.


[2020-11-05] Version 5.49.0
---------------------------
**Library - Feature**
- [PR #545](https://github.com/twilio/twilio-csharp/pull/545): add http logging for c#. Thanks to [@JenniferMah](https://github.com/JenniferMah)!

**Api**
- Added `verify-push` to `usage_record` API

**Bulkexports**
- When creating a custom export the StartDay, EndDay, and FriendlyName fields were required but this was not reflected in the API documentation.  The API itself failed the request without these fields. **(breaking change)**
- Added property descriptions for Custom Export create method
- Clarified WebhookUrl and WebhookMethod must be provided together for Custom Export

**Insights**
- Added video room and participant summary apis.

**Ip_messaging**
- Create separate definition for ip-messaging
- Restore v2 endpoints for ip-messaging

**Verify**
- Verify Push madurity were updated from `preview` to `beta`
- `twilio_sandbox_mode` header was removed from Verify Push resources **(breaking change)**

**Video**
- [Rooms] Add Recording Rules API


[2020-10-14] Version 5.48.0
---------------------------
**Library - Feature**
- [PR #527](https://github.com/twilio/twilio-csharp/pull/527): Add RecordingRule and RecordingRulesUpdate. Thanks to [@FMV1491](https://github.com/FMV1491)!

**Ai**
- Add `Annotation Project` and `Annotation Task` endpoints
- Add `Primitives` endpoints
- Add `meta.total` to the search endpoint

**Conversations**
- Mutable Conversation Unique Names

**Insights**
- Added `trust` to summary.

**Preview**
- Simplified `Channels` resource. The path is now `/BrandedChannels/branded_channel_sid/Channels` **(breaking change)**

**Verify**
- Changed parameters (`config` and `binding`) to use dot notation instead of JSON string (e.i. Before: `binding={"alg":"ES256", "public_key": "xxx..."}`, Now: `Binding.Alg="ES256"`, `Binding.PublicKey="xxx..."`). **(breaking change)**
- Changed parameters (`details` and `hidden_details`) to use dot notation instead of JSON string (e.i. Before: `details={"message":"Test message", "fields": "[{\"label\": \"Action 1\", \"value\":\"value 1\"}]"}`, Now: `details.Message="Test message"`, `Details.Fields=["{\"label\": \"Action 1\", \"value\":\"value 1\"}"]`). **(breaking change)**
- Removed `notify_service_sid` from `push` service configuration object. Add `Push.IncludeDate`, `Push.ApnCredentialSid` and `Push.FcmCredentialSid` service configuration parameters. **(breaking change)**


[2020-09-28] Version 5.47.2
---------------------------
**Api**
- Add optional property `call_reason` in the participant create request
- Make sip-domain-service endpoints available in stage-au1 and prod-au1

**Messaging**
- Removed beta feature gate from WhatsApp Templates API

**Serverless**
- Add Build Status endpoint

**Video**
- [Rooms] Add new room type "go" for WebRTC Go


[2020-09-21] Version 5.47.1
---------------------------
**Library - Fix**
- [PR #542](https://github.com/twilio/twilio-csharp/pull/542): allow API redirect responses. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Accounts**
- Add Auth Token rotation API

**Conversations**
- Change resource path for Webhook Configuration

**Events**
- Schemas API get all Schemas names and versions


[2020-09-16] Version 5.47.0
---------------------------
**Library - Feature**
- [PR #540](https://github.com/twilio/twilio-csharp/pull/540): add custom header support. Thanks to [@eshanholtz](https://github.com/eshanholtz)!

**Conversations**
- Expose Configuration and Service Configuration resources
- Add Unique Name support for Conversations
- Add Services Push Notification resource
- Add Service scoped Conversation resources
- Support Identity in Users resource endpoint

**Messaging**
- GA Deactivation List API

**Numbers**
- Add API endpoint for Supporting Document deletion

**Proxy**
- Updated usage of FailOnParticipantConflict param to apply only to accounts with ProxyAllowParticipantConflict account flag

**Supersim**
- Add `AccountSid` parameter to Sim resource update request


[2020-09-03] Version 5.46.2
---------------------------
**Library - Fix**
- [PR #538](https://github.com/twilio/twilio-csharp/pull/538): use ReferenceAssemblies NuGet packages. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Messaging**
- Add domain cert API's(fetch, update, create) for link tracker

**Supersim**
- Add `ready` status as an available status for a Sim resource


[2020-09-02] Version 5.46.1
---------------------------
**Library - Chore**
- [PR #535](https://github.com/twilio/twilio-csharp/pull/535): simplify the build-test-pack-release process. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Ai**
- Initial release

**Bulkexports**
- removing public beta feature flag from BulkExports Jobs API

**Messaging**
- Add Deactivation List API
- Added page token parameter for fetch in WhatsApp Templates API

**Numbers**
- Add API endpoint for End User deletion

**Routes**
- Add Resource Route Configurations API
- Add Route Configurations API
- Initial Release

**Trunking**
- Added `transfer_mode` property on Trunks.


[2020-08-19] Version 5.46.0
---------------------------
**Library - Chore**
- [PR #532](https://github.com/twilio/twilio-csharp/pull/532): update GitHub branch references to use HEAD. Thanks to [@thinkingserious](https://github.com/thinkingserious)!

**Conversations**
- Allow Identity addition to Participants

**Events**
- Sinks API Get all Sinks

**Proxy**
- Clarified usage of FailOnParticipantConflict param as experimental
- Add FailOnParticipantConflict param to Proxy Session create and Proxy Participant create

**Supersim**
- Add fleet, network, and isoCountryCode to the UsageRecords resource
- Change sort order of UsageRecords from ascending to descending with respect to start time field, records are now returned newest to oldest

**Wireless**
- Removed `Start` and `End` parameters from the Data Sessions list endpoint. **(breaking change)**


[2020-08-05] Version 5.45.2
---------------------------
**Messaging**
- Add rejection reason support to WhatsApp API
- Removed status parameter for create and update in WhatsApp Templates API

**Proxy**
- Add FailOnParticipantConflict param to Proxy Session update

**Verify**
- Add `CustomFriendlyName` optional parameter on Verification creation.
- Changes in `Challenge` resource to update documentation of both `details` and `hidden_details` properties.


[2020-07-22] Version 5.45.1
---------------------------
**Library - Fix**
- [PR #530](https://github.com/twilio/twilio-csharp/pull/530): Change Default Logo from .ico to .png in NuGet. Thanks to [@garethpaul](https://github.com/garethpaul)!

**Api**
- Add optional Click Tracking and Scheduling parameters to Create action of Message resource

**Supersim**
- Add callback_url and callback_method parameters to Sim resource update request


[2020-07-08] Version 5.45.0
---------------------------
**Library - Feature**
- [PR #528](https://github.com/twilio/twilio-csharp/pull/528): add fax capability to deserialized phone number capabilities. Thanks to [@childish-sambino](https://github.com/childish-sambino)!
- [PR #526](https://github.com/twilio/twilio-csharp/pull/526): include API response headers in 'Last Response'. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Conversations**
- Allow Address updates for Participants
- Message delivery receipts

**Events**
- Add account_sid to subscription and subscribed_events resources

**Flex**
- Changed `wfm_integrations` Flex Configuration key to private **(breaking change)**

**Messaging**
- Add error states to WhatsApp Sender status with failed reason **(breaking change)**
- Delete WhatsApp Template API
- Update WhatsApp Template API
- Add WhatsApp Template Get Api (fetch and read)

**Numbers**
- Add `valid_until` in the Bundles resource
- Add API for Bundle deletion

**Verify**
- Removed support for `sms`, `totp` and `app-push` factor types in Verify push **(breaking change)**


[2020-06-24] Version 5.44.0
---------------------------
**Api**
- Added optional `JitterBufferSize` parameter for creating conference participant
- Added optional `label` property for conference participants
- Added optional parameter `caller_id` for creating conference participant endpoint.

**Autopilot**
- Remove Export resource from Autopilot Assistant

**Conversations**
- Expose Conversation timers

**Monitor**
- Update start/end date filter params to support date-or-time format **(breaking change)**

**Numbers**
- Add `provisionally-approved` as a Supporting Document status

**Preview**
- Removed `Authy` resources. **(breaking change)**

**Supersim**
- Add ready state to the allowed transitions in the sim update call behind the feature flag supersim.ready-state.v1

**Verify**
- Webhook resources added to Verify services and put behind the `api.verify.push` beta feature

**Twiml**
- Add more supported locales for the `Gather` verb.


[2020-06-10] Version 5.43.0
---------------------------
**Library - Docs**
- [PR #524](https://github.com/twilio/twilio-csharp/pull/524): link to handling exceptions. Thanks to [@thinkingserious](https://github.com/thinkingserious)!
- [PR #525](https://github.com/twilio/twilio-csharp/pull/525): link to custom HTTP client instructions. Thanks to [@thinkingserious](https://github.com/thinkingserious)!

**Api**
- Added `pstnconnectivity` to `usage_record` API

**Autopilot**
- Add dialogue_sid param to Query list resource

**Notify**
- delivery_callback_url and delivery_callback_enabled added

**Numbers**
- Add `provisionally-approved` as a Bundle status

**Preview**
- `BrandsInformation` endpoint now returns a single `BrandsInformation`
- Deleted phone number required field in the brand phone number endpoint from `kyc-api`
- Removed insights `preview API` from API Definitions **(breaking change)**
- Added `BrandsInformation` endpoint to query brands information stored in KYC

**Supersim**
- Require a Network Access Profile when creating a Fleet **(breaking change)**


[2020-05-27] Version 5.42.0
---------------------------
**Api**
- Added `reason_conference_ended` and `call_sid_ending_conference` to Conference read/fetch/update
- Fixed some examples to use the correct "TK" SID prefix for Trunk resources.

**Authy**
- Renamed `twilio_authy_sandbox_mode` headers to `twilio_sandbox_mode` **(breaking change)**
- Renamed `Twilio-Authy-*` headers to `Twilio-Veriry-*` **(breaking change)**

**Flex**
- Adding `flex_service_instance_sid` to Flex Configuration

**Preview**
- Removed insights preview API from API Definitions **(breaking change)**
- Added `Channels` endpoint to brand a phone number for BrandedCalls

**Serverless**
- Add Build Sid to Log results

**Supersim**
- Add Network Access Profile resource Networks subresource
- Allow specifying a Data Limit on Fleets

**Trunking**
- Fixed some examples to use the correct "TK" SID prefix for Trunk resources.


[2020-05-20] Version 5.41.1
---------------------------
**Library - Docs**
- [PR #516](https://github.com/twilio/twilio-csharp/pull/516): add troubleshooting guide. Thanks to [@thinkingserious](https://github.com/thinkingserious)!


[2020-05-13] Version 5.41.0
---------------------------
**Library - Chore**
- [PR #521](https://github.com/twilio/twilio-csharp/pull/521): drop the unneeded client region when constructing requests. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Library - Feature**
- [PR #520](https://github.com/twilio/twilio-csharp/pull/520): add regional and edge support. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Api**
- Add optional `emergency_caller_sid` parameter to SIP Domain
- Updated `call_reason` optional property to be treated as PII
- Added optional BYOC Trunk Sid property to Sip Domain API resource

**Autopilot**
- Add Restore resource to Autopilot Assistant

**Contacts**
- Added contacts Create API definition

**Events**
- Subscriptions API initial release

**Numbers**
- Add Evaluations API

**Supersim**
- Allow filtering the Fleets resource by Network Access Profile
- Allow assigning a Network Access Profile when creating and updating a Fleet
- Add Network Access Profiles resource

**Verify**
- Add `CustomCode` optional parameter on Verification creation.
- Add delete action on Service resource.

**Voice**
- Added endpoints for BYOC trunks, SIP connection policies and source IP mappings


[2020-04-29] Version 5.40.0
---------------------------
**Library - Feature**
- [PR #519](https://github.com/twilio/twilio-csharp/pull/519): add details to api exception. Thanks to [@ashish-s](https://github.com/ashish-s)!

**Preview**
- Added `Dispatch` version to `preview`

**Studio**
- Reroute Create Execution for V2 to the V2 downstream

**Supersim**
- Add Networks resource


[2020-04-15] Version 5.39.1
---------------------------
**Library - Chore**
- [PR #515](https://github.com/twilio/twilio-csharp/pull/515): remove S3 URLs from test data. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Api**
- Updated description for property `call_reason` in the call create request

**Contacts**
- Added Read, Delete All, and Delete by SID docs
- Initial Release

**Studio**
- Rename `flow_valid` to `flow_validate`
- Removed `errors` and `warnings` from flows error response and added new property named `details`
- Add Update Execution endpoints to v1 and v2 to end execution via API
- Add new `warnings` attribute v2 flow POST api

**Twiml**
- Add enhanced attribute to use with `speech_model` for the `Gather` verb


[2020-04-01] Version 5.39.0
---------------------------
**Api**
- Add optional 'secure' parameter to SIP Domain

**Authy**
- Added an endpoint to list the challenges of a factor
- Added optional parameter `Push` when updating a service to send the service level push factor configuration

**Bulkexports**
- exposing bulk exports (vault/slapchop) API as public beta API

**Flex**
- Adding `queue_stats_configuration` and `wfm_integrations` to Flex Configuration

**Serverless**
- Add Function Version Content endpoint
- Allow build_sid to be optional for deployment requests

**Supersim**
- Remove `deactivated` status for Super SIM which is replaced by `inactive` **(breaking change)**


[2020-03-18] Version 5.38.0
---------------------------
**Api**
- Add optional `emergency_calling_enabled` parameter to SIP Domain
- Add optional property `call_reason` in the call create request

**Authy**
- Added `friendly_name` and `config` as optional params to Factor update
- Added `config` param to Factor creation **(breaking change)**

**Preview**
- Renamed `SuccessRate` endpoint to `ImpressionsRate` for Branded Calls (fka. Verified by Twilio) **(breaking change)**


[2020-03-04] Version 5.37.6
---------------------------
**Authy**
- Added the `configuration` property to services to return the service level configurations
- Added optional parameter `Push` when creating a service to send the service level push factor configuration
- Remove FactorStrength support for Factors and Challenges **(breaking change)**

**Messaging**
- Correct the alpha sender capabilities property type **(breaking change)**

**Preview**
- Removed `/Devices` register Branded Calls endpoint, as per iOS sample app deprecation **(breaking change)**
- Removed `Twilio-Sandbox-Mode` request header from the Branded Calls endpoints, as not officially supported **(breaking change)**
- Removed `Verify` version from `preview` subdomain in favor to `verify` subdomain. **(breaking change)**

**Serverless**
- Add UI-Editable field to Services

**Supersim**
- Add `inactive` status for Super SIM which is an alias for `deactivated`

**Taskrouter**
- Adding value range to `priority` in task endpoint

**Verify**
- Fix `SendCodeAttempts` type. It's an array of objects instead of a unique object. **(breaking change)**


[2020-02-19] Version 5.37.5
---------------------------
**Api**
- Make call create parameters `async_amd`, `async_amd_status_callback`, and `async_amd_status_callback_method` public
- Add `trunk_sid` as an optional field to Call resource fetch/read responses
- Add property `queue_time` to successful response of create, fetch, and update requests for Call
- Add optional parameter `byoc` to conference participant create.

**Authy**
- Added support for challenges associated to push factors

**Flex**
- Adding `ui_dependencies` to Flex Configuration

**Messaging**
- Deprecate Session API **(breaking change)**

**Numbers**
- Add Regulations API

**Studio**
- Add Execution and Step endpoints to v2 API
- Add webhook_url to Flow response and add new /TestUsers endpoint to v2 API

**Taskrouter**
- Adding `longest_relative_task_age_in_queue` and `longest_relative_task_sid_in_queue` to TaskQueue Real Time Statistics API.
- Add `wait_duration_in_queue_until_accepted` aggregations to TaskQueues Cumulative Statistics endpoint
- Add TaskQueueEnteredDate property to Tasks.

**Video**
- [Composer] Clarification for the composition hooks creation documentation: one source is mandatory, either the `audio_sources` or the `video_layout`, but one of them has to be provided
- [Composer] `audio_sources` type on the composer HTTP POST command, changed from `sid[]` to `string[]` **(breaking change)**
- [Composer] Clarification for the composition creation documentation: one source is mandatory, either the `audio_sources` or the `video_layout`, but one of them has to be provided


[2020-02-05] Version 5.37.4
---------------------------
**Api**
- Making content retention and address retention public
- Update `status` enum for Messages to include 'partially_delivered'

**Authy**
- Added support for push factors

**Autopilot**
- Add one new property in Query i.e dialogue_sid

**Verify**
- Add `SendCodeAttempts` to create verification response.

**Video**
- Clarification in composition creation documentation: one source is mandatory, either `audio_sources` or `video_layout`, but on of them has to be provided

**Twiml**
- Add Polly Neural voices.


[2020-01-22] Version 5.37.3
---------------------------
**Library - Docs**
- [PR #510](https://github.com/twilio/twilio-csharp/pull/510): baseline all the templated markdown docs. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Api**
- Add payments public APIs
- Add optional parameter `byoc` to call create request.

**Flex**
- Updating a Flex Flow `creation_on_message` parameter documentation

**Preview**
-
- Removed Verify v2 from preview in favor of its own namespace as GA **(breaking change)**

**Studio**
- Flow definition type update from string to object

**Verify**
- Add `AppHash` parameter when creating a Verification.
- Add `DoNotShareWarningEnabled` parameter to the Service resource.

**Twiml**
- Add `track` attribute to siprec noun.
- Add attribute `byoc` to `<Number>`


[2020-01-08] Version 5.37.2
---------------------------
**Numbers**
- Add Regulatory Compliance CRUD APIs

**Studio**
- Add parameter validation for Studio v2 Flows API

**Twiml**
- Add support for `speech_model` to `Gather` verb


[2019-12-18] Version 5.37.1
---------------------------
**Preview**
- Add `/Insights/SuccessRate` endpoint for Businesses Branded Calls (Verified by Twilio)

**Studio**
- StudioV2 API in beta

**Verify**
- Add `MailerSid` property to Verify Service resource.

**Wireless**
- Added `data_limit_strategy` to Rate Plan resource.


[2019-12-12] Version 5.37.0
---------------------------
**Api**
- Make `twiml` conditional for create. One of `url`, `twiml`, or `application_sid` is now required.
- Add `bundle_sid` parameter to /IncomingPhoneNumbers API
- Removed discard / obfuscate parameters from ContentRetention, AddressRetention **(breaking change)**

**Chat**
- Added `last_consumed_message_index` and `last_consumption_timestamp` parameters in update method for UserChannel resource **(breaking change)**

**Conversations**
- Add Participant SID to Message properties

**Messaging**
- Fix incorrectly typed capabilities property for ShortCodes. **(breaking change)**


[2019-12-04] Version 5.36.0
---------------------------
**Library**
- [PR #506](https://github.com/twilio/twilio-csharp/pull/506): docs: add supported language versions to README. Thanks to [@childish-sambino](https://github.com/childish-sambino)!
- [PR #504](https://github.com/twilio/twilio-csharp/pull/504): fix: Rename child twiml methods to be the tag name and deprecate old methods. Thanks to [@eshanholtz](https://github.com/eshanholtz)!
- [PR #502](https://github.com/twilio/twilio-csharp/pull/502): fix: add new Twiml type to deal with constructor overloading issue. Thanks to [@craigsdennis](https://github.com/craigsdennis)!

**Api**
- Add optional `twiml` parameter for call create

**Chat**
- Added `delete` method in UserChannel resource

**Conversations**
- Allow Messaging Service update

**Taskrouter**
- Support ReEvaluateTasks parameter on Workflow update

**Twiml**
- Remove unsupported `mixed_track` value from `<Stream>` **(breaking change)**
- Add missing fax `<Receive>` optional attributes


[2019-11-13] Version 5.35.1
---------------------------
**Library**
- [PR #501](https://github.com/twilio/twilio-csharp/pull/501): add TLS 1.2 warning to README. Thanks to [@eshanholtz](https://github.com/eshanholtz)!

**Api**
- Make `persistent_action` parameter public
- Add `twiml` optional private parameter for call create

**Autopilot**
- Add Export resource to Autopilot Assistant.

**Flex**
- Added Integration.RetryCount attribute to Flex Flow
- Updating a Flex Flow `channel_type` options documentation

**Insights**
- Added edges to events and metrics
- Added new endpoint definitions for Events and Metrics

**Messaging**
- **create** support for sender registration
- **fetch** support for fetching a sender
- **update** support for sender verification

**Supersim**
- Add `Direction` filter parameter to list commands endpoint
- Allow filtering commands list by Sim Unique Name
- Add `Iccid` filter parameter to list sims endpoint

**Twiml**
- Add support for `<Refer>` verb


[2019-10-30] Version 5.35.0
---------------------------
**Library**
- [PR #499](https://github.com/twilio/twilio-csharp/pull/499): Update resources after sorting. Thanks to [@childish-sambino](https://github.com/childish-sambino)!
- [PR #498](https://github.com/twilio/twilio-csharp/pull/498): Auto-deploy via Appveyor upon tagged commit to main. Thanks to [@thinkingserious](https://github.com/thinkingserious)!

**Api**
- Add new usage categories to the public api `sms-messages-carrierfees` and `mms-messages-carrierfees`

**Conversations**
- Add ProjectedAddress to Conversations Participant resource

**Preview**
- Implemented different `Sid` for Current Calls (Verified by Twilio), instead of relying in `Call.Sid` from Voice API team **(breaking change)**

**Supersim**
- Add List endpoint to Commands resource for Super Sim Pilot
- Add UsageRecords resource for the Super Sim Pilot
- Add List endpoint to UsageRecords resource for the Super Sim Pilot
- Allow assigning a Sim to a Fleet by Fleet SID or Unique Name for Super SIM Pilot
- Add Update endpoint to Fleets resource for Super Sim Pilot
- Add Fetch endpoint to Commands resource for Super Sim Pilot
- Allow filtering the Sims resource List endpoint by Fleet
- Add List endpoint to Fleets resource for Super Sim Pilot

**Wireless**
- Added `account_sid` to Sim update parameters.

**Twiml**
- Add new locales and voices for `Say` from Polly


[2019-10-16] Version 5.34.0
---------------------------
**Library**
- [PR #496](https://github.com/twilio/twilio-csharp/pull/496): VIDEO-2338 TrackPriority.STANDARD. Thanks to [@innerverse](https://github.com/innerverse)!
- [PR #495](https://github.com/twilio/twilio-csharp/pull/495): Fixed point and project highlight in README. Thanks to [@IrvinDominin](https://github.com/IrvinDominin)!
- [PR #494](https://github.com/twilio/twilio-csharp/pull/494): breaking: Correct video composition date and callback types. Thanks to [@childish-sambino](https://github.com/childish-sambino)! **(breaking change)**

**Api**
- Add new property `attempt` to sms_messages
- Fixed a typo in the documentation for Feedback outcome enum **(breaking change)**
- Update the call price to be optional for deserializing **(breaking change)**

**Flex**
- Added `JanitorEnabled` attribute to Flex Flow
- Change `features_enabled` Flex Configuration key to private **(breaking change)**

**Supersim**
- Add Fetch endpoint to Fleets resource for Super Sim Pilot
- Allow assigning a Sim to a Fleet for Super Sim Pilot
- Add Create endpoint to Fleets resource for Super Sim Pilot

**Twiml**
- Update `<Conference>` rename "whisper" attribute to "coach" **(breaking change)**


[2019-10-02] Version 5.33.1
---------------------------
**Library**
- [PR #493](https://github.com/twilio/twilio-csharp/pull/493): Docs cleanup, clarify .NET support. Thanks to [@dprothero](https://github.com/dprothero)!
- [PR #492](https://github.com/twilio/twilio-csharp/pull/492): add validation for urls with non-standard ports. Thanks to [@eshanholtz](https://github.com/eshanholtz)!

**Conversations**
- Add media to Conversations Message resource

**Supersim**
- Add List endpoint to Sims resource for Super Sim Pilot


[2019-09-18] Version 5.33.0
----------------------------
**Numbers**
- Add v2 of the Identites API

**Preview**
- Changed authentication method for SDK Trusted Comms endpoints: `/CPS`, `/CurrentCall`, and `/Devices`. Please use `Authorization: Bearer <xCNAM JWT>` **(breaking change)**

**Voice**
- Add Recordings endpoints


[2019-09-04] Version 5.32.0
----------------------------
**Api**
-  Pass Twiml in call update request

**Conversations**
- Add attributes to Conversations resources

**Flex**
- Adding `features_enabled` and `serverless_service_sids` to Flex Configuration

**Messaging**
- Message API required params updated **(breaking change)**

**Preview**
- Added support for the optional `CallSid` to `/BrandedCalls` endpoint


[2019-08-21] Version 5.31.4
----------------------------
**Library**
- [PR #490](https://github.com/twilio/twilio-csharp/pull/490): Update the Flex domain name to be 'flex-api'. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Conversations**
- Add Chat Conversation SID to conversation default output properties

**Flex**
- Adding `outbound_call_flows` object to Flex Configuration
- Adding read and fetch to channels API

**Supersim**
- Add Sims and Commands resources for the Super Sim Pilot

**Sync**
- Added configuration option for enabling webhooks from REST.

**Wireless**
- Added `usage_notification_method` and `usage_notification_url` properties to `rate_plan`.

**Twiml**
- Add support for `ach-debit` transactions in `Pay` verb


[2019-08-05] Version 5.31.3
----------------------------
**Preview**
- Added support for the header `Twilio-Sandbox-Mode` to mock all Voice dependencies

**Twiml**
- Add support for `<Siprec>` noun
- Add support for `<Stream>` noun
- Create verbs `<Start>` and `<Stop>`


[2019-07-24] Version 5.31.2
----------------------------
**Insights**
- Added `properties` to summary.

**Preview**
- Added endpoint to brand a call without initiating it, so it can be initiated manually by the Customer

**Twiml**
- Update `<Conference>` recording events **(breaking change)**


[2019-07-10] Version 5.31.1
----------------------------
**Library**
- [PR #485](https://github.com/twilio/twilio-csharp/pull/485): Add urls property in ice servers. Thanks to [@FMV1491](https://github.com/FMV1491)!

**Api**
- Make `friendly_name` optional for applications create
- Add new property `as_of` date to Usage Record API calls

**Wireless**
- Added Usage Records resource.


[2019-06-26] Version 5.31.0
----------------------------
**Autopilot**
- Adds two new properties in Assistant i.e needs_model_build and development_stage

**Preview**
- Changed phone numbers from _URL|Path_ to `X-XCNAM-Sensitive` headers **(breaking change)**

**Verify**
- Add `MessagingConfiguration` resource to verify service


[2019-06-12] Version 5.30.0
----------------------------
**Autopilot**
- Add Webhooks resource to Autopilot Assistant.

**Flex**
- Added missing 'custom' type to Flex Flow
- Adding `integrations` to Flex Configuration

**Insights**
- Added attributes to summary.

**Messaging**
- Message API Create updated with conditional params **(breaking change)**

**Proxy**
- Document that Proxy will return a maximum of 100 records for read/list endpoints **(breaking change)**
- Remove non-updatable property parameters for Session update (mode, participants) **(breaking change)**

**Sync**
- Added reachability debouncing configuration options.

**Verify**
- Add `RateLimits` and `Buckets` resources to Verify Services
- Add `RateLimits` optional parameter on `Verification` creation.

**Twiml**
- Fix `<Room>` participantIdentity casing


[2019-05-29] Version 5.29.1
----------------------------
**Library**
- [PR #482](https://github.com/twilio/twilio-csharp/pull/482): Add SubscribeRule and SubscribeRulesUpdate. Thanks to [@innerverse](https://github.com/innerverse)!
- [PR #481](https://github.com/twilio/twilio-csharp/pull/481): Perform case-insensitive check for 'client:' prefix. Thanks to [@childish-sambino](https://github.com/childish-sambino)!
- [PR #456](https://github.com/twilio/twilio-csharp/pull/456): Updated Twilio.Types.Client implementation of IEndpoint to function as expected. Thanks to [@pwoosam](https://github.com/pwoosam)!
- [PR #480](https://github.com/twilio/twilio-csharp/pull/480): Update the call create 'from' param to be endpoint type for client identifier support. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Verify**
- Add `approved` to status enum


[2019-05-15] Version 5.29.0
----------------------------
**Library**
- [PR #478](https://github.com/twilio/twilio-csharp/pull/478): Handle 'null' string enum lists during JSON deserialization. Thanks to [@childish-sambino](https://github.com/childish-sambino)!

**Api**
- Make `method` optional for queue members update

**Chat**
- Removed `webhook.*.format` update parameters in Service resource from public library visibility in v1 **(breaking change)**

**Insights**
- Added client metrics as sdk_edge to summary.
- Added optional query param processing_state.

**Numbers**
- Add addtional metadata fields on a Document
- Add status callback fields and parameters

**Taskrouter**
- Added `channel_optimized_routing` attribute to task-channel endpoint

**Video**
- [Rooms] Add Video Subscription API

**Wireless**
- Added `imei` to Data Session resource.
- Remove `imeisv` from Data Session resource. **(breaking change)**


[2019-05-01] Version 5.28.4
----------------------------
**Serverless**
- Documentation

**Wireless**
- Added `imeisv` to Data Session resource.


[2019-04-24] Version 5.28.3
----------------------------
**Api**
- Add `verified` property to Addresses

**Numbers**
- Add API for Identites and documents

**Proxy**
- Add in use count on number instance


[2019-04-12] Version 5.28.2
----------------------------
**Serverless**
- Serverless scaffolding


[2019-04-12] Version 5.28.1
----------------------------
**Library**
- PR #476: Add a comment and test to verify thread safety of async HTTP requests. Thanks to @childish-sambino!
- PR #474: SystemNetHttpClient.MakeRequestAsync is thread safe. Thanks to @ysemerikov!

**Flex**
- Adding PluginService to Flex Configuration

**Numbers**
- Add API for Proof of Addresses

**Proxy**
- Clarify documentation for Service and Session fetch


[2019-03-28] Version 5.28.0
----------------------------
**Library**
- PR #470: Revert "Add Google Tag Manager to generated docs". Thanks to @dprothero!
- PR #469: Add Google Tag Manager to generated docs (will add google analytics). Thanks to @dprothero!

**Api**
- Remove optional `if_machine` call create parameter from helper libraries **(breaking change)**
- Changed `call_sid` path parameter type on QueueMember fetch and update requests **(breaking change)**

**Voice**
- changed file names to dialing_permissions prefix **(breaking change)**

**Wireless**
- Added `ResetStatus` property to Sim resource to allow resetting connectivity via the API.


[2019-03-15] Version 5.27.2
----------------------------
**Library**
- PR #468: Add Help Center and Support Ticket links to the README. Thanks to @childish-sambino!

**Api**
- Add `machine_detection_speech_threshold`, `machine_detection_speech_end_threshold`, `machine_detection_silence_timeout` optional params to Call create request

**Flex**
- Adding Flex Channel Orchestration
- Adding Flex Flow


[2019-03-06] Version 5.27.1
----------------------------
**Twiml**
- Add `de1` to `<Conference>` regions


[2019-03-01] Version 5.27.0
----------------------------
**Api**
- Make conference participant preview parameters public

**Authy**
- Added support for FactorType and FactorStrength for Factors and Challenges

**Iam**
- First public release

**Verify**
- Add endpoint to update/cancel a Verification **(breaking change)**

**Video**
- [Composer] Make RoomSid mandatory **(breaking change)**
- [Composer] Add `enqueued` state to Composition

**Twiml**
- Update message body to not be required for TwiML `Dial` noun.


[2019-02-15] Version 5.26.1
----------------------------
**Api**
- Add `force_opt_in` optional param to Messages create request
- Add agent conference category to usage records

**Flex**
- First public release

**Taskrouter**
- Adding `reject_pending_reservations` to worker update endpoint
- Added `event_date_ms` and `worker_time_in_previous_activity_ms` to Events API response
- Add ability to filter events by TaskChannel

**Verify**
- Add `EnablePsd2` optional parameter for PSD2 on Service resource creation or update.
- Add `Amount`, `Payee` optional parameters for PSD2.


[2019-02-04] Version 5.26.0
----------------------------
**Library**
- PR #464: Switch body validator to use hex instead of base64. Thanks to @cjcodes!

**Video**
- [Recordings] Add media type filter to list operation
- [Composer] Filter Composition Hook resources by FriendlyName

**Twiml**
- Update `language` enum for `Gather` to fix language code for Filipino (Philippines) and include additional supported languages **(breaking change)**


[2019-01-11] Version 5.25.1
----------------------------
**Verify**
- Add `lookup` information in the response when creating a new verification (depends on the LookupEnabled flag being enabled at the service level)
- Add `VerificationSid` optional parameter on Verification check.


[2019-01-10] Version 5.25.0
----------------------------
**Chat**
- Mark Member attributes as PII

**Proxy**
- Remove unsupported query parameters **(breaking change)**
- Remove invalid session statuses in doc


[2019-01-02] Version 5.24.1
----------------------------
**Library**
- PR #459: Remove unused dependency Microsoft.IdentityModel.Logging. Thanks to @yannieyip!

**Insights**
- Initial revision.


[2018-12-14] Version 5.24.0
----------------------------
**Authy**
- Reverted the change to `FactorType` and `FormType`, avoiding conflicts with Helper Libraries reserved words (`type`) **(breaking change)**

**Proxy**
- Remove incorrect parameter for Session List

**Studio**
- Support date created filtering on list of executions

**Taskrouter**
- Adding ability to Create, Modify and Delete Task Channels.

**Verify**
- Add `SkipSmsToLandlines`, `TtsName`, `DtmfInputRequired` optional parameters on Service resource creation or update.

**Wireless**
- Added delete action on Command resource.
- Added delete action on Sim resource.

**Twiml**
- Change `currency` from enum to string for `Pay` **(breaking change)**


[2018-11-30] Version 5.23.0
----------------------------
**Api**
- Add `interactive_data` optional param to Messages create request

**Authy**
- Required authentication for `/v1/Forms/{type}` endpoint **(breaking change)**
- Removed `Challenge.reason` to `Challenge.responded_reason`
- Removed `verification_sid` from Challenge responses
- Removed `config` param from the Factor creation
- Replaced all occurrences of `FactorType` and `FormType` in favor of a unified `Type` **(breaking change)**

**Chat**
- Add Member attributes

**Preview**
- Removed `Authy` version from `preview` subdomain in favor to `authy` subdomain. **(breaking change)**

**Verify**
- Add `CustomCode` optional parameter on Verication creation.


[2018-11-16] Version 5.22.0
----------------------------
**Messaging**
- Session API

**Twiml**
- Change `master-card` to `mastercard` as `cardType` for `Pay` and `Prompt`, remove attribute `credential_sid` from `Pay` **(breaking change)**


[2018-10-28] Version 5.21.0
----------------------------
**Library**
- PR #450: Updates target to netstandard 2.0. Thanks to @emagers!

**Api**
- Add new Balance resource:
    - url: '/v1/Accounts/{account sid}/Balance'
    - supported methods: GET
    - returns the balance of the account

**Proxy**
- Add chat_instance_sid to Service

**Verify**
- Add `Locale` optional parameter on Verification creation.


[2018-10-15] Version 5.20.1
----------------------------
**Api**
- Add <Pay> Verb Transactions category to usage records

**Twiml**
- Add support for `Pay` verb


[2018-10-15] Version 5.20.0
----------------------------
**Api**
- Add `coaching` and `call_sid_to_coach` to participant properties, create and update requests.

**Authy**
- Set public library visibility, and added PII stanza
- Dropped support for `FactorType` param given new Factor prefixes **(breaking change)**
- Supported `DELETE` actions for Authy resources
- Move Authy Services resources to `authy` subdomain

**Autopilot**
- Introduce `autopilot` subdomain with all resources from `preview.understand`

**Preview**
- Renamed Understand intent to task **(breaking change)**
- Deprecated Authy endpoints from `preview` to `authy` subdomain

**Taskrouter**
- Allow TaskQueue ReservationActivitySid and AssignmentActivitySid to not be configured for MultiTask Workspaces

**Verify**
- Add `LookupEnabled` optional parameter on Service resource creation or update.
- Add `SendDigits` optional parameter on Verification creation.
- Add delete action on Service resourse.

**Twiml**
- Add custom parameters to TwiML `Client` noun and renamed the optional `name` field to `identity`. This is a breaking change in Ruby, and applications will need to transition from `dial.client ''` and `dial.client 'alice'` formats to `dial.client` and `dial.client(identity: alice)` formats. **(breaking change)**


[2018-10-04] Version 5.19.0
----------------------------
**Twiml**
- Add `debug` to `Gather`


[2018-10-02] Version 5.18.0
----------------------------
**Library**
- PR #449: Update Makefile to run tests on netcoreapp2.0. Thanks to @yannieyip!
- PR #448: Bump .NET Core version for Travis CI. Thanks to @dprothero!
- PR #447: Bump Newtonsoft.Json to 10.0.1 to try to fix #431. Thanks to @dprothero!

**Api**
- Set `call_sid_to_coach` parameter in participant to be `preview`

**Preview**
- Renamed response headers for Challenge and Factors Signatures
- Supported `totp` in Authy preview endpoints
- Allowed `latest` in Authy Challenges endpoints

**Video**
- [Composer] Add Composition Hook resources

**Voice**
- changed path param name from parent_iso_code to iso_code for highrisk_special_prefixes api **(breaking change)**
- added geo permissions public api

**Twiml**
- Add `participantIdentity` to `Room`


[2018-09-20] Version 5.17.0
----------------------------
**Preview**
- Add `Form` resource to Authy preview given a `form_type`
- Add Authy initial api-definitions in the 4 main resources: Services, Entities, Factors, Challenges

**Pricing**
- add voice_numbers resource (v2)

**Verify**
- Move from preview to beta **(breaking change)**


[2018-09-07] Version 5.16.4
----------------------------
**Library**
- PR #444: VCORE-3651 Add support for *for* attribute in twiml element. Thanks to @nmahure!


[2018-08-31] Version 5.16.3
----------------------------
**Library**
- PR #446: fix typo. Thanks to @jbonner89!

**Api**
- Add `call_sid_to_coach` parameter to participant create request
- Add `voice_receive_mode` param to IncomingPhoneNumbers create

**Video**
- [Recordings] Expose `offset` property in resource


[2018-08-23] Version 5.16.2
----------------------------
**Library**
- PR #443: BPIPE-260. Thanks to @jbonner89!

**Chat**
- Add User Channel instance resource


[2018-08-17] Version 5.16.1
----------------------------
**Api**
- Add Proxy Active Sessions category to usage records


[2018-08-17] Version 5.16.0
----------------------------
**Library**
- PR #441: add OutboundPrefixPriceWithOrigin class. Thanks to @jbonner89!

**Preview**
- Add `Actions` endpoints and remove `ResponseUrl` from assistants on the Understand api

**Pricing**
- add voice_country resource (v2)


[2018-08-09] Version 5.15.1
----------------------------
**Library**
- PR #440: Add Linq to referenced assemblies. Thanks to @cjcodes!

**Preview**
- Add new Intent Statistics endpoint
- Remove `ttl` from Assistants

**Studio**
- Studio is now GA


[2018-08-03] Version 5.15.0
----------------------------
**Library**
- PR #434: Tag and push Docker latest image when deploying with TravisCI. Thanks to @jonatasbaldin!

**Chat**
- Make message From field updatable
- Add REST API webhooks

**Notify**
- Removing deprecated `segments`, `users`, `segment_memberships`, `user_bindings` classes from helper libraries. **(breaking change)**

**Twiml**
- Add `Connect` and `Room` for Programmable Video Rooms


[2018-07-26] Version 5.14.1
----------------------------
**Library**
- PR #435: Add support for xml: namespaced properties. Thanks to @cjcodes!

**Api**
- Add support for sip domains to map credential lists for registrations

**Preview**
- Remove `ttl` from Assistants

**Proxy**
- Enable setting a proxy number as reserved

**Video**
- Add `group-small` room type

**Twiml**
- Add support for SSML lang tag on Say verb


[2018-07-16] Version 5.14.0
----------------------------
**Library**
- PR #433: POST doesn't receive params and body for body validation. Thanks to @cjcodes!

**Twiml**
- Add support for SSML on Say verb, the message body is changed to be optional **(breaking change)**


[2018-07-11] Version 5.13.8
----------------------------
**Api**
- Add `cidr_prefix_length` param to SIP IpAddresses API

**Studio**
- Add new /Execution endpoints to begin Engagement -> Execution migration

**Video**
- [Rooms] Allow deletion of individual recordings from a room


[2018-07-05] Version 5.13.7
----------------------------
**Library**
- PR #427: Add Dockerfile and related changes to build the Docker image. Thanks to @jonatasbaldin!

**Api**
- Release `Call Recording Controls` feature support in helper libraries
- Add Voice Insights sub-category keys to usage records


[2018-06-29] Version 5.13.6
----------------------------
**Library**
- PR #430: Add helper method for testing if new SSL cert can be consumed. Thanks to @cjcodes!
- PR #428: Add a method for validating request body. Thanks to @cjcodes!


[2018-06-21] Version 5.13.5
----------------------------
**Library**
- PR #426: Allow adding TwiML children with generic tag names. Thanks to @yannieyip!

**Api**
- Add Fraud Lookups category to usage records

**Video**
- Allow user to set `ContentDisposition` when obtaining media URLs for Room Recordings and Compositions
- Add Composition Settings resource


[2018-06-15] Version 5.13.4
----------------------------
**Library**
- PR #425: Add AddText method to TwiML classes. Thanks to @ekarson!

**Twiml**
- Add methods to helper libraries to inject arbitrary text under a TwiML node


[2018-06-04] Version 5.13.3
----------------------------
**Chat**
- Add Binding and UserBinding documentation

**Lookups**
- Add back support for `fraud` lookup type


[2018-05-25] Version 5.13.2
----------------------------
**Studio**
- Add endpoint to delete engagements

**Trunking**
- Added cnam_lookup_enabled parameter to Trunk resource.
- Added case-insensitivity for recording parameter to Trunk resource.


[2018-05-18] Version 5.13.1
----------------------------
**Api**
- Add more programmable video categories to usage records
- Add 'include_subaccounts' parameter to all variation of usage_record fetch


[2018-05-11] Version 5.13.0
----------------------------
**Chat**
- Add Channel Webhooks resource

**Monitor**
- Update event filtering to support date/time **(breaking change)**


[2018-05-04] Version 5.12.1
----------------------------
**Wireless**
- Updated `maturity` to `ga` for all wireless apis


[2018-04-27] Version 5.12.0
----------------------------
**Video**
- Redesign API by adding custom `VideoLayout` object. **(breaking change)**


[2018-04-20] Version 5.11.1
----------------------------
**Twiml**
- Gather input Enum: remove unnecessary "dtmf speech" value as you can now specify multiple enum values for this parameter and both "dtmf" and "speech" are already available.


[2018-04-13] Version 5.11.0
----------------------------
**Library**
- PR #418: Add incoming.allow to AccessToken VoiceGrant. Thanks to @ryan-rowland!

**Preview**
- Support for Understand V2 APIs - renames various resources and adds new fields

**Studio**
- Change parameters type from string to object in engagement resource

**Video**
- [Recordings] Change `size` type to `long`. **(breaking change)**


[2018-03-22] Version 5.10.0
----------------------------
**Lookups**
- Disable support for `fraud` lookups *(breaking change)*

**Preview**
- Add `BuildDuration` and `ErrorCode` to Understand ModelBuild

**Studio**
- Add new /Context endpoint for step and engagement resources.


[2018-03-09] Version 5.9.8
---------------------------
**Api**
- Add `caller_id` param to Outbound Calls API
- Release `trim` recording Outbound Calls API functionality in helper libraries

**Video**
- [composer] Add `room_sid` to Composition resource.

**Twiml**
- Adds support for passing in multiple input type enums when setting `input` on `Gather`


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

- [Full API Documentation](https://twilio.github.io/twilio-csharp/)
