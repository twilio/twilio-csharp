using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class PauseTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Say("I will pause 10 seconds starting now!");
			response.Pause(10);
			response.Say("I just paused 10 seconds");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Pause(5);
			response.Say("Hi there.");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}