using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.IpMessaging;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging.Tests.Model
{
    [TestFixture]
    public class IpMessagingRoleTests
    {
        [Test]
        public void RestDeserializeRole()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "role.json"));
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

        [Test]
        public void TestDeserializeRoleResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "roles.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<RoleResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.Roles);
            Assert.AreEqual(1, output.Roles.Count);
            Assert.AreEqual("RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Roles[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Roles[0].AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Roles[0].ServiceSid);
            Assert.AreEqual("admin", output.Roles[0].FriendlyName);
            Assert.AreEqual("deployment", output.Roles[0].Type);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Roles[0].Url);
            List<string> permissions = output.Roles[0].Permissions;
            Assert.NotNull(permissions);
            Assert.AreEqual("createChannel", permissions[0]);
            Assert.AreEqual("destroyChannel", permissions[1]);
        }
    }
}
