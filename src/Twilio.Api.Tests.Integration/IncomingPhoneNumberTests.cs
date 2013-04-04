using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class IncomingPhoneNumberTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldAddNewIncomingPhoneNumber()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            
            PhoneNumberOptions options = new PhoneNumberOptions();
            options.PhoneNumber = "+15005550006";
            options.VoiceUrl = "http://example.com/phone";
            options.VoiceMethod = "GET";
            options.VoiceFallbackUrl = "http://example.com/phone";
            options.VoiceFallbackMethod = "GET";
            options.SmsUrl = "http://example.com/sms";
            options.SmsMethod = "GET";
            options.SmsFallbackUrl= "http://example.com/sms";
            options.SmsFallbackMethod="GET";
            
            var result = client.AddIncomingPhoneNumber(options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldAddNewIncomingPhoneNumberAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);

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

            IncomingPhoneNumber result = null;
            client.AddIncomingPhoneNumber(options, number => {
                result = number;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldAddNewIncomingPhoneNumberByAreaCode()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);

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

            var result = client.AddIncomingPhoneNumber(options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldListIncomingPhoneNumbers()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var result = client.ListIncomingPhoneNumbers();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.IncomingPhoneNumbers);
        }

        [TestMethod]
        public void ShouldListIncomingPhoneNumbersAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            IncomingPhoneNumberResult result = null;
            client.ListIncomingPhoneNumbers(numbers =>
            {
                result = numbers;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.IncomingPhoneNumbers);
        }

        [TestMethod]
        public void ShouldListIncomingPhoneNumbersUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var result = client.ListIncomingPhoneNumbers();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.IncomingPhoneNumbers);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldGetIncomingPhoneNumber()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.GetIncomingPhoneNumber("");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldGetIncomingPhoneNumberAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            IncomingPhoneNumber result = null;
            client.GetIncomingPhoneNumber("", number => {
                result = number;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldUpdateIncomingPhoneNumber()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            PhoneNumberOptions options = new PhoneNumberOptions();
            var result = client.UpdateIncomingPhoneNumber("", options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldUpdateIncomingPhoneNumberAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            PhoneNumberOptions options = new PhoneNumberOptions();
            IncomingPhoneNumber result = null;
            client.UpdateIncomingPhoneNumber("", options, number => {
                result = number;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldDeleteIncomingPhoneNumber()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var status = client.DeleteIncomingPhoneNumber("");
            Assert.AreEqual(DeleteStatus.Success, status);
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldDeleteIncomingPhoneNumberAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            
            DeleteStatus status = DeleteStatus.Failed;
            client.DeleteIncomingPhoneNumber("", number => {
                status = number;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();
            
            Assert.AreEqual(DeleteStatus.Success, status);
            Assert.Fail();
        }

    }
}
