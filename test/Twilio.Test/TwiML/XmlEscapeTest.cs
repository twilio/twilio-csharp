using NUnit.Framework;
using System;
using Twilio.TwiML.Messaging;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class XmlEscapeTest : TwilioTest
    {
        [Test]
        public void TestXmlEscapedBodyMessage()
        {
            var elem = new Message("<InvalidBodyMessage></InvalidBodyMessage>");

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Message>&lt;InvalidBodyMessage&gt;&lt;/InvalidBodyMessage&gt;</Message>",
                elem.ToString()
            );
        }
        
        [Test]
        public void TestXmlEscapedText()
        {
            var elem = new Message();
            elem.AddText("<InvalidText></InvalidText>");

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Message>&lt;InvalidText&gt;&lt;/InvalidText&gt;</Message>",
                elem.ToString()
            );
        }
    }

}