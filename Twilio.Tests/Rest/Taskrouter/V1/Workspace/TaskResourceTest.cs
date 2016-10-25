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
using Twilio.Rest.Taskrouter.V1.Workspace;

namespace Twilio.Tests.Rest.Taskrouter.V1.Workspace {

    [TestFixture]
    public class TaskTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TaskResource.Fetcher("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"age\": 25200,\"assignment_status\": \"pending\",\"attributes\": \"{\\\"body\\\": \\\"hello\\\"}\",\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"priority\": 0,\"reason\": \"Test Reason\",\"sid\": \"WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_queue_sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"task-channel\",\"timeout\": 60,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workflow_sid\": \"WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = TaskResource.Fetcher("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TaskResource.Updater("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"age\": 25200,\"assignment_status\": \"pending\",\"attributes\": \"{\\\"body\\\": \\\"hello\\\"}\",\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"priority\": 0,\"reason\": \"Test Reason\",\"sid\": \"WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_queue_sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"task-channel\",\"timeout\": 60,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workflow_sid\": \"WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = TaskResource.Updater("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.DELETE,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TaskResource.Deleter("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
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
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.NoContent,
                                                  "null"));
            
            TaskResource.Deleter("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TaskResource.Reader("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
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
                                                  "{\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks?PageSize=50&Page=0\",\"key\": \"tasks\",\"last_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks?PageSize=50&Page=0\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks?PageSize=50&Page=0\"},\"tasks\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"age\": 25200,\"assignment_status\": \"pending\",\"attributes\": \"{\\\"body\\\": \\\"hello\\\"}\",\"date_created\": \"2014-05-14T14:26:54Z\",\"date_updated\": \"2014-05-15T16:03:42Z\",\"priority\": 0,\"reason\": \"Test Reason\",\"sid\": \"WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_queue_sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"task-channel\",\"timeout\": 60,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workflow_sid\": \"WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}"));
            
            var response = TaskResource.Reader("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks?PageSize=50&Page=0\",\"key\": \"tasks\",\"last_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks?PageSize=50&Page=0\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks?PageSize=50&Page=0\"},\"tasks\": []}"));
            
            var response = TaskResource.Reader("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks");
            request.AddPostParam("Attributes", Serialize("attributes"));
            request.AddPostParam("WorkflowSid", Serialize("WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TaskResource.Creator("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "attributes", "WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
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
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"age\": 25200,\"assignment_status\": \"pending\",\"attributes\": \"{\\\"body\\\": \\\"hello\\\"}\",\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"priority\": 0,\"reason\": \"Test Reason\",\"sid\": \"WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_queue_sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_sid\": \"TCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"task_channel_unique_name\": \"task-channel\",\"timeout\": 60,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tasks/WTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workflow_sid\": \"WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = TaskResource.Creator("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "attributes", "WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}