using NUnit.Framework;
using Nunit.Mock;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Api.V2010.Account.IncomingPhoneNumber {

    public class TollFreeTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [TestCase]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TollFreeResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json?PageSize=1&Page=0\",\"incoming_phone_numbers\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address_requirements\": \"none\",\"api_version\": \"2010-04-01\",\"beta\": null,\"capabilities\": {\"mms\": true,\"sms\": false,\"voice\": true},\"date_created\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"friendly_name\": \"(808) 925-5327\",\"phone_number\": \"+18089255327\",\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_application_sid\": \"\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_method\": \"POST\",\"sms_url\": \"\",\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"trunk_sid\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_application_sid\": \"\",\"voice_caller_id_lookup\": false,\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_url\": null}],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json?PageSize=1&Page=2\",\"next_page_uri\": null,\"num_pages\": 3,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 3,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json?PageSize=1\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(TollFreeResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json?PageSize=1&Page=0\",\"incoming_phone_numbers\": [],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json?PageSize=1&Page=2\",\"next_page_uri\": null,\"num_pages\": 3,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 3,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json?PageSize=1\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(TollFreeResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [TestCase]
        public void TestCreateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/TollFree.json",
                                              "AC123");
                request.addPostParam("PhoneNumber", serialize(new com.twilio.types.PhoneNumber("+987654321")));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TollFreeResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new com.twilio.types.PhoneNumber("+987654321")).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address_requirements\": \"none\",\"api_version\": \"2010-04-01\",\"beta\": false,\"capabilities\": {\"mms\": true,\"sms\": false,\"voice\": true},\"date_created\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 23:19:04 +0000\",\"friendly_name\": \"(808) 925-5327\",\"phone_number\": \"+18089255327\",\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_application_sid\": \"\",\"sms_fallback_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_method\": \"POST\",\"sms_url\": \"\",\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"trunk_sid\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_application_sid\": \"\",\"voice_caller_id_lookup\": false,\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_url\": null}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            TollFreeResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new com.twilio.types.PhoneNumber("+987654321")).execute();
        }
    }
}