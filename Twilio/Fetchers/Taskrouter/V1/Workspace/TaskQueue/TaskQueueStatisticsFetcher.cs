using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.task_queue.TaskQueueStatistics;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace.Taskqueue {

    public class TaskQueueStatisticsFetcher : Fetcher<TaskQueueStatistics> {
        private string workspaceSid;
        private string taskQueueSid;
        private DateTime endDate;
        private string friendlyName;
        private int minutes;
        private DateTime startDate;
    
        /**
         * Construct a new TaskQueueStatisticsFetcher
         * 
         * @param workspaceSid The workspace_sid
         * @param taskQueueSid The task_queue_sid
         */
        public TaskQueueStatisticsFetcher(string workspaceSid, string taskQueueSid) {
            this.workspaceSid = workspaceSid;
            this.taskQueueSid = taskQueueSid;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public TaskQueueStatisticsFetcher setEndDate(DateTime endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TaskQueueStatisticsFetcher setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public TaskQueueStatisticsFetcher setMinutes(int minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public TaskQueueStatisticsFetcher setStartDate(DateTime startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched TaskQueueStatistics
         */
        [Override]
        public TaskQueueStatistics execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/" + this.taskQueueSid + "/Statistics",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueueStatistics fetch failed: Unable to connect to server");
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
            
            return TaskQueueStatistics.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}