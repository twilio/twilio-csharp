using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests.DocExamples.Sms
{
    [TestClass]
	public class SmsTests : TestBase
	{
		[TestMethod]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.", new { action = "/SmsHandler.php", method = "POST" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Sms("Store Location: 123 Easy St.", new { statusCallback = "/SMSHandler.php" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}