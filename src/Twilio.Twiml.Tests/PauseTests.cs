using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twilio.TwiML.Tests
{
    [TestClass]
    public class PauseTests : TestBase
	{
		[TestMethod]
		public void Can_Generate_Single_Pause_With_Length()
		{
			var response = new TwilioResponse();
			response.Pause(10);

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Can_Generate_Single_Pause()
		{
			var response = new TwilioResponse();
			response.Pause();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}