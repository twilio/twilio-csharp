using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Tests.Api.V2010.Account {

    [TestFixture]
    public class MessageTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
                        Request request = new Request(System.Net.Http.HttpMethod.Post,
                                                      Domains.API,
                                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json");
                        request.AddPostParam("To", Serialize(new Twilio.Types.PhoneNumber("+123456789")));
            request.AddPostParam("From", Serialize(new Twilio.Types.PhoneNumber("+987654321")));
            request.AddPostParam("Body", Serialize("body"));
                        
                        twilioRestClient.Request(request)
                                        .Returns(System.Threading.Tasks.Task.FromResult(
                                            new Response(System.Net.HttpStatusCode.InternalServerError,
                                                         "null")));
            
            try {
                var task = MessageResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Twilio.Types.PhoneNumber("+123456789"), new Twilio.Types.PhoneNumber("+987654321"), "body").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}")));
            
            var task = MessageResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Twilio.Types.PhoneNumber("+123456789"), new Twilio.Types.PhoneNumber("+987654321"), "body").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MessageResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
            
            var task = MessageResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MessageResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}")));
            
            var task = MessageResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MessageResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=119771\",\"messages\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Fri, 04 Sep 2015 22:54:39 +0000\",\"date_sent\": \"Fri, 04 Sep 2015 22:54:41 +0000\",\"date_updated\": \"Fri, 04 Sep 2015 22:54:41 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"next_page_uri\": null,\"num_pages\": 119772,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 119772,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\"}")));
            
            var task = MessageResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=119771\",\"messages\": [],\"next_page_uri\": null,\"num_pages\": 119772,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 119772,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\"}")));
            
            var task = MessageResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = MessageResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
        public void TestUpdateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}")));
            
            var task = MessageResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    }
}