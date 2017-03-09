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
    public class ConferenceTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ConferenceResource.Fetch("CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"date_created\": \"Fri, 18 Feb 2011 19:26:50 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 19:27:33 +0000\",\"friendly_name\": \"AHH YEAH\",\"sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"region\": \"us1\",\"status\": \"completed\",\"subresource_uris\": {\"participants\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ConferenceResource.Fetch("CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ConferenceResource.Read(client: twilioRestClient);
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
                                         "{\"conferences\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"date_created\": \"Mon, 22 Aug 2011 20:58:45 +0000\",\"date_updated\": \"Mon, 22 Aug 2011 20:58:46 +0000\",\"friendly_name\": null,\"region\": \"us1\",\"sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"in-progress\",\"subresource_uris\": {\"participants\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences.json?PageSize=1&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences.json?PageSize=1\"}"
                                     ));

            var response = ConferenceResource.Read(client: twilioRestClient);
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
                                         "{\"conferences\": [],\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences.json?PageSize=1&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences.json?PageSize=1\"}"
                                     ));

            var response = ConferenceResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ConferenceResource.Update("CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestUpdateEndConferenceResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"date_created\": \"Mon, 22 Aug 2011 20:58:45 +0000\",\"date_updated\": \"Mon, 22 Aug 2011 20:58:46 +0000\",\"friendly_name\": null,\"region\": \"us1\",\"sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"completed\",\"subresource_uris\": {\"participants\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ConferenceResource.Update("CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}