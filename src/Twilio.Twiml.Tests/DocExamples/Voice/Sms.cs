using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class SmsTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Say("Our store is located at 123 Easy St.");
			response.Sms("Store Location: 123 Easy St.");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Say("Our store is located at 123 Easy St.");
			response.Sms("Store Location: 123 Easy St.", new { action = "/smsHandler.php", method = "POST" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Say("Our store is located at 123 Easy St.");
			response.Sms("Store Location: 123 Easy St.", new { statusCallback = "/smsHandler.php" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}