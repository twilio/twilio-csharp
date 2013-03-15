using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests.QuickStarts
{
    [TestClass]
	public class SmsHelloMonkey : TestBase
	{
		[TestMethod]
		public void _1_0()
		{
			var response = new TwilioResponse();
			response.Sms("Hello, Mobile Monkey");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void _2_0()
		{
			var name = "Monkey";

			var response = new TwilioResponse();
			response.Sms(name + ", thanks for the message!");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void _4_0()
		{
			var name = "Monkey";
			var to = "+15558675309";
			var counter = 2;

			var response = new TwilioResponse();
			response.Sms(name + " has messaged " + to + " " + counter + " times");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void _5_0()
		{
			var name = "Monkey";

			var response = new TwilioResponse();
			response.Say("Hello " + name);
			response.Say(name + ", thanks for the call!");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}
