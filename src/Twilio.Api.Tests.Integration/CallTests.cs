using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Linq;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class CallTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldInitiateOutboundCall()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.InitiateOutboundCall("+15005550006", "+13144586142", "http://www.example.com/phone/");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldInitiateOutboundCallAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);
            
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            Call result = null;
            client.InitiateOutboundCall("+15005550006", "+13144586142", "http://www.example.com/phone/", call =>
            {
                result = call;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }
        
        [TestMethod]
        public void ShouldFailToInitiateOutboundCallWithInvalidFromNumber()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.InitiateOutboundCall("+15005550006", "+15005550001", "http://www.example.com/phone/");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.IsNull(result.Sid);
        }

        [TestMethod]
        public void ShouldFailToInitiateOutboundCallWithInvalidUrl()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.InitiateOutboundCall("+15005550006", "+13144586142", "/phone");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.IsNull(result.Sid);
        }

        [TestMethod]
        public void ShouldGetCall()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            Call originalCall = client.InitiateOutboundCall("+13144586142", "+13215946383", "http://devin.webscript.io/twilioconf?conf=" + Utilities.MakeRandomFriendlyName());

            Assert.IsNotNull(originalCall.Sid);

            var callSid = originalCall.Sid;

            Call call = client.GetCall(callSid);

            Assert.AreEqual(callSid, call.Sid);

            client.HangupCall(originalCall.Sid, HangupStyle.Completed);
        }

        [TestMethod]
        public void ShouldListCalls()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListCalls();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Calls);
        }

        [TestMethod]
        public void ShouldListCallsAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            CallResult result = null;
            client.ListCalls(calls => {
                result = calls;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Calls);
        }

        [TestMethod]
        public void ShouldListCallsWithFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            Call originalCall = client.InitiateOutboundCall("+13144586142", "+13215946383", "http://devin.webscript.io/twilioconf?conf=" + Utilities.MakeRandomFriendlyName());
            
            Assert.IsNotNull(originalCall.Sid);

            var callSid = originalCall.Sid;
            var startTime = originalCall.StartTime;

            client.HangupCall(originalCall.Sid, HangupStyle.Completed);

            CallListRequest options = new CallListRequest();
            options.From = "+13144586142";
            options.StartTime = startTime;

            CallResult calls = client.ListCalls(options);

            Assert.IsNotNull(calls);
            Assert.IsNull(calls.RestException);
            Assert.IsNotNull(calls.Calls);
            Assert.IsNotNull(calls.Calls.FirstOrDefault(c=>c.Sid == callSid));
        }

        [TestMethod]
        public void ShouldRedirectCall()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalFriendlyName = "http://devin.webscript.io/twilioconf?conf=" + Utilities.MakeRandomFriendlyName();
            Call originalCall = client.InitiateOutboundCall("+13144586142", "+13215946383", originalFriendlyName);

            Assert.IsNotNull(originalCall.Sid);

            var callSid = originalCall.Sid;

            int counter = 0;
            while (counter < 10)
            {
                Thread.Sleep(1000);

                var updatedcall = client.GetCall(callSid);
                if (updatedcall.Status == "")
                    break;

                counter++;
            }

            ConferenceResult conferences = client.ListConferences();

            Assert.IsNotNull(conferences);
            Assert.IsNull(conferences.RestException);
            Assert.IsNotNull(conferences.Conferences);

            Conference conference = conferences.Conferences.FirstOrDefault(c => c.FriendlyName == originalFriendlyName);

            Assert.IsNotNull(conference);
            Assert.IsNotNull(conference.Sid);

            Participant participant = client.GetConferenceParticipant(conference.Sid, callSid);

            var redirectedFriendlyName = Utilities.MakeRandomFriendlyName();
            client.RedirectCall(originalCall.Sid, "http://devin.webscript.io/twilioconf?conf=" + redirectedFriendlyName, "GET");

            conferences = client.ListConferences();

            Assert.IsNotNull(conferences);
            Assert.IsNull(conferences.RestException);
            Assert.IsNotNull(conferences.Conferences);

            conference = conferences.Conferences.FirstOrDefault(c => c.FriendlyName == redirectedFriendlyName);

            Assert.IsNotNull(conference);
            Assert.IsNotNull(conference.Sid);

            participant = client.GetConferenceParticipant(conference.Sid, callSid);

            Assert.AreEqual(callSid, participant.CallSid);

            client.HangupCall(originalCall.Sid, HangupStyle.Completed);
        }

        [TestMethod]
        public void ShouldHangupCall()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            Call originalCall = client.InitiateOutboundCall("+13144586142", "+13215946383", "http://devin.webscript.io/twilioconf?conf=" + Utilities.MakeRandomFriendlyName());

            Assert.IsNotNull(originalCall.Sid);

            var callSid = originalCall.Sid;

            client.HangupCall(originalCall.Sid, HangupStyle.Completed);

            Call updatedcall = client.GetCall(callSid);

            Assert.AreEqual("completed", updatedcall.Status);
            
        }
    }
}
