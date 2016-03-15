using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class RecordTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Record();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Say("Please leave a message at the beep. Press the star key when finished.");
			response.Record(new { action = "http://foo.edu/handleRecording.php", method = "GET", maxLength = 20, finishOnKey = "*" });
			response.Say("I did not receive a recording");
			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Record(new { transcribe = true, transcribeCallback = "/handle_transcribe.php" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}