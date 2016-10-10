using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest;
using Twilio.Rest.Pricing.V1.PhoneNumber;

namespace Twilio.Tests.Rest.Pricing.V1.PhoneNumber {

    [TestFixture]
    public class CountryTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.PRICING,
                                          "/v1/PhoneNumbers/Countries");
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                CountryResource.Reader().Read(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"countries\": [{\"country\": \"Austria\",\"iso_country\": \"AT\",\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries/AT\"}],\"meta\": {\"first_page_url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\",\"key\": \"countries\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\"}}"));
            
            var response = CountryResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"countries\": [],\"meta\": {\"first_page_url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\",\"key\": \"countries\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries?PageSize=1&Page=0\"}}"));
            
            var response = CountryResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.PRICING,
                                          "/v1/PhoneNumbers/Countries/US");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                CountryResource.Fetcher("US").Fetch(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"country\": \"Estonia\",\"iso_country\": \"EE\",\"phone_number_prices\": [{\"base_price\": 3.0,\"current_price\": 3.0,\"type\": \"mobile\"},{\"base_price\": 1.0,\"current_price\": 1.0,\"type\": \"national\"}],\"price_unit\": \"usd\",\"url\": \"https://pricing.twilio.com/v1/PhoneNumbers/Countries/US\"}"));
            
            var response = CountryResource.Fetcher("US").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}