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
using Twilio.Rest.IpMessaging.V1;

namespace Twilio.Tests.Rest.IpMessaging.V1 
{

    [TestFixture]
    public class ServiceTest : TwilioTest 
    {
        [SetUp]
        public void SetUp()
        {
        }
    
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.Get,
                                      Twilio.Rest.Domain.IpMessaging,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ServiceResource.Fetcher("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"links\": {},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"http://www.example.com\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"webhooks\": {}}"));
            
            var response = ServiceResource.Fetcher("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.Delete,
                                      Twilio.Rest.Domain.IpMessaging,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ServiceResource.Deleter("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
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
            
            ServiceResource.Deleter("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
        }
    
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.Post,
                                      Twilio.Rest.Domain.IpMessaging,
                                      "/v1/Services");
            request.AddPostParam("FriendlyName", Serialize("FriendlyName"));
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ServiceResource.Creator("FriendlyName").Create(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"links\": {},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"http://www.example.com\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"webhooks\": {}}"));
            
            var response = ServiceResource.Creator("FriendlyName").Create(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.Get,
                                      Twilio.Rest.Domain.IpMessaging,
                                      "/v1/Services");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ServiceResource.Reader().Read(twilioRestClient);
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
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://ip-messaging.twilio.com/v1/Services?Page=0&PageSize=50\",\"key\": \"services\",\"next_page_url\": null,\"page\": 0,\"page_size\": 0,\"previous_page_url\": null,\"url\": \"https://ip-messaging.twilio.com/v1/Services\"},\"services\": []}"));
            
            var response = ServiceResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"first_page_url\": \"https://ip-messaging.twilio.com/v1/Services?Page=0&PageSize=50\",\"key\": \"services\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://ip-messaging.twilio.com/v1/Services\"},\"services\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"links\": {},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"http://www.example.com\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"webhooks\": {}}]}"));
            
            var response = ServiceResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.Post,
                                      Twilio.Rest.Domain.IpMessaging,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                ServiceResource.Updater("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"links\": {},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"http://www.example.com\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"webhooks\": {}}"));
            
            var response = ServiceResource.Updater("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}