using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace Twilio.Trunking.Tests.Model
{
    [TestFixture]
    public class IpAccessControlListTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "ip_access_control_list.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<IpAccessControlList>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual("support", output.FriendlyName);
        }
    }
}
