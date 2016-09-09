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
using Twilio.Rest.Chat.V1;

namespace Twilio.Tests.Rest.Chat.V1 {

    [TestFixture]
    public class ServiceTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.CHAT,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                ServiceResource.Fetch("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"216d4a5b-654a-4b60-acea-cf4e42604fb3\",\"date_created\": \"2015-12-16T17:53:05Z\",\"date_updated\": \"2015-12-16T17:53:05Z\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"read_status_enabled\": true,\"typing_indicator_timeout\": 5,\"consumption_report_interval\": 10,\"webhooks\": {},\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"channels\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"roles\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"users\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\"}}"));
            
            var response = ServiceResource.Fetch("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.DELETE,
                                          Domains.CHAT,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                ServiceResource.Delete("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
            
            ServiceResource.Delete("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.CHAT,
                                          "/v1/Services");
            request.AddPostParam("FriendlyName", Serialize("friendlyName"));
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                ServiceResource.Create("friendlyName").Execute(twilioRestClient);
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
                                                  "{\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"216d4a5b-654a-4b60-acea-cf4e42604fb3\",\"date_created\": \"2015-12-16T17:53:05Z\",\"date_updated\": \"2015-12-16T17:53:05Z\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"read_status_enabled\": true,\"typing_indicator_timeout\": 5,\"consumption_report_interval\": 10,\"webhooks\": {},\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"channels\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"roles\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"users\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\"}}"));
            
            var response = ServiceResource.Create("friendlyName").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.CHAT,
                                          "/v1/Services");
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                ServiceResource.Read().Execute(twilioRestClient);
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
                                                  "{\"meta\": {\"page\": 0,\"page_size\": 1,\"first_page_url\": \"https://ip-messaging.twilio.com/v1/Services?PageSize=1&Page=0\",\"previous_page_url\": null,\"url\": \"https://ip-messaging.twilio.com/v1/Services?PageSize=1&Page=0\",\"next_page_url\": null,\"key\": \"services\"},\"services\": [{\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"216d4a5b-654a-4b60-acea-cf4e42604fb3\",\"date_created\": \"2015-12-16T17:53:05Z\",\"date_updated\": \"2015-12-16T17:53:05Z\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"read_status_enabled\": true,\"typing_indicator_timeout\": 5,\"consumption_report_interval\": 10,\"webhooks\": {},\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"channels\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"roles\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"users\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\"}}]}"));
            
            var response = ServiceResource.Read().Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://ip-messaging.twilio.com/v1/Services?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://ip-messaging.twilio.com/v1/Services?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"services\"},\"services\": []}"));
            
            var response = ServiceResource.Read().Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.CHAT,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                ServiceResource.Update("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"216d4a5b-654a-4b60-acea-cf4e42604fb3\",\"date_created\": \"2015-12-16T17:53:05Z\",\"date_updated\": \"2015-12-16T17:53:05Z\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"read_status_enabled\": true,\"typing_indicator_timeout\": 5,\"consumption_report_interval\": 10,\"webhooks\": {},\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"channels\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"roles\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"users\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\"}}"));
            
            var response = ServiceResource.Update("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}