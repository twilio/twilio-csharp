using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkerReader : Reader<WorkerResource> {
        private string workspaceSid;
        private string activityName;
        private string activitySid;
        private string available;
        private string friendlyName;
        private string targetWorkersExpression;
        private string taskQueueName;
        private string taskQueueSid;
    
        /**
         * Construct a new WorkerReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public WorkerReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The activity_name
         * 
         * @param activityName The activity_name
         * @return this
         */
        public WorkerReader ByActivityName(string activityName) {
            this.activityName = activityName;
            return this;
        }
    
        /**
         * The activity_sid
         * 
         * @param activitySid The activity_sid
         * @return this
         */
        public WorkerReader ByActivitySid(string activitySid) {
            this.activitySid = activitySid;
            return this;
        }
    
        /**
         * The available
         * 
         * @param available The available
         * @return this
         */
        public WorkerReader ByAvailable(string available) {
            this.available = available;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkerReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The target_workers_expression
         * 
         * @param targetWorkersExpression The target_workers_expression
         * @return this
         */
        public WorkerReader ByTargetWorkersExpression(string targetWorkersExpression) {
            this.targetWorkersExpression = targetWorkersExpression;
            return this;
        }
    
        /**
         * The task_queue_name
         * 
         * @param taskQueueName The task_queue_name
         * @return this
         */
        public WorkerReader ByTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public WorkerReader ByTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return WorkerResource ResourceSet
         */
        public override Task<ResourceSet<WorkerResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<WorkerResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return WorkerResource ResourceSet
         */
        public override ResourceSet<WorkerResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<WorkerResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<WorkerResource> NextPage(Page<WorkerResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of WorkerResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<WorkerResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkerResource read failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to read records, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return Page<WorkerResource>.FromJson("workers", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (activityName != null) {
                request.AddQueryParam("ActivityName", activityName);
            }
            
            if (activitySid != null) {
                request.AddQueryParam("ActivitySid", activitySid);
            }
            
            if (available != null) {
                request.AddQueryParam("Available", available);
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (targetWorkersExpression != null) {
                request.AddQueryParam("TargetWorkersExpression", targetWorkersExpression);
            }
            
            if (taskQueueName != null) {
                request.AddQueryParam("TaskQueueName", taskQueueName);
            }
            
            if (taskQueueSid != null) {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}