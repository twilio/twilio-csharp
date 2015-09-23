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
    public class IpMessagingUserTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "user.json"));
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
    }
}
