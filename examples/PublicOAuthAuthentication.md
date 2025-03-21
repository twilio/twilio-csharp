```csharp
using Twilio;
using Twilio.Credential;
using Twilio.Rest.Api.V2010.Account;

//Find client id, client secret of the OAuth App
//Message sid in this example is the sid of any previously sent message
class Program
{
    static void Main(string[] args)
    {
        CredentialProvider credentialProvider = new ClientCredentialProvider(CLIENT_ID, CLIENT_SECRET);
        TwilioClient.Init(credentialProvider, ACCOUNT_SID);

        /*
         * Or use the following if accountSid is not required as a path parameter for an API or when setting accountSid in the API.
           TwilioClient.init(new ClientCredentialProvider(CLIENT_ID, CLIENT_SECRET));
         */
        
        FetchMessageOptions fm = new FetchMessageOptions(MESSAGE_SID);
        MessageResource m = MessageResource.Fetch(fm);
        Console.WriteLine(m.Body);
    }
}
```
