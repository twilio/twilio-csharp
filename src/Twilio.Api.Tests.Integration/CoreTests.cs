using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void ShouldFailToSendSmsMessageWithInvalidCredentials()
        {
            var client = new TwilioRestClient("Foo", "Bar");
            var result = client.SendSmsMessage("+15005550006", "+13144586142", ".NET Unit Test Message");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
        }

        [TestMethod]
        public void ShouldSendSmsMessageUsingWebProxy()
        {
            Assert.Fail();
        }
    }
}
