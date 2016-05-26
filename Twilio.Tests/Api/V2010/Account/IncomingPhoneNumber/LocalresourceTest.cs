using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.IncomingPhoneNumber;

namespace Twilio.Tests.Api.V2010.Account.IncomingPhoneNumber {

    [TestFixture]
    public class LocalTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = LocalResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
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
                                             "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json?PageSize=1&Page=0\",\"incoming_phone_numbers\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address_requirements\": \"none\",\"api_version\": \"2010-04-01\",\"beta\": null,\"capabilities\": {\"mms\": true,\"sms\": false,\"voice\": true},\"date_created\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"friendly_name\": \"(808) 925-5327\",\"phone_number\": \"+18089255327\",\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_application_sid\": \"\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_method\": \"POST\",\"sms_url\": \"\",\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"trunk_sid\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_application_sid\": \"\",\"voice_caller_id_lookup\": false,\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_url\": null}],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json?PageSize=1&Page=2\",\"next_page_uri\": null,\"num_pages\": 3,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 3,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json?PageSize=1\"}")));
            
            var task = LocalResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json?PageSize=1&Page=0\",\"incoming_phone_numbers\": [],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json?PageSize=1&Page=2\",\"next_page_uri\": null,\"num_pages\": 3,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 3,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json?PageSize=1\"}")));
            
            var task = LocalResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/Local.json");
            request.AddPostParam("PhoneNumber", Serialize(new Twilio.Types.PhoneNumber("+987654321")));
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = LocalResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Twilio.Types.PhoneNumber("+987654321")).ExecuteAsync(twilioRestClient);
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
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address_requirements\": \"none\",\"api_version\": \"2010-04-01\",\"beta\": false,\"capabilities\": {\"mms\": true,\"sms\": false,\"voice\": true},\"date_created\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"friendly_name\": \"(808) 925-5327\",\"phone_number\": \"+18089255327\",\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_application_sid\": \"\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_method\": \"POST\",\"sms_url\": \"\",\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"trunk_sid\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_application_sid\": \"\",\"voice_caller_id_lookup\": false,\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_url\": null}")));
            
            var task = LocalResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Twilio.Types.PhoneNumber("+987654321")).ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    }
}