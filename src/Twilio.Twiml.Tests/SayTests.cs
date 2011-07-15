using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class SayTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Say()
		{
			var response = new TwilioResponse();
			response.Say("Hello world");

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Single_Say_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Say("Hello world", new { language = "en" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Consecutive_Mixed_Says()
		{
			var response = new TwilioResponse();
			response.Say("Hello world", new { voice = "woman" });
			response.Say("Hello world2", new { loop = 3 });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}