using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;
using Twilio.Api.Tests.Integration;

namespace Twilio.Pricing.Tests
{
    [TestFixture]
    public class MessagingCountryTests
    {
        private ManualResetEvent _manualResetEvent;
        private Mock<PricingClient> _mockClient;

        [SetUp]
        public void Setup()
        {
            _mockClient = new Mock<PricingClient>(Credentials.AccountSid, Credentials.AuthToken)
            {
                CallBase = true
            };
        }

        [Test]
        public void ShouldListMessagingCountries()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<MessagingCountryResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new MessagingCountryResult());
            var client = _mockClient.Object;

            client.ListMessagingCountries();

            _mockClient.Verify(trc => trc.Execute<MessagingCountryResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Messaging/Countries", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListMessagingCountriesAsynchronously()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<MessagingCountryResult>>()))
                .Callback<IRestRequest, Action<MessagingCountryResult>>((request, action) => savedRequest = request);
            var client = _mockClient.Object;
            _manualResetEvent = new ManualResetEvent(false);

            client.ListMessagingCountries(workspaces => {
                _manualResetEvent.Set();
            });
            _manualResetEvent.WaitOne(1);

            _mockClient
                .Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<MessagingCountryResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Messaging/Countries", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldMessagingCountry()
        {
            IRestRequest savedRequest = null;
            _mockClient.Setup(trc => trc.Execute<MessagingCountry>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new MessagingCountry());
            var client = _mockClient.Object;

            client.GetMessagingCountry("EE");

            _mockClient.Verify(trc => trc.Execute<MessagingCountry>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Messaging/Countries/{IsoCountry}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var isoCountryParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountry");
            Assert.IsNotNull(isoCountryParam);
            Assert.AreEqual("EE", isoCountryParam.Value);
        }

        [Test]
        public void ShouldGetMessagingCountryAsynchronously()
        {
            IRestRequest savedRequest = null;
            _mockClient
                .Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<MessagingCountry>>()))
                .Callback<IRestRequest, Action<MessagingCountry>>((request, action) => savedRequest = request);
            var client = _mockClient.Object;
            _manualResetEvent = new ManualResetEvent(false);

            client.GetMessagingCountry("EE", app => {
                _manualResetEvent.Set();
            });
            _manualResetEvent.WaitOne(1);

            _mockClient
                .Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<MessagingCountry>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Messaging/Countries/{IsoCountry}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var isoCountryParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountry");
            Assert.IsNotNull(isoCountryParam);
            Assert.AreEqual("EE", isoCountryParam.Value);
        }
    }
}
