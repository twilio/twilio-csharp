using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class SayTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Say("Hello world");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Say("Hello world", new { voice = "woman", loop = 2 });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}