using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace.TaskQueue;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Taskrouter.V1.Workspace.TaskQueue {

    public class TaskQueuesStatisticsReader : Reader<TaskQueuesStatisticsResource> {
        private string workspaceSid;
        private DateTime? endDate;
        private string friendlyName;
        private int? minutes;
        private DateTime? startDate;
    
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
        public TaskQueuesStatisticsReader byEndDate(DateTime? endDate) {
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
        public TaskQueuesStatisticsReader byMinutes(int? minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public TaskQueuesStatisticsReader byStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskQueuesStatisticsResource ResourceSet
         */
        public override Task<ResourceSet<TaskQueuesStatisticsResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/Statistics"
            );
            
            AddQueryParams(request);
            
            Page<TaskQueuesStatisticsResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<TaskQueuesStatisticsResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskQueuesStatisticsResource ResourceSet
         */
        public override ResourceSet<TaskQueuesStatisticsResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/Statistics"
            );
            
            AddQueryParams(request);
            
            Page<TaskQueuesStatisticsResource> page = PageForRequest(client, request);
            
            return new ResourceSet<TaskQueuesStatisticsResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TaskQueuesStatisticsResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of TaskQueuesStatisticsResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TaskQueuesStatisticsResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueuesStatisticsResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.OK) {
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
            
            Page<TaskQueuesStatisticsResource> result = new Page<TaskQueuesStatisticsResource>();
            result.deserialize("task_queues_statistics", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (minutes != null) {
                request.AddQueryParam("Minutes", minutes.ToString());
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}