using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class SmsTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Sms()
		{
			var response = new TwilioResponse();
			response.Sms("Hello world");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Single_Sms_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Sms("Hello world", new { to = "+15551111111", from = "+15552222222", action = "sms.php", method = "GET", statusCallback = "status.php" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}