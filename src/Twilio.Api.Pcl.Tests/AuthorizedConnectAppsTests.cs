using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using Simple;
using System.Threading.Tasks;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class AuthorizedConnectAppTests
    {
        private const string AUTHORIZED_CONNECT_APP_SID = "CN123";

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public async Task ShouldGetAuthorizedConnectApp()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<AuthorizedConnectApp>();
            tcs.SetResult(new AuthorizedConnectApp());

            mockClient.Setup(trc => trc.Execute<AuthorizedConnectApp>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.GetAuthorizedConnectApp(AUTHORIZED_CONNECT_APP_SID);

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
        public async Task ShouldListAuthorizedConnectApp()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<AuthorizedConnectAppResult>();
            tcs.SetResult(new AuthorizedConnectAppResult());

            mockClient.Setup(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.ListAuthorizedConnectApps();

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public async Task ShouldListAuthorizedConnectAppUsingFilters()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<AuthorizedConnectAppResult>();
            tcs.SetResult(new AuthorizedConnectAppResult());

            mockClient.Setup(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.ListAuthorizedConnectApps(null, null);

            mockClient.Verify(trc => trc.Execute<AuthorizedConnectAppResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AuthorizedConnectApps.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

    }
}