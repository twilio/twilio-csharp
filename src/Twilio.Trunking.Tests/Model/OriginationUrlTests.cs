using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace Twilio.Trunking.Tests.Model
{
    [TestFixture]
    public class OriginationUrlTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "origination_url.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<OriginationUrl>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual(10, output.Weight);
            Assert.AreEqual(true, output.Enabled);
        }
    }
}
