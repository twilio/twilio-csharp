
namespace Twilio.Tests.pricing.v1.Voice {
    public class NumberTest {
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
                                              TwilioRestClient.Domains.PRICING,
                                              "/v1/Voice/Numbers/+987654321",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                NumberResource.fetch(new com.twilio.types.PhoneNumber("+987654321")).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"country\": \"United States\",\"inbound_call_price\": {\"base_price\": null,\"current_price\": null,\"number_type\": null},\"iso_country\": \"US\",\"number\": \"+987654321\",\"outbound_call_price\": {\"base_price\": \"0.015\",\"current_price\": \"0.015\"},\"price_unit\": \"USD\",\"url\": \"https://pricing.twilio.com/v1/Voice/Numbers/+987654321\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(NumberResource.fetch(new com.twilio.types.PhoneNumber("+987654321")).execute());
        }
    }
}