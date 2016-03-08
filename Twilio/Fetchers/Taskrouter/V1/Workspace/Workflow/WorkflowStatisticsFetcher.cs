using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.workflow.WorkflowStatistics;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace.Workflow {

    public class WorkflowStatisticsFetcher : Fetcher<WorkflowStatistics> {
        private String workspaceSid;
        private String workflowSid;
        private Integer minutes;
        private DateTime startDate;
        private DateTime endDate;
    
        /**
         * Construct a new WorkflowStatisticsFetcher
         * 
         * @param workspaceSid The workspace_sid
         * @param workflowSid The workflow_sid
         */
        public WorkflowStatisticsFetcher(String workspaceSid, String workflowSid) {
            this.workspaceSid = workspaceSid;
            this.workflowSid = workflowSid;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public WorkflowStatisticsFetcher setMinutes(Integer minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public WorkflowStatisticsFetcher setStartDate(DateTime startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public WorkflowStatisticsFetcher setEndDate(DateTime endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched WorkflowStatistics
         */
        [Override]
        public WorkflowStatistics execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows/" + this.workflowSid + "/Statistics",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkflowStatistics fetch failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return WorkflowStatistics.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}