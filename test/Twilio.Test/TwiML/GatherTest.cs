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

            Assert.AreEqual(
                g.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Gather>" + Environment.NewLine +
                "  <Say>Hello</Say>" + Environment.NewLine +
                "  <Play />" + Environment.NewLine +
                "</Gather>"
            );
        }

        [Test]
        public void TestPlayUrlGather()
        {
          var g = new Gather();
          g.Say("Hello");
          g.Play("hey.mp3");

          Assert.AreEqual(
              g.ToString(),
              "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
              "<Gather>" + Environment.NewLine +
              "  <Say>Hello</Say>" + Environment.NewLine +
              "  <Play>hey.mp3</Play>" + Environment.NewLine +
              "</Gather>"
          );
        }
    }
}
