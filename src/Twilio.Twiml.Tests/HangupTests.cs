using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
	public class HangupTests : TestBase
	{
		[Test]
		public void Can_Generate_Single_Hangup()
		{
			var response = new TwilioResponse();
			response.Hangup();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}