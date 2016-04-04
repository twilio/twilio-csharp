using NUnit.Framework;
using Nunit.Mock;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Api.V2010.Account.Call {

    public class FeedbackSummaryTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [TestCase]
        public void TestCreateRequest() {
                        new NonStrictExpectations() {{
                            Request request = new Request(HttpMethod.POST,
                                                          TwilioRestClient.Domains.API,
                                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/FeedbackSummary.json",
                                                          "AC123");
                            request.addPostParam("StartDate", serialize(MarshalConverter.localDateFromString("2008-01-02")));
            request.addPostParam("EndDate", serialize(MarshalConverter.localDateFromString("2008-01-02")));
                            
                            twilioRestClient.request(request);
                            times = 1;
                            result = new Response("", 500);
                            twilioRestClient.getAccountSid();
                            result = "AC123";
                        }};
            
            try {
                FeedbackSummaryResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", MarshalConverter.localDateFromString("2008-01-02"), MarshalConverter.localDateFromString("2008-01-02")).execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestCreateResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_count\": 10200,\"call_feedback_count\": 729,\"end_date\": \"2011-01-01\",\"include_subaccounts\": false,\"issues\": [{\"count\": 45,\"description\": \"imperfect-audio\",\"percentage_of_total_calls\": \"0.04%\"}],\"quality_score_average\": 4.5,\"quality_score_median\": 4,\"quality_score_standard_deviation\": 1,\"sid\": \"FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_date\": \"2011-01-01\",\"status\": \"completed\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\"}", TwilioRestClient.HTTP_STATUS_CODE_CREATED);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            FeedbackSummaryResource.create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", MarshalConverter.localDateFromString("2008-01-02"), MarshalConverter.localDateFromString("2008-01-02")).execute();
        }
    
        [TestCase]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/FeedbackSummary/FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                FeedbackSummaryResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_count\": 10200,\"call_feedback_count\": 729,\"end_date\": \"2011-01-01\",\"include_subaccounts\": false,\"issues\": [{\"count\": 45,\"description\": \"imperfect-audio\",\"percentage_of_total_calls\": \"0.04%\"}],\"quality_score_average\": 4.5,\"quality_score_median\": 4,\"quality_score_standard_deviation\": 1,\"sid\": \"FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_date\": \"2011-01-01\",\"status\": \"completed\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(FeedbackSummaryResource.fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    
        [TestCase]
        public void TestDeleteRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.DELETE,
                                              TwilioRestClient.Domains.API,
                                              "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/FeedbackSummary/FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                FeedbackSummaryResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
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
            
            FeedbackSummaryResource.delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
        }
    }
}