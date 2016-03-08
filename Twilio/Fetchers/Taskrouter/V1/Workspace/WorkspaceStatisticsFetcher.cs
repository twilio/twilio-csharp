using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.WorkspaceStatistics;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace {

    public class WorkspaceStatisticsFetcher : Fetcher<WorkspaceStatistics> {
        private String workspaceSid;
        private Integer minutes;
        private String startDate;
        private String endDate;
    
        /**
         * Construct a new WorkspaceStatisticsFetcher
         * 
         * @param workspaceSid The workspace_sid
         */
        public WorkspaceStatisticsFetcher(String workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public WorkspaceStatisticsFetcher setMinutes(Integer minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public WorkspaceStatisticsFetcher setStartDate(String startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public WorkspaceStatisticsFetcher setEndDate(String endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched WorkspaceStatistics
         */
        [Override]
        public WorkspaceStatistics execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Statistics",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceStatistics fetch failed: Unable to connect to server");
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
            
            return WorkspaceStatistics.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}