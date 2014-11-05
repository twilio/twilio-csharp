using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class AvailablePhoneNumberTests
    {
        private const string ISO_COUNTRY_CODE = "US";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }
        
        [Test]
        public void ShouldListAvailableLocalPhoneNumbers()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AvailablePhoneNumberResult());
            var client = mockClient.Object;
            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();

            client.ListAvailableLocalPhoneNumbers(ISO_COUNTRY_CODE, options);

            mockClient.Verify(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
        }

        [Test]
        public void ShouldListAvailableLocalPhoneNumbersWithOptions()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AvailablePhoneNumberResult());
            var client = mockClient.Object;
            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();
            options.AreaCode = "314";
            options.Contains = "EA"; //contains must be 2 or more characters, unless using * alone
            options.Distance = 50;
            
            client.ListAvailableLocalPhoneNumbers(ISO_COUNTRY_CODE, options);

            mockClient.Verify(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
            var areaCodeParam = savedRequest.Parameters.Find(x => x.Name == "AreaCode");
            Assert.IsNotNull(areaCodeParam);
            Assert.AreEqual(options.AreaCode, areaCodeParam.Value);
            var containsParam = savedRequest.Parameters.Find(x => x.Name == "Contains");
            Assert.IsNotNull(containsParam);
            Assert.AreEqual(options.Contains, containsParam.Value);
            var distanceParam = savedRequest.Parameters.Find(x => x.Name == "Distance");
            Assert.IsNotNull(distanceParam);
            Assert.AreEqual(options.Distance, distanceParam.Value);
        }

        [Test]
        public void ShouldListAvailableLocalPhoneNumbersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AvailablePhoneNumberResult>>()))
                .Callback<IRestRequest, Action<AvailablePhoneNumberResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();

            client.ListAvailableLocalPhoneNumbers(ISO_COUNTRY_CODE, options, numbers => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AvailablePhoneNumberResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
        }

        [Test]
        public void ShouldListAvailableTollFreePhoneNumbers()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AvailablePhoneNumberResult());
            var client = mockClient.Object;

            client.ListAvailableTollFreePhoneNumbers(ISO_COUNTRY_CODE);

            mockClient.Verify(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
        }

        [Test]
        public void ShouldListAvailableTollFreePhoneNumbersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AvailablePhoneNumberResult>>()))
                .Callback<IRestRequest, Action<AvailablePhoneNumberResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListAvailableTollFreePhoneNumbers(ISO_COUNTRY_CODE, numbers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AvailablePhoneNumberResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
        }

        [Test]
        public void ShouldListAvailableTollFreePhoneNumbersThatContain()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AvailablePhoneNumberResult());
            var client = mockClient.Object;

            client.ListAvailableTollFreePhoneNumbers(ISO_COUNTRY_CODE, "EA");

            mockClient.Verify(trc => trc.Execute<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
            var containsParam = savedRequest.Parameters.Find(x => x.Name == "Contains");
            Assert.IsNotNull(containsParam);
            Assert.AreEqual("EA", containsParam.Value);
        }

        [Test]
        public void ShouldListAvailableTollFreePhoneNumbersAsynchronouslyThatContain()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AvailablePhoneNumberResult>>()))
                .Callback<IRestRequest, Action<AvailablePhoneNumberResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListAvailableTollFreePhoneNumbers(ISO_COUNTRY_CODE, "EA", numbers => { 
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AvailablePhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AvailablePhoneNumberResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var isoCountryCodeParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountryCode");
            Assert.IsNotNull(isoCountryCodeParam);
            Assert.AreEqual(ISO_COUNTRY_CODE, isoCountryCodeParam.Value);
            var containsParam = savedRequest.Parameters.Find(x => x.Name == "Contains");
            Assert.IsNotNull(containsParam);
            Assert.AreEqual("EA", containsParam.Value);
        }

    }
}
