
namespace Twilio.Tests.taskrouter.v1.Workspace {
    public class EventTest {
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
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                EventResource.fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"workspace\",\"actor_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"description\": \"Worker JustinWorker updated to Idle Activity\",\"event_data\": {\"worker_activity_name\": \"Offline\",\"worker_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_attributes\": \"{}\",\"worker_name\": \"JustinWorker\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_time_in_previous_activity\": \"26\",\"workspace_name\": \"WorkspaceName\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"event_date\": \"2015-02-07T00:32:41Z\",\"event_type\": \"worker.activity\",\"resource_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"worker\",\"resource_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"twilio\",\"source_ip_address\": \"1.2.3.4\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(EventResource.fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TASKROUTER,
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                EventResource.read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"events\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"workspace\",\"actor_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"description\": \"Worker JustinWorker updated to Idle Activity\",\"event_data\": {\"worker_activity_name\": \"Offline\",\"worker_activity_sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_attributes\": \"{}\",\"worker_name\": \"JustinWorker\",\"worker_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"worker_time_in_previous_activity\": \"26\",\"workspace_name\": \"WorkspaceName\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"event_date\": \"2015-02-07T00:32:41Z\",\"event_type\": \"worker.activity\",\"resource_sid\": \"WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"worker\",\"resource_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/WKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"twilio\",\"source_ip_address\": \"1.2.3.4\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events/EVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(EventResource.read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"events\": [],\"meta\": {\"first_page_url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Events?PageSize=50&Page=0\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(EventResource.read("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    }
}