using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class UsageTriggerTests
    {
        //list/get/create/update/delete
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldGetUsageTrigger()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            UsageTriggerOptions options = new UsageTriggerOptions() { FriendlyName = "ShouldGetUsageTrigger" };
            var originalUsageTrigger = client.CreateUsageTrigger(options);

            var usageTriggerSid = originalUsageTrigger.Sid;

            var result = client.GetUsageTrigger(usageTriggerSid);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteUsageTrigger(usageTriggerSid); //cleanup
        }

        [TestMethod]
        public void ShouldListUsageTriggers()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var result = client.ListUsageTriggers();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.UsageTriggers);
        }

        [TestMethod]
        public void ShouldListUsageTriggersAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            UsageTriggerResult result = null;
            client.ListUsageTriggers(usageTriggers =>
            {
                result = usageTriggers;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.UsageTriggers);
        }

        [TestMethod]
        public void ShouldCreateNewUsageTrigger()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            UsageTriggerOptions options = new UsageTriggerOptions() { FriendlyName = "ShouldCreateNewUsageTrigger" };
            var result = client.CreateUsageTrigger(options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteQueue(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateUsageTrigger()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            UsageTriggerOptions options = new UsageTriggerOptions() { FriendlyName = "ShouldUpdateUsageTrigger" };
            var originalUsageTrigger = client.CreateUsageTrigger(options);

            var usagetriggersid = originalUsageTrigger.Sid;

            var result = client.UpdateUsageTrigger(usagetriggersid, "ShouldUpdateUsageTriggerUpdated", null, null);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual("ShouldUpdateUsageTriggerUpdated", result.FriendlyName);

            client.DeleteQueue(usagetriggersid); //cleanup
        }

        [TestMethod]
        public void ShouldDeleteUsageTrigger()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            UsageTriggerOptions options = new UsageTriggerOptions() { FriendlyName = "ShouldDeleteUsageTrigger" };
            var originalUsageTrigger = client.CreateUsageTrigger(options);

            var status = client.DeleteQueue(originalUsageTrigger.Sid);
            Assert.AreEqual(DeleteStatus.Success, status);
        }

    }
}
