using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Pricing;

namespace Twilio.Pricing.Tests.Model
{
    [TestFixture]
    public class PhoneNumberCountryTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "phone_number_country.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<PhoneNumberCountry>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("EE", output.IsoCountry);
            Assert.AreEqual("Estonia", output.Country);
            Assert.AreEqual("USD", output.PriceUnit);

            var prices = output.PhoneNumberPrices;
            Assert.AreEqual(2, prices.Count);

            var price = prices [0];
            Assert.NotNull(price);
            Assert.AreEqual("mobile", price.NumberType);
            Assert.AreEqual(3.00m, price.BasePrice);
            Assert.AreEqual(3.00m, price.CurrentPrice);
        }

        [Test]
        public void testDeserializeListResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "phone_number_countries.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<PhoneNumberCountryResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual(3, output.Countries.Count);
            Assert.AreEqual("AC", output.Countries [0].IsoCountry);
            Assert.AreEqual("Ascension", output.Countries [0].Country);
        }
    }
}