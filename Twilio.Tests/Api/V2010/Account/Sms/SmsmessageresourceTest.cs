using NUnit.Framework;
using Nunit.Mock;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Api.V2010.Account.Sms {

    public class SmsMessageTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [TestCase]
        public void TestCreateRequest() {
                        new NonStrictExpectations() {{
                            Request request = new Request(HttpMethod.POST,
                                                          TwilioRestClient.Domains.API,
                                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json",
                                                          "AC123");
                            request.addPostParam("To", serialize(new com.twilio.types.PhoneNumber("+123456789")));
            request.addPostParam("From", serialize(new com.twilio.types.PhoneNumber("+987654321")));
            request.addPostParam("Body", serialize("body"));
                            
                            twilioRestClient.request(request);
                            times = 1;
                            result = new Response("", 500);
                            twilioRestClient.getAccountSid();
                            result = "AC123";
                        }};
            
            try {
                SmsMessageResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new com.twilio.types.PhoneNumber("+123456789"), new com.twilio.types.PhoneNumber("+987654321"), "body").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"body\": \"n\",\"date_created\": \"Mon, 26 Jul 2010 21:46:42 +0000\",\"date_sent\": \"Mon, 26 Jul 2010 21:46:44 +0000\",\"date_updated\": \"Mon, 26 Jul 2010 21:46:44 +0000\",\"direction\": \"outbound-api\",\"from\": \"+141586753093\",\"price\": \"-0.03000\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"to\": \"+141586753096\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            SmsMessageResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new com.twilio.types.PhoneNumber("+123456789"), new com.twilio.types.PhoneNumber("+987654321"), "body").execute();
        }
    
        [TestCase]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                SmsMessageResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
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
            
            SmsMessageResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    
        [TestCase]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                SmsMessageResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"body\": \"n\",\"date_created\": \"Mon, 26 Jul 2010 21:46:42 +0000\",\"date_sent\": \"Mon, 26 Jul 2010 21:46:44 +0000\",\"date_updated\": \"Mon, 26 Jul 2010 21:46:44 +0000\",\"direction\": \"outbound-api\",\"from\": \"+141586753093\",\"price\": \"-0.03000\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"to\": \"+141586753096\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(SmsMessageResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [TestCase]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                SmsMessageResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json?PageSize=1&Page=119771\",\"next_page_uri\": null,\"num_pages\": 119772,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"sms_messages\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Fri, 04 Sep 2015 22:54:39 +0000\",\"date_sent\": \"Fri, 04 Sep 2015 22:54:41 +0000\",\"date_updated\": \"Fri, 04 Sep 2015 22:54:41 +0000\",\"direction\": \"outbound-api\",\"from\": \"+14155552345\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"start\": 0,\"total\": 119772,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json?PageSize=1&Page=0\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(SmsMessageResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json?PageSize=1&Page=119771\",\"next_page_uri\": null,\"num_pages\": 119772,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"sms_messages\": [],\"start\": 0,\"total\": 119772,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages.json?PageSize=1&Page=0\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(SmsMessageResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [TestCase]
        public void TestUpdateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                SmsMessageResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"body\": \"n\",\"date_created\": \"Mon, 26 Jul 2010 21:46:42 +0000\",\"date_sent\": \"Mon, 26 Jul 2010 21:46:44 +0000\",\"date_updated\": \"Mon, 26 Jul 2010 21:46:44 +0000\",\"direction\": \"outbound-api\",\"from\": \"+141586753093\",\"price\": \"-0.03000\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"to\": \"+141586753096\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SMS/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            SmsMessageResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}