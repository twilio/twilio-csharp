using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class UsageTriggerTests
    {
        private const string USAGE_TRIGGER_SID = "UT123";

        //list/get/create/update/delete
        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetUsageTrigger()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<UsageTrigger>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new UsageTrigger());
            var client = mockClient.Object;

            client.GetUsageTrigger(USAGE_TRIGGER_SID);

            mockClient.Verify(trc => trc.Execute<UsageTrigger>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Triggers/{UsageTriggerSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var usageTriggerSidParam = savedRequest.Parameters.Find(x => x.Name == "UsageTriggerSid");
            Assert.IsNotNull(usageTriggerSidParam);
            Assert.AreEqual(USAGE_TRIGGER_SID, usageTriggerSidParam.Value);
        }

        [Test]
        public void ShouldListUsageTriggers()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<UsageTriggerResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new UsageTriggerResult());
            var client = mockClient.Object;

            client.ListUsageTriggers();

            mockClient.Verify(trc => trc.Execute<UsageTriggerResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Triggers.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListUsageTriggersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<UsageTriggerResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<UsageTriggerResult>>()))
                .Callback<IRestRequest, Action<UsageTriggerResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListUsageTriggers(usageTriggers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<UsageTriggerResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<UsageTriggerResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Triggers.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateNewUsageTrigger()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<UsageTrigger>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new UsageTrigger());
            var client = mockClient.Object;
            UsageTriggerOptions options = new UsageTriggerOptions() {
                CallbackUrl = "CallbackUrl",
                TriggerValue = "TriggerValue",
                UsageCategory = "UsageCategory"
            };

            client.CreateUsageTrigger(options);

            mockClient.Verify(trc => trc.Execute<UsageTrigger>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Triggers.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var callbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "CallbackUrl");
            Assert.IsNotNull(callbackUrlParam);
            Assert.AreEqual(options.CallbackUrl, callbackUrlParam.Value);
            var triggerValueParam = savedRequest.Parameters.Find(x => x.Name == "TriggerValue");
            Assert.IsNotNull(triggerValueParam);
            Assert.AreEqual(options.TriggerValue, triggerValueParam.Value);
            var usageCategoryParam = savedRequest.Parameters.Find(x => x.Name == "UsageCategory");
            Assert.IsNotNull(usageCategoryParam);
            Assert.AreEqual(options.UsageCategory, usageCategoryParam.Value);
        }

        [Test]
        public void ShouldUpdateUsageTrigger()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<UsageTrigger>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new UsageTrigger());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateUsageTrigger(USAGE_TRIGGER_SID, friendlyName, null, null);

            mockClient.Verify(trc => trc.Execute<UsageTrigger>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Triggers/{UsageTriggerSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var usageTriggerSidParam = savedRequest.Parameters.Find(x => x.Name == "UsageTriggerSid");
            Assert.IsNotNull(usageTriggerSidParam);
            Assert.AreEqual(USAGE_TRIGGER_SID, usageTriggerSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldDeleteUsageTrigger()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteUsageTrigger(USAGE_TRIGGER_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Triggers/{UsageTriggerSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var usageTriggerSidParam = savedRequest.Parameters.Find(x => x.Name == "UsageTriggerSid");
            Assert.IsNotNull(usageTriggerSidParam);
            Assert.AreEqual(USAGE_TRIGGER_SID, usageTriggerSidParam.Value);
        }

    }
}
