using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
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
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AuthorizedConnectApp>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AuthorizedConnectApp());
            var client = mockClient.Object;

            client.GetAuthorizedConnectApp(AUTHORIZED_CONNECT_APP_SID);

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectApp>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "AuthorizedConnectAppSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(AUTHORIZED_CONNECT_APP_SID, applicationSidParam.Value);
        }

        [Test]
        public void ShouldGetAuthorizedConnectAppAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AuthorizedConnectApp>(It.IsAny<IRestRequest>(), It.IsAny<Action<AuthorizedConnectApp>>()))
                .Callback<IRestRequest, Action<AuthorizedConnectApp>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAuthorizedConnectApp(AUTHORIZED_CONNECT_APP_SID, app=>{
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AuthorizedConnectApp>(It.IsAny<IRestRequest>(), It.IsAny<Action<AuthorizedConnectApp>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "AuthorizedConnectAppSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(AUTHORIZED_CONNECT_APP_SID, applicationSidParam.Value);
        }

        [Test]
        public void ShouldListAuthorizedConnectApp()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AuthorizedConnectAppResult());
            var client = mockClient.Object;

            client.ListAuthorizedConnectApps();

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAuthorizedConnectAppAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AuthorizedConnectAppResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AuthorizedConnectAppResult>>()))
                .Callback<IRestRequest, Action<AuthorizedConnectAppResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListAuthorizedConnectApps(apps => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AuthorizedConnectAppResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AuthorizedConnectAppResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAuthorizedConnectAppUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AuthorizedConnectAppResult());
            var client = mockClient.Object;

            client.ListAuthorizedConnectApps(null, null);

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

    }
}
