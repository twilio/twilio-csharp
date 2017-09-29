# Upgrade Guide

_After `5.0.0` all `MINOR` and `MAJOR` version bumps will have upgrade notes
posted here._

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

