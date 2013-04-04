using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class NotificationTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldGetNotification()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.GetNotification("");

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldGetNotificationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            
            Notification result = null;
            client.GetNotification("", notification => {
                result = notification;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldListNotification()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListNotifications();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Notifications);
        }

        [TestMethod]
        public void ShouldListNotificationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            NotificationResult result = null;
            client.ListNotifications(notifications => { 
                result = notifications;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Notifications);
        }

        [TestMethod]
        public void ShouldListNotificationUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListNotifications();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Notifications);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldDeleteNotification()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var status = client.DeleteNotification("");            
            Assert.AreEqual(DeleteStatus.Success, status);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldDeleteNotificationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            DeleteStatus status = DeleteStatus.Failed;
            client.DeleteNotification("", notification => {
                status = notification;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.AreEqual(DeleteStatus.Success, status);
            Assert.Fail();
        }

    }
}
