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
    }
}
