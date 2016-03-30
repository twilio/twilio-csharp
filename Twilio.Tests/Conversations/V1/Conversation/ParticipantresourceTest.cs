
namespace Twilio.Tests.conversations.v1.Conversation {
    public class ParticipantTest {
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
                                              TwilioRestClient.Domains.CONVERSATIONS,
                                              "/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                ParticipantResource.read("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"meta\": {\"first_page_url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants?PageSize=50&Page=0\",\"key\": \"participants\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants?PageSize=50&Page=0\"},\"participants\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address\": \"torkel2@ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.endpoint.twilio.com\",\"conversation_sid\": \"CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-05-13T23:03:12Z\",\"duration\": 685,\"end_time\": \"2015-05-13T23:14:40Z\",\"sid\": \"PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_time\": \"2015-05-13T23:03:15Z\",\"status\": \"disconnected\",\"url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(ParticipantResource.read("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"meta\": {\"first_page_url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants?PageSize=50&Page=0\",\"key\": \"participants\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants?PageSize=50&Page=0\"},\"participants\": []}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(ParticipantResource.read("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestCreateRequest() {
                        new NonStrictExpectations() {{
                            Request request = new Request(HttpMethod.POST,
                                                          TwilioRestClient.Domains.CONVERSATIONS,
                                                          "/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants",
                                                          "AC123");
                            request.addPostParam("To", serialize(new com.twilio.types.PhoneNumber("+123456789")));
            request.addPostParam("From", serialize(new com.twilio.types.PhoneNumber("+987654321")));
                            
                            twilioRestClient.request(request);
                            times = 1;
                            result = new Response("", 500);
                            twilioRestClient.getAccountSid();
                            result = "AC123";
                        }};
            
            try {
                ParticipantResource.create("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new com.twilio.types.PhoneNumber("+123456789"), new com.twilio.types.PhoneNumber("+987654321")).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address\": \"torkel2@ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.endpoint.twilio.com\",\"conversation_sid\": \"CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-05-13T23:03:12Z\",\"duration\": 685,\"end_time\": \"2015-05-13T23:14:40Z\",\"sid\": \"PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_time\": \"2015-05-13T23:03:15Z\",\"status\": \"disconnected\",\"url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            ParticipantResource.create("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new com.twilio.types.PhoneNumber("+123456789"), new com.twilio.types.PhoneNumber("+987654321")).execute();
        }
    
        [Test]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.CONVERSATIONS,
                                              "/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                ParticipantResource.fetch("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"address\": \"torkel2@ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.endpoint.twilio.com\",\"conversation_sid\": \"CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-05-13T23:03:12Z\",\"duration\": 685,\"end_time\": \"2015-05-13T23:14:40Z\",\"sid\": \"PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_time\": \"2015-05-13T23:03:15Z\",\"status\": \"disconnected\",\"url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(ParticipantResource.fetch("CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "PAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    }
}