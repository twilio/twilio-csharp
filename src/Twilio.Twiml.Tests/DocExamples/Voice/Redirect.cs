using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class RedirectTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial("415-123-4567");
			response.Redirect("http://www.foo.com/nextInstructions");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Redirect("../nextInstructions");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}