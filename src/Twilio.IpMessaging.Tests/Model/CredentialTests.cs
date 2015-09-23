using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.IpMessaging;

namespace Twilio.IpMessaging.Tests.Model
{
    [TestFixture]
    public class IpMessagingCredentialTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "credential.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Credential>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("CRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("Certificate", output.FriendlyName);
            Assert.AreEqual("apn", output.Type);
            Assert.AreEqual("sandbox", output.Sandbox);
            Assert.AreEqual("http://localhost/v1/Credentials/CRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Url);
        }
    }
}
