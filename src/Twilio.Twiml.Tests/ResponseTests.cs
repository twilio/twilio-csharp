using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class ResponseTests : TestBase
	{
		[Fact]
		public void Can_Generate_Empty_Response()
		{
			var response = new TwilioResponse();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}
