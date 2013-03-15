using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests
{
    [TestClass]
	public class HangupTests : TestBase
	{
		[TestMethod]
		public void Can_Generate_Single_Hangup()
		{
			var response = new TwilioResponse();
			response.Hangup();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}