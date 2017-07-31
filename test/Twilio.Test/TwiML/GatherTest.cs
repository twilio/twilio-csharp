using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class GatherTest
    {
        [Test]
        public void TestEmptyPlayUrlGather()
        {
            var g = new Gather();
            g.Say("Hello");
            g.Play();

            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather>" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "    <Play />" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestPlayUrlGather()
        {
          var g = new Gather();
          g.Say("Hello");
          g.Play("hey.mp3");

          var vr = new VoiceResponse();
          vr.Gather(g);

          Assert.AreEqual(
              vr.ToString(),
              "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
              "<Response>" + Environment.NewLine +
              "  <Gather>" + Environment.NewLine +
              "    <Say>Hello</Say>" + Environment.NewLine +
              "    <Play>hey.mp3</Play>" + Environment.NewLine +
              "  </Gather>" + Environment.NewLine +
              "</Response>"
          );
        }
        
        [Test]
        public void TestPartialResultCallbackGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", partialResultCallback: "http://some_url_here");
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" partialResultCallback=\"http://some_url_here\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
        
        [Test]
        public void TestPartialResultCallbackMethodGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", partialResultCallbackMethod: "POST");
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" partialResultCallbackMethod=\"POST\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
        
        [Test]
        public void TestLanguageGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", language: "en-gb");
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" language=\"en-gb\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
        
        [Test]
        public void TestHintsGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", hints: "words, phrases that have many words");
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" hints=\"words, phrases that have many words\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
        
        [Test]
        public void TestProfanityFilterGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", profanityFilter: false);
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" profanityFilter=\"false\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
        
        [Test]
        public void TestSpeechTimeoutGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", speechTimeout: 10);
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" speechTimeout=\"10\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
        
        [Test]
        public void TestBargeInGather()
        {
            var g = new Gather(input:"speech", action:"/finalresult", bargeIn: false);
            g.Say("Hello");
            
            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather input=\"speech\" action=\"/finalresult\" bargeIn=\"false\">" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }
    }
}
