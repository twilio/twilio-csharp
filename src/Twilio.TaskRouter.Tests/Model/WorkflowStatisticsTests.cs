using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.TaskRouter;

namespace Twilio.TaskRouter.Tests.Integration.Model
{
    [TestFixture]
    public class WorkflowStatisticsTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "workflow_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<WorkflowStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}

