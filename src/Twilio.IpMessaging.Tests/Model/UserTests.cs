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
    public class IpMessagingUserTests
    {
        [Test]
        public void TestDeserializeUser()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "user.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<User>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("USaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.AreEqual("test@twilio.com", output.Identity);
            Assert.AreEqual("RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.RoleSid);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users/USaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Url);
        }

        [Test]
        public void TestDeserializeUserResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "users.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<UserResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.Users);
            Assert.AreEqual(1, output.Users.Count);
            Assert.AreEqual("USaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Users[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Users[0].AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Users[0].ServiceSid);
            Assert.AreEqual("test@twilio.com", output.Users[0].Identity);
            Assert.AreEqual("RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Users[0].RoleSid);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users/USaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Users[0].Url);
        }
    }
}
