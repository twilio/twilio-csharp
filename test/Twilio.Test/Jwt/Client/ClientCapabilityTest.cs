#if NET40
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Jwt.Client;
using System.IdentityModel.Tokens.Jwt;

namespace Twilio.Tests.Jwt.Client
{
    [TestFixture]
    public class ClientCapabilityTest
    {
        private static readonly string AccountSid = "AC123";
        private static readonly string Secret = "superdupersecretsecret";

        [Test]
        public void TestEmptyToken()
        {
            var jwt = new ClientCapability(AccountSid, Secret).ToJwt();

            var token = new JwtSecurityToken(jwt);
            var headers = token.Header;
            var payload = token.Payload;

            Assert.AreEqual(AccountSid, payload.Iss);
            Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
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

            var token = new JwtSecurityToken(jwt);
            var headers = token.Header;
            var payload = token.Payload;

            Assert.AreEqual(AccountSid, payload.Iss);
            Assert.Greater(payload.Exp.Value, BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            Assert.AreEqual(
                "scope:client:incoming?clientName=incomingClient " +
                "scope:stream:subscribe?path=/2010-04-01/Events " +
                "scope:client:outgoing?appSid=AP123",
                payload["scope"]
            );
        }
    }
}
#endif
