using System;

using Twilio.Jwt.Client;

namespace Twilio.UnitTests.Jwt.Client
{
    
    public class IncomingClientScopeTest
    {
        [Fact]
        public void TestGenerate()
        {
            var scope = new IncomingClientScope("foobar");
            Assert.Equal(
                "scope:client:incoming?clientName=foobar",
                scope.Payload
            );
        }
    }
}
