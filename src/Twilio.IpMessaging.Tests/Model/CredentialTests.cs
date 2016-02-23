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
        public void TestDeserializeCredential()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "credential.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Twilio.IpMessaging.Model.Credential>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("CRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("Certificate", output.FriendlyName);
            Assert.AreEqual("apn", output.Type);
            Assert.AreEqual("sandbox", output.Sandbox);
            Assert.AreEqual("http://localhost/v1/Credentials/CRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Url);
        }

        [Test]
        public void TestDeserializeCredentialResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "credentials.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Twilio.IpMessaging.Model.CredentialResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.Credentials);
            Assert.AreEqual(1, output.Credentials.Count);
            Assert.AreEqual("CRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Credentials[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Credentials[0].AccountSid);
            Assert.AreEqual("Certificate", output.Credentials[0].FriendlyName);
            Assert.AreEqual("apn", output.Credentials[0].Type);
            Assert.AreEqual("sandbox", output.Credentials[0].Sandbox);
            Assert.AreEqual("http://localhost/v1/Credentials/CRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Credentials[0].Url);
        }
    }
}
