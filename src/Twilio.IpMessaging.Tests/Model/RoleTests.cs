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
    public class IpMessagingRoleTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "role.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Role>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.AreEqual("admin", output.FriendlyName);
            Assert.AreEqual("deployment", output.Type);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Url);
            List<string> permissions = output.Permissions;
            Assert.NotNull(permissions);
            Assert.AreEqual("createChannel", permissions[0]);
            Assert.AreEqual("destroyChannel", permissions[1]);
        }
    }
}
