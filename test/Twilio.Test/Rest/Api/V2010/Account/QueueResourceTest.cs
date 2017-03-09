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
    public class QueueTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                QueueResource.Fetch("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"average_wait_time\": 0,\"current_size\": 0,\"date_created\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"date_updated\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"friendly_name\": \"0.361280134646222\",\"max_size\": 100,\"sid\": \"QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = QueueResource.Fetch("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                QueueResource.Update("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"average_wait_time\": 0,\"current_size\": 0,\"date_created\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"date_updated\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"friendly_name\": \"0.361280134646222\",\"max_size\": 100,\"sid\": \"QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = QueueResource.Update("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                QueueResource.Delete("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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

            var response = QueueResource.Delete("QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                QueueResource.Read(client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json?PageSize=1&Page=12857\",\"next_page_uri\": null,\"num_pages\": 12858,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"queues\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"average_wait_time\": 0,\"current_size\": 0,\"date_created\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"date_updated\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"friendly_name\": \"0.361280134646222\",\"max_size\": 100,\"sid\": \"QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"start\": 0,\"total\": 12858,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json?PageSize=1&Page=0\"}"
                                     ));

            var response = QueueResource.Read(client: twilioRestClient);
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
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json?PageSize=1&Page=12857\",\"next_page_uri\": null,\"num_pages\": 12858,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"queues\": [],\"start\": 0,\"total\": 12858,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json?PageSize=1&Page=0\"}"
                                     ));

            var response = QueueResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues.json",
                ""
            );
            request.AddPostParam("FriendlyName", Serialize("FriendlyName"));
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                QueueResource.Create("FriendlyName", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"average_wait_time\": 0,\"current_size\": 0,\"date_created\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"date_updated\": \"Tue, 04 Aug 2015 18:39:09 +0000\",\"friendly_name\": \"0.361280134646222\",\"max_size\": 100,\"sid\": \"QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Queues/QUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = QueueResource.Create("FriendlyName", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}