using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;

namespace Twilio.Tests.Rest.Api.V2010.Account 
{

    [TestFixture]
    public class ShortCodeTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes/SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ShortCodeResource.Fetch("SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"date_created\": null,\"date_updated\": null,\"friendly_name\": \"API_CLUSTER_TEST_SHORT_CODE\",\"short_code\": \"99990\",\"sid\": \"SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": null,\"sms_method\": \"POST\",\"sms_url\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes/SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ShortCodeResource.Fetch("SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes/SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ShortCodeResource.Update("SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"date_created\": null,\"date_updated\": null,\"friendly_name\": \"API_CLUSTER_TEST_SHORT_CODE\",\"short_code\": \"99990\",\"sid\": \"SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": null,\"sms_method\": \"POST\",\"sms_url\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes/SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ShortCodeResource.Update("SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ShortCodeResource.Read(client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"short_codes\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"date_created\": null,\"date_updated\": null,\"friendly_name\": \"API_CLUSTER_TEST_SHORT_CODE\",\"short_code\": \"99990\",\"sid\": \"SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": null,\"sms_method\": \"POST\",\"sms_url\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes/SCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json\"}"
                                     ));

            var response = ShortCodeResource.Read(client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"short_codes\": [],\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/ShortCodes.json\"}"
                                     ));

            var response = ShortCodeResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}