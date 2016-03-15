using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Twilio.TwiML.Tests;
using Twilio.TwiML;

namespace Twilio.Twiml.Tests
{
    [TestFixture]
    public class SmsTests : TestBase
    {
        [Test]
        public void Can_Generate_Single_Message()
        {
            var response = new TwilioResponse();
            response.Message("Hello world");

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [Test]
        public void Can_Generate_Single_Message_With_Attributes()
        {
            var response = new TwilioResponse();
            response.Message(
                "Hello world", 
                new { to = "+15551111111", from = "+15552222222", action = "sms.php", method = "GET", statusCallback = "status.php" }
            );

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [Test]
        public void Can_Generate_Single_Message_With_Media()
        {
            var response = new TwilioResponse();
            response.Message(
                new string[] { 
                    "http://example.com/1", 
                    "http://example.com/2" }, 
                new { to = "+15551111111", from = "+15552222222", action = "sms.php", method = "GET", statusCallback = "status.php" }
            );

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [Test]
        public void Can_Generate_Single_Message_With_Body_And_Media()
        {
            var response = new TwilioResponse();
            response.Message(
                "Hello world",
                new string[] { 
                    "http://example.com/1", 
                    "http://example.com/2" },
                new { to = "+15551111111", from = "+15552222222", action = "sms.php", method = "GET", statusCallback = "status.php" }
            );


            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }
    }
}
