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

namespace Twilio.Tests.Rest.Taskrouter.V1.Workspace 
{

    [TestFixture]
    public class TaskQueueTest : TwilioTest 
    {
        [SetUp]
        public void SetUp()
        {
        }
    
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.GET,
                                      Domains.TASKROUTER,
                                      "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                TaskQueueResource.Fetcher("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assignment_activity_name\": \"817ca1c5-3a05-11e5-9292-98e0d9a1eb73\",\"assignment_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-08-03T17:31:41Z\",\"date_updated\": \"2015-08-03T17:31:41Z\",\"friendly_name\": \"81f96435-3a05-11e5-9f81-98e0d9a1eb73\",\"max_reserved_workers\": 1,\"links\": {\"assignment_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"reservation_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"reservation_activity_name\": \"80fa2beb-3a05-11e5-8fc8-98e0d9a1eb73\",\"reservation_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"target_workers\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = TaskQueueResource.Fetcher("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.TASKROUTER,
                                      "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                TaskQueueResource.Updater("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestUpdateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assignment_activity_name\": \"817ca1c5-3a05-11e5-9292-98e0d9a1eb73\",\"assignment_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-08-03T17:31:41Z\",\"date_updated\": \"2015-08-03T17:31:41Z\",\"friendly_name\": \"81f96435-3a05-11e5-9f81-98e0d9a1eb73\",\"max_reserved_workers\": 1,\"links\": {\"assignment_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"reservation_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"reservation_activity_name\": \"80fa2beb-3a05-11e5-8fc8-98e0d9a1eb73\",\"reservation_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"target_workers\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = TaskQueueResource.Updater("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.GET,
                                      Domains.TASKROUTER,
                                      "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                TaskQueueResource.Reader("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues?PageSize=50&Page=0\",\"key\": \"task_queues\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues?PageSize=50&Page=0\"},\"task_queues\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assignment_activity_name\": \"817ca1c5-3a05-11e5-9292-98e0d9a1eb73\",\"assignment_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-08-03T17:31:41Z\",\"date_updated\": \"2015-08-03T17:31:41Z\",\"friendly_name\": \"81f96435-3a05-11e5-9f81-98e0d9a1eb73\",\"max_reserved_workers\": 1,\"links\": {\"assignment_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"reservation_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"reservation_activity_name\": \"80fa2beb-3a05-11e5-8fc8-98e0d9a1eb73\",\"reservation_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"target_workers\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}"));
            
            var response = TaskQueueResource.Reader("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues?PageSize=50&Page=0\",\"key\": \"task_queues\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues?PageSize=50&Page=0\"},\"task_queues\": []}"));
            
            var response = TaskQueueResource.Reader("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.TASKROUTER,
                                      "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues");
            request.AddPostParam("FriendlyName", Serialize("friendlyName"));
            request.AddPostParam("ReservationActivitySid", Serialize("WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            request.AddPostParam("AssignmentActivitySid", Serialize("WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                TaskQueueResource.Creator("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"assignment_activity_name\": \"817ca1c5-3a05-11e5-9292-98e0d9a1eb73\",\"assignment_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-08-03T17:31:41Z\",\"date_updated\": \"2015-08-03T17:31:41Z\",\"friendly_name\": \"81f96435-3a05-11e5-9f81-98e0d9a1eb73\",\"max_reserved_workers\": 1,\"links\": {\"assignment_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"reservation_activity\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"reservation_activity_name\": \"80fa2beb-3a05-11e5-8fc8-98e0d9a1eb73\",\"reservation_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"target_workers\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = TaskQueueResource.Creator("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.DELETE,
                                      Domains.TASKROUTER,
                                      "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/TaskQueues/WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                TaskQueueResource.Deleter("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.NoContent,
                                                  "null"));
            
            TaskQueueResource.Deleter("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WQaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
        }
    }
}