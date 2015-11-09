using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Twilio.Api.Tests.Integration.Model
{
    [TestFixture]
    public class KeyTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "key.json"));
            var json = new JsonDeserializer();
            //json.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";
            var output = json.Deserialize<Key>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual("My Signing Key", output.FriendlyName);
            Assert.AreEqual("PsPPv0QtxuPFID7tl4wAZdGe0I4OrWNX", output.Secret);
        }
    }
}
