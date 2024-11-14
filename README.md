# twilio-csharp

[![Test](https://github.com/twilio/twilio-csharp/actions/workflows/test-and-deploy.yml/badge.svg)](https://github.com/twilio/twilio-csharp/actions/workflows/test-and-deploy.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=twilio_twilio-csharp&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=twilio_twilio-csharp)
[![NuGet](https://img.shields.io/nuget/v/Twilio.svg)](https://www.nuget.org/packages/Twilio)
[![Learn with TwilioQuest](https://img.shields.io/static/v1?label=TwilioQuest&message=Learn%20to%20contribute%21&color=F22F46&labelColor=1f243c&style=flat-square&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAASFBMVEUAAAAZGRkcHBwjIyMoKCgAAABgYGBoaGiAgICMjIyzs7PJycnMzMzNzc3UoBfd3d3m5ubqrhfrMEDu7u739/f4vSb/3AD///9tbdyEAAAABXRSTlMAAAAAAMJrBrEAAAKoSURBVHgB7ZrRcuI6EESdyxXGYoNFvMD//+l2bSszRgyUYpFAsXOeiJGmj4NkuWx1Qeh+Ekl9DgEXOBwOx+Px5xyQhDykfgq4wG63MxxaR4ddIkg6Ul3g84vCIcjPBA5gmUMeXESrlukuoK33+33uID8TWeLAdOWsKpJYzwVMB7bOzYSGOciyUlXSn0/ABXTosJ1M1SbypZ4O4MbZuIDMU02PMbauhhHMHXbmebmALIiEbbbbbUrpF1gwE9kFfRNAJaP+FQEXCCTGyJ4ngDrjOFo3jEL5JdqjF/pueR4cCeCGgAtwmuRS6gDwaRiGvu+DMFwSBLTE3+jF8JyuV1okPZ+AC4hDFhCHyHQjdjPHUKFDlHSJkHQXMB3KpSwXNGJPcwwTdZiXlRN0gSp0zpWxNtM0beYE0nRH6QIbO7rawwXaBYz0j78gxjokDuv12gVeUuBD0MDi0OQCLvDaAho4juP1Q/jkAncXqIcCfd+7gAu4QLMACCLxpRsSuQh0igu0C9Svhi7weAGZg50L3IE3cai4IfkNZAC8dfdhsUD3CgKBVC9JE5ABAFzg4QL/taYPAAWrHdYcgfLaIgAXWJ7OV38n1LEF8tt2TH29E+QAoDoO5Ve/LtCQDmKM9kPbvCEBApK+IXzbcSJ0cIGF6e8gpcRhUDogWZ8JnaWjPXc/fNnBBUKRngiHgTUSivSzDRDgHZQOLvBQgf8rRt+VdBUUhwkU6VpJ+xcOwQUqZr+mR0kvBUgv6cB4+37hQAkXqE8PwGisGhJtN4xAHMzrsgvI7rccXqSvKh6jltGlrOHA3Xk1At3LC4QiPdX9/0ndHpGVvTjR4bZA1ypAKgVcwE5vx74ulwIugDt8e/X7JgfkucBMIAr26ndnB4UCLnDOqvteQsHlgX9N4A+c4cW3DXSPbwAAAABJRU5ErkJggg==)](https://twil.io/learn-open-source)

## Twilio REST API and TwiML Libraries for .NET

Twilio provides a HTTP-based API for sending and receiving phone calls and text messages. Learn more on [twilio.com][apidocs].

More documentation for this library can be found [here][libdocs].

## Versions

`twilio-csharp` uses a modified version of [Semantic Versioning](https://semver.org) for all changes. [See this document](VERSIONS.md) for details.

### Migrate from earlier versions

See the migration guide [here](./UPGRADE.md). Also, if you were using the `Twilio.Mvc` package, that has been replaced by the [Twilio.AspNet.Mvc][aspnet] package which is compatible with this version of the library.

### TLS 1.2 Requirements

New accounts and subaccounts are now required to use TLS 1.2 when accessing the REST API. ["Upgrade Required" errors](https://www.twilio.com/docs/api/errors/20426) indicate that TLS 1.0/1.1 is being used. With .NET, you can enable TLS 1.2 using this setting:

```csharp
System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
```

### Supported .NET versions

This library supports .NET applications that utilize .NET6+.

## Installation

The best and easiest way to add the Twilio libraries to your .NET project is to use the NuGet package manager.

### With Visual Studio IDE

From within Visual Studio, you can use the NuGet GUI to search for and install the Twilio NuGet package. Or, as a shortcut, simply type the following command into the Package Manager Console:

```shell
Install-Package Twilio
```

### With .NET Core Command Line Tools

If you are building with the .NET Core command line tools, then you can run the following command from within your project directory:

```shell
dotnet add package Twilio
```

## Sample usage

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
## OAuth Feature for Twilio APIs
We are introducing Client Credentials Flow-based OAuth 2.0 authentication. This feature is currently in beta and its implementation is subject to change.

API examples [here](https://github.com/twilio/twilio-csharp/blob/main/examples/PublicOAuthAuthentication.md)

Organisation API examples [here](https://github.com/twilio/twilio-csharp/blob/main/examples/BearerTokenAuthentication.md)

## Specify Region and/or Edge

To take advantage of Twilio's [Global Infrastructure](https://www.twilio.com/docs/global-infrastructure), specify the target Region and/or Edge for the client:

```csharp
TwilioClient.SetRegion("au1");
TwilioClient.SetEdge("sydney");
```

This will result in the `hostname` transforming from `api.twilio.com` to `api.sydney.au1.twilio.com`. Use appropriate client depending on the type of authentication used

## Enable debug logging

There are two ways to enable debug logging in the default HTTP client. You can create an environment variable called `TWILIO_LOG_LEVEL` and set it to `debug` or you can set the LogLevel variable on the client as debug:

```csharp
TwilioClient.SetLogLevel("debug");
```

## Handle exceptions

For an example on how to handle exceptions in this helper library, please see the [Twilio documentation](https://www.twilio.com/docs/libraries/csharp-dotnet/usage-guide#handle-errors).

## Generate TwiML

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

## Use a custom HTTP Client

To use a custom HTTP client with this helper library, please see the [advanced example of how to do so](./advanced-examples/custom-http-client.md).

## Annotations

### Beta
Features marked with the `[Beta]` attribute are in a beta stage and may undergo changes in future releases. Use these features with caution as they may not be stable.

### Deprecated
Features marked with the `[Deprecated]` attribute are deprecated and are not encouraged to use

### Preview
Features marked with the `[Preview]` attribute are in a preview stage and are intended for evaluation purposes. They are subject to change and should not be used in production without thorough testing.

## Docker Image

The `Dockerfile` present in this repository and its respective `twilio/twilio-csharp` Docker image are used by Twilio for testing purposes.

You could use the docker image for building and running tests:

```bash
docker build -t twiliobuild .
```

Bash:

```bash
docker run -it --rm -v $(pwd):/twilio twiliobuild
make test
```

Powershell:

```pwsh
docker run -it --rm -v ${PWD}:/twilio twiliobuild
make test
```

## Get support

If you need help installing or using the library, please check the [Twilio Support Help Center](https://support.twilio.com) first, and [file a support ticket](https://twilio.com/help/contact) if you don't find an answer to your question.

If you've instead found a bug in the library or would like new features added, go ahead and open issues or pull requests against this repo!

[twilio]: https://www.twilio.com
[apidocs]: https://www.twilio.com/docs/api
[twiml]: https://www.twilio.com/docs/api/twiml
[libdocs]: https://www.twilio.com/docs/libraries/reference/twilio-csharp/
[aspnet]: https://github.com/twilio/twilio-aspnet
