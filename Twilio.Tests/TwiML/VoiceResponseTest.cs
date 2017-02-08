using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class VoiceResponseTest
    {
        [Test]
        public void TestEmptyResponse()
        {
            var vr = new VoiceResponse();
            Assert.AreEqual(
                vr.ToString(), 
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response />"
            );
        }

        [Test]
        public void TestDial()
        {
            var vr = new VoiceResponse();
            vr.Dial("+11234567890", method: "GET", timeout: 5);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Dial timeout=\"5\" method=\"GET\">+11234567890</Dial>" + Environment.NewLine + 
                "</Response>"
            );
        }

        [Test]
        public void TestNestedDial()
        {
            Dial dial = new Dial(hangupOnStar: false, timeLimit: 100);
            dial.Client("client", method: "GET", url: "www.twilio.com");

            var vr = new VoiceResponse();
            vr.Dial(dial);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Dial hangupOnStar=\"false\" timeLimit=\"100\">" + Environment.NewLine +
                "    <Client method=\"GET\" url=\"www.twilio.com\">client</Client>" + Environment.NewLine +
                "  </Dial>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestEnqueue()
        {
            var vr = new VoiceResponse();
            vr.Enqueue("queue", action: "www.twilio.com");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine + 
                "  <Enqueue action=\"www.twilio.com\">queue</Enqueue>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestGather()
        {
            var vr = new VoiceResponse();
            vr.Gather(timeout: 5);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather timeout=\"5\" />" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestNestedGather()
        {
            var gather = new Gather();
            gather.Say("Hello world");

            var vr = new VoiceResponse();
            vr.Gather(gather);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather>" + Environment.NewLine +
                "    <Say>Hello world</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestHangup()
        {
            var vr = new VoiceResponse();
            vr.Hangup();

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Hangup />" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestLeave()
        {
            var vr = new VoiceResponse();
            vr.Leave();

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Leave />" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestPause()
        {
            var vr = new VoiceResponse();
            vr.Pause(length: 5);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Pause length=\"5\" />" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestPlay()
        {
            var vr = new VoiceResponse();
            vr.Play("www.twilio.com", loop: 2);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Play loop=\"2\">www.twilio.com</Play>" + Environment.NewLine + 
                "</Response>"
            );
        }

        [Test]
        public void TestRecord()
        {
            var vr = new VoiceResponse();
            vr.Record(transcribe: true, method: "GET", action: "www.twilio.com");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Record transcribe=\"true\" action=\"www.twilio.com\" method=\"GET\" />" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestRedirect()
        {
            var vr = new VoiceResponse();
            vr.Redirect("www.twilio.com", method: "POST");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Redirect method=\"POST\">www.twilio.com</Redirect>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestReject()
        {
            var vr = new VoiceResponse();
            vr.Reject(reason: "busy");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Reject reason=\"busy\" />" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestSay()
        {
            var vr = new VoiceResponse();
            vr.Say("hello world", loop: 3);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Say loop=\"3\">hello world</Say>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestSms()
        {
            var vr = new VoiceResponse();
            vr.Sms("twilio sms", to: "+11234567890", from: "+10987654321");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Sms to=\"+11234567890\" from=\"+10987654321\">twilio sms</Sms>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestVoiceResponse()
        {
            var vr = new VoiceResponse();
            vr.Hangup();
            vr.Leave();
            vr.Sms("twilio sms", to: "+11234567890", from: "+10987654321");

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Hangup />" + Environment.NewLine +
                "  <Leave />" + Environment.NewLine +
                "  <Sms to=\"+11234567890\" from=\"+10987654321\">twilio sms</Sms>" + Environment.NewLine +
                "</Response>"
            );

        }
    }
}

