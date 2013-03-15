using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests.DocExamples.Sms
{
    [TestClass]
	public class RedirectTests : TestBase
	{
		[TestMethod]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Redirect("http://www.foo.com/nextInstructions");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Redirect("../nextInstructions");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}