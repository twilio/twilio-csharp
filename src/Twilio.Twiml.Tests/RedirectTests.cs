using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class RedirectTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Redirect()
		{
			var response = new TwilioResponse();
			response.Redirect("url");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Single_Redirect_With_Method()
		{
			var response = new TwilioResponse();
			response.Redirect("url", "GET");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}