using System;
using System.Collections.Generic;

using Twilio.Jwt;
using Twilio.Jwt.Client;

namespace Twilio.UnitTests.Jwt.Client
{

    public class ClientCapabilityTest
    {
        private static readonly string AccountSid = "AC123";
        private static readonly string Secret = "superdupersecretsecret";

        [Fact]
        public void TestEmptyToken()
        {
            var jwt = new ClientCapability(AccountSid, Secret).ToJwt();

            var token = new DecodedJwt(jwt, Secret);
            var payload = token.Payload;

            Assert.Equal(AccountSid, payload["iss"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
        }

        [Fact]
        public void TestToken()
        {
            var scopes = new HashSet<IScope>
            {
                { new IncomingClientScope("incomingClient") },
                { new EventStreamScope() },
                { new OutgoingClientScope("AP123") }
            };

            var jwt = new ClientCapability(AccountSid, Secret, scopes: scopes).ToJwt();

            var token = new DecodedJwt(jwt, Secret);
            var payload = token.Payload;

            Assert.Equal(AccountSid, payload["iss"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            Assert.Equal(
                "scope:client:incoming?clientName=incomingClient " +
                "scope:stream:subscribe?path=/2010-04-01/Events " +
                "scope:client:outgoing?appSid=AP123",
                payload["scope"]
            );
        }
    }
}
