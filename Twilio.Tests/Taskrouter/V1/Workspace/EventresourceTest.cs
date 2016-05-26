using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Tests.Taskrouter.V1.Workspace {

    [TestFixture]
    public class EventTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = EventResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                        return false;
                    }
            
                    return true;
                });
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"workspace\",\"actor_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"description\": \"Worker JustinWorker updated to Idle Activity\",\"event_data\": {\"worker_activity_name\": \"Offline\",\"worker_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_attributes\": \"{}\",\"worker_name\": \"JustinWorker\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_time_in_previous_activity\": \"26\",\"workspace_name\": \"WorkspaceName\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"event_date\": \"2015-02-07T00:32:41Z\",\"event_type\": \"worker.activity\",\"resource_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"worker\",\"resource_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"twilio\",\"source_ip_address\": \"1.2.3.4\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}")));
            
            var task = EventResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TASKROUTER,
                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = EventResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                        return false;
                    }
            
                    return true;
                });
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"events\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"workspace\",\"actor_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"description\": \"Worker JustinWorker updated to Idle Activity\",\"event_data\": {\"worker_activity_name\": \"Offline\",\"worker_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_attributes\": \"{}\",\"worker_name\": \"JustinWorker\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_time_in_previous_activity\": \"26\",\"workspace_name\": \"WorkspaceName\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"event_date\": \"2015-02-07T00:32:41Z\",\"event_type\": \"worker.activity\",\"resource_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"worker\",\"resource_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"twilio\",\"source_ip_address\": \"1.2.3.4\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\"}}")));
            
            var task = EventResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"events\": [],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\"}}")));
            
            var task = EventResource.Read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    }
}