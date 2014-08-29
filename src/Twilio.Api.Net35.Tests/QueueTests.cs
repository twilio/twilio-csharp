using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using Simple;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private const string QUEUE_SID = "QU123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetQueue()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Queue>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Queue());
            var client = mockClient.Object;

            client.GetQueue(QUEUE_SID);

            mockClient.Verify(trc => trc.Execute<Queue>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Queues/{QueueSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var queueSidParam = savedRequest.Parameters.Find(x => x.Name == "QueueSid");
            Assert.IsNotNull(queueSidParam);
            Assert.AreEqual(QUEUE_SID, queueSidParam.Value);
        }

        [Test]
        public void ShouldListQueues()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<QueueResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new QueueResult());
            var client = mockClient.Object;

            client.ListQueues();

            mockClient.Verify(trc => trc.Execute<QueueResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Queues.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListQueuesAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<QueueResult>(It.IsAny<RestRequest>(), It.IsAny<Action<QueueResult>>()))
                .Callback<RestRequest, Action<QueueResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListQueues(queues =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<QueueResult>(It.IsAny<RestRequest>(), It.IsAny<Action<QueueResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Queues.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateNewQueue()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Queue>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Queue());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.CreateQueue(friendlyName);

            mockClient.Verify(trc => trc.Execute<Queue>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Queues.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldUpdateQueue()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Queue>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Queue());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateQueue(QUEUE_SID, friendlyName, 10);

            mockClient.Verify(trc => trc.Execute<Queue>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Queues/{QueueSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var queueSidParam = savedRequest.Parameters.Find(x => x.Name == "QueueSid");
            Assert.IsNotNull(queueSidParam);
            Assert.AreEqual(QUEUE_SID, queueSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var maxSizeParam = savedRequest.Parameters.Find(x => x.Name == "MaxSize");
            Assert.IsNotNull(maxSizeParam);
            Assert.AreEqual(10, maxSizeParam.Value);
        }

        [Test]
        public void ShouldDeleteQueue()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteQueue(QUEUE_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Queues/{QueueSid}.json", savedRequest.Resource);
            Assert.AreEqual("DELETE", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var queueSidParam = savedRequest.Parameters.Find(x => x.Name == "QueueSid");
            Assert.IsNotNull(queueSidParam);
            Assert.AreEqual(QUEUE_SID, queueSidParam.Value);
        }
    }
}