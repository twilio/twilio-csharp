using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Pricing;

namespace Twilio.Api.Tests.Integration.Model
{
    [TestFixture]
    public class VoiceNumberTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources/Pricing", "voice_number.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<VoiceNumber>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("US", output.IsoCountry);
            Assert.AreEqual("United States", output.Country);
            Assert.AreEqual("usd", output.PriceUnit);
            Assert.AreEqual(0.0075m, output.InboundCallPrice.CallBasePrice);
            Assert.AreEqual(0.0070m, output.InboundCallPrice.CallCurrentPrice);
            Assert.AreEqual(0.015m, output.OutboundCallPrice.CallBasePrice);
            Assert.AreEqual(0.015m, output.OutboundCallPrice.CallCurrentPrice);
            Assert.AreEqual("+14089673429", output.Number);
        }
    }
}
