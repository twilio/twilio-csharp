using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class MessagingResponseTest
    {
        [Test]
        public void TestEmptyResponse()
        {
            var mr = new MessagingResponse();
            Assert.AreEqual(
                mr.ToString(), 
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response />"
            );
        }

        [Test]
        public void TestMessage()
        {
            var mr = new MessagingResponse();
            mr.Message("foobar", to: "+11234567890", method: "GET");
            Assert.AreEqual(
                mr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Message to=\"+11234567890\" method=\"GET\">foobar</Message>" + Environment.NewLine +
                "</Response>" 
            );
        }

        [Test]
        public void TestMultipleMessages()
        {
            var m1 = new Message(to: "+11111111111", from: "+12222222222");
            m1.Body("foobar");
            m1.Body("barbaz");

            var m2 = new Message();
            m2.Body("barbaz2");

            var mr = new MessagingResponse();
            mr.Message(m1).Message(m2);
            Assert.AreEqual(
                mr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Message to=\"+11111111111\" from=\"+12222222222\">" + Environment.NewLine +
                "    <Body>foobar</Body>" + Environment.NewLine + 
                "    <Body>barbaz</Body>" + Environment.NewLine + 
                "  </Message>" + Environment.NewLine +
                "  <Message>" + Environment.NewLine +
                "    <Body>barbaz2</Body>" + Environment.NewLine + 
                "  </Message>" + Environment.NewLine +
                "</Response>"   
            );
        }

        [Test]
        public void TestRedirect()
        {
            var mr = new MessagingResponse();
            mr.Redirect(method: "GET", url: "http://www.twilio.com");

            Assert.AreEqual(
                mr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Redirect method=\"GET\" url=\"http://www.twilio.com\" />" + Environment.NewLine +
                "</Response>" 
            );
        }
    }
}

