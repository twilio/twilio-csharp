using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests
{
    [TestFixture]
    public class MessagingResponseTest
    {
        [Test]
        public void TestEmptyResponse()
        {
            MessagingResponse mr = new MessagingResponse();
            Assert.AreEqual(
                mr.ToString(), 
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response />"
            );
        }

        [Test]
        public void TestMessage()
        {
            MessagingResponse mr = new MessagingResponse();
            mr.Message("foobar", to: "+11234567890", method: "GET");
            Assert.AreEqual(
                mr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Message to=\"+11234567890\"" 
            );
        }
    }
}

