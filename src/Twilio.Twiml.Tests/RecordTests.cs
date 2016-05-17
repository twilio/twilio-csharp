using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
	public class RecordTests : TestBase
	{
		[Test]
		public void Can_Generate_Single_Record()
		{
			var response = new TwilioResponse();
			response.Record();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Record_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Record(new { action = "record.php" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Record_With_All_Attributes()
		{
			var response = new TwilioResponse();
			response.Record(new { action = "record.php", method = "GET", timeout = 10, finishOnKey = "#", maxLength = 90, transcribe = true, transcribeCallback = "transcribe.php", playBeep = false });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}