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
                "  <Message to=\"+11234567890\" method=\"GET\">foobar</Message>\n" +
                "</Response>" 
            );
        }

        [Test]
        public void TestMultipleMessages()
        {
            Message m1 = new Message(to: "+11111111111", from: "+12222222222");
            m1.Body("foobar");
            m1.Body("barbaz");

            Message m2 = new Message();
            m2.Body("barbaz2");

            MessagingResponse mr = new MessagingResponse();
            mr.Message(m1).Message(m2);
            Assert.AreEqual(
                mr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Message to=\"+11111111111\" from=\"+12222222222\">\n" +
                "    <Body>foobar</Body>\n" + 
                "    <Body>barbaz</Body>\n" + 
                "  </Message>\n" +
                "  <Message>\n" +
                "    <Body>barbaz2</Body>\n" + 
                "  </Message>\n" +
                "</Response>"   
            );
        }

        [Test]
        public void TestRedirect()
        {
            MessagingResponse mr = new MessagingResponse();
            mr.Redirect(method: "GET", url: "http://www.twilio.com");

            Assert.AreEqual(
                mr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Redirect method=\"GET\" url=\"http://www.twilio.com\" />\n" +
                "</Response>" 
            );
        }
    }
}

