using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Moq;
using RestSharp;
using NUnit.Framework;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    class KeyTests
    {
        private const string KEY_SID = "SK123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }
        [Test]
        public void ShouldAddNewKey()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Key>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Key());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddKey(friendlyName);

            mockClient.Verify(trc => trc.Execute<Key>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Keys.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldAddNewKeyAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Key>(It.IsAny<IRestRequest>(), It.IsAny<Action<Key>>()))
                .Callback<IRestRequest, Action<Key>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddKey(friendlyName, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Key>(It.IsAny<IRestRequest>(), It.IsAny<Action<Key>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Keys.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldGetKey()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Key>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Key());
            var client = mockClient.Object;

            client.GetKey(KEY_SID);

            mockClient.Verify(trc => trc.Execute<Key>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Keys/{Sid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var KeySidParam = savedRequest.Parameters.Find(x => x.Name == "Sid");
            Assert.IsNotNull(KeySidParam);
            Assert.AreEqual(KEY_SID, KeySidParam.Value);
        }

        [Test]
        public void ShouldGetKeyAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Key>(It.IsAny<IRestRequest>(), It.IsAny<Action<Key>>()))
                .Callback<IRestRequest, Action<Key>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetKey(KEY_SID, app =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Key>(It.IsAny<IRestRequest>(), It.IsAny<Action<Key>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Keys/{Sid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var KeySidParam = savedRequest.Parameters.Find(x => x.Name == "Sid");
            Assert.IsNotNull(KeySidParam);
            Assert.AreEqual(KEY_SID, KeySidParam.Value);
        }
    }
}
