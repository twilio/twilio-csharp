using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class PauseTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Pause_With_Length()
		{
			var response = new TwilioResponse();
			response.Pause(10);

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Single_Pause()
		{
			var response = new TwilioResponse();
			response.Pause();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}