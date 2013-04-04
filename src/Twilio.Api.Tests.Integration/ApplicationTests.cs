using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Linq;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class ApplicationTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldAddNewApplication()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            
            ApplicationOptions options = new ApplicationOptions();

            var result = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteApplication(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldAddNewApplicationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions options = new ApplicationOptions();

            Application result = null;
            client.AddApplication(Utilities.MakeRandomFriendlyName(), options, app =>
            {
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteApplication(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldGetApplication()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions options = new ApplicationOptions();
            var originalApplication = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);

            Assert.IsNotNull(originalApplication.Sid);

            var result = client.GetApplication(originalApplication.Sid);
            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalApplication.Sid, result.Sid);

            client.DeleteApplication(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldGetApplicationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions options = new ApplicationOptions();
            var originalApplication = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);

            Assert.IsNotNull(originalApplication.Sid);

            Application result = null;

            client.GetApplication(originalApplication.Sid, app => {
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalApplication.Sid, result.Sid);

            client.DeleteApplication(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldListApplications()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var result = client.ListApplications();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Applications);
        }

        [TestMethod]
        public void ShouldListApplicationsAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationResult result = null;
            client.ListApplications(applications => {
                result = applications;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Applications);
        }
        
        [TestMethod]
        public void ShouldListApplicationsUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions options = new ApplicationOptions();
            var originalApplicationOne = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);
            var originalApplicationTwo = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);
            var originalApplicationThree = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);

            Assert.IsNotNull(originalApplicationOne.Sid);
            Assert.IsNotNull(originalApplicationTwo.Sid);
            Assert.IsNotNull(originalApplicationThree.Sid);

            var result = client.ListApplications(originalApplicationTwo.FriendlyName, null, null);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Applications);
            Assert.IsNotNull(result.Applications.FirstOrDefault(a=>a.FriendlyName==originalApplicationTwo.FriendlyName));

            client.DeleteApplication(originalApplicationOne.Sid); //cleanup
            client.DeleteApplication(originalApplicationTwo.Sid); //cleanup
            client.DeleteApplication(originalApplicationThree.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateApplication()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions originalOptions = new ApplicationOptions();
            var originalApplication = client.AddApplication(Utilities.MakeRandomFriendlyName(), originalOptions);

            Assert.IsNotNull(originalApplication.Sid);

            ApplicationOptions options = new ApplicationOptions();
            var result = client.UpdateApplication(originalApplication.Sid, "", options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalApplication.Sid, result.Sid);

            client.DeleteApplication(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateApplicationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions originalOptions = new ApplicationOptions();
            var originalApplication = client.AddApplication(Utilities.MakeRandomFriendlyName(), originalOptions);

            Assert.IsNotNull(originalApplication.Sid);

            ApplicationOptions options = new ApplicationOptions();
            Application result = null;
            client.UpdateApplication(originalApplication.Sid, "", options, app => {
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalApplication.Sid, result.Sid);

            client.DeleteApplication(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldDeleteApplication()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions options = new ApplicationOptions();
            var originalApplication = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);

            Assert.IsNotNull(originalApplication.Sid);

            var status = client.DeleteApplication(originalApplication.Sid);
            Assert.AreEqual(DeleteStatus.Success, status);
        }

        [TestMethod]
        public void ShouldDeleteApplicationAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ApplicationOptions options = new ApplicationOptions();
            var originalApplication = client.AddApplication(Utilities.MakeRandomFriendlyName(), options);

            Assert.IsNotNull(originalApplication.Sid);

            DeleteStatus status = DeleteStatus.Failed;
            client.DeleteApplication(originalApplication.Sid, app => {
                status = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.AreEqual(DeleteStatus.Success, status);
        }
    }
}
