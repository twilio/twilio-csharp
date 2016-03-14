using System;
using NUnit.Framework;


namespace Twilio.TwiML.Tests
{
    [TestFixture]
	public class PlayTests : TestBase
	{
		[Test]
		public void Can_Generate_Single_Play()
		{
			var response = new TwilioResponse();
			response.Play("Hello world");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Single_Play_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Play("Hello world", new { loop = 3 });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Consecutive_Mixed_Plays()
		{
			var response = new TwilioResponse();
			response.Play("Hello world");
			response.Play("Hello world2", new { loop = 3 });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}