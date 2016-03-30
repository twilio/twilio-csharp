
namespace Twilio.Tests.api.v2010.Account {
    public class TokenTest {
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
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tokens.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                TokenResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 24 Jul 2015 18:43:58 +0000\",\"date_updated\": \"Fri, 24 Jul 2015 18:43:58 +0000\",\"ice_servers\": [{\"url\": \"stun:global.stun:3478?transport=udp\"},{\"credential\": \"5SR2x8mZK1lTFJW3NVgLGw6UM9C0dja4jI/Hdw3xr+w=\",\"url\": \"turn:global.turn:3478?transport=udp\",\"username\": \"cda92e5006c7810494639fc466ecc80182cef8183fdf400f84c4126f3b59d0bb\"}],\"password\": \"5SR2x8mZK1lTFJW3NVgLGw6UM9C0dja4jI/Hdw3xr+w=\",\"ttl\": \"86400\",\"username\": \"cda92e5006c7810494639fc466ecc80182cef8183fdf400f84c4126f3b59d0bb\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            TokenResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}