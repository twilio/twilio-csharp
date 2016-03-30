
namespace Twilio.Tests.api.v2010.Account {
    public class SandboxTest {
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
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                SandboxResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"application_sid\": \"APaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"date_created\": \"Sun, 15 Mar 2009 02:08:47 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 17:37:18 +0000\",\"phone_number\": \"4155992671\",\"pin\": \"66528411\",\"sms_method\": \"POST\",\"sms_url\": \"http://demo.twilio.com/welcome/sms\",\"status_callback\": null,\"status_callback_method\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json\",\"voice_method\": \"POST\",\"voice_url\": \"http://www.digg.com\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(SandboxResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestUpdateRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.POST,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                SandboxResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestUpdateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"application_sid\": \"APaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2008-08-01\",\"date_created\": \"Sun, 15 Mar 2009 02:08:47 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 17:37:18 +0000\",\"phone_number\": \"4155992671\",\"pin\": \"66528411\",\"sms_method\": \"POST\",\"sms_url\": \"http://demo.twilio.com/welcome/sms\",\"status_callback\": null,\"status_callback_method\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sandbox.json\",\"voice_method\": \"POST\",\"voice_url\": \"http://www.digg.com\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            SandboxResource.update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}