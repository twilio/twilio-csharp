using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.TaskRouter;

namespace Twilio.TaskRouter.Tests.Integration.Model
{
    [TestFixture]
    public class TaskQueueStatisticsTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "task_queue_statistics.json"));
            var json = new JsonDeserializer();
            json.DateFormat = "";
            var output = json.Deserialize<TaskQueueStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }

        [Test]
        public void testDeserializeListResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "task_queues_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<TaskQueueStatisticsResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}

