using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.Pricing;

namespace Twilio.Api.Tests.Integration.Model
{
    [TestFixture]
    public class PhoneNumberCountryTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources/Pricing", "phone_number_country.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<PhoneNumberCountry>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }

        [Test]
        public void testDeserializeListResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources/Pricing", "phone_number_countries.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<PhoneNumberCountryResult>(new RestResponse { Content = doc });

            Assert.NotNull(output);
        }
    }
}