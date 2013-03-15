using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests
{
    [TestClass]
    public class RejectTests : TestBase
	{
		[TestMethod]
		public void Can_Generate_Empty_Reject()
		{
			var response = new TwilioResponse();
			response.Reject();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Can_Generate_Reject_With_Reason()
		{
			var response = new TwilioResponse();
			response.Reject("busy");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}