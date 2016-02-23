using Moq;
using NUnit.Framework;
using RestSharp;
using Twilio.Api.Tests.Integration;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging.Tests
{
    [TestFixture]
    public class IpMessagingChannelTests
    {
        private Mock<IpMessagingClient> _mockClient;
        private const string FriendlyName = "FriendlyName";
        private const string UniqueName = "UniqueName";

        [SetUp]
        public void Setup()
        {
            _mockClient = new Mock<IpMessagingClient>(Credentials.AccountSid, Credentials.AuthToken) { CallBase = true };
        }

        [Test]
        public void ShouldCreatePrivateChannel()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Channel());
            var client = _mockClient.Object;
            const string type = "private";

            client.CreateChannel(Credentials.IpmServiceSid, type, "FriendlyName", string.Empty);

            _mockClient.Verify(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(FriendlyName, friendlyNameParam.Value);
            var typeParam = savedRequest.Parameters.Find(x => x.Name == "Type");
            Assert.IsNotNull(typeParam);
            Assert.AreEqual(type, typeParam.Value);
        }

        [Test]
        public void ShouldCreatePublicChannel()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Channel());
            var client = _mockClient.Object;
            const string type = "public";

            client.CreateChannel(Credentials.IpmServiceSid, type, "FriendlyName", string.Empty);

            _mockClient.Verify(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(FriendlyName, friendlyNameParam.Value);
            var typeParam = savedRequest.Parameters.Find(x => x.Name == "Type");
            Assert.IsNotNull(typeParam);
            Assert.AreEqual(type, typeParam.Value);
        }

        [Test]
        public void ShouldCreatePrivateChannelWithUniqueName()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Channel());
            var client = _mockClient.Object;
            const string type = "private";

            client.CreateChannel(Credentials.IpmServiceSid, type, "FriendlyName","UniqueName", string.Empty);

            _mockClient.Verify(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(FriendlyName, friendlyNameParam.Value);
            var uniqueNameParam = savedRequest.Parameters.Find(x => x.Name == "UniqueName");
            Assert.IsNotNull(uniqueNameParam);
            Assert.AreEqual(UniqueName, uniqueNameParam.Value);
            var typeParam = savedRequest.Parameters.Find(x => x.Name == "Type");
            Assert.IsNotNull(typeParam);
            Assert.AreEqual(type, typeParam.Value);
        }

        [Test]
        public void ShouldCreatePublicChannelWithUniqueName()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Channel());
            var client = _mockClient.Object;
            const string type = "public";

            client.CreateChannel(Credentials.IpmServiceSid, type, "FriendlyName", "UniqueName", string.Empty);

            _mockClient.Verify(trc => trc.Execute<Channel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(FriendlyName, friendlyNameParam.Value);
            var uniqueNameParam = savedRequest.Parameters.Find(x => x.Name == "UniqueName");
            Assert.IsNotNull(uniqueNameParam);
            Assert.AreEqual(UniqueName, uniqueNameParam.Value);
            var typeParam = savedRequest.Parameters.Find(x => x.Name == "Type");
            Assert.IsNotNull(typeParam);
            Assert.AreEqual(type, typeParam.Value);
        }
    }
}
