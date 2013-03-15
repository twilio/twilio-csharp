using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestClass]
	public class NumberTests : TestBase
	{
		[TestMethod]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Dial(new Number("415-123-4567", new { sendDigits = "wwww1928" }));

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.DialNumbers("858-987-6543", "415-123-4567", "619-765-4321");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}