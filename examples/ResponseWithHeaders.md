```csharp
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.Http;
using Twilio.Credential;

namespace TwilioTest {
    class Program
    {
        static void Main(string[] args)
        {
            TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);
        }
        
        public static void createWithHeaders()
        {
            var record = MessageResource.CreateWithHeaders(
                from: new PhoneNumber("fromNumber"),
                body: "Body",
                to: new PhoneNumber("toNumber")
            );
            Console.WriteLine(record);
            Console.WriteLine(record.Headers);
            Console.WriteLine(record.Data.Sid);
        }
        
        public static void fetchWithHeaders()
        {
            var record = MessageResource.FetchWithHeaders(pathSid: "SM123");
            Console.WriteLine(record);
            Console.WriteLine(record.Headers);
            Console.WriteLine(record.Data.Body);
        }
        
        public static void updateWithHeaders()
        {
            var record = MessageResource.UpdateWithHeaders(pathSid: "SM123", body: "");
            Console.WriteLine(record);
            Console.WriteLine(record.Headers);
            Console.WriteLine(record.Data);
        }
        
        public static void deleteWithHeaders()
        {
            var record = MessageResource.DeleteWithHeaders(pathSid: "SM123");
            Console.WriteLine(record);
            Console.WriteLine(record.Headers);
            Console.WriteLine(record.Data);
        }
    }
}
```