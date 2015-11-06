using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class MessageTests
    {
        private const string From = "+15005550006";

        private const string To = "+13144586142";

        ManualResetEvent _manualResetEvent;

        private Mock<TwilioRestClient> _mockClient;

        [SetUp]
        public void Setup()
        {
            _mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken) {CallBase = true};
        }

        [Test]
        public void ShouldSendMessage()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Message());
            var client = _mockClient.Object;
            const string body = ".NET Unit Test Message";

            client.SendMessage(From, To, body);

            _mockClient.Verify(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(From, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(To, toParam.Value);
            var bodyParam = savedRequest.Parameters.Find(x => x.Name == "Body");
            Assert.IsNotNull(bodyParam);
            Assert.AreEqual(body, bodyParam.Value);
        }

        [Test]
        public void ShouldSendMessageWithService()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Message());
            var client = _mockClient.Object;
            const string body = ".NET Unit Test Message";

            client.SendMessageWithService(From, To, body);

            _mockClient.Verify(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "MessagingServiceSid");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(From, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(To, toParam.Value);
            var bodyParam = savedRequest.Parameters.Find(x => x.Name == "Body");
            Assert.IsNotNull(bodyParam);
            Assert.AreEqual(body, bodyParam.Value);
        }

        [Test]
        public void ShouldSendMessageAsynchronously()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<Message>>()))
                .Callback<IRestRequest, Action<Message>>((request, action) => savedRequest = request);
            var client = _mockClient.Object;
            _manualResetEvent = new ManualResetEvent(false);
            const string body = ".NET Unit Test Message";

            client.SendMessage(From, To, body, message => _manualResetEvent.Set());
            _manualResetEvent.WaitOne(1);

            _mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<Message>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(From, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(To, toParam.Value);
            var bodyParam = savedRequest.Parameters.Find(x => x.Name == "Body");
            Assert.IsNotNull(bodyParam);
            Assert.AreEqual(body, bodyParam.Value);
        }

        [Test]
        public void ShouldSendMessageWithServiceAsynchronously()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<Message>>()))
                .Callback<IRestRequest, Action<Message>>((request, action) => savedRequest = request);
            var client = _mockClient.Object;
            _manualResetEvent = new ManualResetEvent(false);
            const string body = ".NET Unit Test Message";

            client.SendMessageWithService(From, To, body, message => _manualResetEvent.Set());
            _manualResetEvent.WaitOne(1);

            _mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<Message>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "MessagingServiceSid");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(From, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(To, toParam.Value);
            var bodyParam = savedRequest.Parameters.Find(x => x.Name == "Body");
            Assert.IsNotNull(bodyParam);
            Assert.AreEqual(body, bodyParam.Value);
        }

        [Test]
        public void ShouldSendMessageWithUnicodeCharacters()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Message());
            var client = _mockClient.Object;
            const string body = "رسالة اختبار وحدة.NET";

            client.SendMessage(From, To, body);

            _mockClient.Verify(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(From, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(To, toParam.Value);
            var bodyParam = savedRequest.Parameters.Find(x => x.Name == "Body");
            Assert.IsNotNull(bodyParam);
            Assert.AreEqual(body, bodyParam.Value);
        }

        [Test]
        public void ShouldListMessages()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<MessageResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new MessageResult());
            var client = _mockClient.Object;

            client.ListMessages();

            _mockClient.Verify(trc => trc.Execute<MessageResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListMessagesAsynchronously()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<MessageResult>>()))
                .Callback<IRestRequest, Action<MessageResult>>((request, action) => savedRequest = request);
            var client = _mockClient.Object;
            _manualResetEvent = new ManualResetEvent(false);

            client.ListMessages(messages => _manualResetEvent.Set());
            _manualResetEvent.WaitOne(1);

            _mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<MessageResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListMessagesWithFilters()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<MessageResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new MessageResult());
            var client = _mockClient.Object;

            client.ListMessages(new MessageListRequest(){To = To, From = From});

            _mockClient.Verify(trc => trc.Execute<MessageResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Messages.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(From, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(To, toParam.Value);
        }
    }
}
