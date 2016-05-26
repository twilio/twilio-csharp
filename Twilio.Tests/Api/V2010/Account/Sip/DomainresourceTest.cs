using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;

namespace Twilio.Tests.Api.V2010.Account.Sip {

    [TestFixture]
    public class DomainTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = DomainResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"domains\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"\",\"date_created\": \"Fri, 06 Sep 2013 18:48:50 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 18:48:50 -0000\",\"domain_name\": \"dunder-mifflin-scranton.api.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\"}")));
            
            var task = DomainResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"domains\": [],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\"}")));
            
            var task = DomainResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json");
            request.AddPostParam("DomainName", Serialize("domainName"));
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = DomainResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "domainName").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"IP_ACL\",\"date_created\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"domain_name\": \"dunder-mifflin-scranton.sip.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}")));
            
            var task = DomainResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "domainName").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = DomainResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"IP_ACL\",\"date_created\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"domain_name\": \"dunder-mifflin-scranton.sip.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}")));
            
            var task = DomainResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = DomainResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"IP_ACL\",\"date_created\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"domain_name\": \"dunder-mifflin-scranton.sip.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}")));
            
            var task = DomainResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = DomainResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
            
            var task = DomainResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    }
}