using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Pricing.V1.PhoneNumber;

namespace Twilio.Tests.Rest.Pricing.V1.PhoneNumber 
{

    [TestFixture]
    public class CountryTest : TwilioTest 
    {
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Pricing,
                "/v1/PhoneNumbers/Countries",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                CountryResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"countries\": [{\"country\": \"Austria\",\"iso_country\": \"AT\",\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries/AT\"}],\"meta\": {\"first_page_url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\",\"key\": \"countries\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\"}}"
                                     ));

            var response = CountryResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"countries\": [],\"meta\": {\"first_page_url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\",\"key\": \"countries\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\"}}"
                                     ));

            var response = CountryResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Pricing,
                "/v1/PhoneNumbers/Countries/US",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                CountryResource.Fetch("US", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"country\": \"Estonia\",\"iso_country\": \"EE\",\"phone_number_prices\": [{\"base_price\": 3.0,\"current_price\": 3.0,\"type\": \"mobile\"},{\"base_price\": 1.0,\"current_price\": 1.0,\"type\": \"national\"}],\"price_unit\": \"usd\",\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries/US\"}"
                                     ));

            var response = CountryResource.Fetch("US", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}