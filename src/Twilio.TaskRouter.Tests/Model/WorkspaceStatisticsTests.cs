using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.TaskRouter;

namespace Twilio.TaskRouter.Tests.Integration.Model
{
    [TestFixture]
    public class WorkspaceStatisticsTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "workspace_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<WorkspaceStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}

