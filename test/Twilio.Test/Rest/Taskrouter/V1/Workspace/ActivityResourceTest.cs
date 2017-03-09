using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Taskrouter.V1.Workspace;

namespace Twilio.Tests.Rest.Taskrouter.V1.Workspace 
{

    [TestFixture]
    public class ActivityTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ActivityResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = ActivityResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ActivityResource.Update("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = ActivityResource.Update("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ActivityResource.Delete("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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

            var response = ActivityResource.Delete("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ActivityResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"activities\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"key\": \"activities\",\"last_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\"}}"
                                     ));

            var response = ActivityResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"activities\": [],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"key\": \"activities\",\"last_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\"}}"
                                     ));

            var response = ActivityResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities",
                ""
            );
            request.AddPostParam("FriendlyName", Serialize("FriendlyName"));
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ActivityResource.Create("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FriendlyName", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = ActivityResource.Create("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FriendlyName", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}