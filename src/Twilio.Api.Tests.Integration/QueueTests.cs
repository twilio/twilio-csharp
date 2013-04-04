using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class QueueTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldGetQueue()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalQueue = client.CreateQueue("ShouldGetQueue");

            var queuesid = originalQueue.Sid;

            var result = client.GetQueue(queuesid);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteQueue(queuesid); //cleanup
        }

        [TestMethod]
        public void ShouldListQueues()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var result = client.ListQueues();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Queues);
        }

        [TestMethod]
        public void ShouldListQueuesAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            QueueResult result = null;
            client.ListQueues(queues => {
                result = queues;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Queues);
        }

        [TestMethod]
        public void ShouldCreateNewQueue()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.CreateQueue("ShouldCreateNewQueue");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteQueue(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateQueue()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalQueue = client.CreateQueue("ShouldUpdateQueue");

            var queuesid = originalQueue.Sid;

            var result = client.UpdateQueue(queuesid, "ShouldUpdateQueueUpdated", originalQueue.MaxSize.Value);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual("ShouldUpdateQueueUpdated", result.FriendlyName);

            client.DeleteQueue(queuesid); //cleanup
        }

        [TestMethod]
        public void ShouldDeleteQueue()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalQueue = client.CreateQueue("ShouldDeleteQueue");

            var status = client.DeleteQueue(originalQueue.Sid);
            Assert.AreEqual(DeleteStatus.Success, status);
        }
    }
}
