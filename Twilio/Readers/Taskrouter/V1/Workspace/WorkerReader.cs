using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Worker;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Taskrouter.V1.Workspace {

    public class WorkerReader : Reader<Worker> {
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
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Worker ResourceSet
         */
        [Override]
        public ResourceSet<Worker> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Worker> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        [Override]
        public Page<Worker> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Worker Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Worker> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Worker read failed: Unable to connect to server");
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
            
            Page<Worker> result = new Page<>();
            result.deserialize("workers", response.getContent(), Worker.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (activityName != null) {
                request.addQueryParam("ActivityName", activityName);
            }
            
            if (activitySid != null) {
                request.addQueryParam("ActivitySid", activitySid);
            }
            
            if (available != null) {
                request.addQueryParam("Available", available);
            }
            
            if (friendlyName != null) {
                request.addQueryParam("FriendlyName", friendlyName);
            }
            
            if (targetWorkersExpression != null) {
                request.addQueryParam("TargetWorkersExpression", targetWorkersExpression);
            }
            
            if (taskQueueName != null) {
                request.addQueryParam("TaskQueueName", taskQueueName);
            }
            
            if (taskQueueSid != null) {
                request.addQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}