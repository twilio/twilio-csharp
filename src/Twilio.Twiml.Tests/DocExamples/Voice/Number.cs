using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class NumberTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial(new Number("415-123-4567", new { sendDigits = "wwww1928" }));

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.DialNumbers("858-987-6543", "415-123-4567", "619-765-4321");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}