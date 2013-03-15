using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestClass]
	public class PlayTests : TestBase
	{
		[TestMethod]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Play("http://foo.com/cowbell.mp3");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}