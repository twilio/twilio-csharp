using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class HangupTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Hangup();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}