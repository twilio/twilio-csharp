
namespace Twilio.Tests.api.v2010.Account.Call {
    public class FeedbackTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [Before]
        public void SetUp() throws Exception {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [Test]
        public void TestCreateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Feedback.json",
                                              "AC123");
                request.addPostParam("QualityScore", serialize(1));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                FeedbackResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Thu, 20 Aug 2015 21:45:46 +0000\",\"date_updated\": \"Thu, 20 Aug 2015 21:45:46 +0000\",\"issues\": [\"imperfect-audio\",\"post-dial-delay\"],\"quality_score\": 5,\"sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            FeedbackResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1).execute();
        }
    
        [Test]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Feedback.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                FeedbackResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Thu, 20 Aug 2015 21:45:46 +0000\",\"date_updated\": \"Thu, 20 Aug 2015 21:45:46 +0000\",\"issues\": [\"imperfect-audio\",\"post-dial-delay\"],\"quality_score\": 5,\"sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(FeedbackResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestUpdateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Feedback.json",
                                              "AC123");
                request.addPostParam("QualityScore", serialize(1));
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                FeedbackResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Thu, 20 Aug 2015 21:45:46 +0000\",\"date_updated\": \"Thu, 20 Aug 2015 21:45:46 +0000\",\"issues\": [\"imperfect-audio\",\"post-dial-delay\"],\"quality_score\": 5,\"sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            FeedbackResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1).execute();
        }
    }
}