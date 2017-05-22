# Upgrade Guide

_After `5.0.0` all `MINOR` and `MAJOR` version bumps will have upgrade notes
posted here._

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

