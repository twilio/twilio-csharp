using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Twilio.TwiML.Tests
{
    [TestClass]
	public class PlayTests : TestBase
	{
		[TestMethod]
		public void Can_Generate_Single_Play()
		{
			var response = new TwilioResponse();
			response.Play("Hello world");

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Can_Generate_Single_Play_And_Attributes()
		{
			var response = new TwilioResponse();
			response.Play("Hello world", new { loop = 3 });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}

		[TestMethod]
		public void Can_Generate_Consecutive_Mixed_Plays()
		{
			var response = new TwilioResponse();
			response.Play("Hello world");
			response.Play("Hello world2", new { loop = 3 });

			Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
		}
	}
}