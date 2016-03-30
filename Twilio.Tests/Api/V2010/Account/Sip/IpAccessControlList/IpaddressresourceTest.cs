
namespace Twilio.Tests.api.v2010.Account.Sip.IpAccessControlList {
    public class IpAddressTest {
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
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAddressResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json?PageSize=50&Page=0\",\"ip_addresses\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"date_updated\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"friendly_name\": \"aaa\",\"ip_access_control_list_sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"ip_address\": \"192.1.1.2\",\"sid\": \"IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json?PageSize=50&Page=0\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(IpAddressResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json?PageSize=50&Page=0\",\"ip_addresses\": [],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json?PageSize=50&Page=0\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(IpAddressResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestCreateRequest() {
                        new NonStrictExpectations() {{
                            Request request = new Request(HttpMethod.POST,
                                                          TwilioRestClient.Domains.API,
                                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json",
                                                          "AC123");
                            request.addPostParam("FriendlyName", serialize("friendlyName"));
            request.addPostParam("IpAddress", serialize("ipAddress"));
                            
                            twilioRestClient.request(request);
                            times = 1;
                            result = new Response("", 500);
                            twilioRestClient.getAccountSid();
                            result = "AC123";
                        }};
            
            try {
                IpAddressResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName", "ipAddress").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"date_updated\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"friendly_name\": \"aaa\",\"ip_access_control_list_sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"ip_address\": \"192.1.1.2\",\"sid\": \"IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            IpAddressResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName", "ipAddress").execute();
        }
    
        [Test]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAddressResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"date_updated\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"friendly_name\": \"aaa\",\"ip_access_control_list_sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"ip_address\": \"192.1.1.2\",\"sid\": \"IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(IpAddressResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestUpdateRequest() {
                        new NonStrictExpectations() {{
                            Request request = new Request(HttpMethod.POST,
                                                          TwilioRestClient.Domains.API,
                                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                                          "AC123");
                            request.addPostParam("IpAddress", serialize("ipAddress"));
            request.addPostParam("FriendlyName", serialize("friendlyName"));
                            
                            twilioRestClient.request(request);
                            times = 1;
                            result = new Response("", 500);
                            twilioRestClient.getAccountSid();
                            result = "AC123";
                        }};
            
            try {
                IpAddressResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ipAddress", "friendlyName").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"date_updated\": \"Mon, 20 Jul 2015 17:27:10 +0000\",\"friendly_name\": \"aaa\",\"ip_access_control_list_sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"ip_address\": \"192.1.1.2\",\"sid\": \"IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            IpAddressResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ipAddress", "friendlyName").execute();
        }
    
        [Test]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses/IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                IpAddressResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
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
            
            IpAddressResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "IPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}