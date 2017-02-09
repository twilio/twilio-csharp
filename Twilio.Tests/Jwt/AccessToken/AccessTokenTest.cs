using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Jwt.AccessToken;

namespace Twilio.Tests.Jwt.AccessToken
{
	class TestToken : Token
	{
		public TestToken(
			string accountSid,
			string signingKeySid,
			string secret,
			string identity = null,
			DateTime? expiration = null,
			DateTime? nbf = null,
			HashSet<IGrant> grants = null
		) : base(accountSid, signingKeySid, secret, identity, expiration, nbf, grants) {}

		public override Dictionary<string, object> Headers
		{
			get
			{
				return new Dictionary<string, object>();
			}
		}
	}

	[TestFixture]
	public class AccessTokenTests
	{
		private Dictionary<string, object> ToDict(object o)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, object>>(o.ToString());
		}

		[Test]
		public void TestBuildToken()
		{
			var jwt = new TestToken("AC456", "SK123", "superdupersecretsecret").ToJwt();

			var decoded = new JwtSecurityToken(jwt);
			var headers = decoded.Header;
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			Assert.AreEqual("{}", payload["grants"].ToString());
		}

		[Test]
		public void TestHaveNbf()
		{
			var now = DateTime.UtcNow;
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", nbf: now).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.AreEqual(BaseJwt.ConvertToUnixTimestamp(now), payload.Nbf);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			Assert.AreEqual("{}", payload["grants"].ToString());
		}

		[Test]
		public void TestAddGrant()
		{
			var grants = new HashSet<IGrant>
			{
				{ new ConversationsGrant() }
			};
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", grants: grants).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			var decodedGrants = ToDict(payload["grants"]);
			Assert.AreEqual(1, decodedGrants.Count);
			Assert.IsNotNull(decodedGrants["rtc"]);
		}

		[Test]
		public void TestAddGrants()
		{
			var grants = new HashSet<IGrant>
			{
				{ new ConversationsGrant() },
				{ new IpMessagingGrant() }
			};
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", grants: grants).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			var decodedGrants = ToDict(payload["grants"]);
			Assert.AreEqual(2, decodedGrants.Count);
			Assert.IsNotNull(decodedGrants["rtc"]);
			Assert.IsNotNull(decodedGrants["ip_messaging"]);
		}

		[Test]
		public void TestCreateVoiceGrant()
		{
			var grants = new HashSet<IGrant>
			{
				{ 
					new VoiceGrant 
					{ 
						OutgoingApplicationSid = "AP123",
						OutgoingApplicationParams = new Dictionary<string, string> { { "foo", "bar" } }
					} 
				}
			};
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", grants: grants).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			var decodedGrants = ToDict(payload["grants"]);
			Assert.AreEqual(1, decodedGrants.Count);

			var decodedPvg = decodedGrants["voice"];
			var outgoing = ToDict(decodedPvg.ToString())["outgoing"];
			Assert.AreEqual("AP123", ToDict(outgoing)["application_sid"]);

			var decodedParams = ToDict(outgoing)["params"];
			Assert.AreEqual("bar", ToDict(decodedParams)["foo"]);
		}

		[Test]
		public void TestCreateSyncGrant()
		{
			var grants = new HashSet<IGrant>
			{
				{
					new SyncGrant
					{
						ServiceSid = "IS123",
						EndpointId = "foobar"
					}
				}
			};
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", grants: grants).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			var decodedGrants = ToDict(payload["grants"]);
			Assert.AreEqual(1, decodedGrants.Count);

			var decodedSg = ToDict(decodedGrants["data_sync"]);
			Assert.AreEqual("IS123", decodedSg["service_sid"]);
			Assert.AreEqual("foobar", decodedSg["endpoint_id"]);

		}

		[Test]
		public void TestCreateVideoGrant()
		{
			var grants = new HashSet<IGrant>
			{
				{ new VideoGrant { ConfigurationProfileSid = "CP123" } }
			};
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", grants: grants).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			var decodedGrants = ToDict(payload["grants"]);
			Assert.AreEqual(1, decodedGrants.Count);

			var decodedVg = ToDict(decodedGrants["video"]);
			Assert.AreEqual("CP123", decodedVg["configuration_profile_sid"]);
		}

		[Test]
		public void TestCreateTaskRouterGrant()
		{
			var grants = new HashSet<IGrant>
			{
				{
					new TaskRouterGrant
					{
						WorkspaceSid = "WS123",
						WorkerSid = "WK123",
						Role = "worker"
					}
				}
			};
			var token = new TestToken("AC456", "SK123", "superdupersecretsecret", grants: grants).ToJwt();
			Assert.IsNotNull(token);
			Assert.IsNotEmpty(token);

			var decoded = new JwtSecurityToken(token);
			var payload = decoded.Payload;
			Assert.IsNotNull(payload);

			Assert.AreEqual("SK123", payload.Iss);
			Assert.AreEqual("AC456", payload.Sub);
			Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

			var decodedGrants = ToDict(payload["grants"]);
			Assert.AreEqual(1, decodedGrants.Count);

			var decodedTrg = ToDict(decodedGrants["task_router"]);
			Assert.AreEqual("WS123", decodedTrg["workspace_sid"]);
			Assert.AreEqual("WK123", decodedTrg["worker_sid"]);
			Assert.AreEqual("worker", decodedTrg["role"]);
		}
	}
}
