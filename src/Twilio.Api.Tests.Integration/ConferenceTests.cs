using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class ConferenceTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldGetConference()
        {
            //create a new conference

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.GetConference("");

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldGetConferenceAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);
            //create a new conference

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            Conference result = null;
            client.GetConference("", conference => {
                result = conference;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldListConferences()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListConferences();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Conferences);
        }
        
        [TestMethod]
        public void ShouldListConferencesAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ConferenceResult result = null;
            client.ListConferences(conferences => {
                result = conferences;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Conferences);
        }

        [TestMethod]
        public void ShouldListConferenceUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            
            ConferenceListRequest options = new ConferenceListRequest();
            client.ListConferences(options);

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldListConferenceAsynchronouslyUsingFilters()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            ConferenceListRequest options = new ConferenceListRequest();
            ConferenceResult result = null;

            client.ListConferences(options, conferences => {
                result = conferences;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.Fail();
        }

    }
}
