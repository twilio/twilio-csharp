using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class GatherTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Gather();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		// http://www.twilio.com/docs/api/twiml/gather#examples-2
		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.BeginGather(new { action = "/process_gather.php", method = "GET" });
			response.Say("Please enter your account number, followed by the pound sign");
			response.EndGather();
			response.Say("We didn't receive any input. Goodbye!");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		// http://www.twilio.com/docs/api/twiml/gather#hints
		[Fact]
		public void Advanced()
		{
			var response = new TwilioResponse();
			response.BeginGather(new { action = "/process_gather.php", method = "GET" });
			response.Say("Enter something, or not");
			response.EndGather();
			response.Redirect("/process_gather.php?Digits=TIMEOUT", "GET");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}