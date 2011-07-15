using System;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class PlayTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Play()
		{
			var response = new TwilioResponse();
			response.Play("Hello world");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Single_Play_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Play("Hello world", new { loop = 3 });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Consecutive_Mixed_Plays()
		{
			var response = new TwilioResponse();
			response.Play("Hello world");
			response.Play("Hello world2", new { loop = 3 });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}