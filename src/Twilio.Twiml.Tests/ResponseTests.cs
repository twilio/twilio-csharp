using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
    public class ResponseTests : TestBase
	{
		[Test]
		public void Can_Generate_Empty_Response()
		{
			var response = new TwilioResponse();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}
