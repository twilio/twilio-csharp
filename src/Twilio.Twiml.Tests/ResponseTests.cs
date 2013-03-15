using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests
{
    [TestClass]
    public class ResponseTests : TestBase
	{
		[TestMethod]
		public void Can_Generate_Empty_Response()
		{
			var response = new TwilioResponse();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}
