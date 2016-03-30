
namespace Twilio.Tests.taskrouter.v1.Workspace {
    public class ActivityTest {
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
                                              TwilioRestClient.Domains.TASKROUTER,
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                ActivityResource.fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(ActivityResource.fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestUpdateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.TASKROUTER,
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                request.addPostParam("FriendlyName", serialize("friendlyName"));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                ActivityResource.update("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            ActivityResource.update("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").execute();
        }
    
        [Test]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.TASKROUTER,
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                ActivityResource.delete("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
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
            
            ActivityResource.delete("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    
        [Test]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TASKROUTER,
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                ActivityResource.read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"activities\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"key\": \"activities\",\"last_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(ActivityResource.read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"activities\": [],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"key\": \"activities\",\"last_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities?PageSize=50&Page=0\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(ActivityResource.read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestCreateRequest() {
                        new NonStrictExpectations() {{
                            Request request = new Request(HttpMethod.POST,
                                                          TwilioRestClient.Domains.TASKROUTER,
                                                          "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities",
                                                          "AC123");
                            request.addPostParam("FriendlyName", serialize("friendlyName"));
            request.addPostParam("Available", serialize(true));
                            
                            twilioRestClient.request(request);
                            times = 1;
                            result = new Response("", 500);
                            twilioRestClient.getAccountSid();
                            result = "AC123";
                        }};
            
            try {
                ActivityResource.create("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName", true).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"available\": true,\"date_created\": \"2014-05-14T10:50:02Z\",\"date_updated\": \"2014-05-14T23:26:06Z\",\"friendly_name\": \"New Activity\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Activities/WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            ActivityResource.create("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName", true).execute();
        }
    }
}