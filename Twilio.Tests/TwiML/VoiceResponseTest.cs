using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests
{
    [TestFixture]
    public class VoiceResponseTest
    {
        [Test]
        public void TestEmptyResponse()
        {
            VoiceResponse vr = new VoiceResponse();
            Assert.AreEqual(
                vr.ToString(), 
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response />"
            );
        }

        [Test]
        public void TestDial()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Dial("+11234567890", method: "GET", timeout: 5);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Dial timeout=\"5\" method=\"GET\">+11234567890</Dial>\n" + 
                "</Response>"
            );
        }

        [Test]
        public void TestNestedDial()
        {
            Dial dial = new Dial(hangupOnStar: false, timeLimit: 100);
            dial.Client("client", method: "GET", url: "www.twilio.com");

            VoiceResponse vr = new VoiceResponse();
            vr.Dial(dial);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Dial hangupOnStar=\"false\" timeLimit=\"100\">\n" +
                "    <Client method=\"GET\" url=\"www.twilio.com\">client</Client>\n" +
                "  </Dial>\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestEnqueue()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Enqueue("queue", action: "www.twilio.com");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" + 
                "  <Enqueue action=\"www.twilio.com\">queue</Enqueue>\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestGather()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Gather(timeout: 5);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Gather timeout=\"5\" />\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestNestedGather()
        {
            Gather gather = new Gather();
            gather.Say("Hello world");

            VoiceResponse vr = new VoiceResponse();
            vr.Gather(gather);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Gather>\n" +
                "    <Say>Hello world</Say>\n" +
                "  </Gather>\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestHangup()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Hangup();

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Hangup />\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestLeave()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Leave();

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Leave />\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestPause()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Pause(length: 5);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Pause />\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestPlay()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Play("www.twilio.com", loop: 2);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Play loop=\"2\">www.twilio.com</Play>\n" + 
                "</Response>"
            );
        }

        [Test]
        public void TestRecord()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Record(transcribe: true, method: "GET", action: "www.twilio.com");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Record transcribe=\"true\" action=\"www.twilio.com\" method=\"GET\" />\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestRedirect()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Redirect("www.twilio.com", method: "POST");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Redirect method=\"POST\">www.twilio.com</Redirect>\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestReject()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Reject(reason: "busy");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Reject reason=\"busy\" />\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestSay()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Say("hello world", loop: 3);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Say loop=\"3\">hello world</Say>\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestSms()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Sms("twilio sms", to: "+11234567890", from: "+10987654321");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Sms to=\"+11234567890\" from=\"+10987654321\">twilio sms</Sms>\n" +
                "</Response>"
            );
        }

        [Test]
        public void TestVoiceResponse()
        {
            VoiceResponse vr = new VoiceResponse();
            vr.Hangup();
            vr.Leave();
            vr.Sms("twilio sms", to: "+11234567890", from: "+10987654321");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\n" +
                "<Response>\n" +
                "  <Hangup />\n" +
                "  <Leave />\n" +
                "  <Sms to=\"+11234567890\" from=\"+10987654321\">twilio sms</Sms>\n" +
                "</Response>"
            );

        }
    }
}

