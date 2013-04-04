using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class SmsTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldSendSmsMessage()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendSmsMessage("+15005550006", "+13144586142", ".NET Unit Test Message");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldSendSmsMessageAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);

            SMSMessage result = null;
            client.SendSmsMessage("+15005550006", "+13144586142", ".NET Unit Test Message", message =>
            {
                result = message;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldFailToSendSmsMessageWithLongMessage()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendSmsMessage("+15005550006", "+13144586142", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.IsTrue( int.Parse(result.RestException.Status) < 401);
            Assert.IsNull(result.Sid);
        }

        [TestMethod]
        public void ShouldSendSmsMessageWithUnicodeCharacters()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendSmsMessage("+15005550006", "+13144586142", "رسالة اختبار وحدة.NET");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldFailToSendSmsMessageWithInvalidFromNumberFormat()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendSmsMessage("+15005550006", "+15005550001", ".NET Unit Test Message");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.AreEqual("21211", result.RestException.Code);
            Assert.IsNull(result.Sid);
        }

        [TestMethod]
        public void ShouldFailToSendSmsMessageAsynchronouslyWithInvalidFromNumber()
        {
            manualResetEvent = new ManualResetEvent(false);

            SMSMessage result = null;
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);

            client.SendSmsMessage("+15005550006", "+15005550001", ".NET Unit Test Message", message =>
            {
                result = message;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.AreEqual("21211", result.RestException.Code);
            Assert.IsNull(result.Sid);
        }

        [TestMethod]
        public void ShouldListSmsMessages()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            SMSMessage message = client.SendSmsMessage("", "", ".NET Unit Test Message");

            Assert.IsNotNull(message.Sid);

            var smsSid = message.Sid;

            SmsMessageResult messages = client.ListSmsMessages();

            Assert.IsNotNull(messages);
            Assert.IsNull(messages.RestException);
            Assert.IsNotNull(messages.SMSMessages);
        }

        [TestMethod]
        public void ShouldListSmsMessagesAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var newmessage = client.SendSmsMessage("", "", ".NET Unit Test Message");

            Assert.IsNotNull(newmessage.Sid);

            var smsSid = newmessage.Sid;

            SmsMessageResult result = null;
            client.ListSmsMessages(messages => {
                result = messages;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.SMSMessages);
            
        }

        [TestMethod]
        public void ShouldListSmsMessagesWithFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            SMSMessage message = client.SendSmsMessage("", "", ".NET Unit Test Message");

            Assert.IsNotNull(message.Sid);

            var smsSid = message.Sid;

            SmsMessageResult messages = client.ListSmsMessages("", "", null, null, null);

            Assert.IsNotNull(messages);
            Assert.IsNull(messages.RestException);
            Assert.IsNotNull(messages.SMSMessages);
        }
    }
}
