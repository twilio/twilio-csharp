using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class PlayTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Play("http://foo.com/cowbell.mp3");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}