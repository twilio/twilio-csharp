
using System;
using System.Collections.Generic;
using Twilio.Jwt.Client;

namespace Twilio.UnitTests.Jwt.Client
{
    
    public class EventStreamScopeTest
    {
#if NET35
        private const string expectedPayload = "scope:stream:subscribe?path=/2010-04-01/Events&appParams=foo%3dbar";
#else
        private const string expectedPayload = "scope:stream:subscribe?path=/2010-04-01/Events&appParams=foo%3Dbar";
#endif

        [Fact]
        public void TestGenerate()
        {
            var filters = new Dictionary<string, string> { { "foo", "bar" } };
            var scope = new EventStreamScope(filters: filters);

            Assert.Equal(
                expectedPayload,
                scope.Payload
            );
        }
    }
}
