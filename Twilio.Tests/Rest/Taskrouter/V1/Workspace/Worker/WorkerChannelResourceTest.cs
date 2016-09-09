using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest;
using Twilio.Rest.Taskrouter.V1.Workspace.Worker;

namespace Twilio.Tests.Rest.Taskrouter.V1.Workspace.Worker {

    [TestFixture]
    public class WorkerChannelTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels");
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                WorkerChannelResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels?PageSize=50&Page=0\",\"key\": \"channels\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\"},\"channels\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assigned_tasks\": 0,\"available\": true,\"available_capacity_percentage\": 100,\"configured_capacity\": 1,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-15T16:03:42Z\",\"links\": {\"taskchannel\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskChannels/TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"sid\": \"WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"default\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/WRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}"));
            
            var response = WorkerChannelResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels?PageSize=50&Page=0\",\"key\": \"channels\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\"},\"channels\": []}"));
            
            var response = WorkerChannelResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                WorkerChannelResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assigned_tasks\": 0,\"available\": true,\"available_capacity_percentage\": 100,\"configured_capacity\": 1,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-15T16:03:42Z\",\"links\": {\"taskchannel\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskChannels/TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"sid\": \"WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"default\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/WRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = WorkerChannelResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                WorkerChannelResource.Update("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestUpdateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assigned_tasks\": 0,\"available\": true,\"available_capacity_percentage\": 100,\"configured_capacity\": 3,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-15T16:03:42Z\",\"links\": {\"taskchannel\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskChannels/TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"sid\": \"WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"default\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/WRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = WorkerChannelResource.Update("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}