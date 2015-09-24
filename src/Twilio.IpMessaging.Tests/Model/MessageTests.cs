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
    public class IpMessagingMessageTests
    {
        [Test]
        public void TestDeserializeMessage()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "message.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Twilio.IpMessaging.Model.Message>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("IMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.False(output.WasEdited);
            Assert.AreEqual("alice", output.From);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.To);
            Assert.AreEqual("hi", output.Body);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/IMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
              output.Url);
        }

        [Test]
        public void TestDeserializeMessageResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "messages.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Twilio.IpMessaging.Model.MessageResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.Messages);
            Assert.AreEqual(1, output.Messages.Count);
            Assert.AreEqual("IMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Messages[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Messages[0].AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Messages[0].ServiceSid);
            Assert.False(output.Messages[0].WasEdited);
            Assert.AreEqual("alice", output.Messages[0].From);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Messages[0].To);
            Assert.AreEqual("hi", output.Messages[0].Body);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/IMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
              output.Messages[0].Url);
        }
    }
}
