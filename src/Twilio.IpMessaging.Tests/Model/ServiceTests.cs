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
    public class IpMessagingServiceTests
    {
        [Test]
        public void TestDeserializeService()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "service.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Service>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("my instance", output.FriendlyName);
            Assert.AreEqual("default role", output.DefaultServiceRoleSid);
            Assert.AreEqual("default channel", output.DefaultChannelRoleSid);
            Assert.AreEqual(5, output.TypingIndicatorTimeout);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Url);

            Dictionary<string, Dictionary<string, string>> webHooks = output.Webhooks;
            Assert.NotNull(webHooks);
            Assert.True(webHooks.ContainsKey("on_message_send"));
            Dictionary<string, string> onMessageDictionary = webHooks["on_message_send"];
            Assert.NotNull(onMessageDictionary);
            Assert.True(onMessageDictionary.ContainsKey("url"));
            Assert.True(onMessageDictionary.ContainsKey("method"));
            Assert.True(onMessageDictionary.ContainsKey("format"));
            Assert.AreEqual("http://twilio.com/message-send", onMessageDictionary["url"]);
            Assert.AreEqual("POST", onMessageDictionary["method"]);
            Assert.AreEqual("XML", onMessageDictionary["format"]);

            Dictionary<string, string> dictionary = output.Links;
            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("channels"));
            Assert.True(dictionary.ContainsKey("roles"));
            Assert.True(dictionary.ContainsKey("users"));
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels", dictionary["channels"]);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles", dictionary["roles"]);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users", dictionary["users"]);
        }

        [Test]
        public void TestDeserializeServiceResult()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "services.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<ServiceResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.Services);
            Assert.AreEqual(1, output.Services.Count);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Services[0].Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Services[0].AccountSid);
            Assert.AreEqual("my instance", output.Services[0].FriendlyName);
            Assert.AreEqual("default role", output.Services[0].DefaultServiceRoleSid);
            Assert.AreEqual("default channel", output.Services[0].DefaultChannelRoleSid);
            Assert.AreEqual(5, output.Services[0].TypingIndicatorTimeout);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Services[0].Url);

            Dictionary<string, Dictionary<string, string>> webHooks = output.Services[0].Webhooks;
            Assert.NotNull(webHooks);
            Assert.True(webHooks.ContainsKey("on_message_send"));
            Dictionary<string, string> onMessageDictionary = webHooks["on_message_send"];
            Assert.NotNull(onMessageDictionary);
            Assert.True(onMessageDictionary.ContainsKey("url"));
            Assert.True(onMessageDictionary.ContainsKey("method"));
            Assert.True(onMessageDictionary.ContainsKey("format"));
            Assert.AreEqual("http://twilio.com/message-send", onMessageDictionary["url"]);
            Assert.AreEqual("POST", onMessageDictionary["method"]);
            Assert.AreEqual("XML", onMessageDictionary["format"]);

            Dictionary<string, string> dictionary = output.Services[0].Links;
            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("channels"));
            Assert.True(dictionary.ContainsKey("roles"));
            Assert.True(dictionary.ContainsKey("users"));
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels", dictionary["channels"]);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles", dictionary["roles"]);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users", dictionary["users"]);
        }
    }
}
