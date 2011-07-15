using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples.Sms
{
	public class SmsTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.", new { action = "/SmsHandler.php", method = "POST" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.", new { statusCallback = "/SMSHandler.php" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}