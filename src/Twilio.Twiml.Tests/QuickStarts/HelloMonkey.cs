using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Twilio.TwiML.Tests.QuickStarts
{
    [TestFixture]
	public class HelloMonkey : TestBase
	{
		[Test]
		public void _1_0()
		{
			var response = new TwilioResponse();
			response.Say("Hello monkey");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_1()
		{
			var name = "Monkey";

			var response = new TwilioResponse();
			response.Say("Hello " + name);

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_2()
		{
			var name = "Monkey";

			var response = new TwilioResponse();
			response.Say("Hello " + name);
			response.Play("http://demo.twilio.com/hellomonkey/monkey.mp3");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_3a()
		{
			var name = "Monkey";

			var response = new TwilioResponse();
			response.Say("Hello " + name);
			response.Play("http://demo.twilio.com/hellomonkey/monkey.mp3");
			response.BeginGather(new { numDigits = 1, action = "hello-monkey-handle-key.php", method = "POST" });
			response.Say("To speak to a real monkey, press 1. Press any other key to start over.");
			response.EndGather();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_3b()
		{
			var response = new TwilioResponse();
			response.Dial("+13105551212");
			response.Say("The call failed or the remote party hung up. Goodbye.");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_4a()
		{
			var name = "Monkey";

			var response = new TwilioResponse();
			response.Say("Hello " + name);
			response.Play("http://demo.twilio.com/hellomonkey/monkey.mp3");
			response.BeginGather(new { numDigits = 1, action = "hello-monkey-handle-key.php", method = "POST" });
			response.Say("To speak to a real monkey, press 1. Press 2 to record your own monkey howl. Press any other key to start over.");
			response.EndGather();

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_4b()
		{
			var digits = 1;

			var response = new TwilioResponse();
			if (digits == 1)
			{
				response.Dial("+13105551212");
				response.Say("The call failed or the remote party hung up. Goodbye.");
			}
			else if (digits == 2)
			{
				response.Say("Record your monkey howl after the tone.");
				response.Record(new { maxLength = 30, action = "hello-monkey-handle-recording.php" });
			}

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void _1_4c()
		{
			var recordingUrl = "http://example.com/example.mp3";
			
			var response = new TwilioResponse();
			response.Say("Thanks for howling... take a listen to what you howled.");
			response.Play(recordingUrl);
			response.Say("Goodbye");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}
