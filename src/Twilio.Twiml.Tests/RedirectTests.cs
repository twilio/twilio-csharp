using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests
{
    [TestClass]
    public class RedirectTests : TestBase
	{
		[TestMethod]
		public void Can_Generate_Single_Redirect()
		{
			var response = new TwilioResponse();
			response.Redirect("url");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Can_Generate_Single_Redirect_With_Method()
		{
			var response = new TwilioResponse();
			response.Redirect("url", "GET");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}