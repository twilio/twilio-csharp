using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class RejectTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Reject();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Reject("busy");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}