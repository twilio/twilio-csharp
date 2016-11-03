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
using Twilio.Rest.Preview.Wireless;

namespace Twilio.Tests.Rest.Preview.Wireless 
{

    [TestFixture]
    public class CommandTest : TwilioTest 
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
                                      Domains.PREVIEW,
                                      "/wireless/Commands/DCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                CommandResource.Fetcher("DCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"command\": \"command\",\"command_mode\": \"command_mode\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"device_sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"direction\": \"direction\",\"sid\": \"DCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"status\",\"url\": \"http://www.example.com\"}"));
            
            var response = CommandResource.Fetcher("DCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.GET,
                                      Domains.PREVIEW,
                                      "/wireless/Commands");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                CommandResource.Reader().Read(twilioRestClient);
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
                                                  "{\"commands\": [],\"meta\": {\"first_page_url\": \"https://preview.twilio.com/wireless/Commands?Page=0&PageSize=50\",\"key\": \"commands\",\"next_page_url\": null,\"page\": 0,\"page_size\": 0,\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/wireless/Commands\"}}"));
            
            var response = CommandResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"commands\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"command\": \"command\",\"command_mode\": \"command_mode\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"device_sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"direction\": \"direction\",\"sid\": \"DCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"status\",\"url\": \"http://www.example.com\"}],\"meta\": {\"first_page_url\": \"https://preview.twilio.com/wireless/Commands?Page=0&PageSize=50\",\"key\": \"commands\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://preview.twilio.com/wireless/Commands\"}}"));
            
            var response = CommandResource.Reader().Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.PREVIEW,
                                      "/wireless/Commands");
            request.AddPostParam("Device", Serialize("device"));
            request.AddPostParam("Command", Serialize("command"));
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                CommandResource.Creator("device", "command").Create(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"command\": \"command\",\"command_mode\": \"command_mode\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"device_sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"direction\": \"direction\",\"sid\": \"DCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"status\",\"url\": \"http://www.example.com\"}"));
            
            var response = CommandResource.Creator("device", "command").Create(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}