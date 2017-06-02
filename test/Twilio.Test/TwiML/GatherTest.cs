using System;
using NUnit.Framework;
using Twilio.TwiML;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class PlayTest
    {
        [Test]
        public void TestEmptyPlayUrl()
        {
            var p = new Gather.Play();

            Assert.AreEqual(
                p.ToString(),
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Gather>" + Environment.NewLine +
                "  <Play />" + Environment.NewLine +
                "</Gather>"
            );
        }

        [Test]
        public void TestPlayUrl()
        {
          var p = new Gather.Play("hey.mp3");

          Assert.AreEqual(
              p.ToString(),
              "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
              "<Gather>" + Environment.NewLine +
              "  <Play>hey.mp3</Play>" + Environment.NewLine +
              "</Gather>"
          );
        }
    }
}
