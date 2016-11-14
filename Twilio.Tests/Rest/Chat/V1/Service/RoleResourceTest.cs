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
using Twilio.Rest.Chat.V1.Service;

namespace Twilio.Tests.Rest.Chat.V1.Service 
{

    [TestFixture]
    public class RoleTest : TwilioTest 
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
                                      Domains.CHAT,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                RoleResource.Fetcher("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"channel user\",\"type\": \"channel\",\"permissions\": [\"sendMessage\",\"leaveChannel\",\"editOwnMessage\",\"deleteOwnMessage\"],\"date_created\": \"2016-03-03T19:47:15Z\",\"date_updated\": \"2016-03-03T19:47:15Z\",\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = RoleResource.Fetcher("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.DELETE,
                                      Domains.CHAT,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                RoleResource.Deleter("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
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
            
            RoleResource.Deleter("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
        }
    
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.CHAT,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles");
            request.AddPostParam("FriendlyName", Serialize("FriendlyName"));
            request.AddPostParam("Type", Serialize(RoleResource.RoleTypeEnum.Channel));
            request.AddPostParam("Permission", Serialize(new List<string> { "Permission" }));
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                RoleResource.Creator("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FriendlyName", RoleResource.RoleTypeEnum.Channel, new List<string> { "Permission" }).Create(twilioRestClient);
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
                                                  "{\"sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"channel user\",\"type\": \"channel\",\"permissions\": [\"sendMessage\",\"leaveChannel\",\"editOwnMessage\",\"deleteOwnMessage\"],\"date_created\": \"2016-03-03T19:47:15Z\",\"date_updated\": \"2016-03-03T19:47:15Z\",\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = RoleResource.Creator("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FriendlyName", RoleResource.RoleTypeEnum.Channel, new List<string> { "Permission" }).Create(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.GET,
                                      Domains.CHAT,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                RoleResource.Reader("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
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
                                                  "{\"meta\": {\"page\": 0,\"page_size\": 1,\"first_page_url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles?PageSize=1&Page=0\",\"previous_page_url\": null,\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles?PageSize=1&Page=0\",\"next_page_url\": null,\"key\": \"roles\"},\"roles\": [{\"sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"channel user\",\"type\": \"channel\",\"permissions\": [\"sendMessage\",\"leaveChannel\",\"editOwnMessage\",\"deleteOwnMessage\"],\"date_created\": \"2016-03-03T19:47:15Z\",\"date_updated\": \"2016-03-03T19:47:15Z\",\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}"));
            
            var response = RoleResource.Reader("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"meta\": {\"page\": 0,\"page_size\": 1,\"first_page_url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles?PageSize=1&Page=0\",\"previous_page_url\": null,\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles?PageSize=1&Page=0\",\"next_page_url\": null,\"key\": \"roles\"},\"roles\": []}"));
            
            var response = RoleResource.Reader("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.CHAT,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            request.AddPostParam("Permission", Serialize(new List<string> { "Permission" }));
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                RoleResource.Updater("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new List<string> { "Permission" }).Update(twilioRestClient);
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
                                                  "{\"sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"channel user\",\"type\": \"channel\",\"permissions\": [\"sendMessage\",\"leaveChannel\",\"editOwnMessage\",\"deleteOwnMessage\"],\"date_created\": \"2016-03-03T19:47:15Z\",\"date_updated\": \"2016-03-03T19:47:15Z\",\"url\": \"https://ip-messaging.twilio.com/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles/RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = RoleResource.Updater("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new List<string> { "Permission" }).Update(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}