using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Jwt.Client;

namespace Twilio.Tests.Jwt.Client
{
    [TestFixture]
    public class OutgoingClientScopeTest
    {
#if NET35
        private const string expectedPayload = "scope:client:outgoing?appSid=AP123&clientName=CL123&appParams=foo%3dbar";
#else
        private const string expectedPayload = "scope:client:outgoing?appSid=AP123&clientName=CL123&appParams=foo%3Dbar";
#endif

        [Test]
        public void TestGenerate()
        {
            var parameters = new Dictionary<string, string> { { "foo", "bar" } };
            var scope = new OutgoingClientScope("AP123", clientName: "CL123", parameters: parameters);

            Assert.AreEqual(
                expectedPayload,
                scope.Payload
            );
        }
    }
}
