using System;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using Moq;
using Simple;
using System.Threading.Tasks;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        private const string APPLICATION_SID = "AP123";

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public async Task ShouldAddNewApplication()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Application>();
            tcs.SetResult(new Application());

            mockClient.Setup(trc => trc.Execute<Application>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;
            var options = new ApplicationOptions();
            var friendlyName = Utilities.MakeRandomFriendlyName();

            await client.AddApplication(friendlyName, options);

            mockClient.Verify(trc => trc.Execute<Application>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }
        
        [Test]
        public async Task ShouldGetApplication()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Application>();
            tcs.SetResult(new Application());
            
            mockClient.Setup(trc => trc.Execute<Application>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.GetApplication(APPLICATION_SID);

            mockClient.Verify(trc => trc.Execute<Application>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications/{ApplicationSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "ApplicationSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(APPLICATION_SID, applicationSidParam.Value);
        }

        [Test]
        public async Task ShouldListApplications()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<ApplicationResult>();
            tcs.SetResult(new ApplicationResult());
            
            mockClient.Setup(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.ListApplications();

            mockClient.Verify(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public async Task ShouldListApplicationsUsingFilters()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<ApplicationResult>();
            tcs.SetResult(new ApplicationResult());

            mockClient.Setup(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            await client.ListApplications(friendlyName, null, null);

            mockClient.Verify(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public async Task ShouldUpdateApplication()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Application>();
            tcs.SetResult(new Application());

            mockClient.Setup(trc => trc.Execute<Application>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;
            ApplicationOptions options = new ApplicationOptions();

            await client.UpdateApplication(APPLICATION_SID, "", options);

            mockClient.Verify(trc => trc.Execute<Application>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications/{ApplicationSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "ApplicationSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(APPLICATION_SID, applicationSidParam.Value);
        }

        [Test]
        public async Task ShouldDeleteApplication()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<RestResponse>();
            tcs.SetResult(new RestResponse());
            
            mockClient.Setup(trc => trc.Execute(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);

            var client = mockClient.Object;

            await client.DeleteApplication(APPLICATION_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications/{ApplicationSid}.json", savedRequest.Resource);
            Assert.AreEqual("DELETE", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSid = savedRequest.Parameters.Find(x => x.Name == "ApplicationSid");
            Assert.IsNotNull(applicationSid);
            Assert.AreEqual(APPLICATION_SID, applicationSid.Value);
        }
    }
}