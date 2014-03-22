using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class MessageTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldSendSmsMessage()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendMessage("+15005550006", "+13144586142", ".NET Unit Test Message");

            if (result.RestException!=null)
                System.Diagnostics.Debug.WriteLine(result.RestException.Message);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldSendSmsMessageAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);

            Message result = null;
            client.SendMessage("+15005550006", "+13144586142", ".NET Unit Test Message", message =>
            {
                result = message;

                if (result.RestException != null)
                    System.Diagnostics.Debug.WriteLine(result.RestException.Message);
                
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldSendSmsMessageWithLongMessage()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendMessage("+15005550006", "+13144586142", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldSendSmsMessageWithUnicodeCharacters()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendMessage("+15005550006", "+13144586142", "رسالة اختبار وحدة.NET");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);
        }

        [TestMethod]
        public void ShouldFailToSendSmsMessageWithInvalidFromNumberFormat()
        {
            var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);
            var result = client.SendMessage("+15005550006", "+15005550001", ".NET Unit Test Message");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.AreEqual("21211", result.RestException.Code);
            Assert.IsNull(result.Sid);
        }

        //[TestMethod]
        //public void ShouldFailToSendSmsMessageAsynchronouslyWithInvalidFromNumber()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    Message result = null;
        //    var client = new TwilioRestClient(Credentials.TestAccountSid, Credentials.TestAuthToken);

        //    client.SendMessage("+15005550006", "+15005550001", ".NET Unit Test Message", message =>
        //    {
        //        result = message;
        //        manualResetEvent.Set();
        //    });

        //    manualResetEvent.WaitOne();

        //    Assert.IsNotNull(result);
        //    Assert.IsNotNull(result.RestException);
        //    Assert.AreEqual("21211", result.RestException.Code);
        //    Assert.IsNull(result.Sid);
        //}

        [TestMethod]
        public void ShouldListSmsMessages()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            MessageResult messages = client.ListMessages();

            Assert.IsNotNull(messages);
            Assert.IsNull(messages.RestException);
            Assert.IsNotNull(messages.Messages);
        }

        //[TestMethod]
        //public void ShouldListSmsMessagesAsynchronously()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
        //    var newmessage = client.SendMessage("", "", ".NET Unit Test Message");

        //    Assert.IsNotNull(newmessage.Sid);

        //    var smsSid = newmessage.Sid;

        //    MessageResult result = null;
        //    client.ListMessages(messages => {
        //        result = messages;
        //        manualResetEvent.Set();
        //    });

        //    manualResetEvent.WaitOne();

        //    Assert.IsNotNull(result);
        //    Assert.IsNull(result.RestException);
        //    Assert.IsNotNull(result.Messages);
            
        //}

        //[TestMethod]
        //public void ShouldListSmsMessagesWithFilters()
        //{
        //    var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
        //    Message message = client.SendMessage("", "", ".NET Unit Test Message");

        //    Assert.IsNotNull(message.Sid);

        //    var smsSid = message.Sid;

        //    MessageResult messages = client.ListMessages("", "", null, null, null);

        //    Assert.IsNotNull(messages);
        //    Assert.IsNull(messages.RestException);
        //    Assert.IsNotNull(messages.Messages);
        //}
    }
}
