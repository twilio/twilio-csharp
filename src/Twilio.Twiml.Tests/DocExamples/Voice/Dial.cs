using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestClass]
	public class DialTests : TestBase
	{
		[TestMethod]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial("515-123-4567");
			response.Say("Goodbye");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Dial("415-123-4567", new { action = "/handleDialCallStatus.php", method = "GET" });
			response.Say("I am unreachable");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}