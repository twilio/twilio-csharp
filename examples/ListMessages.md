```csharp
using System;
using Twilio;
using Twilio.Base;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

class Program
{
    static void Main(string[] args)
    {
        TwilioClient.Init("TWILIO_ACCOUNT_SID", "TWILIO_AUTH_TOKEN");

        var messages = MessageResource.Read(limit: 20);
        foreach (var record in messages) {
            Console.WriteLine(record.Body);
        }
    }
}

```
