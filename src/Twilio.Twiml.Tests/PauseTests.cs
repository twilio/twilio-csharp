using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
    public class PauseTests : TestBase
	{
		[Test]
		public void Can_Generate_Single_Pause_With_Length()
		{
			var response = new TwilioResponse();
			response.Pause(10);

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Single_Pause()
		{
			var response = new TwilioResponse();
			response.Pause();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}