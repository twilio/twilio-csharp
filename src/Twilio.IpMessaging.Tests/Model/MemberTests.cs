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
    public class IpMessagingMemberTests
    {
        [Test]
        public void TestDeserializeMember()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "member.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Member>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("MBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ChannelSid);
            Assert.AreEqual("test@twilio.com", output.Identity);
            Assert.AreEqual("RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.RoleSid);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/MBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
              output.Url);
        }

        [Test]
        public void TestDeserializeMemberResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "members.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<MemberResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.Members);
            Assert.AreEqual(1, output.Members.Count);
            Assert.AreEqual("MBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Members[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Members[0].AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Members[0].ServiceSid);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Members[0].ChannelSid);
            Assert.AreEqual("test@twilio.com", output.Members[0].Identity);
            Assert.AreEqual("RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Members[0].RoleSid);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/MBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
              output.Members[0].Url);
        }
    }
}
