using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class ConferenceParticipantTests
    {
        [TestMethod]
        public void ShouldListConferenceParticipants()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.ListConferenceParticipants("", null);

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldGetConferenceParticipant()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.GetConferenceParticipant("", "");

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldMuteConferenceParticipant()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.MuteConferenceParticipant("", "");

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldUnMuteConferenceParticipant()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.UnmuteConferenceParticipant("", "");

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldKickConferenceParticipant()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            client.KickConferenceParticipant("", "");

            Assert.Fail();
        }
    }
}
