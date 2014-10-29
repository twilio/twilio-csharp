using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Wds;

namespace Twilio.Api.Tests.Integration.Model
{
    [TestFixture]
    public class WorkerStatisticsTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources/Wds", "worker_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<WorkerStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }

        [Test]
        public void testDeserializeListResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources/Wds", "workers_statistics.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<WorkersStatistics>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}


