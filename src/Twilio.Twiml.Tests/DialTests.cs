using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using System.Xml.Schema;
using System.IO;
using System.Xml;
using System.Diagnostics;
using NUnit.Framework;

namespace Twilio.TwiML.Tests
{
    [TestFixture]
    public class DialTests : TestBase
	{
		[Test]
		public void Can_Generate_Dial_Conference_And_Attributes()
		{
			var response = new TwilioResponse();
			response.DialConference("room1", new { muted = true, beep = false, waitUrl = "wait.xml", waitMethod = "GET" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_Conference_And_Attributes_And_Dial_Attributes()
		{
			var response = new TwilioResponse();
			response.DialConference("room1",
				new { muted = true, beep = false, waitUrl = "wait.xml", waitMethod = "GET" },
				new { timeLimit = 30, action = "http://example.com" }
			);

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_Conference()
		{
			var response = new TwilioResponse();
			response.DialConference("room1");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

        [Test]
		public void Can_Generate_Dial_Multiple_Numbers()
		{
			var response = new TwilioResponse();
			response.DialNumbers("555-111-1111", "555-222-2222", "555-333-3333");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Attributes_And_Number_Attributes()
		{
			var response = new TwilioResponse();
			response.Dial("555-111-2222",
				new { action = "dial.xml", method = "GET", timeout = "30", hangupOnStar = "true", timeLimit = "1000", callerId = "555-111-2222" },
				new { url = "whisper.xml", sendDigits = 1234 }
			);

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Dial("555-111-2222", new { action = "dial.xml", method = "GET", timeout = "30", hangupOnStar = "true", timeLimit = "1000", callerId = "555-111-2222" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial()
		{
			var response = new TwilioResponse();
			response.Dial("555-111-2222");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Number_Object_Param()
		{
			var response = new TwilioResponse();
			response.Dial(new Number("555-111-2222"));

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Conf_Object_Param()
		{
			var response = new TwilioResponse();
			response.Dial(new Conference("room1"));

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Number_Object_Param_And_Dial_Attributes()
		{
			var response = new TwilioResponse();
			response.Dial(new Number("555-111-2222"), new { action = "dial.xml", method = "GET", timeout = "30", hangupOnStar = "true", timeLimit = "1000", callerId = "555-111-2222" });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Conf_Object_Param_And_Dial_Attributes()
		{
			var response = new TwilioResponse();
			response.Dial(new Conference("room1"), new { action = "dial.xml", method = "GET", timeout = "30", hangupOnStar = "true", timeLimit = "1000", callerId = "555-111-2222" });
			
			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

        [Test]
        public void Can_Generate_Dial_And_Queue()
        {
            var response = new TwilioResponse();
            response.Dial(new Queue("example"));

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [Test]
        public void Can_Generate_Dial_And_Queue_Object_Param()
        {
            var response = new TwilioResponse();
            response.Dial(new Queue(new { reservationSid = "RSXXXXX", postworkActivitySid="PWXXXXXX" }));

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }
        
        [Test]
		public void Can_Generate_Dial_And_Client_Noun()
		{
			var response = new TwilioResponse();
			response.Dial(new Client("Jenny"));

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_Multiple_Clients()
		{
			var response = new TwilioResponse();
			response.DialClients("Jenny", "Tommy", "Olive");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[Test]
		public void Can_Generate_Dial_And_Mixed_Number_And_Client_Nouns()
		{
			var response = new TwilioResponse();
			response.Dial(
				new Number("+15551112222"),
				new Client("Tommy"),
				new Number("+15553334444"),
				new Number("+15556667777"),
				new Client("Jenny")
			);

			Debug.Write(response.ToString());
			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

        [Test]
        public void Can_Generate_Dial_And_Sip_Object()
        {
            var response = new TwilioResponse();
            response.Dial(new Sip("asdasd@asdasd.com"));

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [Test]
        public void Can_Generate_Dial_And_Sip_Object_And_Sip_Parameters()
        {
            var response = new TwilioResponse();
            response.Dial(new Sip("asdasd@asdasd.com", new { username="asdasd", password="asdasd", url="asdsad", method="POST" }));

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [Test]
        public void Can_Generate_Dial_And_Sip_Object_And_Dial_Parameters()
        {
            var response = new TwilioResponse();
            response.Dial(
                new Sip("asdasd@asdasd.com"),
                new { action = "dial.xml", method = "GET", timeout = "30", hangupOnStar = "true", timeLimit = "1000", callerId = "555-111-2222" }
            );

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }       
	}
}
