using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Pricing.V1.Messaging;

namespace Twilio.Tests.Rest.Pricing.V1.Messaging 
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
                "/v1/Messaging/Countries",
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
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"countries\": [],\"meta\": {\"first_page_url\": \"https://pricing.twilio.com/v1/Messaging/Countries?Page=0&PageSize=50\",\"key\": \"countries\",\"next_page_url\": null,\"page\": 0,\"page_size\": 0,\"previous_page_url\": null,\"url\": \"https://pricing.twilio.com/v1/Messaging/Countries\"}}"
                                     ));

            var response = CountryResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"countries\": [{\"country\": \"country\",\"iso_country\": \"US\",\"url\": \"http://www.example.com\"}],\"meta\": {\"first_page_url\": \"https://pricing.twilio.com/v1/Messaging/Countries?Page=0&PageSize=50\",\"key\": \"countries\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://pricing.twilio.com/v1/Messaging/Countries\"}}"
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
                "/v1/Messaging/Countries/US",
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
                                         "{\"country\": \"country\",\"inbound_sms_prices\": [{\"base_price\": 0.05,\"current_price\": 0.05,\"number_type\": \"mobile\"}],\"iso_country\": \"US\",\"outbound_sms_prices\": [{\"carrier\": \"att\",\"mcc\": \"foo\",\"mnc\": \"bar\",\"prices\": [{\"base_price\": 0.05,\"current_price\": 0.05,\"number_type\": \"mobile\"}]}],\"price_unit\": \"USD\",\"url\": \"http://www.example.com\"}"
                                     ));

            var response = CountryResource.Fetch("US", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}