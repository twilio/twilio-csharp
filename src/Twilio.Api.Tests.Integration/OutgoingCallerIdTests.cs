using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class OutgoingCallerIdTests
    {
        private const string OUTGOING_CALLER_ID_SID = "PN123";

        private const string PHONE_NUMBER = "+15005550006";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldAddNewOutgoingCallerId()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ValidationRequestResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ValidationRequestResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddOutgoingCallerId(PHONE_NUMBER, friendlyName, null, null);

            mockClient.Verify(trc => trc.Execute<ValidationRequestResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var PhoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "PhoneNumber");
            Assert.IsNotNull(PhoneNumberParam);
            Assert.AreEqual(PHONE_NUMBER, PhoneNumberParam.Value);
        }
        
        [Test]
        public void ShouldListOutgoingCallerIds()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OutgoingCallerIdResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OutgoingCallerIdResult());
            var client = mockClient.Object;

            client.ListOutgoingCallerIds();

            mockClient.Verify(trc => trc.Execute<OutgoingCallerIdResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }
        
        [Test]
        public void ShouldListOutgoingCallerIdsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<OutgoingCallerIdResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<OutgoingCallerIdResult>>()))
                .Callback<IRestRequest, Action<OutgoingCallerIdResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListOutgoingCallerIds(callerIds =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<OutgoingCallerIdResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<OutgoingCallerIdResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }
        
        [Test]
        public void ShouldListOutgoingCallerIdsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OutgoingCallerIdResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OutgoingCallerIdResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListOutgoingCallerIds(PHONE_NUMBER,friendlyName,null,null);

            mockClient.Verify(trc => trc.Execute<OutgoingCallerIdResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var PhoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "PhoneNumber");
            Assert.IsNotNull(PhoneNumberParam);
            Assert.AreEqual(PHONE_NUMBER, PhoneNumberParam.Value);
        }
        
        [Test]
        public void ShouldGetOutgoingCallerId()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OutgoingCallerId>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OutgoingCallerId());
            var client = mockClient.Object;

            client.GetOutgoingCallerId(OUTGOING_CALLER_ID_SID);

            mockClient.Verify(trc => trc.Execute<OutgoingCallerId>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var outgoingCallerIdSidParam = savedRequest.Parameters.Find(x => x.Name == "OutgoingCallerIdSid");
            Assert.IsNotNull(outgoingCallerIdSidParam);
            Assert.AreEqual(OUTGOING_CALLER_ID_SID, outgoingCallerIdSidParam.Value);
        }
        
        [Test]
        public void ShouldUpdateOutgoingCallerId()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OutgoingCallerId>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OutgoingCallerId());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateOutgoingCallerIdName(OUTGOING_CALLER_ID_SID, friendlyName);

            mockClient.Verify(trc => trc.Execute<OutgoingCallerId>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var outgoingCallerIdSidParam = savedRequest.Parameters.Find(x => x.Name == "OutgoingCallerIdSid");
            Assert.IsNotNull(outgoingCallerIdSidParam);
            Assert.AreEqual(OUTGOING_CALLER_ID_SID, outgoingCallerIdSidParam.Value);
        }

        [Test]
        public void ShouldDeleteOutgoingCallerId()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteOutgoingCallerId(OUTGOING_CALLER_ID_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var outgoingCallerIdSidParam = savedRequest.Parameters.Find(x => x.Name == "OutgoingCallerIdSid");
            Assert.IsNotNull(outgoingCallerIdSidParam);
            Assert.AreEqual(OUTGOING_CALLER_ID_SID, outgoingCallerIdSidParam.Value);
        }
    }
}
