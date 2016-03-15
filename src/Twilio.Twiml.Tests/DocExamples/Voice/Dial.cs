using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class DialTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial("515-123-4567");
			response.Say("Goodbye");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Dial("415-123-4567", new { action = "/handleDialCallStatus.php", method = "GET" });
			response.Say("I am unreachable");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}