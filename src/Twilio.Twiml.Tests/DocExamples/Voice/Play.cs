using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class PlayTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Play("http://foo.com/cowbell.mp3");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}