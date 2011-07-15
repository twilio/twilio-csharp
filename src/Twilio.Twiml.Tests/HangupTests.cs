using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class HangupTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Hangup()
		{
			var response = new TwilioResponse();
			response.Hangup();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}