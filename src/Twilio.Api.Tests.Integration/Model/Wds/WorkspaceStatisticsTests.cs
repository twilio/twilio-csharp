using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Wds;

namespace Twilio.Api.Tests.Integration.Model
{
    [TestFixture]
    public class WorkspaceStatisticsTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources/Wds", "workspace_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<WorkspaceStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}

