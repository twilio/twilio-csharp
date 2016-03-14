using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
    public class RejectTests : TestBase
	{
		[Test]
		public void Can_Generate_Empty_Reject()
		{
			var response = new TwilioResponse();
			response.Reject();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Reject_With_Reason()
		{
			var response = new TwilioResponse();
			response.Reject("busy");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}