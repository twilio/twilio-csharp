using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Jwt.Taskrouter;
using Twilio.Http;

namespace Twilio.Tests.Jwt.Taskrouter
{
    [TestFixture]
    public class PolicyTest
    {
        [Test]
        public void TestToJson()
        {
            var filter = new Dictionary<string, Policy.FilterRequirement>
            {
                { "foo", Policy.FilterRequirement.Required }
            };

            var policy = new Policy("http://localhost", HttpMethod.Get, queryFilter: filter);

            var result = new Dictionary<string, object>
            {
                { "url", "http://localhost" },
                { "method", "GET" },
                { 
                    "query_filter", new Dictionary<string, object>
                    {
                        { "foo", new Dictionary<string, object>
                            {
                                { "required", true }
                            }
                        }
                    }
                },
                { "post_filter", new Dictionary<string, object>() },
                { "allow", true }
            };

            Assert.AreEqual(result, policy.ToDict());
        }
    }
}
