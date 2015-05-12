using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace Twilio.Monitor.Tests.Model
{
    [TestFixture]
    public class AlertTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "alert.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Alert>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual("11200", output.ErrorCode);
            Assert.AreEqual("error", output.LogLevel);
        }
    }
}

