using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.Pricing.Tests
{
    [TestFixture]
    public class VoiceNumberTests
    {
        ManualResetEvent manualResetEvent = null;

        private Mock<PricingClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<PricingClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetVoiceCountry()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<VoiceNumber>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new VoiceNumber());
            var client = mockClient.Object;

            client.GetVoiceNumber("+14155551234");

            mockClient.Verify(trc => trc.Execute<VoiceNumber>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Voice/Numbers/{Number}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var numberParam = savedRequest.Parameters.Find(x => x.Name == "Number");
            Assert.IsNotNull(numberParam);
            Assert.AreEqual("+14155551234", numberParam.Value);
        }

        [Test]
        public void ShouldGetVoiceCountryAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<VoiceNumber>(It.IsAny<IRestRequest>(), It.IsAny<Action<VoiceNumber>>()))
                .Callback<IRestRequest, Action<VoiceNumber>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetVoiceNumber("+14155551234", app => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<VoiceNumber>(It.IsAny<IRestRequest>(), It.IsAny<Action<VoiceNumber>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Voice/Numbers/{Number}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var numberParam = savedRequest.Parameters.Find(x => x.Name == "Number");
            Assert.IsNotNull(numberParam);
            Assert.AreEqual("+14155551234", numberParam.Value);
        }
    }
}
