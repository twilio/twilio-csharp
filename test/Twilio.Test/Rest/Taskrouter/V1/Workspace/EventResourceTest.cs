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
    public class EventTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                EventResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"workspace\",\"actor_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"description\": \"Worker JustinWorker updated to Idle Activity\",\"event_data\": {\"worker_activity_name\": \"Offline\",\"worker_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_attributes\": \"{}\",\"worker_name\": \"JustinWorker\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_time_in_previous_activity\": \"26\",\"workspace_name\": \"WorkspaceName\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"event_date\": \"2015-02-07T00:32:41Z\",\"event_type\": \"worker.activity\",\"resource_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"worker\",\"resource_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"twilio\",\"source_ip_address\": \"1.2.3.4\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = EventResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                EventResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"events\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"workspace\",\"actor_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"description\": \"Worker JustinWorker updated to Idle Activity\",\"event_data\": {\"worker_activity_name\": \"Offline\",\"worker_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_attributes\": \"{}\",\"worker_name\": \"JustinWorker\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_time_in_previous_activity\": \"26\",\"workspace_name\": \"WorkspaceName\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"event_date\": \"2015-02-07T00:32:41Z\",\"event_type\": \"worker.activity\",\"resource_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"worker\",\"resource_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"twilio\",\"source_ip_address\": \"1.2.3.4\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\"}}"
                                     ));

            var response = EventResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"events\": [],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\"}}"
                                     ));

            var response = EventResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}