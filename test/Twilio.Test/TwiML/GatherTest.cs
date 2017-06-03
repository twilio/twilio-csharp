using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class GatherTest
    {
        [Test]
        public void TestGatherEmptyInput()
        {
            var g = new Gather();
            g.Say("Hello");

            var vr = new VoiceResponse();
            vr.Gather(g);

            Assert.AreEqual(
                vr.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Response>" + Environment.NewLine +
                "  <Gather>" + Environment.NewLine +
                "    <Say>Hello</Say>" + Environment.NewLine +
                "  </Gather>" + Environment.NewLine +
                "</Response>"
            );
        }

        [Test]
        public void TestGatherInput()
        {
          var g = new Gather(input: "dtmf");
          g.Say("Hello");

          var vr = new VoiceResponse();
          vr.Gather(g);

          Assert.AreEqual(
              vr.ToString(),
              "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
              "<Response>" + Environment.NewLine +
              "  <Gather input=\"dtmf\">" + Environment.NewLine +
              "    <Say>Hello</Say>" + Environment.NewLine +
              "  </Gather>" + Environment.NewLine +
              "</Response>"
          );
        }
    }
}
