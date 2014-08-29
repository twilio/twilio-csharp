using System;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using Moq;
using Simple;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        private const string APPLICATION_SID = "AP123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldAddNewApplication()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Application>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Application());
            var client = mockClient.Object;
            var options = new ApplicationOptions();
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddApplication(friendlyName, options);

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
        public void ShouldAddNewApplicationAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Application>(It.IsAny<RestRequest>(), It.IsAny<Action<Application>>()))
                .Callback<RestRequest, Action<Application>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new ApplicationOptions();
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddApplication(friendlyName, options, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Application>(It.IsAny<RestRequest>(), It.IsAny<Action<Application>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldGetApplication()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Application>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Application());
            var client = mockClient.Object;

            client.GetApplication(APPLICATION_SID);

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
        public void ShouldGetApplicationAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Application>(It.IsAny<RestRequest>(), It.IsAny<Action<Application>>()))
                .Callback<RestRequest, Action<Application>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetApplication(APPLICATION_SID, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Application>(It.IsAny<RestRequest>(), It.IsAny<Action<Application>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications/{ApplicationSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "ApplicationSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(APPLICATION_SID, applicationSidParam.Value);
        }

        [Test]
        public void ShouldListApplications()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new ApplicationResult());
            var client = mockClient.Object;

            client.ListApplications();

            mockClient.Verify(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListApplicationsAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ApplicationResult>(It.IsAny<RestRequest>(), It.IsAny<Action<ApplicationResult>>()))
                .Callback<RestRequest, Action<ApplicationResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListApplications(applications =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ApplicationResult>(It.IsAny<RestRequest>(), It.IsAny<Action<ApplicationResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListApplicationsUsingFilters()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ApplicationResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new ApplicationResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListApplications(friendlyName, null, null);

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
        public void ShouldUpdateApplication()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Application>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Application());
            var client = mockClient.Object;
            ApplicationOptions options = new ApplicationOptions();

            client.UpdateApplication(APPLICATION_SID, "", options);

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
        public void ShouldUpdateApplicationAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Application>(It.IsAny<RestRequest>(), It.IsAny<Action<Application>>()))
                .Callback<RestRequest, Action<Application>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            var options = new ApplicationOptions();
            client.UpdateApplication(APPLICATION_SID, "", options, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Application>(It.IsAny<RestRequest>(), It.IsAny<Action<Application>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications/{ApplicationSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSidParam = savedRequest.Parameters.Find(x => x.Name == "ApplicationSid");
            Assert.IsNotNull(applicationSidParam);
            Assert.AreEqual(APPLICATION_SID, applicationSidParam.Value);
        }

        [Test]
        public void ShouldDeleteApplication()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteApplication(APPLICATION_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Applications/{ApplicationSid}.json", savedRequest.Resource);
            Assert.AreEqual("DELETE", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var applicationSid = savedRequest.Parameters.Find(x => x.Name == "ApplicationSid");
            Assert.IsNotNull(applicationSid);
            Assert.AreEqual(APPLICATION_SID, applicationSid.Value);
        }

        [Test]
        public void ShouldDeleteApplicationAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<Action<RestResponse>>()))
                .Callback<RestRequest, Action<RestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteApplication(APPLICATION_SID, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<Action<RestResponse>>()), Times.Once);
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