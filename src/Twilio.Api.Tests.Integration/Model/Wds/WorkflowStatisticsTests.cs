using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.TaskRouter;

namespace Twilio.Api.Tests.Integration.Model
{
    [TestFixture]
    public class WorkflowStatisticsTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources/Wds", "workflow_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<WorkflowStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}

