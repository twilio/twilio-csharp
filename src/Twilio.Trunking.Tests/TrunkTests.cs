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
    public class TrunkTests
    {
        private const string Trunk_SID = "TK123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TrunkingClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TrunkingClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetTrunk()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Trunk>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Trunk());
            var client = mockClient.Object;

            client.GetTrunk(Trunk_SID);

            mockClient.Verify(trc => trc.Execute<Trunk>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var TrunkSidParam = savedRequest.Parameters.Find(x => x.Name == "TrunkSid");
            Assert.IsNotNull(TrunkSidParam);
            Assert.AreEqual(Trunk_SID, TrunkSidParam.Value);
        }

        [Test]
        public void ShouldGetTrunkAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Trunk>(It.IsAny<IRestRequest>(), It.IsAny<Action<Trunk>>()))
                .Callback<IRestRequest, Action<Trunk>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetTrunk(Trunk_SID, Trunk =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Trunk>(It.IsAny<IRestRequest>(), It.IsAny<Action<Trunk>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var TrunkSidParam = savedRequest.Parameters.Find(x => x.Name == "TrunkSid");
            Assert.IsNotNull(TrunkSidParam);
            Assert.AreEqual(Trunk_SID, TrunkSidParam.Value);
        }

        [Test]
        public void ShouldListTrunks()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TrunkResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TrunkResult());
            var client = mockClient.Object;

            client.ListTrunks();

            mockClient.Verify(trc => trc.Execute<TrunkResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListTrunksAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TrunkResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TrunkResult>>()))
                .Callback<IRestRequest, Action<TrunkResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListTrunks(workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TrunkResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TrunkResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateTrunks()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Trunk>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Trunk());
            var client = mockClient.Object;

            client.CreateTrunk("friendly", "test1.pstn.twilio.com", "", "", null, false);

            mockClient.Verify(trc => trc.Execute<Trunk>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateTrunkAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Trunk>(It.IsAny<IRestRequest>(), It.IsAny<Action<Trunk>>()))
                .Callback<IRestRequest, Action<Trunk>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.CreateTrunk(Trunk_SID, "test1.pstn.twilio.com", "", "", null, false, Trunk =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Trunk>(It.IsAny<IRestRequest>(), It.IsAny<Action<Trunk>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var TrunkSidParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(TrunkSidParam);
            Assert.AreEqual(Trunk_SID, TrunkSidParam.Value);
        }

        [Test]
        public void ShouldUpdateTrunks()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Trunk>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Trunk());
            var client = mockClient.Object;

            client.UpdateTrunk(Trunk_SID, "friendly", "test1.pstn.twilio.com", "", "", null, false);

            mockClient.Verify(trc => trc.Execute<Trunk>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldUpdateTrunkAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Trunk>(It.IsAny<IRestRequest>(), It.IsAny<Action<Trunk>>()))
                .Callback<IRestRequest, Action<Trunk>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.UpdateTrunk(Trunk_SID, "friendly", "test1.pstn.twilio.com", "", "", null, false, Trunk =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Trunk>(It.IsAny<IRestRequest>(), It.IsAny<Action<Trunk>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var TrunkSidParam = savedRequest.Parameters.Find(x => x.Name == "TrunkSid");
            Assert.IsNotNull(TrunkSidParam);
            Assert.AreEqual(Trunk_SID, TrunkSidParam.Value);
        }

        [Test]
        public void ShouldDeleteTrunks()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteTrunk(Trunk_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldDeleteTrunkAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteTrunk(Trunk_SID, status =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Trunks/{TrunkSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }
    }
}
