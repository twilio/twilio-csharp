# Twilio REST API and TwiML Libraries for .NET, ASP.NET, ASP.NET MVC and WebMatrix

Twilio provides a simple HTTP-based API for sending and receiving phone calls and text messages. Learn more at [http://www.twilio.com][0]

## [.NET Helper Library Documentation][3]
#### [Twilio REST API Documentation][1] - [Twilio TwiML Documentation][2]

### Installation

#### Via NuGet

Install REST API wrapper:

    Install-Package Twilio

Install ASP.NET MVC helpers and REST API wrapper:

    Install-Package Twilio.Mvc

To install WebMatrix/ASP.NET Web Pages helpers, search for Twilio in the WebMatrix site administration.

### Sample Usage

    using Twilio;
    var twilio = new TwilioRestClient("accountSid", "authToken");
    var call = twilio.InitiateOutboundCall("+1555456790", "+15551112222", "http://example.com/handleCall");
    var msg = twilio.SendSmsMessage("+15551112222", "+15553334444", "Can you believe it's this easy to send an SMS?!");

### Silverlight/Windows Phone 7/Asynchronous Requests Sample

    using Twilio;
    var twilio = new TwilioRestClient("accountSid", "authToken");
    twilio.InitiateOutboundCall("+1123456790", "+15555551212", "http://example.com/handleCall", (call) => {
        // Console.WriteLog(call.Sid);
    });

    twilio.SendSmsMessage("+15555551212", "+11234567890", "Hello!", (msg) => {
        // Console.WriteLine(msg.Sid);
    });

### TwiML Generation with ASP.NET Sample

	var response = new TwilioResponse();
	response.Say("Hello Monkey");
	response.Play("http://demo.twilio.com/hellomonkey/monkey.mp3");
	response.BeginGather(new { numDigits = 1, action = "hello-monkey-handle-key.cshtml", method = "POST" });
	response.Say("To speak to a real monkey, press 1. Press 2 to record your own monkey howl. Press any other key to start over.");
	response.EndGather();

	// ASP.NET MVC when controller inherits from TwilioController
	return TwiML(response);

	// ASP.NET MVC regular controller
	return new TwiMLResult(response);

	// ASP.NET Webforms
	var doc = response.ToXDocument();
    Response.ContentType = "application/xml";
	doc.Save(Response.Output);

## Migrating from earlier versions

### Migrating from original twilio/twilio-csharp (version 2.1 and below)
Moving from version 2.1 or below to 3.0 will require changes to your existing code. The library now centers around a `TwilioRestClient` class from which all operations you can make against the API are rooted. Refer to the [[Twilio.Api]] REST API wrapper documentation for the list of available methods.

### Migrating from johnsheehan/TwilioApi
This library is derived from johnsheehan/TwilioApi. Minimal changes should be required to your code in order to use this version. The most notable change is the renaming of `TwilioClient` to `TwilioRestClient`. In addition to the REST API wrapper, this new version also includes TwiML generation and ASP.NET MVC helpers.


[0]: http://www.twilio.com
[1]: http://www.twilio.com/docs/api/rest
[2]: http://www.twilio.com/docs/api/twiml
[3]: https://github.com/twilio/twilio-csharp/wiki
