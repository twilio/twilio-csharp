using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class PauseTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Say("I will pause 10 seconds starting now!");
			response.Pause(10);
			response.Say("I just paused 10 seconds");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Pause(5);
			response.Say("Hi there.");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}