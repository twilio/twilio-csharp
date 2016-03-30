
namespace Twilio.Tests.trunking.v1 {
    public class TrunkTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [Before]
        public void SetUp() throws Exception {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [Test]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TrunkResource.fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"domain_name\": \"test.pstn.twilio.com\",\"disaster_recovery_method\": \"POST\",\"disaster_recovery_url\": \"http://disaster-recovery.com\",\"friendly_name\": \"friendly_name\",\"secure\": false,\"recording\": {\"mode\": \"do-not-record\",\"trim\": \"do-not-trim\"},\"auth_type\": \"\",\"auth_type_set\": [],\"date_created\": \"2015-01-02T11:23:45Z\",\"date_updated\": \"2015-01-02T11:23:45Z\",\"url\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"origination_urls\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls\",\"credential_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialLists\",\"ip_access_control_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists\",\"phone_numbers\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(TrunkResource.fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TrunkResource.delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
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
            
            TrunkResource.delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    
        [Test]
        public void TestCreateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TrunkResource.create().execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"domain_name\": \"test.pstn.twilio.com\",\"disaster_recovery_method\": \"POST\",\"disaster_recovery_url\": \"http://disaster-recovery.com\",\"friendly_name\": \"friendly_name\",\"secure\": false,\"recording\": {\"mode\": \"do-not-record\",\"trim\": \"do-not-trim\"},\"auth_type\": \"\",\"auth_type_set\": [],\"date_created\": \"2015-01-02T11:23:45Z\",\"date_updated\": \"2015-01-02T11:23:45Z\",\"url\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"origination_urls\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls\",\"credential_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialLists\",\"ip_access_control_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists\",\"phone_numbers\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers\"}}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            TrunkResource.create().execute();
        }
    
        [Test]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TrunkResource.read().execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"meta\": {\"first_page_url\": \"https://trunking.twilio.com/v1/Trunks?PageSize=1&Page=0\",\"key\": \"trunks\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://trunking.twilio.com/v1/Trunks?PageSize=1&Page=0\"},\"trunks\": [{\"sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"domain_name\": \"test.pstn.twilio.com\",\"disaster_recovery_method\": \"POST\",\"disaster_recovery_url\": \"http://disaster-recovery.com\",\"friendly_name\": \"friendly_name\",\"secure\": false,\"recording\": {\"mode\": \"do-not-record\",\"trim\": \"do-not-trim\"},\"auth_type\": \"\",\"auth_type_set\": [],\"date_created\": \"2015-01-02T11:23:45Z\",\"date_updated\": \"2015-01-02T11:23:45Z\",\"url\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"origination_urls\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls\",\"credential_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialLists\",\"ip_access_control_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists\",\"phone_numbers\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers\"}}]}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(TrunkResource.read().execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"meta\": {\"first_page_url\": \"https://trunking.twilio.com/v1/Trunks?PageSize=1&Page=0\",\"key\": \"trunks\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://trunking.twilio.com/v1/Trunks?PageSize=1&Page=0\"},\"trunks\": []}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(TrunkResource.read().execute());
        }
    
        [Test]
        public void TestUpdateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.TRUNKING,
                                              "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TrunkResource.update("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"domain_name\": \"test.pstn.twilio.com\",\"disaster_recovery_method\": \"GET\",\"disaster_recovery_url\": \"http://updated-recovery.com\",\"friendly_name\": \"updated_name\",\"secure\": true,\"recording\": {\"mode\": \"do-not-record\",\"trim\": \"do-not-trim\"},\"auth_type\": \"\",\"auth_type_set\": [],\"date_created\": \"2015-01-02T11:23:45Z\",\"date_updated\": \"2015-01-02T11:23:45Z\",\"url\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"origination_urls\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls\",\"credential_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialLists\",\"ip_access_control_lists\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists\",\"phone_numbers\": \"http://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            TrunkResource.update("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}