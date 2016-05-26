using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Readers.Taskrouter.V1.Workspace {

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
        public WorkerReader byActivityName(string activityName) {
            this.activityName = activityName;
            return this;
        }
    
        /**
         * The activity_sid
         * 
         * @param activitySid The activity_sid
         * @return this
         */
        public WorkerReader byActivitySid(string activitySid) {
            this.activitySid = activitySid;
            return this;
        }
    
        /**
         * The available
         * 
         * @param available The available
         * @return this
         */
        public WorkerReader byAvailable(string available) {
            this.available = available;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkerReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The target_workers_expression
         * 
         * @param targetWorkersExpression The target_workers_expression
         * @return this
         */
        public WorkerReader byTargetWorkersExpression(string targetWorkersExpression) {
            this.targetWorkersExpression = targetWorkersExpression;
            return this;
        }
    
        /**
         * The task_queue_name
         * 
         * @param taskQueueName The task_queue_name
         * @return this
         */
        public WorkerReader byTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public WorkerReader byTaskQueueSid(string taskQueueSid) {
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
        public override Task<ResourceSet<WorkerResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            
            AddQueryParams(request);
            
            Page<WorkerResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<WorkerResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return WorkerResource ResourceSet
         */
        public override ResourceSet<WorkerResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            
            AddQueryParams(request);
            
            Page<WorkerResource> page = PageForRequest(client, request);
            
            return new ResourceSet<WorkerResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<WorkerResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of WorkerResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<WorkerResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkerResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            Page<WorkerResource> result = new Page<WorkerResource>();
            result.deserialize("workers", response.GetContent());
            
            return result;
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
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}