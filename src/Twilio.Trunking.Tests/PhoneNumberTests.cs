using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;
using Twilio.Trunking.Model;

namespace Twilio.Trunking.Tests
{
    [TestFixture]
    public class PhoneNumberTests
    {
        private const string PhoneNumber_SID = "PN123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TrunkingClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TrunkingClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldListPhoneNumbers()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<PhoneNumberResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new PhoneNumberResult());
            var client = mockClient.Object;

            client.ListPhoneNumbers("TK123");

            mockClient.Verify(trc => trc.Execute<PhoneNumberResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/PhoneNumbers", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListPhoneNumbersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<PhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<PhoneNumberResult>>()))
                .Callback<IRestRequest, Action<PhoneNumberResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListPhoneNumbers("TK123", workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<PhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<PhoneNumberResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/PhoneNumbers", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldAssociatePhoneNumbers()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AssociatedPhoneNumber>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AssociatedPhoneNumber());
            var client = mockClient.Object;

            client.AssociatePhoneNumber("TK123", PhoneNumber_SID);

            mockClient.Verify(trc => trc.Execute<AssociatedPhoneNumber>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/PhoneNumbers", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldAssociatePhoneNumberAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AssociatedPhoneNumber>(It.IsAny<IRestRequest>(), It.IsAny<Action<AssociatedPhoneNumber>>()))
                .Callback<IRestRequest, Action<AssociatedPhoneNumber>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.AssociatePhoneNumber("TK123", PhoneNumber_SID, PhoneNumber =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AssociatedPhoneNumber>(It.IsAny<IRestRequest>(), It.IsAny<Action<AssociatedPhoneNumber>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/PhoneNumbers", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var PhoneNumberSidParam = savedRequest.Parameters.Find(x => x.Name == "PhoneNumberSid");
            Assert.IsNotNull(PhoneNumberSidParam);
            Assert.AreEqual(PhoneNumber_SID, PhoneNumberSidParam.Value);
        }

        [Test]
        public void ShouldDeletePhoneNumber()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeletePhoneNumber("TK123", PhoneNumber_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/PhoneNumbers/{PhoneNumberSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldDeletePhoneNumberAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeletePhoneNumber("TK123", PhoneNumber_SID, status =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/PhoneNumbers/{PhoneNumberSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }
    }
}
