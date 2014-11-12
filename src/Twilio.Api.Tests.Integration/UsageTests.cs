using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.Api.Tests.Integration
{
    using System.Threading;

    [TestClass]
    public class UsageTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldListUsage()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListUsage("calls-inbound");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.UsageRecords);
        }

        [TestMethod]
        public void ShouldListUsageWithUri()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListUsage("calls-inbound", "Daily");

            var continuationResult = client.ListUsage(result.NextPageUri);

            Assert.IsNotNull(continuationResult);
            Assert.IsNull(continuationResult.RestException);
            Assert.IsNotNull(continuationResult.UsageRecords);
        }

        [TestMethod]
        public void ShouldListUsageWithUriAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            UsageResult result = null;
            client.ListUsage("calls-inbound", "Daily", usage =>
            {
                result = usage;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            manualResetEvent = new ManualResetEvent(false);
            UsageResult continuationResult = null;

            client.ListUsage(result.NextPageUri, usage =>
            {
                continuationResult = usage;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();            

            Assert.IsNotNull(continuationResult);
            Assert.IsNull(continuationResult.RestException);
            Assert.IsNotNull(continuationResult.UsageRecords);
        }
    }
}
