using System.Web.Mvc;
using System.Xml.Linq;
using NUnit.Framework;
using Twilio.TwiML.Mvc;
using System.Xml;

namespace Twilio.Mvc.Tests
{
    [TestFixture]
    public class TwiMLResultTest : TestBase
    {
        [Test]
        public void Can_Create_From_String()
        {
            const string payload = "<?xml version=\"1.0\"?>" +
                                   "<Response><Say>test</Say></Response>";

            var result = new TwiMLResult(payload);
            var expected = XDocument.Parse(payload);

            Assert.AreEqual(expected.ToString(), result.Data.ToString());
        }

        [Test]
        public void Can_Reject_XXE_Payload()
        {
            const string xxePayload = "<?xml version=\"1.0\"?>\n" +
                                      "<!DOCTYPE lolz [\n" +
                                      "<!ENTITY lol \"lol\">\n" +
                                      "<!ENTITY lol2 \"&lol;&lol;&lol;\">\n" +
                                      "]>\n" +
                                      "<lolz>&lol2;</lolz>";

            Assert.Throws<XmlException>(delegate { new TwiMLResult(xxePayload); });
        }
    }
}