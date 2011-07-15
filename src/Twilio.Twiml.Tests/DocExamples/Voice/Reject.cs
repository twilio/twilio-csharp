using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class RejectTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Reject();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Reject("busy");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}