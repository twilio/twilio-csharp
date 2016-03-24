using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Taskrouter.V1.Workspace.TaskQueue;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Taskrouter.V1.Workspace.Taskqueue {

    public class TaskQueuesStatisticsReader : Reader<TaskQueuesStatisticsResource> {
        private string workspaceSid;
        private DateTime endDate;
        private string friendlyName;
        private int minutes;
        private DateTime startDate;
    
        /**
         * Construct a new TaskQueuesStatisticsReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public TaskQueuesStatisticsReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public TaskQueuesStatisticsReader byEndDate(DateTime endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TaskQueuesStatisticsReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public TaskQueuesStatisticsReader byMinutes(int minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public TaskQueuesStatisticsReader byStartDate(DateTime startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return TaskQueuesStatisticsResource ResourceSet
         */
        public override ResourceSet<TaskQueuesStatisticsResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/Statistics"
            );
            
            addQueryParams(request);
            
            Page<TaskQueuesStatisticsResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TaskQueuesStatisticsResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of TaskQueuesStatisticsResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TaskQueuesStatisticsResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueuesStatisticsResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            Page<TaskQueuesStatisticsResource> result = new Page<>();
            result.deserialize("task_queues_statistics", response.GetContent(), TaskQueuesStatisticsResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (endDate != null) {
                request.addQueryParam("EndDate", endDate.ToString());
            }
            
            if (friendlyName != null) {
                request.addQueryParam("FriendlyName", friendlyName);
            }
            
            if (minutes != null) {
                request.addQueryParam("Minutes", minutes.ToString());
            }
            
            if (startDate != null) {
                request.addQueryParam("StartDate", startDate.ToString());
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}