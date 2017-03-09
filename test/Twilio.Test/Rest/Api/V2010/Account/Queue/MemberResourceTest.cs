using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Queue;

namespace Twilio.Tests.Rest.Api.V2010.Account.Queue 
{

    [TestFixture]
    public class MemberTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                MemberResource.Fetch("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_enqueued\": \"Tue, 07 Aug 2012 22:57:41 +0000\",\"position\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"wait_time\": 143}"
                                     ));

            var response = MemberResource.Fetch("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            request.AddPostParam("Url", Serialize(new Uri("https://example.com")));
            request.AddPostParam("Method", Serialize(Twilio.Http.HttpMethod.Get));
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                MemberResource.Update("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Uri("https://example.com"), Twilio.Http.HttpMethod.Get, client: twilioRestClient);
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
                                         "{\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_enqueued\": \"Tue, 07 Aug 2012 22:57:41 +0000\",\"position\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"wait_time\": 143}"
                                     ));

            var response = MemberResource.Update("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Uri("https://example.com"), Twilio.Http.HttpMethod.Get, client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                MemberResource.Read("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"queue_members\": [{\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_enqueued\": \"Tue, 07 Aug 2012 22:57:41 +0000\",\"position\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"wait_time\": 124}],\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json\"}"
                                     ));

            var response = MemberResource.Read("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"queue_members\": [],\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members.json\"}"
                                     ));

            var response = MemberResource.Read("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}