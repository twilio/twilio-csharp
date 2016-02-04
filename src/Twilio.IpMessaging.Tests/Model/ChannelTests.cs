using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging.Tests.Model
{
    [TestFixture]
    public class IpMessagingChannelTests
    {
        [Test]
        public void TestDeserializeChannel()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "channel.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Channel>(new RestResponse {Content = doc});

            Assert.NotNull(output);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.AreEqual("my channel", output.FriendlyName);
            Assert.IsEmpty(output.Attributes);
            Assert.AreEqual("system", output.CreatedBy);
            Assert.AreEqual("public", output.Type);
            Assert.AreEqual(
                "http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                output.Url);
            Dictionary<string, string> dictionary = output.Links;
            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("members"));
            Assert.True(dictionary.ContainsKey("messages"));
            Assert.AreEqual(
                "http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members",
                dictionary["members"]);
            Assert.AreEqual(
                "http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages",
                dictionary["messages"]);
        }

        [Test]
        public void TestDeserializeChannelResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "channels.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<ChannelResult>(new RestResponse {Content = doc});

            Assert.NotNull(output);
            Assert.NotNull(output.Channels);
            Assert.AreEqual(1, output.Channels.Count);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Channels[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Channels[0].AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Channels[0].ServiceSid);
            Assert.AreEqual("my channel", output.Channels[0].FriendlyName);
            Assert.IsEmpty(output.Channels[0].Attributes);
            Assert.AreEqual("system", output.Channels[0].CreatedBy);
            Assert.AreEqual("public", output.Channels[0].Type);
            Assert.AreEqual(
                "http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                output.Channels[0].Url);
            Dictionary<string, string> dictionary = output.Channels[0].Links;
            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("members"));
            Assert.True(dictionary.ContainsKey("messages"));
            Assert.AreEqual(
                "http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members",
                dictionary["members"]);
            Assert.AreEqual(
                "http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages",
                dictionary["messages"]);
        }
    }
}
