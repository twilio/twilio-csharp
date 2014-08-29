using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using Simple;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class IncomingPhoneNumberTests
    {
        private const string INCOMING_PHONE_NUMBER_SID = "PN123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldAddNewIncomingPhoneNumber()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new IncomingPhoneNumber());
            var client = mockClient.Object;
            PhoneNumberOptions options = new PhoneNumberOptions();
            options.PhoneNumber = "+15005550006";
            options.VoiceUrl = "http://example.com/phone";
            options.VoiceMethod = "GET";
            options.VoiceFallbackUrl = "http://example.com/phone";
            options.VoiceFallbackMethod = "GET";
            options.SmsUrl = "http://example.com/sms";
            options.SmsMethod = "GET";
            options.SmsFallbackUrl = "http://example.com/sms";
            options.SmsFallbackMethod = "GET";

            client.AddIncomingPhoneNumber(options);

            mockClient.Verify(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(9, savedRequest.Parameters.Count);
            var phoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "PhoneNumber");
            Assert.IsNotNull(phoneNumberParam);
            Assert.AreEqual(options.PhoneNumber, phoneNumberParam.Value);
            var voiceUrlParam = savedRequest.Parameters.Find(x => x.Name == "VoiceUrl");
            Assert.IsNotNull(voiceUrlParam);
            Assert.AreEqual(options.VoiceUrl, voiceUrlParam.Value);
            var voiceMethodParam = savedRequest.Parameters.Find(x => x.Name == "VoiceMethod");
            Assert.IsNotNull(voiceMethodParam);
            Assert.AreEqual(options.VoiceMethod, voiceMethodParam.Value);
            var voiceFallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "VoiceFallbackUrl");
            Assert.IsNotNull(voiceFallbackUrlParam);
            Assert.AreEqual(options.VoiceFallbackUrl, voiceFallbackUrlParam.Value);
            var voiceFallbackMethodParam = savedRequest.Parameters.Find(x => x.Name == "VoiceFallbackMethod");
            Assert.IsNotNull(voiceFallbackMethodParam);
            Assert.AreEqual(options.VoiceFallbackMethod, voiceFallbackMethodParam.Value);
            var smsUrlParam = savedRequest.Parameters.Find(x => x.Name == "SmsUrl");
            Assert.IsNotNull(smsUrlParam);
            Assert.AreEqual(options.SmsUrl, smsUrlParam.Value);
            var smsMethodParam = savedRequest.Parameters.Find(x => x.Name == "SmsMethod");
            Assert.IsNotNull(smsMethodParam);
            Assert.AreEqual(options.SmsMethod, smsMethodParam.Value);
            var smsFallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "SmsFallbackUrl");
            Assert.IsNotNull(smsFallbackUrlParam);
            Assert.AreEqual(options.SmsFallbackUrl, smsFallbackUrlParam.Value);
            var smsFallbackMethodParam = savedRequest.Parameters.Find(x => x.Name == "SmsFallbackMethod");
            Assert.IsNotNull(smsFallbackMethodParam);
            Assert.AreEqual(options.SmsFallbackMethod, smsFallbackMethodParam.Value);
        }

        [Test]
        public void ShouldAddNewIncomingPhoneNumberAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<IncomingPhoneNumber>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumber>>()))
                .Callback<RestRequest, Action<IncomingPhoneNumber>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            PhoneNumberOptions options = new PhoneNumberOptions();
            options.PhoneNumber = "+15005550006";
            options.VoiceUrl = "http://example.com/phone";
            options.VoiceMethod = "GET";
            options.VoiceFallbackUrl = "http://example.com/phone";
            options.VoiceFallbackMethod = "GET";
            options.SmsUrl = "http://example.com/sms";
            options.SmsMethod = "GET";
            options.SmsFallbackUrl = "http://example.com/sms";
            options.SmsFallbackMethod = "GET";

            client.AddIncomingPhoneNumber(options, number =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<IncomingPhoneNumber>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumber>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(9, savedRequest.Parameters.Count);
            var phoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "PhoneNumber");
            Assert.IsNotNull(phoneNumberParam);
            Assert.AreEqual(options.PhoneNumber, phoneNumberParam.Value);
            var voiceUrlParam = savedRequest.Parameters.Find(x => x.Name == "VoiceUrl");
            Assert.IsNotNull(voiceUrlParam);
            Assert.AreEqual(options.VoiceUrl, voiceUrlParam.Value);
            var voiceMethodParam = savedRequest.Parameters.Find(x => x.Name == "VoiceMethod");
            Assert.IsNotNull(voiceMethodParam);
            Assert.AreEqual(options.VoiceMethod, voiceMethodParam.Value);
            var voiceFallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "VoiceFallbackUrl");
            Assert.IsNotNull(voiceFallbackUrlParam);
            Assert.AreEqual(options.VoiceFallbackUrl, voiceFallbackUrlParam.Value);
            var voiceFallbackMethodParam = savedRequest.Parameters.Find(x => x.Name == "VoiceFallbackMethod");
            Assert.IsNotNull(voiceFallbackMethodParam);
            Assert.AreEqual(options.VoiceFallbackMethod, voiceFallbackMethodParam.Value);
            var smsUrlParam = savedRequest.Parameters.Find(x => x.Name == "SmsUrl");
            Assert.IsNotNull(smsUrlParam);
            Assert.AreEqual(options.SmsUrl, smsUrlParam.Value);
            var smsMethodParam = savedRequest.Parameters.Find(x => x.Name == "SmsMethod");
            Assert.IsNotNull(smsMethodParam);
            Assert.AreEqual(options.SmsMethod, smsMethodParam.Value);
            var smsFallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "SmsFallbackUrl");
            Assert.IsNotNull(smsFallbackUrlParam);
            Assert.AreEqual(options.SmsFallbackUrl, smsFallbackUrlParam.Value);
            var smsFallbackMethodParam = savedRequest.Parameters.Find(x => x.Name == "SmsFallbackMethod");
            Assert.IsNotNull(smsFallbackMethodParam);
            Assert.AreEqual(options.SmsFallbackMethod, smsFallbackMethodParam.Value);
        }

        [Test]
        public void ShouldAddNewIncomingPhoneNumberByAreaCode()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new IncomingPhoneNumber());
            var client = mockClient.Object;
            PhoneNumberOptions options = new PhoneNumberOptions();
            options.AreaCode = "500";
            options.VoiceUrl = "http://example.com/phone";
            options.VoiceMethod = "GET";
            options.VoiceFallbackUrl = "http://example.com/phone";
            options.VoiceFallbackMethod = "GET";
            options.SmsUrl = "http://example.com/sms";
            options.SmsMethod = "GET";
            options.SmsFallbackUrl = "http://example.com/sms";
            options.SmsFallbackMethod = "GET";

            client.AddIncomingPhoneNumber(options);

            mockClient.Verify(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(9, savedRequest.Parameters.Count);
            var areaCodeParam = savedRequest.Parameters.Find(x => x.Name == "AreaCode");
            Assert.IsNotNull(areaCodeParam);
            Assert.AreEqual(options.AreaCode, areaCodeParam.Value);
            var voiceUrlParam = savedRequest.Parameters.Find(x => x.Name == "VoiceUrl");
            Assert.IsNotNull(voiceUrlParam);
            Assert.AreEqual(options.VoiceUrl, voiceUrlParam.Value);
            var voiceMethodParam = savedRequest.Parameters.Find(x => x.Name == "VoiceMethod");
            Assert.IsNotNull(voiceMethodParam);
            Assert.AreEqual(options.VoiceMethod, voiceMethodParam.Value);
            var voiceFallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "VoiceFallbackUrl");
            Assert.IsNotNull(voiceFallbackUrlParam);
            Assert.AreEqual(options.VoiceFallbackUrl, voiceFallbackUrlParam.Value);
            var voiceFallbackMethodParam = savedRequest.Parameters.Find(x => x.Name == "VoiceFallbackMethod");
            Assert.IsNotNull(voiceFallbackMethodParam);
            Assert.AreEqual(options.VoiceFallbackMethod, voiceFallbackMethodParam.Value);
            var smsUrlParam = savedRequest.Parameters.Find(x => x.Name == "SmsUrl");
            Assert.IsNotNull(smsUrlParam);
            Assert.AreEqual(options.SmsUrl, smsUrlParam.Value);
            var smsMethodParam = savedRequest.Parameters.Find(x => x.Name == "SmsMethod");
            Assert.IsNotNull(smsMethodParam);
            Assert.AreEqual(options.SmsMethod, smsMethodParam.Value);
            var smsFallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "SmsFallbackUrl");
            Assert.IsNotNull(smsFallbackUrlParam);
            Assert.AreEqual(options.SmsFallbackUrl, smsFallbackUrlParam.Value);
            var smsFallbackMethod = savedRequest.Parameters.Find(x => x.Name == "SmsFallbackMethod");
            Assert.IsNotNull(smsFallbackMethod);
            Assert.AreEqual(options.SmsFallbackMethod, smsFallbackMethod.Value);
        }

        [Test]
        public void ShouldListIncomingPhoneNumbers()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IncomingPhoneNumberResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new IncomingPhoneNumberResult());
            var client = mockClient.Object;

            client.ListIncomingPhoneNumbers();

            mockClient.Verify(trc => trc.Execute<IncomingPhoneNumberResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListIncomingPhoneNumbersAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<IncomingPhoneNumberResult>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumberResult>>()))
                .Callback<RestRequest, Action<IncomingPhoneNumberResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListIncomingPhoneNumbers(numbers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<IncomingPhoneNumberResult>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumberResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListIncomingPhoneNumbersUsingFilters()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IncomingPhoneNumberResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new IncomingPhoneNumberResult());
            var client = mockClient.Object;

            client.ListIncomingPhoneNumbers("+15005550006", null, null, null);

            mockClient.Verify(trc => trc.Execute<IncomingPhoneNumberResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var phoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "PhoneNumber");
            Assert.IsNotNull(phoneNumberParam);
            Assert.AreEqual("+15005550006", phoneNumberParam.Value);
        }

        [Test]
        public void ShouldGetIncomingPhoneNumber()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new IncomingPhoneNumber());
            var client = mockClient.Object;

            client.GetIncomingPhoneNumber(INCOMING_PHONE_NUMBER_SID);

            mockClient.Verify(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var incomingPhoneNumberSidParam = savedRequest.Parameters.Find(x => x.Name == "IncomingPhoneNumberSid");
            Assert.IsNotNull(incomingPhoneNumberSidParam);
            Assert.AreEqual(INCOMING_PHONE_NUMBER_SID, incomingPhoneNumberSidParam.Value);
        }

        [Test]
        public void ShouldGetIncomingPhoneNumberAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<IncomingPhoneNumber>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumber>>()))
                .Callback<RestRequest, Action<IncomingPhoneNumber>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetIncomingPhoneNumber(INCOMING_PHONE_NUMBER_SID, number =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<IncomingPhoneNumber>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumber>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var incomingPhoneNumberSidParam = savedRequest.Parameters.Find(x => x.Name == "IncomingPhoneNumberSid");
            Assert.IsNotNull(incomingPhoneNumberSidParam);
            Assert.AreEqual(INCOMING_PHONE_NUMBER_SID, incomingPhoneNumberSidParam.Value);
        }

        [Test]
        public void ShouldUpdateIncomingPhoneNumber()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new IncomingPhoneNumber());
            var client = mockClient.Object;

            PhoneNumberOptions options = new PhoneNumberOptions();
            client.UpdateIncomingPhoneNumber(INCOMING_PHONE_NUMBER_SID, options);

            mockClient.Verify(trc => trc.Execute<IncomingPhoneNumber>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var incomingPhoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "IncomingPhoneNumberSid");
            Assert.IsNotNull(incomingPhoneNumberParam);
            Assert.AreEqual(INCOMING_PHONE_NUMBER_SID, incomingPhoneNumberParam.Value);
        }

        [Test]
        public void ShouldUpdateIncomingPhoneNumberAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<IncomingPhoneNumber>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumber>>()))
                .Callback<RestRequest, Action<IncomingPhoneNumber>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            PhoneNumberOptions options = new PhoneNumberOptions();
            client.UpdateIncomingPhoneNumber(INCOMING_PHONE_NUMBER_SID, options, number =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<IncomingPhoneNumber>(It.IsAny<RestRequest>(), It.IsAny<Action<IncomingPhoneNumber>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var incomingPhoneNumberParam = savedRequest.Parameters.Find(x => x.Name == "IncomingPhoneNumberSid");
            Assert.IsNotNull(incomingPhoneNumberParam);
            Assert.AreEqual(INCOMING_PHONE_NUMBER_SID, incomingPhoneNumberParam.Value);
        }

        [Test]
        public void ShouldDeleteIncomingPhoneNumber()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteIncomingPhoneNumber(INCOMING_PHONE_NUMBER_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json", savedRequest.Resource);
            Assert.AreEqual("DELETE", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var incomingPhoneNumberSidParam = savedRequest.Parameters.Find(x => x.Name == "IncomingPhoneNumberSid");
            Assert.IsNotNull(incomingPhoneNumberSidParam);
            Assert.AreEqual(INCOMING_PHONE_NUMBER_SID, incomingPhoneNumberSidParam.Value);
        }

        [Test]
        public void ShouldDeleteIncomingPhoneNumberAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<Action<RestResponse>>()))
                .Callback<RestRequest, Action<RestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteIncomingPhoneNumber(INCOMING_PHONE_NUMBER_SID, number =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<Action<RestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json", savedRequest.Resource);
            Assert.AreEqual("DELETE", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var incomingPhoneNumberSidParam = savedRequest.Parameters.Find(x => x.Name == "IncomingPhoneNumberSid");
            Assert.IsNotNull(incomingPhoneNumberSidParam);
            Assert.AreEqual(INCOMING_PHONE_NUMBER_SID, incomingPhoneNumberSidParam.Value);
        }

    }
}