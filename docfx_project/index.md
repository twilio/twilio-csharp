[![Build status](https://ci.appveyor.com/api/projects/status/7e21yfla3877kdu6?svg=true)](https://ci.appveyor.com/project/mplacona/twilio-csharp-5t72d)

# Twilio REST API and TwiML Libraries for .NET, ASP.NET, ASP.NET MVC and WebMatrix

Twilio provides a simple HTTP-based API for sending and receiving phone calls and text messages. Learn more at [http://www.twilio.com][0]

## [.NET Helper Library Documentation][3]
#### [Twilio REST API Documentation][1] - [Twilio TwiML Documentation][2]

## Alpha Version
A new alpha version (v3.7.55) of the Twilio .NET library is available on nuget.  This version removes the RestSharp dependency and includes a new Portable Class Library version which can be used by .NET 4.0 and newer. To install the alpha version from the NuGet Package manager console, add the *-prerelease* flag to the *Install-Package* command:

    Install-Package Twilio -prerelease

### Adding Twilio libraries to your .NET project

The best and easiest way to add the Twilio libraries to your .NET project is to use the NuGet package manager.  NuGet is a Visual Studio extension that makes it easy to install and update third-party libraries and tools in Visual Studio.  

NuGet is available for Visual Studio 2010 and Visual Studio 2012, and you can find instructions for installing the NuGet extension on the NuGet.org website:

[http://docs.nuget.org/docs/start-here/installing-nuget](http://docs.nuget.org/docs/start-here/installing-nuget)

Once you have installed the NuGet extension, you can choose to install the Twilio libraries using either the Package Manager dialog, or using the Package Manager console.

#### Installing via the Package Manager Dialog

To install a Twilio library using the Package Manager dialog, first open the dialog by right-clicking the References folder in your project and selecting the package manager option:

![](https://lh4.googleusercontent.com/f7arKv3rtF3_0x8ckYwDC4d9qr3lfcHcIYROjAAI2h6StebF_szFVy_irxjDuKtUlemg2PC9uWaUKjtSuZfwPh6PatIN76BrksWaL8slscC5yDpxxtQ)

When the package manager dialog opens simply search the online catalog for _‘Twilio’_.  The screen shot below shows the results returned from the NuGet catalog:

![](https://lh3.googleusercontent.com/5MJ4NZuU2u38BrXAaXCAaQNIG-A5GR9SpdfOylya2HCHoRgCdybmdfbKpo9-AAOx3TmH_Yn2vri5vBR4cXMrFoVcKl5SWQ5POPgDNTzrUxlCJiDq-Jc)

Simply click the Install button next to the Twilio package you want to add to your project and watch as NuGet downloads the Twilio library package (and its dependencies) and adds the proper  references to your project.

![](http://i.imgur.com/qX02AAF.png)

#### Installing via the Package Manager Console

To install a Twilio library using the Package Manager console, first open the console, then Use the _Install-Package_ command to install the different Twilio packages:

Install REST API wrapper:

    Install-Package Twilio

Install ASP.NET MVC helpers and REST API wrapper:

    Install-Package Twilio.Mvc

#### Installing in WebMatrix

If you are using Microsoft’s free web developer tool WebMatrix, it also includes integration with NuGet.  To add the Twilio helpers to a site created using WebMatrix simply open the WebMatrix administration website (as described here).  Change the Show dropdown from Installed to Online and use the search field to Search for _‘Twilio’_.

![](https://lh6.googleusercontent.com/hooO2wNh3UZnXOLkrvDIFQJuFBQEl2mrmzLjjneceniB4IT6QX927qMR5TV3XGciZMAg__Np0RwKhnmq45drgIBYEHcEtYxXGUL9Q2TaEAJnO9tCfTE)


### Sample Usage

The examples below show how to have your application initiate and outbound phone call and send an SMS message using the Twilio .NET helper library:

    using Twilio;
    var twilio = new TwilioRestClient("accountSid", "authToken");
    var call = twilio.InitiateOutboundCall("+1555456790", "+15551112222", "http://example.com/handleCall");
    var msg = twilio.SendMessage("+15551112222", "+15553334444", "Can you believe it's this easy to send an SMS?!");

### Silverlight/Windows Phone 7/Asynchronous Requests Sample

    using Twilio;
    var twilio = new TwilioRestClient("accountSid", "authToken");
    twilio.InitiateOutboundCall("+1123456790", "+15555551212", "http://example.com/handleCall", (call) => {
        // Console.WriteLog(call.Sid);
    });

    twilio.SendMessage("+15555551212", "+11234567890", "Hello!", (msg) => {
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
	
## Getting help

If you need help installing or using the library, please contact Twilio Support at help@twilio.com first. Twilio's Support staff are well-versed in all of the Twilio Helper Libraries, and usually reply within 24 hours.

If you've instead found a bug in the library or would like new features added, go ahead and open issues or pull requests against this repo!

## Migrating from earlier versions

### Migrating from original twilio/twilio-csharp (version 2.1 and below)
Moving from version 2.1 or below to 3.0 will require changes to your existing code. The library now centers around a `TwilioRestClient` class from which all operations you can make against the API are rooted. Refer to the [[Twilio.Api]] REST API wrapper documentation for the list of available methods.

### Migrating from johnsheehan/TwilioApi
This library is derived from johnsheehan/TwilioApi. Minimal changes should be required to your code in order to use this version. The most notable change is the renaming of `TwilioClient` to `TwilioRestClient`. In addition to the REST API wrapper, this new version also includes TwiML generation and ASP.NET MVC helpers.


[0]: http://www.twilio.com
[1]: http://www.twilio.com/docs/api/rest
[2]: http://www.twilio.com/docs/api/twiml
[3]: https://github.com/twilio/twilio-csharp/wiki

## Developing on the library with Mono
You can setup a mono/nunit development environment using the Makefile:

**Note:** You will need Homebrew.

```bash
> make develop
```

Then, you can build the solution using `xbuild`:

```bash
> make
```

and run the tests using `nunit`:

```bash
> make test
```

