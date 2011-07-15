using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class SayTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Say("Hello world");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Say("Hello world", new { voice = "woman", loop = 2 });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}