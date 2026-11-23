using System;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Jwt.Client;

namespace Twilio.Tests.Jwt.Client
{
    [TestFixture]
    public class IncomingClientScopeTest
    {
        [Test]
        public void TestGenerate()
        {
            var scope = new IncomingClientScope("foobar");
            Assert.AreEqual(
                "scope:client:incoming?clientName=foobar",
                scope.Payload
            );
        }

        [Test]
        public void TestInjectedScopeIsEncoded()
        {
            var name = "attacker scope:client:outgoing?appSid=AP99&clientName=attacker";
            var scope = new IncomingClientScope(name);
            Assert.IsFalse(scope.Payload.Contains(" "));
            Assert.AreEqual(1, scope.Payload.Split(' ').Length);
            Assert.AreEqual(
                "scope:client:incoming?clientName=attacker+scope%3Aclient%3Aoutgoing%3FappSid%3DAP99%26clientName%3Dattacker",
                scope.Payload
            );
        }

        [Test]
        public void TestClaimHasSingleScope()
        {
            var scopes = new System.Collections.Generic.HashSet<Twilio.Jwt.IScope>
            {
                new IncomingClientScope("a scope:client:outgoing?appSid=AP99")
            };
            var jwt = new ClientCapability("AC123", "superdupersecretsecret-superdupersecretsecret", scopes: scopes).ToJwt();
            var payload = new DecodedJwt(jwt, "superdupersecretsecret-superdupersecretsecret").Payload;
            Assert.AreEqual(1, ((string)payload["scope"]).Split(' ').Length);
        }
    }
}
