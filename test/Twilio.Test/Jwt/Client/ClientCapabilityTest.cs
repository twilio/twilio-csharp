using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Jwt.Client;

namespace Twilio.Tests.Jwt.Client
{
    [TestFixture]
    public class ClientCapabilityTest
    {
        private static readonly string AccountSid = "AC123";
        // HS256 signing requires a key of at least 256 bits (32 bytes); Microsoft.IdentityModel
        // rejects anything shorter with IDX10720. Keep this at 32+ characters.
        private static readonly string Secret = "superdupersecretsecretsuperdupersecret";

        [Test]
        public void TestEmptyToken()
        {
            var jwt = new ClientCapability(AccountSid, Secret).ToJwt();

            var token = new DecodedJwt(jwt, Secret);
            var payload = token.Payload;

            Assert.AreEqual(AccountSid, payload["iss"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
        }

        [Test]
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

            Assert.AreEqual(AccountSid, payload["iss"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            Assert.AreEqual(
                "scope:client:incoming?clientName=incomingClient " +
                "scope:stream:subscribe?path=/2010-04-01/Events " +
                "scope:client:outgoing?appSid=AP123",
                payload["scope"]
            );
        }
    }
}
