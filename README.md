# twilio-csharp

[![Build status](https://ci.appveyor.com/api/projects/status/e0qcgl8r6rid4akb/branch/master?svg=true)](https://ci.appveyor.com/project/TwilioAPI/twilio-csharp-lum8a/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Twilio.svg)](https://www.nuget.org/packages/Twilio)

# Twilio REST API and TwiML Libraries for .NET

Twilio provides a simple HTTP-based API for sending and receiving phone calls and text messages. Learn more on [twilio.com][apidocs]

More documentation for this library can be found [here][libdocs].

## Supported .NET versions

This library supports .NET applications written in C#, VB.Net, and F# that utilize .NET Framework 3.5 or above or any [supported version](https://dotnet.microsoft.com/platform/support/policy/dotnet-core#lifecycle) of .NET Core (.NET Standard v1.4).

## Adding Twilio libraries to your .NET project

The best and easiest way to add the Twilio libraries to your .NET project is to use the NuGet package manager.

### With Visual Studio IDE

From within Visual Studio, you can use the NuGet GUI to search for and install the Twilio NuGet package. Or, as a shortcut, simply type the following command into the Package Manager Console:

    Install-Package Twilio

### With .NET Core Command Line Tools

If you are building with the .NET Core command line tools, then you can run the following command from within your project directory:

    dotnet add package Twilio

## Versions

`twilio-csharp` uses a modified version of [Semantic Versioning](https://semver.org) for all changes. [See this document](VERSIONS.md) for details.

### Migrating from earlier versions

See the migration guide [here][migrating]. Also, if you were using the Twilio.Mvc package, that has been replaced by the [Twilio.AspNet.Mvc][aspnet] package which is compatible with this version of the library.

### Alpha Version (deprecated)

The alpha version is no longer necessary. All Twilio products are available in the main-line library.

## Sample Usage

The examples below show how to have your application initiate and outbound phone call and send an SMS message using the Twilio .NET helper library:
```csharp
TwilioClient.Init("ACCOUNT_SID", "AUTH_TOKEN");

var call = CallResource.Create(
    new PhoneNumber("+11234567890"),
    from: new PhoneNumber("+10987654321"),
    url: new Uri("https://my.twiml.here")
);
Console.WriteLine(call.Sid);

var message = MessageResource.Create(
    new PhoneNumber("+11234567890"),
    from: new PhoneNumber("+10987654321"),
    body: "Hello World!"
);
Console.WriteLine(message.Sid);
```

## Generating TwiML

To control phone calls, your application needs to output [TwiML][twiml].

```csharp
// TwiML classes can be created as standalone elements
var gather = new Gather(numDigits: 1, action: new Uri("hello-monkey-handle-key.cshtml"), method: HttpMethod.Post)
    .Say("To speak to a real monkey, press 1. Press 2 to record your own monkey howl. Press any other key to start over.");

// Attributes can be set directly on the object
gather.Timeout = 100;
gather.MaxSpeechTime = 200

// Arbitrary attributes can be set by calling set/getOption
var dial = new Dial().SetOption("myAttribute", 200)
                     .SetOption("newAttribute", false);

// Or can be created and attached to a response directly using helper methods
var response = new VoiceResponse()
    .Say("Hello Monkey")
    .Play(new Uri("http://demo.twilio.com/hellomonkey/monkey.mp3"))
    .Append(gather)
    .Append(dial);
    
// Serialize the TwiML objects to XML string
Console.WriteLine(response);

/*
<?xml version="1.0" encoding="utf-8"?>
<Response>
  <Say>Hello Monkey</Say>
  <Play>http://demo.twilio.com/hellomonkey/monkey.mp3</Play>
  <Gather numDigits="1" action="hello-monkey-handle-key.cshtml" method="POST" timeout="100" maxSpeechTime="200">
    <Say>To speak to a real monkey, press 1. Press 2 to record your own monkey howl. Press any other key to start over.</Say>
  </Gather>
  <Dial myAttribute="200" newAttribute="false"></Dial>
</Response>
*/
```

## Docker Image

The `Dockerfile` present in this repository and its respective `twilio/twilio-csharp` Docker image are currently used by Twilio for testing purposes only.

## Getting help

If you need help installing or using the library, please check the [Twilio Support Help Center](https://support.twilio.com) first, and [file a support ticket](https://twilio.com/help/contact) if you don't find an answer to your question.

If you've instead found a bug in the library or would like new features added, go ahead and open issues or pull requests against this repo!

[twilio]: https://www.twilio.com
[apidocs]: https://www.twilio.com/docs/api
[twiml]: https://www.twilio.com/docs/api/twiml
[libdocs]: https://twilio.github.io/twilio-csharp
[migrating]: https://www.twilio.com/docs/libraries/csharp/migrating-your-csharp-dot-net-application-twilio-sdk-4x-5x
[aspnet]: https://github.com/twilio/twilio-aspnet
