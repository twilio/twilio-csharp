using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Taskrouter.V1.Workspace {

    public class TaskQueueReader : Reader<TaskQueueResource> {
        private string workspaceSid;
        private string friendlyName;
        private string evaluateWorkerAttributes;
    
        /**
         * Construct a new TaskQueueReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public TaskQueueReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TaskQueueReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The evaluate_worker_attributes
         * 
         * @param evaluateWorkerAttributes The evaluate_worker_attributes
         * @return this
         */
        public TaskQueueReader ByEvaluateWorkerAttributes(string evaluateWorkerAttributes) {
            this.evaluateWorkerAttributes = evaluateWorkerAttributes;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskQueueResource ResourceSet
         */
        public override Task<ResourceSet<TaskQueueResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues"
            );
            
            AddQueryParams(request);
            
            Page<TaskQueueResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<TaskQueueResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskQueueResource ResourceSet
         */
        public override ResourceSet<TaskQueueResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues"
            );
            
            AddQueryParams(request);
            
            Page<TaskQueueResource> page = PageForRequest(client, request);
            
            return new ResourceSet<TaskQueueResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TaskQueueResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of TaskQueueResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TaskQueueResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueueResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            Page<TaskQueueResource> result = new Page<TaskQueueResource>();
            result.deserialize("task_queues", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (evaluateWorkerAttributes != null) {
                request.AddQueryParam("EvaluateWorkerAttributes", evaluateWorkerAttributes);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}