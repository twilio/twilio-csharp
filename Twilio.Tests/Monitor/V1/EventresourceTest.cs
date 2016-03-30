
namespace Twilio.Tests.monitor.v1 {
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
                                              TwilioRestClient.Domains.MONITOR,
                                              "/v1/Events/AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                EventResource.fetch("AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"account\",\"description\": null,\"event_data\": {\"friendly_name\": {\"previous\": \"SubAccount Created at 2014-10-03 09:48 am\",\"updated\": \"Mr. Friendly\"}},\"event_date\": \"2014-10-03T16:48:25Z\",\"event_type\": \"account.updated\",\"links\": {\"actor\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"resource_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"account\",\"sid\": \"AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"api\",\"source_ip_address\": \"10.86.6.250\",\"url\": \"https://monitor.twilio.com/v1/Events/AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(EventResource.fetch("AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.MONITOR,
                                              "/v1/Events",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                EventResource.read().execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"events\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"account\",\"description\": null,\"event_data\": {\"friendly_name\": {\"previous\": \"SubAccount Created at 2014-10-03 09:48 am\",\"updated\": \"Mr. Friendly\"}},\"event_date\": \"2014-10-03T16:48:25Z\",\"event_type\": \"account.updated\",\"links\": {\"actor\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"resource_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"account\",\"sid\": \"AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"api\",\"source_ip_address\": \"10.86.6.250\",\"url\": \"https://monitor.twilio.com/v1/Events/AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(EventResource.read().execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"events\": [],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\"}}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(EventResource.read().execute());
        }
    }
}