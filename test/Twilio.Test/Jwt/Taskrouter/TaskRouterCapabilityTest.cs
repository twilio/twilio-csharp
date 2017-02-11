using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using NUnit.Framework;
using Twilio.Http;
using Twilio.Jwt;
using Twilio.Jwt.Taskrouter;

namespace Twilio.Tests.Jwt.Taskrouter
{
	[TestFixture]
	public class TaskRouterCapabilityTest
	{
		private static readonly string AccountSid = "AC123";
    	private static readonly string AuthToken = "superdupersecretsecret";
    	private static readonly string WorkspaceSid = "WS123";
    	private static readonly string WorkerSid = "WK123";

		[Test]
		public void TestToken()
		{
			var policies = new List<Policy>
			{
				{ new Policy("https://taskrouter.twilio.com/v1/Workspaces", HttpMethod.Get) }
			};

			var jwt = new TaskRouterCapability(AccountSid, AuthToken, WorkspaceSid, WorkerSid, policies: policies).ToJwt();

			var token = new JwtSecurityToken(jwt);
			var headers = token.Header;
			var payload = token.Payload;

			Assert.AreEqual(WorkspaceSid, payload["workspace_sid"]);
			Assert.AreEqual(WorkerSid, payload["channel"]);
			Assert.AreEqual(AccountSid, payload["account_sid"]);
			Assert.AreEqual(AccountSid, payload.Iss);

			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
		}
	}
}
