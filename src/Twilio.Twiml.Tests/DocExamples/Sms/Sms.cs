using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples.Sms
{
    [TestFixture]
	public class SmsTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.", new { action = "/SmsHandler.php", method = "POST" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.", new { statusCallback = "/SMSHandler.php" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}