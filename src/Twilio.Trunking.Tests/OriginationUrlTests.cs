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
    public class OriginationUrlTests
    {
        private const string OriginationUrl_SID = "OU123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TrunkingClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TrunkingClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetOriginationUrl()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OriginationUrl>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OriginationUrl());
            var client = mockClient.Object;

            client.GetOriginationUrl("TK123", OriginationUrl_SID);

            mockClient.Verify(trc => trc.Execute<OriginationUrl>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var OriginationUrlSidParam = savedRequest.Parameters.Find(x => x.Name == "OriginationUrlSid");
            Assert.IsNotNull(OriginationUrlSidParam);
            Assert.AreEqual(OriginationUrl_SID, OriginationUrlSidParam.Value);
        }

        [Test]
        public void ShouldGetOriginationUrlAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<OriginationUrl>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrl>>()))
                .Callback<IRestRequest, Action<OriginationUrl>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetOriginationUrl("TK123", OriginationUrl_SID, OriginationUrl =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<OriginationUrl>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrl>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var OriginationUrlSidParam = savedRequest.Parameters.Find(x => x.Name == "OriginationUrlSid");
            Assert.IsNotNull(OriginationUrlSidParam);
            Assert.AreEqual(OriginationUrl_SID, OriginationUrlSidParam.Value);
        }

        [Test]
        public void ShouldListOriginationUrls()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OriginationUrlResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OriginationUrlResult());
            var client = mockClient.Object;

            client.ListOriginationUrls("TK123");

            mockClient.Verify(trc => trc.Execute<OriginationUrlResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListOriginationUrlsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<OriginationUrlResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrlResult>>()))
                .Callback<IRestRequest, Action<OriginationUrlResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListOriginationUrls("TK123", workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<OriginationUrlResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrlResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateOriginationUrls()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OriginationUrl>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OriginationUrl());
            var client = mockClient.Object;

            client.CreateOriginationUrl("TK123", "friendly", "http://sip.com", 10, 1, true);

            mockClient.Verify(trc => trc.Execute<OriginationUrl>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateOriginationUrlAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<OriginationUrl>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrl>>()))
                .Callback<IRestRequest, Action<OriginationUrl>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.CreateOriginationUrl("TK123", "friendly", "http://sip.com", 10, 1, true, OriginationUrl =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<OriginationUrl>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrl>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldUpdateOriginationUrls()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<OriginationUrl>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new OriginationUrl());
            var client = mockClient.Object;

            client.UpdateOriginationUrl("TK123", OriginationUrl_SID, "friendly", "http://sip.com", 10, 1, true);

            mockClient.Verify(trc => trc.Execute<OriginationUrl>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldUpdateOriginationUrlAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<OriginationUrl>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrl>>()))
                .Callback<IRestRequest, Action<OriginationUrl>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.UpdateOriginationUrl("TK123", OriginationUrl_SID, "friendly", "http://sip.com", 10, 1, true, OriginationUrl =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<OriginationUrl>(It.IsAny<IRestRequest>(), It.IsAny<Action<OriginationUrl>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var OriginationUrlSidParam = savedRequest.Parameters.Find(x => x.Name == "OriginationUrlSid");
            Assert.IsNotNull(OriginationUrlSidParam);
            Assert.AreEqual(OriginationUrl_SID, OriginationUrlSidParam.Value);
        }

        [Test]
        public void ShouldDeleteOriginationUrls()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteOriginationUrl("TK123", OriginationUrl_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldDeleteOriginationUrlAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteOriginationUrl("TK123", OriginationUrl_SID, status =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
        }
    }
}
