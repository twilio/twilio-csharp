using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class AuthorizedConnectAppTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldGetAuthorizedConnectApp()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.GetAuthorizedConnectApp("");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldGetAuthorizedConnectAppAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AuthorizedConnectApp result = null;
            client.GetAuthorizedConnectApp("", app=>{
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldListAuthorizedConnectApp()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListAuthorizedConnectApps();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AuthorizedConnectApps);
        }

        [TestMethod]
        public void ShouldListAuthorizedConnectAppAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AuthorizedConnectAppResult result = null;
            client.ListAuthorizedConnectApps(apps => {
                result = apps;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AuthorizedConnectApps);
        }

        [TestMethod]
        public void ShouldListAuthorizedConnectAppUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.ListAuthorizedConnectApps(null,null);

            Assert.Fail();
        }

    }
}
