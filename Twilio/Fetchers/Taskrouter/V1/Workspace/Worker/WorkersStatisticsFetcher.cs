using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.worker.WorkersStatistics;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace.Worker {

    public class WorkersStatisticsFetcher : Fetcher<WorkersStatistics> {
        private string workspaceSid;
        private int minutes;
        private DateTime startDate;
        private DateTime endDate;
        private string taskQueueSid;
        private string taskQueueName;
        private string friendlyName;
    
        /**
         * Construct a new WorkersStatisticsFetcher
         * 
         * @param workspaceSid The workspace_sid
         */
        public WorkersStatisticsFetcher(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public WorkersStatisticsFetcher setMinutes(int minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public WorkersStatisticsFetcher setStartDate(DateTime startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public WorkersStatisticsFetcher setEndDate(DateTime endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public WorkersStatisticsFetcher setTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /**
         * The task_queue_name
         * 
         * @param taskQueueName The task_queue_name
         * @return this
         */
        public WorkersStatisticsFetcher setTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkersStatisticsFetcher setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched WorkersStatistics
         */
        [Override]
        public WorkersStatistics execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/Statistics",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkersStatistics fetch failed: Unable to connect to server");
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
            
            return WorkersStatistics.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}