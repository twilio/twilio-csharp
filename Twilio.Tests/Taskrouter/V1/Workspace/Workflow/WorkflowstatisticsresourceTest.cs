using NUnit.Framework;
using Nunit.Mock;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Taskrouter.V1.Workspace.Workflow {

    public class WorkflowStatisticsTest {
        [Mocked]
        private TwilioRestClient twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            Twilio.init("AC123", "AUTH TOKEN");
        }
    
        [TestCase]
        public void TestFetchRequest() {
            new NonStrictExpectations() {{
                Request request = new Request(HttpMethod.GET,
                                              TwilioRestClient.Domains.TASKROUTER,
                                              "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workflows/WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Statistics",
                                              "AC123");
                
                
                twilioRestClient.request(request);
                times = 1;
                result = new Response("", 500);
                twilioRestClient.getAccountSid();
                result = "AC123";
            }};
            
            try {
                WorkflowStatisticsResource.fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute();
                fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
        }
    
        [Test]
        public void TestFetchResponse() {
            new NonStrictExpectations() {{
                twilioRestClient.request((Request) any);
                result = new Response("{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"cumulative\": {\"avg_task_acceptance_time\": 0.0,\"end_time\": \"2014-08-06T22:39:00Z\",\"reservations_accepted\": 0,\"reservations_rejected\": 0,\"reservations_timed_out\": 0,\"start_time\": \"2014-08-06T22:24:00Z\",\"tasks_canceled\": 0,\"tasks_entered\": 0,\"tasks_moved\": 0,\"tasks_timed_out_in_workflow\": 0},\"realtime\": {\"longest_task_waiting_age\": 0,\"longest_task_waiting_sid\": null,\"tasks_by_status\": {\"assigned\": 1,\"pending\": 0,\"reserved\": 0},\"total_tasks\": 1},\"workflow_sid\": \"WWaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}", TwilioRestClient.HTTP_STATUS_CODE_OK);
                twilioRestClient.getObjectMapper();
                result = new ObjectMapper();
            }};
            
            assertNotNull(WorkflowStatisticsResource.fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "WFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").execute());
        }
    }
}