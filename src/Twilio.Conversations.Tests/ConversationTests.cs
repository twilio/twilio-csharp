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
    [TestFixture]
    public class ConversationTests
    {
        private const string CONVERSATION_SID = "CV123";

        ManualResetEvent manualResetEvent = null;

        private Mock<ConversationsClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<ConversationsClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetConversation()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Conversation>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Conversation());
            var client = mockClient.Object;

            client.GetConversation(CONVERSATION_SID);

            mockClient.Verify(trc => trc.Execute<Conversation>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
        }

        [Test]
        public void ShouldGetConversationAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Conversation>(It.IsAny<IRestRequest>(), It.IsAny<Action<Conversation>>()))
                .Callback<IRestRequest, Action<Conversation>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetConversation(CONVERSATION_SID, Conversation =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Conversation>(It.IsAny<IRestRequest>(), It.IsAny<Action<Conversation>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/{ConversationSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conversationSidParam = savedRequest.Parameters.Find(x => x.Name == "ConversationSid");
            Assert.IsNotNull(conversationSidParam);
            Assert.AreEqual(CONVERSATION_SID, conversationSidParam.Value);
        }

        [Test]
        public void ShouldListCompletedConversations()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ConversationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ConversationResult());
            var client = mockClient.Object;

            client.ListCompletedConversations();

            mockClient.Verify(trc => trc.Execute<ConversationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/Completed", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCompletedConversationsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ConversationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConversationResult>>()))
                .Callback<IRestRequest, Action<ConversationResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListCompletedConversations(workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ConversationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConversationResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/Completed", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListInProgressConversations()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ConversationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ConversationResult());
            var client = mockClient.Object;

            client.ListInProgressConversations();

            mockClient.Verify(trc => trc.Execute<ConversationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/InProgress", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListInProgressConversationsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ConversationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConversationResult>>()))
                .Callback<IRestRequest, Action<ConversationResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListInProgressConversations(workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ConversationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConversationResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Conversations/InProgress", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }


    }
}
