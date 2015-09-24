using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;
using Twilio.Trunking;

namespace Twilio.Trunking.Tests
{
    [TestFixture]
    public class CredentialListTests
    {
        private const string CredentialList_SID = "CL123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TrunkingClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TrunkingClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldListCredentialLists()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CredentialListResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new CredentialListResult());
            var client = mockClient.Object;

            client.ListCredentialLists("TK123");

            mockClient.Verify(trc => trc.Execute<CredentialListResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/CredentialLists", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCredentialListsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<CredentialListResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<CredentialListResult>>()))
                .Callback<IRestRequest, Action<CredentialListResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListCredentialLists("TK123", workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<CredentialListResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<CredentialListResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/CredentialLists", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldAssociateCredentialLists()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CredentialList>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new CredentialList());
            var client = mockClient.Object;

            client.AssociateCredentialList("TK123", CredentialList_SID);

            mockClient.Verify(trc => trc.Execute<CredentialList>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/CredentialLists", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldAssociateCredentialListAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<CredentialList>(It.IsAny<IRestRequest>(), It.IsAny<Action<CredentialList>>()))
                .Callback<IRestRequest, Action<CredentialList>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.AssociateCredentialList("TK123", CredentialList_SID, CredentialList =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<CredentialList>(It.IsAny<IRestRequest>(), It.IsAny<Action<CredentialList>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/CredentialLists", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var CredentialListSidParam = savedRequest.Parameters.Find(x => x.Name == "CredentialListSid");
            Assert.IsNotNull(CredentialListSidParam);
            Assert.AreEqual(CredentialList_SID, CredentialListSidParam.Value);
        }

        [Test]
        public void ShouldDeleteCredentialList()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteCredentialList("TK123", CredentialList_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/CredentialLists/{CredentialListSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldDeleteCredentialListAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteCredentialList("TK123", CredentialList_SID, status =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/CredentialLists/{CredentialListSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }
    }
}
