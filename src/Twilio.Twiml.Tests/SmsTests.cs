using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
	public class SmsTests : TestBase
	{
		[Test]
		public void Can_Generate_Single_Sms()
		{
			var response = new TwilioResponse();
			response.Sms("Hello world");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Single_Sms_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Sms("Hello world", new { to = "+15551111111", from = "+15552222222", action = "sms.php", method = "GET", statusCallback = "status.php" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}