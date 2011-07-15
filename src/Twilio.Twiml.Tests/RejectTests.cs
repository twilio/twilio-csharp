using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class RejectTests : TestBase
	{
		[Fact]
		public void Can_Generate_Empty_Reject()
		{
			var response = new TwilioResponse();
			response.Reject();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Reject_With_Reason()
		{
			var response = new TwilioResponse();
			response.Reject("busy");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}