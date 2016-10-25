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

namespace Twilio.Tests.Rest.Api.V2010.Account {

    [TestFixture]
    public class SandboxTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                SandboxResource.Fetcher(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"application_sid\": \"APaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"date_created\": \"Sun, 15 Mar 2009 02:08:47 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 17:37:18 +0000\",\"phone_number\": \"4155992671\",\"pin\": \"66528411\",\"sms_method\": \"POST\",\"sms_url\": \"http://demo.twilio.com/welcome/sms\",\"status_callback\": null,\"status_callback_method\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json\",\"voice_method\": \"POST\",\"voice_url\": \"http://www.digg.com\"}"));
            
            var response = SandboxResource.Fetcher(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                SandboxResource.Updater(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"application_sid\": \"APaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"date_created\": \"Sun, 15 Mar 2009 02:08:47 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 17:37:18 +0000\",\"phone_number\": \"4155992671\",\"pin\": \"66528411\",\"sms_method\": \"POST\",\"sms_url\": \"http://demo.twilio.com/welcome/sms\",\"status_callback\": null,\"status_callback_method\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json\",\"voice_method\": \"POST\",\"voice_url\": \"http://www.digg.com\"}"));
            
            var response = SandboxResource.Updater(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}