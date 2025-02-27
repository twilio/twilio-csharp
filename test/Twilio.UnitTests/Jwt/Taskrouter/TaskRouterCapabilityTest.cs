using System;
using System.Collections.Generic;

using Twilio.Jwt;
using Twilio.Jwt.Taskrouter;
using Twilio.Http;
using HttpMethod = Twilio.Http.HttpMethod;

namespace Twilio.UnitTests.Jwt.Taskrouter
{
    
    public class TaskRouterCapabilityTest
    {
        private static readonly string AccountSid = "AC123";
        private static readonly string AuthToken = "superdupersecretsecretNEEDSTOBELONGERTHOUGH";
        private static readonly string WorkspaceSid = "WS123";
        private static readonly string WorkerSid = "WK123";

        [Fact]
        public void TestToken()
        {
            var policies = new List<Policy>
            {
                { new Policy("https://taskrouter.twilio.com/v1/Workspaces", HttpMethod.Get) }
            };

            var jwt = new TaskRouterCapability(AccountSid, AuthToken, WorkspaceSid, WorkerSid, policies: policies).ToJwt();

            var token = new DecodedJwt(jwt, AuthToken);
            var payload = token.Payload;

            Assert.Equal(WorkspaceSid, payload["workspace_sid"]);
            Assert.Equal(WorkerSid, payload["channel"]);
            Assert.Equal(AccountSid, payload["account_sid"]);
            Assert.Equal(AccountSid, payload["iss"]);

            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
        }
    }
}
