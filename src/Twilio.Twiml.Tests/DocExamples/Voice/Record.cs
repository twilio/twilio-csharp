using System;
using Xunit;

namespace Twilio.TwiML.Tests.DocExamples
{
	public class RecordTests : TestBase
	{
		[Fact]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.Record();

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_2()
		{
			var response = new TwilioResponse();
			response.Say("Please leave a message at the beep. Press the star key when finished.");
			response.Record(new { action = "http://foo.edu/handleRecording.php", method = "GET", maxLength = 20, finishOnKey = "*" });
			response.Say("I did not receive a recording");
			Assert.True(IsValidTwiML(response.ToXDocument()));
		}

		[Fact]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.Record(new { transcribe = true, transcribeCallback = "/handle_transcribe.php" });

			Assert.True(IsValidTwiML(response.ToXDocument()));
		}
	}
}