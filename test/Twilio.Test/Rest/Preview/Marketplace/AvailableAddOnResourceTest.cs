using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Preview.Marketplace;

namespace Twilio.Tests.Rest.Preview.Marketplace 
{

    [TestFixture]
    public class AvailableAddOnTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));
            
            try
            {
                AvailableAddOnResource.Fetch("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"sid\": \"XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"VoiceBase High Accuracy Transcription\",\"description\": \"Automatic Transcription and Keyword Extract...\",\"pricing_type\": \"per minute\",\"configuration_schema\": {\"type\": \"object\",\"properties\": {\"bad_words\": {\"type\": \"boolean\"}},\"required\": [\"bad_words\"]},\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"extensions\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions\"}}"
                                     ));
            
            var response = AvailableAddOnResource.Fetch("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/marketplace/AvailableAddOns",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));
            
            try
            {
                AvailableAddOnResource.Read(client: twilioRestClient);
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
                                         "{\"available_add_ons\": [{\"sid\": \"XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"VoiceBase High Accuracy Transcription\",\"description\": \"Automatic Transcription and Keyword Extract...\",\"pricing_type\": \"per minute\",\"configuration_schema\": {\"type\": \"object\",\"properties\": {\"bad_words\": {\"type\": \"boolean\"}},\"required\": [\"bad_words\"]},\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"extensions\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions\"}}],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://preview.twilio.com/marketplace/AvailableAddOns?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"available_add_ons\"}}"
                                     ));
            
            var response = AvailableAddOnResource.Read(client: twilioRestClient);
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
                                         "{\"available_add_ons\": [],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://preview.twilio.com/marketplace/AvailableAddOns?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"available_add_ons\"}}"
                                     ));
            
            var response = AvailableAddOnResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}