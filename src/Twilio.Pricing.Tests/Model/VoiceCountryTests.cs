using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Pricing;

namespace Twilio.Pricing.Tests.Model
{
    [TestFixture]
    public class VoiceCountryTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "voice_country.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<VoiceCountry>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("EE", output.IsoCountry);
            Assert.AreEqual("Estonia", output.Country);
            Assert.AreEqual("USD", output.PriceUnit);

            var prefixPrices = output.OutboundPrefixPrices;
            Assert.NotNull(prefixPrices);
            Assert.AreEqual(3, prefixPrices.Count);

            var prefixPrice = prefixPrices [0];
            Assert.NotNull(prefixPrice);
            Assert.AreEqual("Programmable Outbound Minute - Estonia", prefixPrice.FriendlyName);
            Assert.AreEqual(0.033m, prefixPrice.BasePrice);
            Assert.AreEqual(0.030m, prefixPrice.CurrentPrice);

            Assert.AreEqual("372", prefixPrice.PrefixList [0]);
        }

        [Test]
        public void testDeserializeListResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "voice_countries.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<VoiceCountryResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual(3, output.Countries.Count);
            Assert.AreEqual("AC", output.Countries [0].IsoCountry);
            Assert.AreEqual("Ascension", output.Countries [0].Country);
            Assert.IsNull(output.Countries [0].PriceUnit);
        }
    }
}