using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class GatherTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Gather();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		// http://www.twilio.com/docs/api/twiml/gather#examples-2
		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.BeginGather(new { action = "/process_gather.php", method = "GET" });
			response.Say("Please enter your account number, followed by the pound sign");
			response.EndGather();
			response.Say("We didn't receive any input. Goodbye!");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		// http://www.twilio.com/docs/api/twiml/gather#hints
		[Test]
		public void Advanced()
		{
			var response = new TwilioResponse();
			response.BeginGather(new { action = "/process_gather.php", method = "GET" });
			response.Say("Enter something, or not");
			response.EndGather();
			response.Redirect("/process_gather.php?Digits=TIMEOUT", "GET");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}