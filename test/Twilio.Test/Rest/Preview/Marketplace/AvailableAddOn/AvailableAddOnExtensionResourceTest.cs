using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Preview.Marketplace.AvailableAddOn;

namespace Twilio.Tests.Rest.Preview.Marketplace.AvailableAddOn 
{

    [TestFixture]
    public class AvailableAddOnExtensionTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));
            
            try
            {
                AvailableAddOnExtensionResource.Fetch("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"sid\": \"XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available_add_on_sid\": \"XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"Incoming Voice Call\",\"product_name\": \"Programmable Voice\",\"unique_name\": \"voice-incoming\",\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));
            
            var response = AvailableAddOnExtensionResource.Fetch("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));
            
            try
            {
                AvailableAddOnExtensionResource.Read("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"extensions\": [{\"sid\": \"XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available_add_on_sid\": \"XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"Incoming Voice Call\",\"product_name\": \"Programmable Voice\",\"unique_name\": \"voice-incoming\",\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"extensions\"}}"
                                     ));
            
            var response = AvailableAddOnExtensionResource.Read("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"extensions\": [],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/marketplace/AvailableAddOns/XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"extensions\"}}"
                                     ));
            
            var response = AvailableAddOnExtensionResource.Read("XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}