using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Chat.V2;
using Twilio.Rest.Chat.V2.Service;
using Twilio.Rest.Events.V1;
using Twilio.Credential;

namespace Twilio.UnitTests
{

    public class ClusterTest
    {
        string? accountSid;
        string? secret;
        private string? apiKey;
        string? toNumber;
        string? fromNumber;
        string? orgsSid;
        string? clientId;
        string? clientSecret;
        string? oAuthClientId;
        string? oAuthClientSecret;
        string? oAuthMessageId;


        public ClusterTest()
        {
            accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            secret = Environment.GetEnvironmentVariable("TWILIO_API_SECRET");
            apiKey = Environment.GetEnvironmentVariable("TWILIO_API_KEY");
            toNumber = Environment.GetEnvironmentVariable("TWILIO_TO_NUMBER");
            fromNumber = Environment.GetEnvironmentVariable("TWILIO_FROM_NUMBER");
            orgsSid = Environment.GetEnvironmentVariable("TWILIO_ORG_SID");
            clientId = Environment.GetEnvironmentVariable("TWILIO_ORGS_CLIENT_ID");
            clientSecret = Environment.GetEnvironmentVariable("TWILIO_ORGS_CLIENT_SECRET");

            oAuthClientId = Environment.GetEnvironmentVariable("TWILIO_CLIENT_ID");
            oAuthClientSecret = Environment.GetEnvironmentVariable("TWILIO_CLIENT_SECRET");
            oAuthMessageId = Environment.GetEnvironmentVariable("TWILIO_MESSAGE_SID");
            TwilioClient.Init(username: apiKey, password: secret, accountSid: accountSid);
            TwilioOrgsTokenAuthClient.Init(clientId, clientSecret);
        }


        [Trait("Category", "ClusterTest")]
        [Fact]
        public void TestSendingAText()
        {
            var message = MessageResource.Create(
               from: new Twilio.Types.PhoneNumber(fromNumber),
               body: "Where's Wallace?",
               to: new Twilio.Types.PhoneNumber(toNumber)
           );
            Assert.NotNull(message);
            Assert.Contains("Where's Wallace?", message.Body);
            Assert.Equal(fromNumber, message.From.ToString());
            Assert.Equal(toNumber, message.To.ToString());
        }

        [Fact]
        [Trait("Category", "ClusterTest")]
        public void TestListingNumbers()
        {
            var incomingPhoneNumberResourceSet = IncomingPhoneNumberResource.Read(
                phoneNumber: new Twilio.Types.PhoneNumber(fromNumber)
            );
            Assert.NotNull(incomingPhoneNumberResourceSet);
            Assert.True(incomingPhoneNumberResourceSet.Count() > 0);
        }

        [Fact]
        [Trait("Category", "ClusterTest")]
        public void TestListingANumber()
        {

            var incomingPhoneNumberResourceSet = IncomingPhoneNumberResource.Read(
                phoneNumber: new Twilio.Types.PhoneNumber(fromNumber)
            );
            var enumerator = incomingPhoneNumberResourceSet.GetEnumerator();
            enumerator.MoveNext();
            var firstPage = enumerator.Current;
            Assert.NotNull(firstPage);
            Assert.Equal(fromNumber, firstPage.PhoneNumber.ToString());
        }

        [Fact]
        [Trait("Category", "ClusterTest")]
        public void TestSpecialCharacters()
        {
            var service = ServiceResource.Create(friendlyName: "service|friendly&name");
            Assert.NotNull(service);
            UserResource user = UserResource.Create(pathServiceSid: service.Sid, identity: "user|identity&string");
            Assert.NotNull(user);
            bool isUserDeleted = UserResource.Delete(pathServiceSid: service.Sid, pathSid: user.Sid);
            Assert.True(isUserDeleted);
            bool isServiceDeleted = ServiceResource.Delete(pathSid: service.Sid);
            Assert.True(isServiceDeleted);
        }

        [Fact]
        [Trait("Category", "ClusterTest")]
        public void TestListParams()
        {
            var sinkConfiguration = new Dictionary<string, object>()
            {
                {"destination", "http://example.org/webhook"},
                {"method", "post"},
                {"batch_events",false}
            };

            var types1 = new Dictionary<string, object>(){
                {"type","com.twilio.messaging.message.delivered"},
            };

            var types2 = new Dictionary<string, object>(){
                {"type", "com.twilio.messaging.message.sent"},
            };

            var types = new List<object>(){
                types1,types2
            };

            var sink = SinkResource.Create(
                description: "test sink csharp",
                sinkConfiguration: sinkConfiguration,
                sinkType: SinkResource.SinkTypeEnum.Webhook
             );
            Assert.NotNull(sink);

            var subscription = SubscriptionResource.Create("test subscription csharp", sink.Sid, types);
            Assert.NotNull(subscription);

            Assert.True(SubscriptionResource.Delete(subscription.Sid));
            Assert.True(SinkResource.Delete(sink.Sid));

        }

        [Fact]
        [Trait("Category", "ClusterTest")]
        public void TestFetchingOrgsAccounts()
        {
            Twilio.Base.ResourceSet<Twilio.Rest.PreviewIam.Organizations.AccountResource>? accountList = null;
            accountList = Twilio.Rest.PreviewIam.Organizations.AccountResource.Read(orgsSid);
            Assert.NotNull(accountList.ElementAt(0).FriendlyName);

            var userList = UserResource.Read(orgsSid);
            Assert.NotNull(userList);

        }

        [Fact]
        [Trait("Category", "ClusterTest")]
        public void TestPublicOAuth()
        {

            CredentialProvider cp = new ClientCredentialProvider(oAuthClientId, oAuthClientSecret);
            TwilioClient.SetAccountSid(accountSid);
            TwilioClient.Init(cp, accountSid);

            // Fetching an existing message; if this test fails, the SID might be deleted,
            // in that case, change TWILIO_MESSAGE_SID in twilio-csharp repo env variables
            FetchMessageOptions fm = new FetchMessageOptions(oAuthMessageId);
            MessageResource m = MessageResource.Fetch(fm);
            Assert.NotNull(m.Body);

        }
    }
}
