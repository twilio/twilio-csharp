using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Pricing;

namespace Twilio.Pricing.Tests.Model
{
    [TestFixture]
    public class MessagingCountryTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "messaging_country.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<MessagingCountry>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("US", output.IsoCountry);
            Assert.AreEqual("United States", output.Country);
            Assert.AreEqual("USD", output.PriceUnit);

            var outboundSmsPrices = output.OutboundSmsPrices;
            Assert.NotNull(outboundSmsPrices);
            Assert.AreEqual(1, outboundSmsPrices.Count);
            Assert.AreEqual("311", outboundSmsPrices[0].Mcc);
            Assert.AreEqual("484", outboundSmsPrices[0].Mnc);
            Assert.AreEqual("Verizon", outboundSmsPrices[0].Carrier);

            var prices = outboundSmsPrices[0].Prices;
            Assert.NotNull(prices);
            Assert.AreEqual(2, prices.Count);

            Assert.AreEqual("mobile", prices[0].NumberType);
            Assert.AreEqual("0.0075", prices[0].BasePrice);
            Assert.AreEqual("0.0070", prices[0].CurrentPrice);

            Assert.AreEqual("shortcode", prices[0].NumberType);
            Assert.AreEqual("0.01", prices[0].BasePrice);
            Assert.AreEqual("0.01", prices[0].CurrentPrice);

            var inboundSmsPrices = output.InboundSmsPrices;
            Assert.NotNull(inboundSmsPrices);
            Assert.AreEqual(2, inboundSmsPrices.Count);

            Assert.AreEqual("mobile", inboundSmsPrices[0].NumberType);
            Assert.AreEqual("0.0075", inboundSmsPrices[0].BasePrice);
            Assert.AreEqual("0.0070", inboundSmsPrices[0].CurrentPrice);

            Assert.AreEqual("shortcode", inboundSmsPrices[1].NumberType);
            Assert.AreEqual("0.01", inboundSmsPrices[1].BasePrice);
            Assert.AreEqual("0.01", inboundSmsPrices[1].CurrentPrice);
        }

        [Test]
        public void testDeserializeListResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "messaging_countries.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<MessagingCountryResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual(2, output.Countries.Count);

            Assert.AreEqual("US", output.Countries[0].IsoCountry);
            Assert.AreEqual("United States", output.Countries[0].Country);

            Assert.AreEqual("DE", output.Countries[1].IsoCountry);
            Assert.AreEqual("Germany", output.Countries[1].Country);
        }
    }
}
