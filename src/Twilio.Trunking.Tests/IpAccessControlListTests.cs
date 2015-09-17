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
    public class IpAccessControlListTests
    {
        private const string IpAccessControlList_SID = "IP123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TrunkingClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TrunkingClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldListIpAccessControlLists()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IpAccessControlListResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new IpAccessControlListResult());
            var client = mockClient.Object;

            client.ListIpAccessControlLists("TK123");

            mockClient.Verify(trc => trc.Execute<IpAccessControlListResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/IpAccessControlLists", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListIpAccessControlListsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<IpAccessControlListResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<IpAccessControlListResult>>()))
                .Callback<IRestRequest, Action<IpAccessControlListResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListIpAccessControlLists("TK123", workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<IpAccessControlListResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<IpAccessControlListResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/IpAccessControlLists", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldAssociateIpAccessControlLists()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IpAccessControlList>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new IpAccessControlList());
            var client = mockClient.Object;

            client.AssociateIpAccessControlList("TK123", IpAccessControlList_SID);

            mockClient.Verify(trc => trc.Execute<IpAccessControlList>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/IpAccessControlLists", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldAssociateIpAccessControlListAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<IpAccessControlList>(It.IsAny<IRestRequest>(), It.IsAny<Action<IpAccessControlList>>()))
                .Callback<IRestRequest, Action<IpAccessControlList>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.AssociateIpAccessControlList("TK123", IpAccessControlList_SID, IpAccessControlList =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<IpAccessControlList>(It.IsAny<IRestRequest>(), It.IsAny<Action<IpAccessControlList>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/IpAccessControlLists", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var IpAccessControlListSidParam = savedRequest.Parameters.Find(x => x.Name == "IpAccessControlListSid");
            Assert.IsNotNull(IpAccessControlListSidParam);
            Assert.AreEqual(IpAccessControlList_SID, IpAccessControlListSidParam.Value);
        }

        [Test]
        public void ShouldDeleteIpAccessControlList()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteIpAccessControlList("TK123", IpAccessControlList_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/IpAccessControlLists/{IpAccessControlListSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldDeleteIpAccessControlListAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteIpAccessControlList("TK123", IpAccessControlList_SID, status =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/IpAccessControlLists/{IpAccessControlListSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }
    }
}
