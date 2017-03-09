using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Recording.AddOnResult;

namespace Twilio.Tests.Rest.Api.V2010.Account.Recording.AddOnResult 
{

    [TestFixture]
    public class PayloadTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads/XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                PayloadResource.Fetch("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"sid\": \"XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"reference_sid\": \"REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"add_on_sid\": \"XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"add_on_configuration_sid\": \"XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"add_on_result_sid\": \"XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"content_type\": \"application/json\",\"date_created\": \"Wed, 01 Sep 2010 15:15:41 +0000\",\"date_updated\": \"Wed, 01 Sep 2010 15:15:41 +0000\",\"subresource_uris\": {\"data\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads/XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Data.json\"}}"
                                     ));

            var response = PayloadResource.Fetch("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                PayloadResource.Read("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"payloads\": [{\"sid\": \"XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"reference_sid\": \"REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"add_on_sid\": \"XBaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"add_on_configuration_sid\": \"XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"add_on_result_sid\": \"XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"content_type\": \"application/json\",\"date_created\": \"Wed, 01 Sep 2010 15:15:41 +0000\",\"date_updated\": \"Wed, 01 Sep 2010 15:15:41 +0000\",\"subresource_uris\": {\"data\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads/XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Data.json\"}}],\"start\": 0,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads.json?PageSize=50&Page=0\"}"
                                     ));

            var response = PayloadResource.Read("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"payloads\": [],\"start\": 0,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads.json?PageSize=50&Page=0\"}"
                                     ));

            var response = PayloadResource.Read("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AddOnResults/XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Payloads/XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                PayloadResource.Delete("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = PayloadResource.Delete("REaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "XHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}