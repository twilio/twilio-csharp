using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class DialTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial("515-123-4567");
			response.Say("Goodbye");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Dial("415-123-4567", new { action = "/handleDialCallStatus.php", method = "GET" });
			response.Say("I am unreachable");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}