using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Message;

namespace Twilio.Tests.Api.V2010.Account.Message {

    [TestFixture]
    public class MediaTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media/MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MediaResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
            
            var task = MediaResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media/MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MediaResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"content_type\": \"image/jpeg\",\"date_created\": \"Sun, 16 Aug 2015 15:53:54 +0000\",\"date_updated\": \"Sun, 16 Aug 2015 15:53:55 +0000\",\"parent_sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media/MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}")));
            
            var task = MediaResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MediaResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json?PageSize=50&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json?PageSize=50&Page=0\",\"media_list\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"content_type\": \"image/jpeg\",\"date_created\": \"Sun, 16 Aug 2015 15:53:54 +0000\",\"date_updated\": \"Sun, 16 Aug 2015 15:53:55 +0000\",\"parent_sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media/MEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json?PageSize=50&Page=0\"}")));
            
            var task = MediaResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json?PageSize=50&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json?PageSize=50&Page=0\",\"media_list\": [],\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json?PageSize=50&Page=0\"}")));
            
            var task = MediaResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    }
}