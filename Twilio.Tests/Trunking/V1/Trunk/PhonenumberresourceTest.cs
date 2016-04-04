using NUnit.Framework;
using Nunit.Mock;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Trunking.V1.Trunk {

    public class PhoneNumberTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [TestCase]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                PhoneNumberResource.fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2010-12-10T17:27:34Z\",\"date_updated\": \"2015-10-09T11:36:32Z\",\"friendly_name\": \"(415) 867-5309\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"phone_number\": \"+14158675309\",\"api_version\": \"2010-04-01\",\"voice_caller_id_lookup\": null,\"voice_url\": \"\",\"voice_method\": \"POST\",\"voice_fallback_url\": null,\"voice_fallback_method\": null,\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"voice_application_sid\": null,\"trunk_sid\": \"TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_url\": \"\",\"sms_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_fallback_method\": \"POST\",\"sms_application_sid\": \"\",\"address_requirements\": \"none\",\"beta\": false,\"url\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"capabilities\": {\"voice\": true,\"sms\": true,\"mms\": true},\"links\": {\"phone_number\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(PhoneNumberResource.fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [TestCase]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                PhoneNumberResource.delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestDeleteResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("null", TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            PhoneNumberResource.delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    
        [TestCase]
        public void TestCreateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers",
                                              "AC123");
                request.addPostParam("PhoneNumberSid", serialize("PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                PhoneNumberResource.create("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2010-12-10T17:27:34Z\",\"date_updated\": \"2015-10-09T11:36:32Z\",\"friendly_name\": \"(415) 867-5309\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"phone_number\": \"+14158675309\",\"api_version\": \"2010-04-01\",\"voice_caller_id_lookup\": null,\"voice_url\": \"\",\"voice_method\": \"POST\",\"voice_fallback_url\": null,\"voice_fallback_method\": null,\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"voice_application_sid\": null,\"trunk_sid\": \"TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_url\": \"\",\"sms_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_fallback_method\": \"POST\",\"sms_application_sid\": \"\",\"address_requirements\": \"none\",\"beta\": false,\"url\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"capabilities\": {\"voice\": true,\"sms\": true,\"mms\": true},\"links\": {\"phone_number\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            PhoneNumberResource.create("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    
        [TestCase]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                PhoneNumberResource.read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"meta\": {\"first_page_url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers?PageSize=1&Page=0\",\"key\": \"phone_numbers\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers?PageSize=1&Page=0\"},\"phone_numbers\": [{\"sid\": \"PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2010-12-10T17:27:34Z\",\"date_updated\": \"2015-10-09T11:36:32Z\",\"friendly_name\": \"(415) 867-5309\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"phone_number\": \"+14158675309\",\"api_version\": \"2010-04-01\",\"voice_caller_id_lookup\": null,\"voice_url\": \"\",\"voice_method\": \"POST\",\"voice_fallback_url\": null,\"voice_fallback_method\": null,\"status_callback\": \"\",\"status_callback_method\": \"POST\",\"voice_application_sid\": null,\"trunk_sid\": \"TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sms_url\": \"\",\"sms_method\": \"POST\",\"sms_fallback_url\": \"\",\"sms_fallback_method\": \"POST\",\"sms_application_sid\": \"\",\"address_requirements\": \"none\",\"beta\": false,\"url\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"capabilities\": {\"voice\": true,\"sms\": true,\"mms\": true},\"links\": {\"phone_number\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IncomingPhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}}]}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(PhoneNumberResource.read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"meta\": {\"first_page_url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers?PageSize=1&Page=0\",\"key\": \"phone_numbers\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers?PageSize=1&Page=0\"},\"phone_numbers\": []}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(PhoneNumberResource.read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    }
}