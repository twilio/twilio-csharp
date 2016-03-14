using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples.Sms
{
    [TestFixture]
	public class RedirectTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Redirect("http://www.foo.com/nextInstructions");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Redirect("../nextInstructions");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}