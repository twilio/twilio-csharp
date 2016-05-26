using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Notifications.V1.Service;

namespace Twilio.Tests.Notifications.V1.Service {

    [TestFixture]
    public class BindingTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.NOTIFICATIONS,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings/BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = BindingResource.Fetch("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"sid\": \"BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2016-03-24T23:24:45Z\",\"date_updated\": \"2016-03-24T23:24:45Z\",\"notification_protocol_version\": \"3\",\"endpoint\": \"abcd\",\"identity\": \"jing\",\"binding_type\": \"apn\",\"address\": \"1234\",\"tags\": [],\"url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings/BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}")));
            
            var task = BindingResource.Fetch("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.NOTIFICATIONS,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings/BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = BindingResource.Delete("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.NoContent,
                                             "null")));
            
            var task = BindingResource.Delete("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
                        Request request = new Request(System.Net.Http.HttpMethod.Post,
                                                      Domains.NOTIFICATIONS,
                                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings");
                        request.AddPostParam("Endpoint", Serialize("endpoint"));
            request.AddPostParam("Identity", Serialize("identity"));
            request.AddPostParam("BindingType", Serialize(BindingResource.BindingType.APN));
            request.AddPostParam("Address", Serialize("address"));
                        
                        twilioRestClient.Request(request)
                                        .Returns(System.Threading.Tasks.Task.FromResult(
                                            new Response(System.Net.HttpStatusCode.InternalServerError,
                                                         "null")));
            
            try {
                var task = BindingResource.Create("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "endpoint", "identity", BindingResource.BindingType.APN, "address").ExecuteAsync(twilioRestClient);
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
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.Created,
                                             "{\"sid\": \"BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2016-03-24T23:24:45Z\",\"date_updated\": \"2016-03-24T23:24:45Z\",\"notification_protocol_version\": \"3\",\"endpoint\": \"abcd\",\"identity\": \"jing\",\"binding_type\": \"apn\",\"address\": \"1234\",\"tags\": [],\"url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings/BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}")));
            
            var task = BindingResource.Create("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "endpoint", "identity", BindingResource.BindingType.APN, "address").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.NOTIFICATIONS,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = BindingResource.Read("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"meta\": {\"page\": 0,\"page_size\": 1,\"first_page_url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings?PageSize=1&Page=0\",\"previous_page_url\": null,\"url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings?PageSize=1&Page=0\",\"next_page_url\": null,\"key\": \"bindings\"},\"bindings\": [{\"sid\": \"BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2016-03-24T23:24:45Z\",\"date_updated\": \"2016-03-24T23:24:45Z\",\"notification_protocol_version\": \"3\",\"endpoint\": \"abcd\",\"identity\": \"jing\",\"binding_type\": \"apn\",\"address\": \"1234\",\"tags\": [],\"url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings/BSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}")));
            
            var task = BindingResource.Read("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"meta\": {\"page\": 0,\"page_size\": 1,\"first_page_url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings?PageSize=1&Page=0\",\"previous_page_url\": null,\"url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings?PageSize=1&Page=0\",\"next_page_url\": \"https://notifications.stage.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings?PageSize=1&Page=1&PageToken=PABSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"key\": \"bindings\"},\"bindings\": []}")));
            
            var task = BindingResource.Read("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    }
}