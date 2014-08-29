using System;
using NUnit.Framework;
using Moq;
using Simple;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class ConferenceParticipantTests
    {

        private const string CALL_SID = "CA123";

        private const string CONFERENCE_SID = "CF123";

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldListConferenceParticipants()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ParticipantResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new ParticipantResult());
            var client = mockClient.Object;

            client.ListConferenceParticipants(CONFERENCE_SID, null);

            mockClient.Verify(trc => trc.Execute<ParticipantResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
        }

        [Test]
        public void ShouldGetConferenceParticipant()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Participant>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Participant());
            var client = mockClient.Object;

            client.GetConferenceParticipant(CONFERENCE_SID, CALL_SID);

            mockClient.Verify(trc => trc.Execute<Participant>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
        }

        [Test]
        public void ShouldMuteConferenceParticipant()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Participant>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Participant());
            var client = mockClient.Object;

            client.MuteConferenceParticipant(CONFERENCE_SID, CALL_SID);

            mockClient.Verify(trc => trc.Execute<Participant>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
            var mutedParam = savedRequest.Parameters.Find(x => x.Name == "Muted");
            Assert.IsNotNull(mutedParam);
            Assert.AreEqual(true, mutedParam.Value);
        }

        [Test]
        public void ShouldUnMuteConferenceParticipant()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Participant>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Participant());
            var client = mockClient.Object;

            client.UnmuteConferenceParticipant(CONFERENCE_SID, CALL_SID);

            mockClient.Verify(trc => trc.Execute<Participant>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
            var mutedParam = savedRequest.Parameters.Find(x => x.Name == "Muted");
            Assert.IsNotNull(mutedParam);
            Assert.AreEqual(false, mutedParam.Value);
        }

        [Test]
        public void ShouldKickConferenceParticipant()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.KickConferenceParticipant(CONFERENCE_SID, CALL_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("DELETE", savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
        }
    }
}