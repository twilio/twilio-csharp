using System;
using Xunit;

namespace Twilio.TwiML.Tests
{
	public class RecordTests : TestBase
	{
		[Fact]
		public void Can_Generate_Single_Record()
		{
			var response = new TwilioResponse();
			response.Record();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Record_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Record(new { action = "record.php" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Can_Generate_Record_With_All_Attributes()
		{
			var response = new TwilioResponse();
			response.Record(new { action = "record.php", method = "GET", timeout = 10, finishOnKey = "#", maxLength = 90, transcribe = true, transcribeCallback = "transcribe.php", playBeep = false });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}