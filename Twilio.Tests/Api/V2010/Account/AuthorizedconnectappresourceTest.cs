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
    public class AuthorizedConnectAppTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = AuthorizedConnectAppResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"connect_app_company_name\": \"aaa\",\"connect_app_description\": \"alksjdfl;ajseifj;alsijfl;ajself;jasjfjas;lejflj\",\"connect_app_friendly_name\": \"aaa\",\"connect_app_homepage_url\": \"http://www.google.com\",\"connect_app_sid\": \"CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\",\"permissions\": [\"get-all\"],\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}")));
            
            var task = AuthorizedConnectAppResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = AuthorizedConnectAppResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"authorized_connect_apps\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"connect_app_company_name\": \"YOUR OTHER MOM\",\"connect_app_description\": \"alksjdfl;ajseifj;alsijfl;ajself;jasjfjas;lejflj\",\"connect_app_friendly_name\": \"YOUR MOM\",\"connect_app_homepage_url\": \"http://www.google.com\",\"connect_app_sid\": \"CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\",\"permissions\": [\"get-all\"],\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json\"}")));
            
            var task = AuthorizedConnectAppResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"authorized_connect_apps\": [],\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/AuthorizedConnectApps.json\"}")));
            
            var task = AuthorizedConnectAppResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    }
}