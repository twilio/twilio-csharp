using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Preview.Marketplace.InstalledAddOn;

namespace Twilio.Tests.Rest.Preview.Marketplace.InstalledAddOn 
{

    [TestFixture]
    public class InstalledAddOnExtensionTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                InstalledAddOnExtensionResource.Fetch("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"sid\": \"XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"installed_add_on_sid\": \"XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"Incoming Voice Call\",\"product_name\": \"Programmable Voice\",\"unique_name\": \"voice-incoming\",\"enabled\": true,\"url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = InstalledAddOnExtensionResource.Fetch("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Preview,
                "/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            request.AddPostParam("Enabled", Serialize(true));
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                InstalledAddOnExtensionResource.Update("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true, client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestUpdateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"sid\": \"XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"installed_add_on_sid\": \"XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"Incoming Voice Call\",\"product_name\": \"Programmable Voice\",\"unique_name\": \"voice-incoming\",\"enabled\": false,\"url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = InstalledAddOnExtensionResource.Update("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true, client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                InstalledAddOnExtensionResource.Read("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"extensions\": [{\"sid\": \"XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"installed_add_on_sid\": \"XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"Incoming Voice Call\",\"product_name\": \"Programmable Voice\",\"unique_name\": \"voice-incoming\",\"enabled\": true,\"url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions/XFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"extensions\"}}"
                                     ));

            var response = InstalledAddOnExtensionResource.Read("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"extensions\": [],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/marketplace/InstalledAddOns/XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Extensions?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"extensions\"}}"
                                     ));

            var response = InstalledAddOnExtensionResource.Read("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}