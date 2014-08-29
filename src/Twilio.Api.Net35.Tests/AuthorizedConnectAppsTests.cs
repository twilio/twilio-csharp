using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using Simple;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class AuthorizedConnectAppTests
    {
        private const string AUTHORIZED_CONNECT_APP_SID = "CN123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetAuthorizedConnectApp()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AuthorizedConnectApp>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new AuthorizedConnectApp());
            var client = mockClient.Object;

            client.GetAuthorizedConnectApp(AUTHORIZED_CONNECT_APP_SID);

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectApp>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "AuthorizedConnectAppSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(AUTHORIZED_CONNECT_APP_SID, applicationSidParam.Value);
        }

        [Test]
        public void ShouldGetAuthorizedConnectAppAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AuthorizedConnectApp>(It.IsAny<RestRequest>(), It.IsAny<Action<AuthorizedConnectApp>>()))
                .Callback<RestRequest, Action<AuthorizedConnectApp>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAuthorizedConnectApp(AUTHORIZED_CONNECT_APP_SID, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AuthorizedConnectApp>(It.IsAny<RestRequest>(), It.IsAny<Action<AuthorizedConnectApp>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "AuthorizedConnectAppSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(AUTHORIZED_CONNECT_APP_SID, applicationSidParam.Value);
        }

        [Test]
        public void ShouldListAuthorizedConnectApp()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new AuthorizedConnectAppResult());
            var client = mockClient.Object;

            client.ListAuthorizedConnectApps();

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAuthorizedConnectAppAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AuthorizedConnectAppResult>(It.IsAny<RestRequest>(), It.IsAny<Action<AuthorizedConnectAppResult>>()))
                .Callback<RestRequest, Action<AuthorizedConnectAppResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListAuthorizedConnectApps(apps =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AuthorizedConnectAppResult>(It.IsAny<RestRequest>(), It.IsAny<Action<AuthorizedConnectAppResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAuthorizedConnectAppUsingFilters()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new AuthorizedConnectAppResult());
            var client = mockClient.Object;

            client.ListAuthorizedConnectApps(null, null);

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

    }
}