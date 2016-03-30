
namespace Twilio.Tests.api.v2010.Account.Usage {
    public class RecordTest {
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
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records.json",
                                              "AC123");
                
                request.addQueryParam("PageSize", "50");
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                RecordResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestReadFullResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Page=0&PageSize=1\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Page=68&PageSize=1\",\"next_page_uri\": null,\"num_pages\": 69,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 69,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records\",\"usage_records\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"category\": \"totalprice\",\"count\": null,\"count_unit\": \"\",\"description\": \"Total Price\",\"end_date\": \"2015-09-04\",\"price\": \"2192.84855\",\"price_unit\": \"usd\",\"start_date\": \"2011-08-23\",\"subresource_uris\": {\"all_time\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/AllTime.json?Category=totalprice\",\"daily\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/Daily.json?Category=totalprice\",\"last_month\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/LastMonth.json?Category=totalprice\",\"monthly\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/Monthly.json?Category=totalprice\",\"this_month\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/ThisMonth.json?Category=totalprice\",\"today\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/Today.json?Category=totalprice\",\"yearly\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/Yearly.json?Category=totalprice\",\"yesterday\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records/Yesterday.json?Category=totalprice\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Category=totalprice&StartDate=2011-08-23&EndDate=2015-09-04\",\"usage\": \"2192.84855\",\"usage_unit\": \"usd\"}]}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(RecordResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Page=0&PageSize=1\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Page=68&PageSize=1\",\"next_page_uri\": null,\"num_pages\": 69,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 69,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records\",\"usage_records\": []}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(RecordResource.read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    }
}