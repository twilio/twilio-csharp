using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class SmsTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Say("Our store is located at 123 Easy St.");
			response.Sms("Store Location: 123 Easy St.");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Say("Our store is located at 123 Easy St.");
			response.Sms("Store Location: 123 Easy St.", new { action = "/smsHandler.php", method = "POST" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Say("Our store is located at 123 Easy St.");
			response.Sms("Store Location: 123 Easy St.", new { statusCallback = "/smsHandler.php" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}