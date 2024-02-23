# Upgrade Guide

_`MAJOR` version bumps will have upgrade notes posted here._

[2024-02-XX] 6.x.x to 7.x.x
----------------------------
### Overview

#### Twilio Csharp Helper Library’s major version 7.0.0 is now available. 
#### The Csharp Helper Library version 7.0.0 includes a breaking change related to .NET support.
#### We ensured that you can upgrade to Csharp helper Library 7.0.0 version without any api breaking changes

Support for JSON payloads has been added in the request body

[2022-11-XX] 5.x.x to 6.x.x
---------------------------
### Overview

#### Twilio Csharp Helper Library’s major version 6.0.1 is now available. We ensured that you can upgrade to Csharp helper Library 6.0.1 version without any breaking changes

Behind the scenes Csharp Helper is now auto-generated via OpenAPI with this release. This enables us to rapidly add new features and enhance consistency across versions and languages.

[2017-11-XX] 5.8.x to 5.9.x
---------------------------

### CHANGED - Make `data` an optional parameter on Sync Document/List Item/Map Item update.

#### Rationale
This was changed to add support for time-to-live to Sync objects. Users can now either provide either `data`, `ttl`, or both.
This only affects users who pass the `twilioRestClient` parameter to the _Affected Resources_ below.

#### Affected Resources
- DocumentResource.Update(...)
- SyncListItemResource.Update(...)
- SyncMapItemResource.Update(...)

#### 5.8.x
```cs
using Twilio.Rest.Sync.V1.Service;
using Twilio.Rest.Sync.V1.Service.SyncList;
using Twilio.Rest.Sync.V1.Service.SyncMap;

DocumentResource.Update("IS123", "ET123", "{}", twilioRestClient);
SyncListItemResource.Update("IS123", "ES123", 1, "{}", twilioRestClient);
SyncMapItemResource.Update("IS123", "MP123", "myKey" "{}", twilioRestClient);
```

#### 5.9.x
```cs
using Twilio.Rest.Sync.V1.Service;
using Twilio.Rest.Sync.V1.Service.SyncList;
using Twilio.Rest.Sync.V1.Service.SyncMap;

DocumentResource.Update("IS123", "ET123", "{}", null, twilioRestClient);
SyncListItemResource.Update("IS123", "ES123", 1, "{}", null, twilioRestClient);
SyncMapItemResource.Update("IS123", "MP123", "myKey" "{}", null, twilioRestClient);
```


[2017-10-13] 5.7.x to 5.8.x
---------------------------

### CHANGED - TwiML namespaces are now nested under TwiML type

#### Rationale
We decided to reorganize the TwiML directory now that we are generating TwiML resources for clarity
as we add more and more twiml elements and types of twiml elements.

#### Affected Resources
Previously all TwiML resources were under the `Twilio.TwiML` namespace.
- Moved to `Twilio.TwiML.Voice`
  - Dial
  - Gather
- Moved to `Twilio.TwiML.Messaging`
  - Message

#### 5.7.x
```cs
using Twilio.TwiML;

var vr = new VoiceResponse();
var mr = new MessagingResponse();

var gather = new Gather();
var dial = new Dial();
var msg = new Message();
```

#### 5.8.x
```cs
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Twilio.TwiML.Messaging;

// Still in Twilio.TwiML
var vr = new VoiceResponse();
var mr = new MessagingResponse();

// Now in Twilio.TwiML.Voice
var gather = new Gather();
var dial = new Dial();

// Now in Twilio.TwiML.Messaging
var msg = new Message();
```

### CHANGED - TwiML classes now expect `Uri` type for uri parameters

#### Rationale
Generating TwiML classes allowed us to use the correct types where appropriate to give a better IDE
experience. While most custom types have been written in a backwards compatible way to still accept
string values, we could not do the same for the `System.Uri` type.

#### Affected Resources
- VoiceResponse
- MesagingResponse
- Message
- Gather
- Dial

#### 5.7.x
```cs
using Twilio.TwiML;

var vr = new VoiceResponse().Dial(recordingStatusCallback: "http://example.com/")
                            .Enqueue(waitUrl: "http://example.com/");

var msg = new Message(statusCallback: "http://example.com/");
```

#### 5.8.x
```
using Twilio.TwiML;
using Twilio.TwiML.Messaging;
using System;

var vr = new VoiceResponse().Dial(recordingStatusCallback: new Uri("http://example.com/"))
                            .Enqueue(waitUrl: new Uri("http://example.com/"));

var msg = new Message(statusCallback: new Uri("http://example.com/"));
```


[2017-09-29] 5.6.x to 5.7.x
---------------------------

### CHANGED - Make `body` and optional parameter on Chat Message creation

#### Rationale
This was changed to add support for sending media in Chat messages, users can now either provide a `body` or a `media_sid`.

#### 5.6.x
```cs
using Twilio.Rest.Chat.V2.Message;

var newMessage = MessageResource.Create("IS123", "CH123", "this is the body", from: "me");
```

#### 5.5.x
```cs
using Twilio.Rest.Chat.V2.Message;

var newMessage = MessageResource.Create("IS123", "CH123", from:"me", body: "this is the body");
```


[2017-05-22] 5.4.x to 5.5.x
---------------------------

### CHANGED - Rename room `Recordings` class to `RoomRecordings`

#### Rationale
This was done to avoid a class name conflict with another resource.

#### 5.4.x
```cs
using Twilio.Rest.Video.V1.Room;

var roomRecordings = RecordingResource.Read();
```

#### 5.5.x
```cs
using Twilio.Rest.Video.V1.Room;

var roomRecordings = RoomRecordingResource.Read();
```

