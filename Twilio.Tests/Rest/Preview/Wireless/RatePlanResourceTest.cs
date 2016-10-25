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
using Twilio.Rest.Preview.Wireless;

namespace Twilio.Tests.Rest.Preview.Wireless {

    [TestFixture]
    public class RatePlanTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.PREVIEW,
                                          "/wireless/RatePlans");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                RatePlanResource.Reader().Read(twilioRestClient);
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
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://preview.twilio.com/wireless/RatePlans?Page=0&PageSize=50\",\"key\": \"rate_plans\",\"next_page_url\": null,\"page\": 0,\"page_size\": 0,\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/wireless/RatePlans\"},\"rate_plans\": []}"));
            
            var response = RatePlanResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://preview.twilio.com/wireless/RatePlans?Page=0&PageSize=50\",\"key\": \"rate_plans\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/wireless/RatePlans\"},\"rate_plans\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"alias\": \"alias\",\"cap_period\": 100,\"cap_unit\": \"cap_unit\",\"capabilities\": {},\"commands_cap\": 100,\"data_cap\": 100,\"data_metering\": \"data_metering\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"friendly_name\": \"friendly_name\",\"messaging_cap\": 100,\"sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"http://www.example.com\",\"voice_cap\": 100}]}"));
            
            var response = RatePlanResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.PREVIEW,
                                          "/wireless/RatePlans/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                RatePlanResource.Fetcher("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"alias\": \"alias\",\"cap_period\": 100,\"cap_unit\": \"cap_unit\",\"capabilities\": {},\"commands_cap\": 100,\"data_cap\": 100,\"data_metering\": \"data_metering\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"friendly_name\": \"friendly_name\",\"messaging_cap\": 100,\"sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"http://www.example.com\",\"voice_cap\": 100}"));
            
            var response = RatePlanResource.Fetcher("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}