using System;
using NUnit.Framework;
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
    }
}
