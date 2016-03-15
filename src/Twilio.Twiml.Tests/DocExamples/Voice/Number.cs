using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class NumberTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial(new Number("415-123-4567", new { sendDigits = "wwww1928" }));

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.DialNumbers("858-987-6543", "415-123-4567", "619-765-4321");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}