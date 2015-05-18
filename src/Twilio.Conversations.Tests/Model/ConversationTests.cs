using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

using Twilio.Conversations.Model;

namespace Twilio.Conversations.Tests.Model
{
    [TestFixture]
    public class ConversationTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "conversation.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Conversation>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual("completed", output.Status);
        }
    }
}

