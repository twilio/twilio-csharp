using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace {

    public class WorkspaceStatisticsFetcher : Fetcher<WorkspaceStatisticsResource> {
        private string workspaceSid;
        private int? minutes;
        private string startDate;
        private string endDate;
    
        /**
         * Construct a new WorkspaceStatisticsFetcher
         * 
         * @param workspaceSid The workspace_sid
         */
        public WorkspaceStatisticsFetcher(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public WorkspaceStatisticsFetcher setMinutes(int? minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public WorkspaceStatisticsFetcher setStartDate(string startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public WorkspaceStatisticsFetcher setEndDate(string endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched WorkspaceStatisticsResource
         */
        public override async Task<WorkspaceStatisticsResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Statistics"
            );
            
            
                AddQueryParams(request);
            
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceStatisticsResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return WorkspaceStatisticsResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (minutes != null) {
                request.AddQueryParam("Minutes", minutes.ToString());
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate);
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate);
            }
        }
    }
}