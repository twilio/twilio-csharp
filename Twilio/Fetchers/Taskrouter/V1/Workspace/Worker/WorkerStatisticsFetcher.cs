using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.worker.WorkerStatistics;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace.Worker {

    public class WorkerStatisticsFetcher : Fetcher<WorkerStatistics> {
        private String workspaceSid;
        private String workerSid;
        private Integer minutes;
        private DateTime startDate;
        private DateTime endDate;
    
        /**
         * Construct a new WorkerStatisticsFetcher
         * 
         * @param workspaceSid The workspace_sid
         * @param workerSid The worker_sid
         */
        public WorkerStatisticsFetcher(String workspaceSid, String workerSid) {
            this.workspaceSid = workspaceSid;
            this.workerSid = workerSid;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public WorkerStatisticsFetcher setMinutes(Integer minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public WorkerStatisticsFetcher setStartDate(DateTime startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public WorkerStatisticsFetcher setEndDate(DateTime endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched WorkerStatistics
         */
        [Override]
        public WorkerStatistics execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.workerSid + "/Statistics",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkerStatistics fetch failed: Unable to connect to server");
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
            
            return WorkerStatistics.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}