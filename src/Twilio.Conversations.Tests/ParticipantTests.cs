using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;
using Twilio.Conversations.Model;

namespace Twilio.Conversations.Tests
{
    class ParticipantTests
    {
        private const string CONVERSATION_SID = "CV123";
        private const string PARTICIPANT_SID = "PA123";

        ManualResetEvent manualResetEvent = null;

        private Mock<ConversationsClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<ConversationsClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetParticipant()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Participant>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Participant());
            var client = mockClient.Object;

            client.GetParticipant(CONVERSATION_SID, PARTICIPANT_SID);

            mockClient.Verify(trc => trc.Execute<Participant>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants/{ParticipantSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
            var participantSidParam = savedRequest.Parameters.Find(x => x.Name == "ParticipantSid");
            Assert.IsNotNull(participantSidParam);
            Assert.AreEqual(PARTICIPANT_SID, participantSidParam.Value);
        }

        [Test]
        public void ShouldGetParticipantAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Participant>(It.IsAny<IRestRequest>(), It.IsAny<Action<Participant>>()))
                .Callback<IRestRequest, Action<Participant>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetParticipant(CONVERSATION_SID, PARTICIPANT_SID, participant =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Participant>(It.IsAny<IRestRequest>(), It.IsAny<Action<Participant>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants/{ParticipantSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
            var participantSidParam = savedRequest.Parameters.Find(x => x.Name == "ParticipantSid");
            Assert.IsNotNull(participantSidParam);
            Assert.AreEqual(PARTICIPANT_SID, participantSidParam.Value);
        }

        [Test]
        public void ShouldListParticipants()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ParticipantResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ParticipantResult());
            var client = mockClient.Object;

            client.ListParticipants(CONVERSATION_SID);

            mockClient.Verify(trc => trc.Execute<ParticipantResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
        }

        [Test]
        public void ShouldListParticipantsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ParticipantResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ParticipantResult>>()))
                .Callback<IRestRequest, Action<ParticipantResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListParticipants(CONVERSATION_SID, participants =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ParticipantResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ParticipantResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
        }

        [Test]
        public void ShouldDisconnectParticipant()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Participant>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Participant());
            var client = mockClient.Object;

            client.DisconnectParticipant(CONVERSATION_SID, PARTICIPANT_SID);

            mockClient.Verify(trc => trc.Execute<Participant>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants/{ParticipantSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
            var participantSidParam = savedRequest.Parameters.Find(x => x.Name == "ParticipantSid");
            Assert.IsNotNull(participantSidParam);
            Assert.AreEqual(PARTICIPANT_SID, participantSidParam.Value);
            var statusParam = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(statusParam);
            Assert.AreEqual("disconnected", statusParam.Value);
        }

        [Test]
        public void ShouldDisconnectParticipantAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Participant>(It.IsAny<IRestRequest>(), It.IsAny<Action<Participant>>()))
                .Callback<IRestRequest, Action<Participant>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DisconnectParticipant(CONVERSATION_SID, PARTICIPANT_SID, participant =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Participant>(It.IsAny<IRestRequest>(), It.IsAny<Action<Participant>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants/{ParticipantSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
            var participantSidParam = savedRequest.Parameters.Find(x => x.Name == "ParticipantSid");
            Assert.IsNotNull(participantSidParam);
            Assert.AreEqual(PARTICIPANT_SID, participantSidParam.Value);
            var statusParam = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(statusParam);
            Assert.AreEqual("disconnected", statusParam.Value);
        }

        [Test]
        public void ShouldAddParticipant()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Participant>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Participant());
            var client = mockClient.Object;

            client.AddParticipant(CONVERSATION_SID, "ryan@AC123.endpoint.twilio.com", "connie@AC123.endpoint.twilio.com");

            mockClient.Verify(trc => trc.Execute<Participant>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual("ryan@AC123.endpoint.twilio.com", toParam.Value);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual("connie@AC123.endpoint.twilio.com", fromParam.Value);
        }

        [Test]
        public void ShouldAddParticipantAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Participant>(It.IsAny<IRestRequest>(), It.IsAny<Action<Participant>>()))
                .Callback<IRestRequest, Action<Participant>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.AddParticipant(CONVERSATION_SID, "ryan@AC123.endpoint.twilio.com", "connie@AC123.endpoint.twilio.com", participants =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Participant>(It.IsAny<IRestRequest>(), It.IsAny<Action<Participant>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}/Participants", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual("ryan@AC123.endpoint.twilio.com", toParam.Value);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual("connie@AC123.endpoint.twilio.com", fromParam.Value);
        }
    }
}
