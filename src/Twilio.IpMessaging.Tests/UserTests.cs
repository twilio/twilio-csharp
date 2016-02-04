using Moq;
using NUnit.Framework;
using RestSharp;
using Twilio.Api.Tests.Integration;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging.Tests
{
    [TestFixture]
    public class IpMessagingUserTests
    {
        private Mock<IpMessagingClient> _mockClient;
        private const string Identity = "UserName";
        private const string RoleSid = "RL00000000000000000000000000000000";

        [SetUp]
        public void Setup()
        {
            _mockClient = new Mock<IpMessagingClient>(Credentials.AccountSid, Credentials.AuthToken) { CallBase = true };
        }

        [Test]
        public void ShouldCreateUser()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<User>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new User());
            var client = _mockClient.Object;

            client.CreateUser(Credentials.IpmServiceSid, Identity);

            _mockClient.Verify(trc => trc.Execute<User>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var identityParam = savedRequest.Parameters.Find(x => x.Name == "Identity");
            Assert.IsNotNull(identityParam);
            Assert.AreEqual(Identity, identityParam.Value);
        }

        [Test]
        public void ShouldCreateUserWithRole()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<User>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new User());
            var client = _mockClient.Object;

            client.CreateUser(Credentials.IpmServiceSid, Identity, RoleSid);

            _mockClient.Verify(trc => trc.Execute<User>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var identityParam = savedRequest.Parameters.Find(x => x.Name == "Identity");
            Assert.IsNotNull(identityParam);
            Assert.AreEqual(Identity, identityParam.Value);
            var roleParam = savedRequest.Parameters.Find(x => x.Name == "RoleSid");
            Assert.IsNotNull(roleParam);
            Assert.AreEqual(RoleSid, roleParam.Value);
        }
    }
}
