using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class HangupTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Hangup();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}