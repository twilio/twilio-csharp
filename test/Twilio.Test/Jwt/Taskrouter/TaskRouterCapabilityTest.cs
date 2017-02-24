using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Jwt.Taskrouter;
using Twilio.Http;

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

            var token = new DecodedJwt(jwt, AuthToken);
            var payload = token.Payload;

            Assert.AreEqual(WorkspaceSid, payload["workspace_sid"]);
            Assert.AreEqual(WorkerSid, payload["channel"]);
            Assert.AreEqual(AccountSid, payload["account_sid"]);
            Assert.AreEqual(AccountSid, payload["iss"]);

            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
        }
    }
}
