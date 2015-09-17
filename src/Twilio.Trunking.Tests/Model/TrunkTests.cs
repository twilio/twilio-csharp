using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace Twilio.Trunking.Tests.Model
{
    [TestFixture]
    public class TrunkTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "trunk.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Trunk>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual("test1.pstn.twilio.com", output.DomainName);
            Assert.AreEqual("hello 1", output.FriendlyName);
        }
    }
}
