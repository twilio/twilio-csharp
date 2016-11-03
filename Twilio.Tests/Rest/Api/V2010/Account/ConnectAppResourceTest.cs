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
using Twilio.Rest.Api.V2010.Account;

namespace Twilio.Tests.Rest.Api.V2010.Account 
{

    [TestFixture]
    public class ConnectAppTest : TwilioTest 
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
                                      Domains.API,
                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ConnectAppResource.Fetcher("CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"authorize_redirect_url\": \"http://example.com/redirect\",\"company_name\": \"Twilio\",\"deauthorize_callback_method\": \"GET\",\"deauthorize_callback_url\": \"http://example.com/deauth\",\"description\": null,\"friendly_name\": \"Connect app for deletion\",\"homepage_url\": \"http://example.com/home\",\"permissions\": [],\"sid\": \"CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = ConnectAppResource.Fetcher("CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.API,
                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ConnectAppResource.Updater("CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"authorize_redirect_url\": \"http://example.com/redirect\",\"company_name\": \"Twilio\",\"deauthorize_callback_method\": \"GET\",\"deauthorize_callback_url\": \"http://example.com/deauth\",\"description\": null,\"friendly_name\": \"Connect app for deletion\",\"homepage_url\": \"http://example.com/home\",\"permissions\": [],\"sid\": \"CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = ConnectAppResource.Updater("CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.GET,
                                      Domains.API,
                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ConnectAppResource.Reader().Read(twilioRestClient);
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
                                                  "{\"connect_apps\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"authorize_redirect_url\": \"http://example.com/redirect\",\"company_name\": \"Twilio\",\"deauthorize_callback_method\": \"GET\",\"deauthorize_callback_url\": \"http://example.com/deauth\",\"description\": null,\"friendly_name\": \"Connect app for deletion\",\"homepage_url\": \"http://example.com/home\",\"permissions\": [],\"sid\": \"CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps/CNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json\"}"));
            
            var response = ConnectAppResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"connect_apps\": [],\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json?Page=0&PageSize=50\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json?Page=0&PageSize=50\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/ConnectApps.json\"}"));
            
            var response = ConnectAppResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}