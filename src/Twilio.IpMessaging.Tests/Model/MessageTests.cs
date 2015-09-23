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
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "message.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Message>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("IMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.False(output.WasEdited);
            Assert.AreEqual("alice", output.From);
            Assert.AreEqual("to", output.To);
            Assert.AreEqual("hi", output.Body);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/IMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
              output.Url);
        }
    }
}
