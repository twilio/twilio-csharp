using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class NotificationTests
    {
        private const string NOTIFICATION_SID = "";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetNotification()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Notification>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Notification());
            var client = mockClient.Object;

            client.GetNotification(NOTIFICATION_SID);

            mockClient.Verify(trc => trc.Execute<Notification>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications/{NotificationSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var notificationSidParam = savedRequest.Parameters.Find(x => x.Name == "NotificationSid");
            Assert.IsNotNull(notificationSidParam);
            Assert.AreEqual(NOTIFICATION_SID, notificationSidParam.Value);
        }

        [Test]
        public void ShouldGetNotificationAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Notification>(It.IsAny<IRestRequest>(), It.IsAny<Action<Notification>>()))
                .Callback<IRestRequest, Action<Notification>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetNotification(NOTIFICATION_SID, notification => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Notification>(It.IsAny<IRestRequest>(), It.IsAny<Action<Notification>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications/{NotificationSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var notificationSidParam = savedRequest.Parameters.Find(x => x.Name == "NotificationSid");
            Assert.IsNotNull(notificationSidParam);
            Assert.AreEqual(NOTIFICATION_SID, notificationSidParam.Value);
        }

        [Test]
        public void ShouldListNotification()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<NotificationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new NotificationResult());
            var client = mockClient.Object;

            client.ListNotifications();

            mockClient.Verify(trc => trc.Execute<NotificationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListNotificationAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<NotificationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<NotificationResult>>()))
                .Callback<IRestRequest, Action<NotificationResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListNotifications(notifications => { 
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<NotificationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<NotificationResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListNotificationUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<NotificationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new NotificationResult());
            var client = mockClient.Object;

            client.ListNotifications(0, null, null, null);

            mockClient.Verify(trc => trc.Execute<NotificationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var logParam = savedRequest.Parameters.Find(x => x.Name == "Log");
            Assert.IsNotNull(logParam);
            Assert.AreEqual(0, logParam.Value);
        }

        [Test]
        public void ShouldDeleteNotification()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteNotification(NOTIFICATION_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications/{NotificationSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var notificationSidParam = savedRequest.Parameters.Find(x => x.Name == "NotificationSid");
            Assert.IsNotNull(notificationSidParam);
            Assert.AreEqual(NOTIFICATION_SID, notificationSidParam.Value);
        }

        [Test]
        public void ShouldDeleteNotificationAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteNotification(NOTIFICATION_SID, notification => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Notifications/{NotificationSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var notificationSidParam = savedRequest.Parameters.Find(x => x.Name == "NotificationSid");
            Assert.IsNotNull(notificationSidParam);
            Assert.AreEqual(NOTIFICATION_SID, notificationSidParam.Value);
        }

    }
}
