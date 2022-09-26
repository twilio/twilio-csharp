using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Chat.V2;
using Twilio.Rest.Chat.V2.Service;
using Twilio.Rest.Events.V1;
using System.Linq;
namespace Twilio.Tests 
{
    [TestFixture]
    class ClusterTest 
    {
        string   accountSid;
        string  secret;
        private string  apiKey;
        string  toNumber;
        string  fromNumber;
        [SetUp]
        [Category("ClusterTest")]
        public void SetUp()
        {
            accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            secret = Environment.GetEnvironmentVariable("TWILIO_API_SECRET");
            apiKey = Environment.GetEnvironmentVariable("TWILIO_API_KEY");
            toNumber = Environment.GetEnvironmentVariable("TWILIO_TO_NUMBER");
            fromNumber = Environment.GetEnvironmentVariable("TWILIO_FROM_NUMBER");
            TwilioClient.Init(username:apiKey,password:secret,accountSid:accountSid);
        }
        

        [Test]
        [Category("ClusterTest")]
        public void TestSendingAText()
        {
             var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(fromNumber),
                body: "Where's Wallace?",
                to: new Twilio.Types.PhoneNumber(toNumber)
            );
            Assert.IsNotNull(message);
            Assert.True(message.Body.Contains("Where's Wallace?"));
            Assert.AreEqual(fromNumber,message.From.ToString());
            Assert.AreEqual(toNumber,message.To.ToString());
        }

        [Test]
        [Category("ClusterTest")]
        public void TestListingNumbers()
        {
            var incomingPhoneNumberResourceSet = IncomingPhoneNumberResource.Read(
                phoneNumber: new Twilio.Types.PhoneNumber(fromNumber)
            );
            Assert.IsNotNull(incomingPhoneNumberResourceSet);
            Assert.Greater(incomingPhoneNumberResourceSet.Count(), 0);
        }

        [Test]
        [Category("ClusterTest")]
        public void TestListingANumber()
        {
          
            var incomingPhoneNumberResourceSet = IncomingPhoneNumberResource.Read(
                phoneNumber: new Twilio.Types.PhoneNumber(fromNumber)
            );  
            var enumerator = incomingPhoneNumberResourceSet.GetEnumerator();
            enumerator.MoveNext();
            var firstPage = enumerator.Current;
            Assert.IsNotNull(firstPage);
            Assert.AreEqual(fromNumber,firstPage.PhoneNumber.ToString());
        }

        [Test]
        [Category("ClusterTest")]
        public void TestSpecialCharacters()
        {
            var service = ServiceResource.Create(friendlyName: "service|friendly&name");
            Assert.IsNotNull(service);
            UserResource user = UserResource.Create(pathServiceSid:service.Sid,identity:"user|identity&string");
            Assert.IsNotNull(user);
            bool isUserDeleted = UserResource.Delete(pathServiceSid:service.Sid,pathSid:user.Sid);
            Assert.True(isUserDeleted);
            bool isServiceDeleted = ServiceResource.Delete(pathSid:service.Sid);
            Assert.True(isServiceDeleted);
        }

        [Test]
        [Category("ClusterTest")]
        public void TestListParams()
        {
            var sinkConfiguration = new Dictionary<string, Object>()
            {
                {"destination", "http://example.org/webhook"},
                {"method", "post"},
                {"batch_events",false}
            };

            var types1 = new Dictionary<string, Object>(){
                {"type","com.twilio.messaging.message.delivered"},
            };

            var types2 = new Dictionary<string, Object>(){
                {"type", "com.twilio.messaging.message.sent"},
            };

            var types = new List<Object>(){
                types1,types2
            };

            var sink = SinkResource.Create(
                description: "test sink csharp",
                sinkConfiguration: sinkConfiguration,
                sinkType: SinkResource.SinkTypeEnum.Webhook
             );
             Assert.IsNotNull(sink);
             
             var subscription = SubscriptionResource.Create("test subscription csharp",sink.Sid,types);
             Assert.IsNotNull(subscription);

            Assert.True(SubscriptionResource.Delete(subscription.Sid));
            Assert.True(SinkResource.Delete(sink.Sid));

        }
    }
}