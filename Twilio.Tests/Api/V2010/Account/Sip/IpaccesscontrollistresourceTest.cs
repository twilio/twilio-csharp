
namespace Twilio.Tests.api.v2010.Account.Sip {
    public class IpAccessControlListTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [Before]
        public void SetUp() throws Exception {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [Test]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAccessControlListResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"ip_access_control_lists\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(IpAccessControlListResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"ip_access_control_lists\": [],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(IpAccessControlListResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestCreateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json",
                                              "AC123");
                request.addPostParam("FriendlyName", serialize("friendlyName"));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAccessControlListResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            IpAccessControlListResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").execute();
        }
    
        [Test]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAccessControlListResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(IpAccessControlListResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestUpdateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                request.addPostParam("FriendlyName", serialize("friendlyName"));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAccessControlListResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            IpAccessControlListResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").execute();
        }
    
        [Test]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAccessControlListResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
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
            
            IpAccessControlListResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}