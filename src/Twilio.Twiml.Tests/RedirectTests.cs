using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
    public class RedirectTests : TestBase
	{
		[Test]
		public void Can_Generate_Single_Redirect()
		{
			var response = new TwilioResponse();
			response.Redirect("url");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Single_Redirect_With_Method()
		{
			var response = new TwilioResponse();
			response.Redirect("url", "GET");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}