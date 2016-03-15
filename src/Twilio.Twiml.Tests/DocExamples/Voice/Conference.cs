using System;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.DocExamples
{
    [TestFixture]
	public class ConferenceTests : TestBase
	{
		[Test]
		public void Example_1()
		{
			var response = new TwilioResponse();
			response.DialConference("1234");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2a()
		{
			var response = new TwilioResponse();
			response.DialConference("1234", new { startConferenceOnEnter = "false" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_2b()
		{
			var response = new TwilioResponse();
			response.DialConference("1234", new { startConferenceOnEnter = false, endConferenceOnExit = true });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_3()
		{
			var response = new TwilioResponse();
			response.DialConference("SimpleRoom", new { muted = true });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_4()
		{
			var response = new TwilioResponse();
			response.DialConference("NoMusicNoBeepRoom", new { beep = false, waitUrl = "", startConferenceOnEnter = true, endConferenceOnExit = false });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_5a()
		{
			var response = new TwilioResponse();
			response.DialConference("Customer Waiting Room", new { beep = false });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_5b()
		{
			var response = new TwilioResponse();
			response.DialConference("Customer Waiting Room", new { beep = false, endConferenceOnExit = true });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Example_6()
		{
			var response = new TwilioResponse();
			response.Dial(new Conference("LoveTwilio"), new { action = "handleLeaveConference.php", method = "POST", hangupOnStar = "true", timeLimit = 30 });
		}
	}
}