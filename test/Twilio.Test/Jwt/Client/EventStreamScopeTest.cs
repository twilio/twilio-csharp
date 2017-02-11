using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Jwt.Client;

namespace Twilio.Tests.Jwt.Client
{
	[TestFixture]
	public class EventStreamScopeTest
	{
		[Test]
		public void TestGenerate()
		{
			var filters = new Dictionary<string, string> { { "foo", "bar" } };
			var scope = new EventStreamScope(filters: filters);

			Assert.AreEqual(
				"scope:stream:subscribe?path=/2010-04-01/Events&appParams=foo%3Dbar",
				scope.Payload
			);
		}
	}
}
